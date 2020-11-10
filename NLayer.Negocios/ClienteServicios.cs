using NLayer.Datos;
using NLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Negocios
{
    public class ClienteServicios
    {
        List<Cliente> listaclientes;
        public ClienteServicios()
        {
            listaclientes = new List<Cliente>();
        }
        public int IngresarCliente(Cliente item)
        {
            //faltan validaciones de negocio.
            if (listaclientes.Any(o => o.Nombre == item.Nombre))
            {
                throw new ReservasException("El hotel ya existe");
            }
            TransactionResult resultado = ClienteMapper.Insert(item);
            if (resultado.IsOk)
                return resultado.Id;
            else
                return -1;
        }
        public int ModificarCliente(Cliente item)
        {
            //faltan validaciones de negocio.
            TransactionResult resultado = ClienteMapper.Update(item);
            if (resultado.IsOk)
                return resultado.Id;
            else
                return -1;
        }
        public List<Cliente> TraerTodo()
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
            TransactionResult resultado = ClienteMapper.Delete(id);
            return resultado.IsOk;
            
        }
    }
}
