using System.Net.Http;

namespace Clients
{
    public abstract class BaseClient
    {
        public HttpClient _httpclient;
        public string Url { get; set; }
        public string Token { get; set; }
    }
}
