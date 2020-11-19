using NLayer.Entidades;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace NLayer.Datos
{
    public class HotelMapper
    {
        public static List<Hotel> Hotel_getAll()
        {
            string json2 = WebHelper.Get("/Hotel/Hoteles/"+ConfigurationManager.AppSettings["Legajo"]); 
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
            n.Add("Id", item.Id.ToString());
            n.Add("Nombre", item.Nombre);
            n.Add("Estrellas", item.Estrellas.ToString());
            n.Add("Direccion", item.Direccion);
            n.Add("Amenities", item.Amenities.ToString());
            n.Add("Usuario", ConfigurationManager.AppSettings["Legajo"]);
            return n;
        }
     
    }
}
