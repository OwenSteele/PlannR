using System.Net.Http;

namespace Plannr.App.Infrastructure.Services.Base
{
    public partial interface IClient
    {
        // As IClient is produced by NSwag, need permanent access into HttpClient generated property without rebuidling in new NSwag versions
        public HttpClient HttpClient { get; }
    }
}
