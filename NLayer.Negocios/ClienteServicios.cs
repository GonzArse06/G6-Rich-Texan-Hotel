using NLayer.Datos;
using NLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// La clase HotelServicio es una clase parcial que une el codigo con ClienteServicio y ReservaServicio.
/// en el contructor, se carga toda la informacion de las API, para luego los metodos de traer traigan la informacion de la lista en donde se guardo.
/// Se uso un metodo para simular un cache, que actualiza la informacion de las listas cuando se ejecuta correctamente una transaccion de Alta, baja o modificacion.
/// en esta capa, dejamos las validaciones de negocio:
/// - Cliente: control de duplicados por DNI. No se puede eliminar cliente si tiene una reserva.
/// - Reserva: cantidad de huespedes no supere a las plazas. fecha de ingreso no puede ser inferior al dia de registro. la fecha de egreso debe ser mayor a la fecha de ingreso. Habitacion reservada en la fecha elegida.
///     -  si la reserva esta confirmada, se envia mail.
/// - Hotel: validacion que exista el hotel, no se pueda eliminar si tiene una habitacion registrada o una reserva activa.
/// - Habitaciones: el precio debe ser mayor a un minimo, que no se pueda eliminar si tiene reserva activa.
/// </summary>

namespace NLayer.Negocios
{
    public partial class HotelServicios
    {
        List<Cliente> _listaclientes;
      
        public int IngresarCliente(Cliente item)
        {
            if (_listaclientes.Any(o => o.Dni == item.Dni))
            {
                throw new ReservasException("El DNI se encuentra registrado");
            }
            TransactionResult resultado = ClienteMapper.Insert(item);
            if (resultado.IsOk)
            {
                ClienteCache();
                return resultado.Id;
            }
            else
            {
                throw new ReservasException(resultado.Error);
            }
                
        }
        public int ModificarCliente(Cliente item)
        {
            if (_listaclientes.Any(o => o.Dni == item.Dni && o.Id != item.Id))
            {
                throw new ReservasException("El DNI se encuentra registrado");
            }
            TransactionResult resultado = ClienteMapper.Update(item);
            if (resultado.IsOk)
            {
                ClienteCache();
                return resultado.Id;
            }
            else
            {
                throw new ReservasException(resultado.Error);
            }
        }
        public List<Cliente> TraerClientes()
        {
            return _listaclientes;
        }
        private void ClienteCache()
        {
            _listaclientes = ClienteMapper.TraerTodos();
        }
        public bool EliminarCliente(int id)
        {
            if (!_listaclientes.Any(o => o.Id == id))
            {
                throw new ReservasException("No se pudo encontrar el cliente");
            }           
            
            if (_listaReservas.Any(o => o.IdCliente == id))
            {
                throw new ReservasException("Cliente con reservas. Debe eliminarlas.");
            }

            TransactionResult resultado = ClienteMapper.Delete(id);
            if (resultado.IsOk)
            {
                ClienteCache();
                return true;
            }
            else
            {
                throw new ReservasException(resultado.Error);
            }
        }
    }
}
