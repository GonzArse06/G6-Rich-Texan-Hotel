using NLayer.Datos;
using NLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;


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
            var cliente = _listaclientes.FirstOrDefault(o => o.Id == reserva.IdCliente);
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
                reserva.Id = resultado.Id;
                EnviarMail(reserva, cliente.Email);
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

            if (reserva.CantidadHuespedes > hab.CantidadPlazas)
            {
                throw new ReservasException("Cantidad de huespedes superior a las plazas.");
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
            var cliente = _listaclientes.FirstOrDefault(o => o.Id == reserva.IdCliente);

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
                reserva.Id = resultado.Id;
                EnviarMail(reserva, cliente.Email);
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
        //public void DescargarAExcel(ListView listView)
        //{
        //    Exportar.ExportarAExcel(listView);
        //}

        public void DescargarAExcel(List<string[]> listView, string[] headers)
        {
            Exportar.ExportarAExcel(listView, headers);
        }

        public void EnviarMail(Reserva item, string mail)
        {
            //  U + 2600 \u2600
            //char o = '\uF650';
            //o = '✔';//⌛
            string asunto = "Su reserva No. " + item.Id + " en Rich Texan Hotel";


            string message = string.Format("Bienvenido, <br>a continuacion los datos de la reserva: <br><br>Cliente: {3}<br>Habitacion: {2}<br>Fechas: {0} - {1}<br><br>Saludos cordiales,<br><b>Rich Texan Hotel</b>", item.FechaIngreso.ToShortDateString(), item.FechaEgreso.ToShortDateString(), item.IdHabitacion, item.IdCliente);
            ClienteMapper.EnviarMail(mail, asunto, message);
        }
    }
}
