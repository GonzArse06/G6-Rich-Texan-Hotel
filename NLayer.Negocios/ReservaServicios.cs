using NLayer.Datos;
using NLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Negocios
{
    public partial class HotelServicios
    {
        List<Reserva> listaReservas;
       
        public int IngresarReserva(Reserva reserva, Habitacion hab)
        {
            if (reserva.CantidadHuespedes > hab.CantidadPlazas)
            {
                throw new ReservasException("La reserva supera la cantidad de plazas");
            }
            if (reserva.FechaIngreso < DateTime.Today)
            {
                throw new ReservasException("La fecha de reserva es incorrecta");
            }
            if (reserva.FechaEgreso - reserva.FechaIngreso  < TimeSpan.FromDays(1))
            {
                throw new ReservasException("La fecha de reserva es incorrecta");
            }

            var reservas = listaReservas.Where(o => o.IdHabitacion == reserva.IdHabitacion);

            for (DateTime i = reserva.FechaIngreso; i <= reserva.FechaEgreso; i= i.AddDays(1))
            {
                if (reservas.Where( t => i >= t.FechaIngreso & i < t.FechaEgreso).Any())
                {
                    throw new ReservasException("La habitacion se encuentra reservada");
                }
            }
           
            //faltan validaciones de negocio.
            TransactionResult resultado = ReservaMapper.Insert(reserva);
            if (resultado.IsOk)
                return resultado.Id;
            else
            {
                throw new ReservasException(resultado.Error);
            }
        }
        public int ModificarReserva(Reserva reserva, Habitacion hab)
        {
            var old = listaReservas.Where(o => o.Id == reserva.Id).FirstOrDefault();
            if (old==null)
            {

            }
            if (old.IdHabitacion != reserva.IdHabitacion)
            {
                if (reserva.CantidadHuespedes > hab.CantidadPlazas)
                {
                    throw new ReservasException("La reserva supera la cantidad de plazas");
                }
            }
           
            if (reserva.FechaIngreso < DateTime.Today)
            {
                throw new ReservasException("La fecha de reserva es incorrecta");
            }
            if (reserva.FechaEgreso - reserva.FechaIngreso < TimeSpan.FromDays(1))
            {
                throw new ReservasException("La fecha de reserva es incorrecta");
            }

            var reservas = listaReservas.Where(o => o.IdHabitacion == reserva.IdHabitacion && o.Id != reserva.Id);

            for (DateTime i = reserva.FechaIngreso; i <= reserva.FechaEgreso; i = i.AddDays(1))
            {
                if (reservas.Where(t => i >= t.FechaIngreso & i < t.FechaEgreso).Any())
                {
                    throw new ReservasException("La habitacion se encuentra reservada");
                }
            }

            //faltan validaciones de negocio.
            TransactionResult resultado = ReservaMapper.Update(reserva);
            if (resultado.IsOk)
                return resultado.Id;
            else
            {
                throw new ReservasException(resultado.Error);
            }
        }
        public List<Reserva> TraerReservas()
        {
            listaReservas = ReservaMapper.Reserva_getAll();
            return listaReservas;
        }
        public int EliminarReserva(int id)
        {
            //faltan validaciones de negocio.
            TransactionResult resultado = ReservaMapper.Delete(id);
            if (resultado.IsOk)
                return resultado.Id;
            else
            {
                throw new ReservasException(resultado.Error);
            }
        }
    }
}
