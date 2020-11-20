using NLayer.Datos;
using NLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// La clase HotelServicio es una clase parcial que une el codigo con ClienteServicio y ReservaServicio.
/// en el contructor, se carga toda la informacion de las API, para luego los metodos de traer traigan la informacion de la lista en donde se guardo.
/// Se uso un metodo para simular un cache, que actualiza la informacion de las listas cuando se ejecuta correctamente una transaccion de Alta, baja o modificacion.
/// en esta capa, dejamos las validaciones de negocio:
/// - Cliente: control de duplicados por DNI. No se puede eliminar cliente si tiene una reserva.
/// - Reserva: cantidad de huespedes no supere a las plazas. fecha de ingreso no puede ser inferior al dia de registro. la fecha de egreso debe ser mayor a la fecha de ingreso. Habitacion reservada en la fecha elegida.
///     -  si la reserva esta confirmada, se envia mail.
/// - Hotel: validacion que exista el hotel, no se pueda eliminar si tiene una habitacion registrada o una reserva activa.
/// - Habitaciones: el precio debe ser mayor a un minimo, que no se pueda eliminar si tiene reserva activa.
/// </summary>

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

            if (cliente == null)
            {
                throw new ReservasException("El cliente no existe.");
            }

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

                SendMailAsync(reserva, cliente.Email);
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
                SendMailAsync(reserva, cliente.Email);
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

        public void DescargarAExcel(List<string[]> listView, string[] headers, string fileName)
        {
            Exportar.ExportarAExcel(listView, headers, fileName);
        }

        public void EnviarMail(Reserva item, string mail)
        {
            string asunto = "Su reserva No. " + item.Id + " en Rich Texan Hotel";

            string message = string.Format("Bienvenido, <br>a continuacion los datos de la reserva: <br><br>Cliente: {3}<br>Habitacion: {2}<br>Fechas: {0} - {1}<br><br>Saludos cordiales,<br><b>Rich Texan Hotel</b>", item.FechaIngreso.ToShortDateString(), item.FechaEgreso.ToShortDateString(), item.IdHabitacion, item.IdCliente);
            ClienteMapper.EnviarMail(mail, asunto, message);
        }

        /// <summary>
        /// Se manda el mail y no espero la respuesta del enviado OK
        /// </summary>
        /// <param name="item"></param>
        /// <param name="mail"></param>
        private void SendMailAsync(Reserva item, string mail)
        {
            string asunto = "Su reserva No. " + item.Id + " en Rich Texan Hotel";

            string message = string.Format("Bienvenido, <br>a continuacion los datos de la reserva: <br><br>Cliente: {3}<br>Habitacion: {2}<br>Fechas: {0} - {1}<br><br>Saludos cordiales,<br><b>Rich Texan Hotel</b>", item.FechaIngreso.ToShortDateString(), item.FechaEgreso.ToShortDateString(), item.IdHabitacion, item.IdCliente);

            ClienteMapper.EnviarMailAsync(mail, asunto, message);
            //...do something with the Customer object asynchronously
        
        }
    }
}
