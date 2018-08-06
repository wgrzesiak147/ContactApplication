using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContactApplication.Remote.Interfaces
{
    public interface IHttpClientFactory
    {
        HttpClient Create();
    }
}
