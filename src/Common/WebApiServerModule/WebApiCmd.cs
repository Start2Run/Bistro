using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Common.WebApiServerModule
{
    public static class WebApiCmd
    {
        public static async Task<bool> Put(string uri, string command, object obj)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            // Add an Accept header for JSON format.    
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.    
            var stringPayload = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Formatting.Indented);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            try
            {
                response = client.PutAsync(command, content).Result;
            }
            catch
            {
            }
            return response?.IsSuccessStatusCode ?? false;
        }
    }
}
