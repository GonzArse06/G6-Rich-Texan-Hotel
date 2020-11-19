using NLayer.Datos;
using NLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// La clase HotelServicio es una clase parcial que une el codigo con ClienteServicio y ReservaServicio.
/// en el contructor, se carga toda la informacion de las API, para luego los metodos de traer traigan la informacion de la lista en donde se guardo.
/// Se uso un metodo para simular un cache, que actualiza la informacion de las listas cuando se ejecuta correctamente una transaccion de Alta, baja o modificacion.
/// en esta capa, dejamos las validaciones de negocio:
/// - Cliente: control de duplicados por DNI. No se puede eliminar cliente si tiene una reserva.
/// - Reserva: cantidad de huespedes no supere a las plazas. fecha de ingreso no puede ser inferior al dia de registro. la fecha de egreso debe ser mayor a la fecha de ingreso. Habitacion reservada en la fecha elegida.
///     -  si la reserva esta confirmada, se envia mail.
/// - 
/// </summary>

namespace NLayer.Negocios
{
    public partial class HotelServicios
    {
        List<Hotel> _listahoteles;
        List<Habitacion> _listaHabitaciones;

        public HotelServicios()
        {
            _listahoteles = new List<Hotel>();
            _listaHabitaciones = new List<Habitacion>();
            _listaReservas = new List<Reserva>();
            //Cache
            _listaclientes = ClienteMapper.TraerTodos();
            _listahoteles = HotelMapper.Hotel_getAll();
            _listaReservas = ReservaMapper.Reserva_getAll();
            foreach(Hotel a in _listahoteles)
                _listaHabitaciones.AddRange(HabitacionMapper.Habitacion_getAllByHotel(a.Id));
        }
        public void HotelesCache()
        {
            _listahoteles = HotelMapper.Hotel_getAll();
        }
        public int IngresarHotel(Hotel hotel)
        {
            if (_listahoteles.Any(o => o.Nombre == hotel.Nombre))
            {
                throw new ReservasException("El hotel ya existe.");
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
            if (_listahoteles.Any(o => o.Nombre == hotel.Nombre && o.Id != hotel.Id))
            {
                throw new ReservasException("El hotel ya existe.");
            }
            if (!_listahoteles.Any(o =>  o.Id == hotel.Id))
            {
                throw new ReservasException("Hotel no encontrado.");
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
            return _listahoteles;
        }
        public int EliminarHotel(int id)
        {
            if (!_listahoteles.Any(o => o.Id == id))
            {
                throw new ReservasException("No existe el hotel");
            }
            List<Habitacion> listaHabitaciones = _listaHabitaciones.Where(x => x.Id == id).ToList();
            foreach (Habitacion a in listaHabitaciones)
            {
                if (_listaReservas.Any(o => o.IdHabitacion == a.Id))
                    throw new ReservasException("Hotel con reservas. Debe eliminarlas.");
            }
            if (listaHabitaciones.Count > 0)
            { 
                throw new ReservasException("Hotel con habitaciones. Debe eliminarlas.");
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
            _listaHabitaciones.Clear();
            foreach (Hotel a in _listahoteles)
                _listaHabitaciones.AddRange(HabitacionMapper.Habitacion_getAllByHotel(a.Id));
        }
        //private void LlenarListaHabitaciones(Hotel a)
        //{
        //    List<Habitacion> habitacion = HabitacionMapper.Habitacion_getAllByHotel(a.Id);
        //    _listaHabitaciones.AddRange(habitacion);
        //}

        public int IngresarHabitacion(Habitacion habitacion)
        {
            var minimo = int.Parse(ConfigurationSettings.AppSettings["PrecioMinimo"]);
            if (habitacion.Precio <= minimo)
            {
                throw new ReservasException("El precio debe ser superior a " + minimo.ToString());
            }
            if (habitacion.CantidadPlazas <= 0)
            {
                throw new ReservasException("La cantidad de plaza debe ser mayor que 0");
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
            if(habitacion.CantidadPlazas <= 0)
            {
                throw new ReservasException("La cantidad de plaza debe ser mayor que 0");
            }
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
            return _listaHabitaciones.Where(x => x.IdHotel == id).ToList();
        }
        public int EliminarHabitacion(int id)
        {
            if (_listaReservas.Any(o => o.IdHabitacion == id))
            {
                throw new ReservasException("Habitacion con reservas. Debe eliminarlas.");
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
