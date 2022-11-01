using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Clients
{
    public class CoinCapClient : BaseClient
    {
        public CoinCapClient()
        {
            Url = "https://api.coincap.io/v2/";
            _httpclient = new HttpClient()
            {
                BaseAddress = new Uri(Url)
            };
            _httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
