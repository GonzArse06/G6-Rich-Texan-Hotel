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
        private int estrellas;

        [DataMember]
        public int Estrellas
        {
            get { return estrellas; }
            set { estrellas = value; }
        }

        private int id  ;
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Direccion { get; set; }

        private bool amenities;
        [DataMember]
        public bool Amenities
        {
            get { return amenities; }
            set { amenities = value; }
        }

        public List<Habitacion> Habitaciones { get; set; }

        public override string ToString()
        {
            return string.Format($"Nombre: {Nombre} Direccion: {Direccion} "); 
        }
    }
}
