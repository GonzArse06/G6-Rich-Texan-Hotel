using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entidades
{
    [DataContract]
    public class Cliente:Persona
    {
        private DateTime fechaAlta;
        private bool activo;
        private int _id;

        [DataMember]
        public string Usuario { get; set; }

        public Cliente()
        {
            //this.Usuario = "pau";
            this.Usuario = ConfigurationManager.AppSettings["Legajo"];
            this.fechaAlta = DateTime.Now; //-> revisar casos de modificaciones cuando se crea un nuevo contructor.
            this.activo = true;
        }
        [DataMember]
        public int Id { get => _id; set => _id = value; }
        [DataMember]
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        [DataMember]
        public DateTime FechaAlta
        {
            get { return fechaAlta; }
            set { fechaAlta = value; }
        }

        public override string ToString()
        {
            return string.Format("Cliente {0}, {1}",this._apellido,this._nombre);
        }
    }
}
