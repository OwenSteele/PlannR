using PlannR.App.Infrastructure.Contracts.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Services.Security
{
    public class ClientInputService : IClientInputService
    {
        public string FormatToUrl(string link, bool https = true)
        {
            var http = "http://";
            var prefix = https ? "https://" : http;

            if (link.StartsWith(prefix)) return link;

            var sb = new StringBuilder(link);

            if(https && link.StartsWith(http)) sb.Replace(http, prefix);
            else sb.Insert(0, prefix);

            return sb.ToString();
        }

        public bool IsValidUri(string uri, bool httpsOnly = true)
        {
            Uri uriResult;
            return Uri.TryCreate(uri, UriKind.Absolute, out uriResult)
                && ((uriResult.Scheme == Uri.UriSchemeHttp && !httpsOnly) || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
