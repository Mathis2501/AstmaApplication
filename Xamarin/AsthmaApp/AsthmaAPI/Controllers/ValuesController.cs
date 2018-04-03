﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using AsthmaAPI.Models;

namespace AsthmaAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private const string baseUrl = "http://api.openweathermap.org/data/2.5/weather?";
        private const string lat = "lat=";
        private const string lon = "&lon=";
        private HttpClient client;

        public ValuesController()
        {
            client = new HttpClient();
        }
        
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post(AsthmaDP asthmaDp)
        {
            string assembledUrl = baseUrl + lat + asthmaDp.Latitude + lon + asthmaDp.Longitude;
            if (Uri.IsWellFormedUriString(assembledUrl, UriKind.RelativeOrAbsolute))
            {
                asthmaDp.DateAndTime = DateTime.Now;
                Uri assembledUri = new Uri(assembledUrl);
                client.BaseAddress = assembledUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                SaveDP(asthmaDp);
            }
        }

        private void SaveDP(AsthmaDP asthmaDp)
        {
            throw new NotImplementedException();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
