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
                throw new ReservasException("Eel DNI se encuentra registrado");
            }
            TransactionResult resultado = ClienteMapper.Insert(item);
            if (resultado.IsOk)
                return resultado.Id;
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
                throw new ReservasException("Eel DNI se encuentra registrado");
            }
            TransactionResult resultado = ClienteMapper.Update(item);
            if (resultado.IsOk)
                return resultado.Id;
            else
            {
                throw new ReservasException(resultado.Error);
            }
        }
        public List<Cliente> TraerClientes()
        {
            listaclientes = ClienteMapper.TraerTodos();
            return listaclientes;
        }
        public bool EliminarCliente(int id)
        {
            //faltan validaciones de negocio.
            if (!listaclientes.Any(o => o.Id == id))
            {
                throw new ReservasException("No se pudo encontrar el cliente");
            }
            //validar que no tenga reservas o borrarlas?
            TransactionResult resultado = ClienteMapper.Delete(id);
            if (resultado.IsOk)
                return true;
            else
            {
                throw new ReservasException(resultado.Error);
            }
        }
    }
}
