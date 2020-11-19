using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Text;

/// <summary>
/// WebHelper con Get, Post, Update, Delete.
/// </summary>

namespace NLayer.Datos
{
    public class WebHelper
    {
        static WebClient _client;
        static string _rutaBase;

        static WebHelper()
        {
            _client = new WebClient();
            _client.Encoding = Encoding.UTF8;
            _rutaBase = ConfigurationSettings.AppSettings["urlREST"];
            _client.Headers.Add("ContentType", "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">Hotel/Hoteles</param>
        /// <returns></returns>
        public static string Get(string url)
        {
            var uri = _rutaBase + url;

            return _client.DownloadString(uri);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public static string Post(string url, NameValueCollection parametros)
        {
            string uri = _rutaBase + url;
            try
            {
                var response = _client.UploadValues(uri, parametros);
                return Encoding.Default.GetString(response);
            }
            catch (Exception ex)
            {
                return "{ \"isOk\":false,\"id\":-1,\"error\":'" + ex.Message + "'}";
            }


        }

        public static string Delete(string url, NameValueCollection parametros)
        {
            string uri = _rutaBase + url;

            try
            {
                var response = _client.UploadValues(uri, "DELETE", parametros);
                return Encoding.Default.GetString(response);
            }
            catch (Exception ex)
            {
                return "{ \"isOk\":false,\"id\":-1,\"error\":'" + ex.Message + "'}";
            }


        }

        public static string Put(string url, NameValueCollection parametros)
        {
            string uri = _rutaBase + url;

            try
            {
                var response = _client.UploadValues(uri, "PUT", parametros);
                return Encoding.Default.GetString(response);
            }
            catch (Exception ex)
            {
                return "{ \"isOk\":false,\"id\":-1,\"error\":'" + ex.Message + "'}";
            }
        }
    }
}
