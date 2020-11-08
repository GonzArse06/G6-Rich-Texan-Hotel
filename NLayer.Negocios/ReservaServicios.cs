using NLayer.Datos;
using NLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Negocios
{
    public class ReservaServicios
    {
        public ReservaServicios()
        {
        }
        public int IngresarReserva(Reserva reserva)
        {
            //faltan validaciones de negocio.
            TransactionResult resultado = ReservaMapper.Insert(reserva);
            if (resultado.IsOk)
                return resultado.Id;
            else
                return -1;
        }
        public int ModificarReserva(Reserva reserva)
        {
            //faltan validaciones de negocio.
            TransactionResult resultado = ReservaMapper.Update(reserva);
            if (resultado.IsOk)
                return resultado.Id;
            else
                return -1;
        }
        public List<Reserva> TraerTodo()
        {
            return ReservaMapper.Reserva_getAll();
        }
        public int EliminarReserva(int id)
        {
            //faltan validaciones de negocio.
            TransactionResult resultado = ReservaMapper.Delete(id);
            if (resultado.IsOk)
                return resultado.Id;
            else
                return -1;
        }
    }
}
