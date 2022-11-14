using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Controllers; 
using Nop.Plugin.Invoice.Services;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;
using Nop.Plugin.Invoice.Models;

namespace Nop.Plugin.Invoice.Controllers
{
    public class InvoiceController : BasePluginController
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController
            (
                IInvoiceService invoiceService
            )
        {
            _invoiceService = invoiceService;
        }

        public async Task<IActionResult> Index()
        {
            return View("~/Plugins/Invoice/Views/Index.cshtml");
        }

        public async Task<IActionResult> Configure()
        {
            return View("~/Plugins/Invoice/Views/Configure.cshtml");
        }

        public async Task<IActionResult> Create(int? invoiceNo)
        {
            var model = await _invoiceService.GetInvoiceSell(invoiceNo);

            return View("~/Plugins/Invoice/Views/Create.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] InvoiceSellViewModel Form)
        {

            if (!ModelState.IsValid)
                return View("~/Plugins/Invoice/Views/Create.cshtml", Form);

            await _invoiceService.SaveInvoice(Form);

            return RedirectToAction(nameof(InvoiceController.Index), "Invoice");

        }

        [HttpGet]
        public object GetInvoiceSells(DataSourceLoadOptions loadOptions)
        {
            var list = _invoiceService.GetInvoiceSells().GetAwaiter().GetResult();
            return DataSourceLoader.Load(list, loadOptions);
        }

     

    }
}
