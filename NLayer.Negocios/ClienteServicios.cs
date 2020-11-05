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
        public ClienteServicios()
        {
        }
        public int IngresarCliente(Cliente cliente)
        {
            //faltan validaciones de negocio.
            TransactionResult resultado = ClienteMapper.Insert(cliente);

            if (resultado.IsOk)
                return resultado.Id;
            else
                return -1;

        }
        public List<Cliente> TraerTodo()
        {
            return ClienteMapper.TraerTodos();
        }

    }
}
