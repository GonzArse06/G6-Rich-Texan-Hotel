using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

using Newtonsoft.Json;
using NLayer.Entidades;

namespace NLayer.Datos
{
    public class ClienteMapper
    {
        public static List<Cliente> TraerTodos()
        {
            string json2 = WebHelper.Get("/cliente/" + "pau"); // trae un texto en formato json de una web
           // string json2 = WebHelper.Get("/cliente"); // trae un texto en formato json de una web
            List<Cliente> resultado = MapList<Cliente>(json2);
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

        private static List<T> MapList<T>(string json)
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
            
        }

        private static NameValueCollection ReverseMap(Cliente cliente)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("Nombre", cliente.Nombre);
            n.Add("Apellido", cliente.Apellido);
            n.Add("Direccion", cliente.Direccion);
            n.Add("Usuario", "pau");
            //n.Add("Usuario", ConfigurationManager.AppSettings["Legajo"]);
            n.Add("Email", cliente.Mail); // STRING
            n.Add("Telefono", cliente.Telefono.ToString()); // INT
            n.Add("FechaAlta", cliente.FechaAlta.ToShortDateString()); // DateTime
            n.Add("Activo", cliente.Activo.ToString()); // bool
            return n;
        }

        private static TransactionResult MapResultado(string json)
        {
            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);
            return lst;
        }

        public static TransactionResult Delete(int id)
        {
            NameValueCollection obj = new NameValueCollection();
            obj.Add("Id", id.ToString());

            string result = WebHelper.Delete("/cliente", obj);
            return JsonConvert.DeserializeObject<TransactionResult>(result);
        }

            //private Cliente MapObj(string json)
            //{
            //    var lst = JsonConvert.DeserializeObject<Cliente>(json);
            //    return lst;
            //}
            //public Cliente TraerPorCodigo(int codigo)
            //{
            //    string json2 = WebHelper.Get("/api/v1/cliente/" + codigo.ToString()); // trae un texto en formato json de una web
            //    Cliente resultado = MapObj(json2);
            //    return resultado;
            //}
        }
}
