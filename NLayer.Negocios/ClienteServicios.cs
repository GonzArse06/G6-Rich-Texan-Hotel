using NLayer.Datos;
using NLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Negocios
{
    public partial class HotelServicios
    {
        List<Cliente> listaclientes;
      
        public int IngresarCliente(Cliente item)
        {
            //faltan validaciones de negocio.
            if (listaclientes.Any(o => o.Nombre == item.Nombre))
            {
                throw new ReservasException("El cliente ya existe");
            }
            if (listaclientes.Any(o => o.Dni == item.Dni))
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
            //faltan validaciones de negocio.
            if (listaclientes.Any(o => o.Dni == item.Dni && o.Id != item.Id))
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
            //listaclientes = ClienteMapper.TraerTodos();
            return listaclientes;
        }
        private void ClienteCache()
        {
            listaclientes = ClienteMapper.TraerTodos();
        }
        public bool EliminarCliente(int id)
        {
            //faltan validaciones de negocio.
            if (!listaclientes.Any(o => o.Id == id))
            {
                throw new ReservasException("No se pudo encontrar el cliente");
            }           
            
            if (listaReservas.Any(o => o.IdCliente == id))
            {
                throw new ReservasException("El Cliente tiene reservas activas. Primero debe eliminar las reservas.");
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
