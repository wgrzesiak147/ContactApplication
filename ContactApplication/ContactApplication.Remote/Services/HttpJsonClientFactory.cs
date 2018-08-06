using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ContactApplication.Remote.Interfaces;

namespace ContactApplication.Remote.Services
{
    public class HttpJsonClientFactory : IHttpClientFactory
    {

        public HttpClient Create()
        {
            var client = new HttpClient();
            var header = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(header);
            return client;
        }
    }
}
