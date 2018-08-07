using System.Net.Http;

namespace ContactApplication.Remote.Interfaces
{
    public interface IHttpClientFactory
    {
        HttpClient Create();
    }
}