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
        List<Habitacion> listaitems;

        public HotelServicios()
        {
            listahoteles = new List<Hotel>();
            listaitems = new List<Habitacion>();
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
            if (listahoteles.Any(o => o.Nombre == hotel.Nombre && o.Id != hotel.Id))
            {
                throw new ReservasException("El hotel ya existe");
            }
            if (!listahoteles.Any(o =>  o.Id == hotel.Id))
            {
                throw new ReservasException("Hotel no encontrado");
            }
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

            // si tiene reservas?
            
            TransactionResult resultado = HotelMapper.Delete(id);
            if (resultado.IsOk)
                return resultado.Id;
            else
                return -1;
        }

        public int IngresarHabitacion(Habitacion habitacion)
        {
            //faltan validaciones de negocio.
            TransactionResult resultado = HabitacionMapper.Insert(habitacion);
            if (resultado.IsOk)
                return resultado.Id;
            else
                return -1;
        }
        public int ModificarHabitacion(Habitacion habitacion)
        {
            //faltan validaciones de negocio.
            TransactionResult resultado = HabitacionMapper.Update(habitacion);
            if (resultado.IsOk)
                return resultado.Id;
            else
                return -1;
        }
        public List<Habitacion> TraerTodoPorId(int id)
        {
            return HabitacionMapper.Habitacion_getAllByHotel(id);
        }
        public int EliminarHabitacion(int id)
        {

            //faltan validaciones de negocio.
            TransactionResult resultado = HabitacionMapper.Delete(id);
            if (resultado.IsOk)
                return resultado.Id;
            else
                return -1;
        }
    }
}
