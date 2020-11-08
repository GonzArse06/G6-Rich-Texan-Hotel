using NLayer.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Datos
{
    public class ReservaMapper
    {
        public static List<Reserva> Reserva_getAll()
        {
            string json2 = WebHelper.Get("/Hotel/Reservas"); // trae un texto en formato json de una web
            List<Reserva> resultado = JsonConvert.DeserializeObject<List<Reserva>>(json2);
            return resultado;
        }

        public static TransactionResult Insert(Reserva item)
        {
            NameValueCollection obj = ReverseMap(item);

            string result = WebHelper.Post("/Hotel/Reservas", obj);

            return JsonConvert.DeserializeObject<TransactionResult>(result);
        }

        public static TransactionResult Update(Reserva item)
        {
            NameValueCollection obj = ReverseMap(item);
            string result = WebHelper.Put("/Hotel/Reservas", obj);
            return JsonConvert.DeserializeObject<TransactionResult>(result);
        }
        public static TransactionResult Delete(int id)
        {
            NameValueCollection obj = new NameValueCollection();
            obj.Add("Id", id.ToString());
            //NameValueCollection obj = ReverseMap(item);
            string result = WebHelper.Delete("/Hotel/Reservas", obj);

            return JsonConvert.DeserializeObject<TransactionResult>(result);
        }

        private static NameValueCollection ReverseMap(Reserva item)
        {

            NameValueCollection n = new NameValueCollection();
            n.Add("Id", item.Id.ToString());
            n.Add("FechaEgreso", item.FechaEgreso.ToShortDateString());
            n.Add("FechaIngreso", item.FechaIngreso.ToShortDateString());
            n.Add("CantidadHuespedes", item.CantidadHuespedes.ToString());
            n.Add("IdCliente", item.IdCliente.ToString());
            n.Add("IdHabitacion", item.IdHabitacion.ToString());

            return n;
        }
    }
}
