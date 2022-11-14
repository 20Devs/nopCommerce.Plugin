using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Services.Plugins;

namespace Nop.Plugin.Invoice
{
    public class InvoiceManagment : BasePlugin
    {
        private readonly IWebHelper _webHelper;

        public InvoiceManagment(IWebHelper webHelper)
        {
            _webHelper = webHelper;
        }
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Invoice/Configure";
        }
    }
}
