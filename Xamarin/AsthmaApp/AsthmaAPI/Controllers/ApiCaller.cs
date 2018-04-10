using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using AsthmaAPI.Models;

namespace AsthmaAPI.Controllers
{
    public static class ApiCaller
    {
        private static  HttpClient client;
        private static HttpResponseMessage response;
        

        static ApiCaller()
        {
            client = new HttpClient();
        }
        public static async Task<AsthmaDP> RunAsync(Uri assembledUri)
        {

            AsthmaDP ADP = new AsthmaDP();
            client.BaseAddress = assembledUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            response = await client.GetAsync(assembledUri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                ADP = await response.Content.ReadAsAsync<AsthmaDP>();
            }
            return ADP;
        }
    }
}