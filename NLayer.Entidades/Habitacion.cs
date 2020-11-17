using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Entidades
{
    [DataContract]  
    public class Habitacion
    {
        private int _idHotel;
        private int _cantidadPlazas;
        private string _categoria;
        private double _precio;
        private bool _cancelable;
        private int _id;
        private List<Reserva> _reserva;

        [DataMember]
        public int IdHotel
        {
            get { return _idHotel; }
            set { _idHotel = value; }
        }

        [DataMember]
        public int CantidadPlazas
        {
            get { return _cantidadPlazas; }
            set { _cantidadPlazas = value; }
        }

        [DataMember]
        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        [DataMember]
        public double Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        [DataMember]
        public bool Cancelable
        {
            get { return _cancelable; }
            set { _cancelable = value; }
        }
        public string CancelableTexto
        {
            get { if (_cancelable) return "SI"; else return "NO"; }
        }

        [DataMember]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public List<Reserva> Reservas {
            get { return _reserva; }
            set { _reserva = value; }
        }
        public override string ToString()
        {
            return string.Format("Id Habitacion: {0} - Categoria: {1} - Cantidad de plazas: {2} - Precio: {3}"
                ,this._id,this._categoria,this._cantidadPlazas,this._precio );
        }


    }
}
