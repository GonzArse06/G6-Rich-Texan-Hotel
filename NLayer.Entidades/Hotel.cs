using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entidades
{
    [DataContract]
    public class Hotel
    {
        private int _estrellas;
        private int _id;
        private string _nombre;
        private string _direccion;
        private bool _amenities;
        private List<Habitacion> _habitacion;

        [DataMember]
        public int Estrellas
        {
            get { return _estrellas; }
            set { _estrellas = value; }
        }
        [DataMember]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        [DataMember]
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        [DataMember]
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }                
        [DataMember]
        public bool Amenities
        {
            get { return _amenities; }
            set { _amenities = value; }
        }

        public string AmenitiesTexto
        {
            get { if (_amenities) return "SI"; else return "NO"; }
        }

        public List<Habitacion> Habitaciones {
            get { return _habitacion; }
            set { _habitacion = value; }
        }

        public override string ToString()
        {
            return string.Format($"Nombre: {Nombre} Direccion: {Direccion} "); 
        }
    }
}
