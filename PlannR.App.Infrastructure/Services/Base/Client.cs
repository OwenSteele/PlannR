using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Reflection;

namespace PlannR.App.Infrastructure.Services.Base
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
        public Client(HttpClient httpClient)
        {
            BaseUrl = httpClient.BaseAddress.AbsoluteUri;
            _httpClient = httpClient;
            _settings = new System.Lazy<JsonSerializerSettings>(CreateSerializerSettings);
        }
        partial void UpdateJsonSerializerSettings(JsonSerializerSettings settings)
        {
            settings.ContractResolver = new SafeContractResolver();
        }

        class SafeContractResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var jsonProp = base.CreateProperty(member, memberSerialization);
                jsonProp.Required = Required.Default;
                return jsonProp;
            }
        }
    }
}
