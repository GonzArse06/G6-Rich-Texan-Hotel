using NLayer.Datos;
using NLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Negocios
{
    //public class HabitacionServicios
    //{
    //    List<Habitacion> listaitems;
    //    public HabitacionServicios()
    //    {
    //        listaitems = new List<Habitacion>();
    //    }
    //    public int IngresarHabitacion(Habitacion habitacion)
    //    {
    //        //faltan validaciones de negocio.
    //        TransactionResult resultado = HabitacionMapper.Insert(habitacion);
    //        if (resultado.IsOk)
    //            return resultado.Id;
    //        else
    //            return -1;
    //    }
    //    public int ModificarHabitacion(Habitacion habitacion)
    //    {
    //        //faltan validaciones de negocio.
    //        TransactionResult resultado = HabitacionMapper.Update(habitacion);
    //        if (resultado.IsOk)
    //            return resultado.Id;
    //        else
    //            return -1;
    //    }
    //    public List<Habitacion> TraerTodoPorId(int id)
    //    {
    //        return HabitacionMapper.Habitacion_getAllByHotel(id);
    //    }
    //    public int EliminarHabitacion(int id)
    //    {
            
    //        //faltan validaciones de negocio.
    //        TransactionResult resultado = HabitacionMapper.Delete(id);
    //        if (resultado.IsOk)
    //            return resultado.Id;
    //        else
    //            return -1;
    //    }
    //}
}
