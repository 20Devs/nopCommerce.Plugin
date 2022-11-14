using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Nop.Plugin.Invoice.Domain;

namespace Nop.Plugin.Invoice.Models
{
    public class InvoiceSellViewModel
    {
       
        public decimal       buildingNo         { get; set; }
        public long          invoiceNo          { get; set; }

        public DateTime      dateG              { get; set; }
        public string        dateH              { get; set; }
        
        public string        aName              { get; set; }
        public string?       eName              { get; set; }
        
        public string?       mainContact1       { get; set; }
        public string?       invoiceVATID       { get; set; }
        public decimal?      clientVendorNo     { get; set; }

        public string?       Rows               { get; set; }
        public string?       InsertedRows       { get; set; }
        public string?       RemovedRows        { get; set; }

        
        public IList<InvoiceSellUnitViewModel>? sellUnits { get; set; }
    }
}
