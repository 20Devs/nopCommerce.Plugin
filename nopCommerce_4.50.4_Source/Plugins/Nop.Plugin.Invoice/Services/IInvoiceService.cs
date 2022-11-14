using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Invoice.Domain;
using Nop.Plugin.Invoice.Models;

namespace Nop.Plugin.Invoice.Services
{
    public interface IInvoiceService
    {
        Task<IList<InvoiceSell>> GetInvoiceSells();

        Task<InvoiceSellViewModel> GetInvoiceSell(long? invoiceNo);

        Task<IList<InvoiceSellUnit>> GetInvoiceSellUnits(long? InvoiceId);

        Task SaveInvoice(InvoiceSellViewModel InvoiceForm);

    }
}
