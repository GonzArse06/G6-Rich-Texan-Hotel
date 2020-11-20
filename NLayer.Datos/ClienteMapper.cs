using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLayer.Entidades;

namespace NLayer.Datos
{
    public class ClienteMapper
    {

        /// <summary>
        /// Lo hago sincronico para que tarde menos. si no se manda no me importa
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="asunto"></param>
        /// <param name="mensaje"></param>
        public static void EnviarMailAsync(string mail, string asunto, string mensaje)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("Para", mail);
            n.Add("Asunto", asunto);
            n.Add("Mensaje", mensaje);
            WebHelper.PostAsync("/Utilidades", n);

        }
        public static TransactionResult EnviarMail(string mail, string asunto, string mensaje)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("Para", mail);
            n.Add("Asunto", asunto);
            n.Add("Mensaje", mensaje);
            string result = WebHelper.Post("/Utilidades", n);

            TransactionResult resultadoTransaccion = MapResultado(result);
            return resultadoTransaccion;
        }
            
        public static List<Cliente> TraerTodos()
        {
            string json2 = WebHelper.Get("/cliente/" + ConfigurationManager.AppSettings["Legajo"]);
            List<Cliente> resultado = JsonConvert.DeserializeObject<List<Cliente>>(json2);
            return resultado;
        }

        public static TransactionResult Insert(Cliente cliente)
        {
            NameValueCollection obj = ReverseMap(cliente);
            string result = WebHelper.Post("/cliente", obj);

            TransactionResult resultadoTransaccion = MapResultado(result);
            return resultadoTransaccion;
        }

        public static TransactionResult Update(Cliente cliente)
        {
            NameValueCollection obj = ReverseMap(cliente);
            string result = WebHelper.Put("/cliente", obj);

            TransactionResult resultadoTransaccion = MapResultado(result);
            return resultadoTransaccion;
        }


        private static NameValueCollection ReverseMap(Cliente cliente)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("Id", cliente.Id.ToString());
            n.Add("DNI", cliente.Dni.ToString());
            n.Add("Nombre", cliente.Nombre);
            n.Add("Apellido", cliente.Apellido);
            n.Add("Direccion", cliente.Direccion);
            n.Add("Usuario", ConfigurationManager.AppSettings["Legajo"]);
            n.Add("Email", cliente.Email); 
            n.Add("Telefono", cliente.Telefono.ToString()); 
            n.Add("FechaAlta", cliente.FechaAlta.ToString("yyyy-MM-dd"));
            n.Add("Activo", cliente.Activo.ToString()); 
            return n;
        }

        private static TransactionResult MapResultado(string json)
        {
            TransactionResult lst = MapObj<TransactionResult>(json);
            return lst;
        }

        public static TransactionResult Delete(int id)
        {
            NameValueCollection obj = new NameValueCollection();
            obj.Add("Id", id.ToString());

            string result = WebHelper.Delete("/cliente", obj);
            return MapObj<TransactionResult>(result);
        }

        private static T MapObj<T>(string json)
        {
            var lst = JsonConvert.DeserializeObject<T>(json);
            return lst;
        }

    }
}
