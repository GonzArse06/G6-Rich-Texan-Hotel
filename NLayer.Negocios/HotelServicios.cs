using NLayer.Datos;
using NLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Negocios
{
    public partial class HotelServicios
    {
        List<Hotel> listahoteles;
        List<Habitacion> listaitems;

        public HotelServicios()
        {
            listahoteles = new List<Hotel>();
            listaitems = new List<Habitacion>();
            listaReservas = new List<Reserva>();
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
            {
                throw new ReservasException(resultado.Error);
            }
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
            {
                throw new ReservasException(resultado.Error);
            }
        }
        public List<Hotel> TraerHoteles()
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
            {
                throw new ReservasException(resultado.Error);
            }
        }

        public int IngresarHabitacion(Habitacion habitacion)
        {
            //faltan validaciones de negocio.
            var minimo = int.Parse(ConfigurationSettings.AppSettings["PrecioMinimo"]);
            if (habitacion.Precio <= minimo)
            {
                throw new ReservasException("El precio debe ser superior a " + minimo.ToString());
            }

            TransactionResult resultado = HabitacionMapper.Insert(habitacion);
            if (resultado.IsOk)
                return resultado.Id;
            else
            {
                throw new ReservasException(resultado.Error);
            }
        }
        public int ModificarHabitacion(Habitacion habitacion)
        {
            //faltan validaciones de negocio.
            TransactionResult resultado = HabitacionMapper.Update(habitacion);
            if (resultado.IsOk)
                return resultado.Id;
            else
            {
                throw new ReservasException(resultado.Error);
            }
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
            {
                throw new ReservasException(resultado.Error);
            }
        }
    }
}
