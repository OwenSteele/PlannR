using System.Net.Http;

namespace Plannr.App.Infrastructure.Services.Base
{
    public partial class Client : IClient
    {
        // As Client is produced by NSwag, need permanent access into _httpClient generated field without rebuidling in new NSwag versions
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}
