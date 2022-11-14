using Nop.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Plugin.Invoice.Services;

namespace Nop.Plugin.Invoice.Infrastructure
{
    internal class NopStartup : INopStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IInvoiceService,InvoiceService>();

        }

        public void Configure(IApplicationBuilder application)
        {
            
        }

        public int Order { get; }
    }
}
