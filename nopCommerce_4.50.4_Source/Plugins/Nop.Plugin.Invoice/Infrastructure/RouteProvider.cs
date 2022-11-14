using Nop.Web.Framework.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;

namespace Nop.Plugin.Invoice.Infrastructure
{
    public class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapControllerRoute
                                    (
                                        "Plugin.Invoice.Index",
                                        "Plugins/Invoice/Index",
                                        new
                                        {
                                            controller  = "Invoice", 
                                            action      = "Index"
                                        });
        }

        public int Priority => -1;
    }
}
