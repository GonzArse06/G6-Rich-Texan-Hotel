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
