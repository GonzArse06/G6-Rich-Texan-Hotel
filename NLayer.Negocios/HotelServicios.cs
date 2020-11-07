using NLayer.Datos;
using NLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Negocios
{
    public class HotelServicios
    {
        public HotelServicios()
        {
        }
        public int IngresarHotel(Hotel hotel)
        {
            //faltan validaciones de negocio.
            TransactionResult resultado = HotelMapper.Insert(hotel);
            if (resultado.IsOk)
                return resultado.Id;
            else
                return -1;
        }
        public int ModificarHotel(Hotel hotel)
        {
            //faltan validaciones de negocio.
            TransactionResult resultado = HotelMapper.Update(hotel);
            if (resultado.IsOk)
                return resultado.Id;
            else
                return -1;
        }
        public List<Hotel> TraerTodo()
        {
            return HotelMapper.Hotel_getAll();
        }
        public int EliminarHotel(int id)
        {
            //faltan validaciones de negocio.
            TransactionResult resultado = HotelMapper.Delete(id);
            if (resultado.IsOk)
                return resultado.Id;
            else
                return -1;
        }
    }
}
