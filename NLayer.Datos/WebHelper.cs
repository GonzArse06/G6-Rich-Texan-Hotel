using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace NLayer.Datos
{
    public class WebHelper
    {
        static WebClient client;
        static string rutaBase;

        static WebHelper()
        {
            client = new WebClient();
            client.Encoding = Encoding.UTF8;
            rutaBase = "https://cai-api.azurewebsites.net/api/v1";
            client.Headers.Add("ContentType", "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">Hotel/Hoteles</param>
        /// <returns></returns>
        public static string Get(string url)
        {
            var uri = rutaBase + url;

            return client.DownloadString(uri);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public static string Post(string url, NameValueCollection parametros)
        {
            string uri = rutaBase + url;

            try
            {
                var response = client.UploadValues(uri, parametros);

                return Encoding.Default.GetString(response);
            }
            catch (Exception ex)
            {
                return "{ \"isOk\":false,\"id\":-1,\"error\":"+ex.Message+"}";
            }


        }

        public static string Delete(string url, NameValueCollection parametros)
        {
            string uri = rutaBase + url;

            try
            {
                var response = client.UploadValues(uri, "DELETE", parametros);
                return Encoding.Default.GetString(response);
            }
            catch (Exception ex)
            {
                return "{ \"isOk\":false,\"id\":-1,\"error\":" + ex.Message + "}";
            }


        }

        public static string Put(string url, NameValueCollection parametros)
        {
            string uri = rutaBase + url;

            try
            {
                var response = client.UploadValues(uri, "PUT", parametros);
                return Encoding.Default.GetString(response);

            }
            catch (Exception ex)
            {
                return "{ \"isOk\":false,\"id\":-1,\"error\":" + ex.Message + "}";
            }
        }
    }
}
