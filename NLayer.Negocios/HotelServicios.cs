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
        List<Hotel> listahoteles;
        
        public HotelServicios()
        {
            listahoteles = new List<Hotel>();
            //listahoteles = HotelMapper.Hotel_getAll();
        }
        public int IngresarHotel(Hotel hotel)
        {
            //faltan validaciones de negocio.
            if (listahoteles.Any(o => o.Nombre == hotel.Nombre))
            {
                throw new ReservasException("El hotel ya existe");
            }

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
            listahoteles = HotelMapper.Hotel_getAll();
            return listahoteles;
        }
        public int EliminarHotel(int id)
        {
            //faltan validaciones de negocio.
            if (!listahoteles.Any(o => o.Id == id))
            {
                throw new ReservasException("No existe el hotel");
            }
            TransactionResult resultado = HotelMapper.Delete(id);
            if (resultado.IsOk)
                return resultado.Id;
            else
                return -1;
        }
    }
}
