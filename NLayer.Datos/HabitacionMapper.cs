﻿using NLayer.Entidades;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace NLayer.Datos
{
    public class HabitacionMapper
    {
        private static string path = "/Hotel/Habitaciones";
        public static TransactionResult Delete(int id)
        {
            NameValueCollection obj = new NameValueCollection();
            obj.Add("Id", id.ToString());
            string result = WebHelper.Delete(path, obj);

            return JsonConvert.DeserializeObject<TransactionResult>(result);
        }


        public static List<Habitacion> Habitacion_getAllByHotel(int id)
        {
            string json2 = WebHelper.Get("/Hotel/Habitaciones/" + id.ToString()); 
            List<Habitacion> resultado = JsonConvert.DeserializeObject<List<Habitacion>>(json2);
            return resultado;
        }
        private static NameValueCollection ReverseMap(Habitacion item)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("Id", item.Id.ToString());
            n.Add("IdHotel", item.IdHotel.ToString());
            n.Add("Precio", item.Precio.ToString());
            n.Add("Cancelable", item.Cancelable.ToString());
            n.Add("CantidadPlazas", item.CantidadPlazas.ToString());
            n.Add("Categoria", item.Categoria);

            return n;
        }

        public static TransactionResult Insert(Habitacion item)
        {
            NameValueCollection obj = ReverseMap(item);

            string result = WebHelper.Post(path, obj);

            return JsonConvert.DeserializeObject<TransactionResult>(result);
        }

        public static TransactionResult Update(Habitacion item)
        {
            NameValueCollection obj = ReverseMap(item);
            string result = WebHelper.Put(path, obj);

            return JsonConvert.DeserializeObject<TransactionResult>(result);
        }
    }
}
