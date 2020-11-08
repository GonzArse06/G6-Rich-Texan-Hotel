using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entidades
{
    [DataContract]  
    public class Habitacion
    {
        [DataMember]
        public int IdHotel { get; set; }

        private int cantidadPlazas;
        [DataMember]
        public int CantidadPlazas
        {
            get { return cantidadPlazas; }
            set { cantidadPlazas = value; }
        }

        private string categoria;
        [DataMember]
        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        private double precio;
        [DataMember]
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private bool cancelable;
        [DataMember]
        public bool Cancelable
        {
            get { return cancelable; }
            set { cancelable = value; }
        }

        private int id;
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override string ToString()
        {
            return string.Format("Id Habitacion: {0} - Categoria: {1} - Cantidad de plazas: {2} - Precio: {3}"
                ,this.id,this.categoria,this.cantidadPlazas,this.precio );
        }


    }
}
