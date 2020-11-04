using NLayer.Entidades;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace NLayer.Datos
{
    public class HotelMapper
    {
        public static List<Hotel> Hotel_getAll()
        {
            string json2 = WebHelper.Get("/Hotel/Hoteles"); // trae un texto en formato json de una web
            List<Hotel> resultado = JsonConvert.DeserializeObject<List<Hotel>>(json2);
            return resultado;
        }

        public static TransactionResult Insert(Hotel item)
        {
            NameValueCollection obj = ReverseMap(item);

            string result = WebHelper.Post("/Hotel/Hoteles", obj);

            return JsonConvert.DeserializeObject<TransactionResult>(result);
        }

        public static TransactionResult Update (Hotel item)
        {
            NameValueCollection obj = ReverseMap(item);
            //return JsonConvert.SerializeObject(item);
            string result = WebHelper.Put("/Hotel/Hoteles", obj);

            return JsonConvert.DeserializeObject<TransactionResult>(result);
        }

        public static TransactionResult Delete(int id)
        {
            NameValueCollection obj = new NameValueCollection() ;
            obj.Add("Id", id.ToString());

            string result = WebHelper.Delete("/Hotel/Hoteles", obj);

            return JsonConvert.DeserializeObject<TransactionResult>(result);
        }


        private static NameValueCollection ReverseMap(Hotel item)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("Nombre", item.Nombre);
            n.Add("Estrellas", item.Estrellas.ToString());
            n.Add("Direccion", item.Direccion);
            n.Add("Amenities", item.Amenities.ToString());
            //n.Add("Email", cliente.Email); // STRING
            //n.Add("Telefono", cliente.Telefono.ToString()); // INT
            //n.Add("FechaNacimiento", cliente.FechaNacimiento.ToShortDateString()); // DateTime
            //n.Add("Activo", cliente.Activo.ToString()); // bool
            return n;
        }
        
        private List<T> MapList<T>(string json)
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
          
        }
    }
}
