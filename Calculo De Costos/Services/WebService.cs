using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Calculo_De_Costos.Models;
using Newtonsoft.Json;
using RestSharp;
using static Calculo_De_Costos.Models.PI;

namespace Calculo_De_Costos.Services
{
    class WebService
    {
        public static async Task<Response> InsertData(object newPI, string url, DataType insertionType)
        {
            // En el caso de Sandbox http://localhost/costs_api/controller/pi/pi.php
            var client = new RestClient(url);
            client.Timeout = 15000;

            var request = new RestRequest(Method.POST);

            //Generamos el archivo JSON que necesitaremos
            string data = JsonConvert.SerializeObject(newPI);

            // En el caso de JSON
            request.AddParameter("application/json", data, ParameterType.RequestBody);

            request.AddHeader("Content-Type", "application/json"); // Tambien puede ser application/json o application/xml
            IRestResponse response;
            try
            {
                response = await client.ExecuteAsync(request);
                Response result = JsonConvert.DeserializeObject<Response>(response.Content);
                return result;
            }
            catch (TimeoutException e)
            {
                Response result = new Response();
                result.succes = false;
                result.message = "Tiempo de espera agotado... " + e.Message;
                return result;
            }
            catch (Exception e)
            {
                Response result = new Response();
                result.succes = false;
                result.message = "Error... " + e.Message;
                return result;
            }
        }

        public static async Task<Response> DeleteData(int idPI)
        {
            // En el caso de Sandbox 
            var client = new RestClient("http://localhost/costs_api/controller/pi/pi.php");
            client.Timeout = 15000;

            var request = new RestRequest(Method.DELETE);
            request.AddParameter("id_pi", idPI);
            IRestResponse response;
            try
            {
                response = await client.ExecuteAsync(request);
                Response result = JsonConvert.DeserializeObject<Response>(response.Content);
                return result;
            }
            catch (TimeoutException e)
            {
                Response result = new Response();
                result.succes = false;
                result.message = "Tiempo de espera agotado... " + e.Message;
                return result;
            }
            catch (Exception e)
            {
                Response result = new Response();
                result.succes = false;
                result.message = "Error... " + e.Message;
                return result;
            }
        }
    }
}
