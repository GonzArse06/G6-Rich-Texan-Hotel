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
        List<Reserva> listaitems;
        public ReservaServicios()
        {
            listaitems = new List<Reserva>();
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
            listaitems = ReservaMapper.Reserva_getAll();
            return listaitems;
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
