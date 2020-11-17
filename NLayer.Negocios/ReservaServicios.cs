using NLayer.Datos;
using NLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NLayer.Negocios
{
    public partial class HotelServicios
    {
        List<Reserva> _listaReservas;
       
        public int IngresarReserva(Reserva reserva, Habitacion hab)
        {
            if (reserva.CantidadHuespedes > hab.CantidadPlazas)
            {
                throw new ReservasException("Cantidad de huespedes superior a plaza.");
            }
            if (reserva.FechaIngreso.Date < DateTime.Today.Date)
            {
                throw new ReservasException("La fecha debe ser mayor o igual a hoy.");
            }
            if (reserva.FechaEgreso.Date - reserva.FechaIngreso.Date < TimeSpan.FromDays(1))
            {
                throw new ReservasException("Fecha de egreso debe ser mayor a ingreso.");
            }

            var reservas = _listaReservas.Where(o => o.IdHabitacion == reserva.IdHabitacion);

            for (DateTime i = reserva.FechaIngreso; i <= reserva.FechaEgreso; i= i.AddDays(1))
            {
                if (reservas.Where( t => i >= t.FechaIngreso & i < t.FechaEgreso).Any())
                {
                    throw new ReservasException("La habitacion se encuentra reservada.");
                }
            }
            TransactionResult resultado = ReservaMapper.Insert(reserva);
            if (resultado.IsOk)
            {
                ReservaCache();
                return resultado.Id;
            }
            else
            {
                throw new ReservasException(resultado.Error);
            }
        }
        public int ModificarReserva(Reserva reserva, Habitacion hab)
        {
            //var old = _listaReservas.Where(o => o.Id == reserva.Id).FirstOrDefault();
            //if (old==null)
            //{

            //}
            //if (old.IdHabitacion != reserva.IdHabitacion)
            //{
            //    if (reserva.CantidadHuespedes > hab.CantidadPlazas)
            //    {
            //        throw new ReservasException("Cantidad de huespedes superior a plaza.");
            //    }
            //}
            if (reserva.CantidadHuespedes > hab.CantidadPlazas)
            {
                throw new ReservasException("Cantidad de huespedes superior a plaza.");
            }
            if (reserva.FechaIngreso.Date < DateTime.Today.Date)
            {
                throw new ReservasException("La fecha debe ser mayor o igual a hoy.");
            }
            if (reserva.FechaEgreso.Date - reserva.FechaIngreso.Date < TimeSpan.FromDays(1))
            {
                throw new ReservasException("Fecha de egreso debe ser mayor a ingreso.");
            }

            var reservas = _listaReservas.Where(o => o.IdHabitacion == reserva.IdHabitacion && o.Id != reserva.Id);

            for (DateTime i = reserva.FechaIngreso; i <= reserva.FechaEgreso; i = i.AddDays(1))
            {
                if (reservas.Where(t => i >= t.FechaIngreso & i < t.FechaEgreso).Any())
                {
                    throw new ReservasException("La habitacion se encuentra reservada");
                }
            }
            TransactionResult resultado = ReservaMapper.Update(reserva);
            if (resultado.IsOk)
            {
                ReservaCache();
                return resultado.Id;
            }
            else
            {
                throw new ReservasException(resultado.Error);
            }
        }
        public List<Reserva> TraerReservas()
        {
            //listaReservas = ReservaMapper.Reserva_getAll();
            return _listaReservas;
        }
        private void ReservaCache()
        {
            _listaReservas = ReservaMapper.Reserva_getAll();
        }
        public int EliminarReserva(int id)
        {
            TransactionResult resultado = ReservaMapper.Delete(id);
            if (resultado.IsOk)
            {
                ReservaCache();
                return resultado.Id;
            }
            else
            {
                throw new ReservasException(resultado.Error);
            }
        }
        public void DescargarAExcel(ListView listView)
        {
            Exportar.ExportarAExcel(listView);
        }
    }
}
