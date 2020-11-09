using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entidades
{

    [DataContract]
    public class Persona
    {
        protected string _nombre;
        protected string _apellido;
        protected DateTime _fechaNac;
        private string _direccion;
        private string _mail;
        private int _telefono;
        private int _id;

        [DataMember]
        public int Dni { get => _id; set => _id = value; }
        [DataMember]
        public string Nombre { get => _nombre; set => _nombre = value; }

        [DataMember]
        public string Apellido { get => _apellido; set => _apellido = value; }

        [DataMember]
        public string Direccion { get => _direccion; set => _direccion = value; }

        [DataMember]
        public string Email { get => _mail; set => _mail = value; }

        [DataMember]
        public int Telefono { get => _telefono; set => _telefono = value; }

        public DateTime FechaNacimiento { get => _fechaNac; set => _fechaNac = value; }




    }
}
