using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Contracts.Security
{
    public interface IClientInputService
    {
        bool IsValidUri(string uri, bool httpsOnly = true);
        string FormatToUrl(string link, bool httpsOnly = true);
    }
}
