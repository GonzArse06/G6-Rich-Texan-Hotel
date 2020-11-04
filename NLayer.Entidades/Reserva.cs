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
        private int idHabitacion;
        [DataMember]
        public int IdHabitacion
        {
            get { return idHabitacion; }
            set { idHabitacion = value; }
        }

        private int idCliente;
        [DataMember]
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        private int cantidadHuespedes;
        [DataMember]
        public int CantidadHuespedes
        {
            get { return cantidadHuespedes; }
            set { cantidadHuespedes = value; }
        }

        private int id;
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime fechaIngreso;
        [DataMember]
        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }

        private DateTime fechaEgreso;
        [DataMember]
        public DateTime FechaEgreso
        {
            get { return fechaEgreso; }
            set { fechaEgreso = value; }
        }


    }
}
