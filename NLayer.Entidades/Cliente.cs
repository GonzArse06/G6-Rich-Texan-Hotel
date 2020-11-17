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
        private DateTime _fechaAlta;
        private bool _activo;
        private int _id;
        private string _usuario;

        public Cliente()
        {
            this.Usuario = ConfigurationManager.AppSettings["Legajo"];
            this._fechaAlta = DateTime.Now; //-> revisar casos de modificaciones cuando se crea un nuevo contructor.
            this._activo = true;
        }
        [DataMember]
        public int Id { get => _id; set => _id = value; }
        [DataMember]
        public string Usuario { get => _usuario; set => _usuario = value; }
        [DataMember]
        public bool Activo { get { return _activo; } set { _activo = value; } }
        [DataMember]
        public DateTime FechaAlta { get { return _fechaAlta; } set { _fechaAlta = value; } }

        public override string ToString()
        {
            return string.Format("Cliente {0}, {1}",this._apellido,this._nombre);
        }
    }
}
