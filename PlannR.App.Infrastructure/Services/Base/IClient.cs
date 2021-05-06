using System.Net.Http;

namespace Plannr.App.Infrastructure.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}
