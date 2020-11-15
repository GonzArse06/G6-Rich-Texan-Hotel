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
            //Cache
            listaclientes = ClienteMapper.TraerTodos();
            listahoteles = HotelMapper.Hotel_getAll();
            listaReservas = ReservaMapper.Reserva_getAll();
            foreach(Hotel a in listahoteles)
                listaitems.AddRange(HabitacionMapper.Habitacion_getAllByHotel(a.Id));
        }
        public void HotelesCache()
        {
            listahoteles = HotelMapper.Hotel_getAll();
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
            {
                HotelesCache();
                return resultado.Id;
            }
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
            TransactionResult resultado = HotelMapper.Update(hotel);
            if (resultado.IsOk)
            {
                HotelesCache();
                return resultado.Id;
            }
            else
            {
                throw new ReservasException(resultado.Error);
            }
        }
        public List<Hotel> TraerHoteles()
        {
            //listahoteles = HotelMapper.Hotel_getAll();
            return listahoteles;
        }
        public int EliminarHotel(int id)
        {
            if (!listahoteles.Any(o => o.Id == id))
            {
                throw new ReservasException("No existe el hotel");
            }
            List<Habitacion> listaHabitaciones = listaitems.Where(x => x.Id == id).ToList();
            foreach (Habitacion a in listaHabitaciones)
            {
                if (listaReservas.Any(o => o.IdHabitacion == a.Id))
                    throw new ReservasException("Existen reservas para este hotel. Primero elimine las reservas.");
            }
            if (listaHabitaciones.Count > 0)
            { 
                throw new ReservasException("Existen habitaciones para este hotel. Primero elimine las habitaciones.");
            }
            TransactionResult resultado = HotelMapper.Delete(id);
            if (resultado.IsOk)
            {
                HotelesCache();
                return resultado.Id;
            }
            else
            {
                throw new ReservasException(resultado.Error);
            }
        }

        private void HabitacionesCache()
        {
            foreach (Hotel a in listahoteles)
                listaitems = HabitacionMapper.Habitacion_getAllByHotel(a.Id);
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
            {
                HabitacionesCache();
                return resultado.Id;
            }
            else
            {
                throw new ReservasException(resultado.Error);
            }
        }
        public int ModificarHabitacion(Habitacion habitacion)
        {
            var minimo = int.Parse(ConfigurationSettings.AppSettings["PrecioMinimo"]);
            if (habitacion.Precio <= minimo)
            {
                throw new ReservasException("El precio debe ser superior a " + minimo.ToString());
            }
            //faltan validaciones de negocio.
            TransactionResult resultado = HabitacionMapper.Update(habitacion);
            if (resultado.IsOk)
            {
                HabitacionesCache();
                return resultado.Id;
            }
            else
            {
                throw new ReservasException(resultado.Error);
            }
        }
        public List<Habitacion> TraerTodoPorId(int id)
        {
            return listaitems.Where(x => x.IdHotel == id).ToList();
        }
        public int EliminarHabitacion(int id)
        {
            if (listaReservas.Any(o => o.IdHabitacion == id))
            {
                throw new ReservasException("La habitacion tiene reservas activas. Primero debe eliminar las reservas.");
            }
            TransactionResult resultado = HabitacionMapper.Delete(id);
            if (resultado.IsOk)
            {
                HabitacionesCache();
                return resultado.Id;
            }
            else
            {
                throw new ReservasException(resultado.Error);
            }
        }
    }
}
