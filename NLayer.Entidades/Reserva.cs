using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entidades
{
    [DataContract]
    public class Reserva
    {
        private int _idHabitacion;
        private int _idCliente;
        private int _cantidadHuespedes;
        private int _id;
        private DateTime _fechaIngreso;
        private DateTime _fechaEgreso;

        [DataMember]
        public int IdHabitacion
        {
            get { return _idHabitacion; }
            set { _idHabitacion = value; }
        }
        [DataMember]
        public int IdCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }
        [DataMember]
        public int CantidadHuespedes
        {
            get { return _cantidadHuespedes; }
            set { _cantidadHuespedes = value; }
        }
        [DataMember]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        [DataMember]
        public DateTime FechaIngreso
        {
            get { return _fechaIngreso; }
            set { _fechaIngreso = value; }
        }
        [DataMember]
        public DateTime FechaEgreso
        {
            get { return _fechaEgreso; }
            set { _fechaEgreso = value; }
        }
    }
}
