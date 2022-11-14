using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;

namespace Nop.Plugin.Invoice.Domain
{
    public class InvoiceSell : BaseEntity
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


    }
}
