using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;

namespace Nop.Plugin.Invoice.Domain
{
    public  class InvoiceSellUnit : BaseEntity
    {

        public long      invoiceNo               { get; set; }
        public decimal   buildingNo              { get; set; }
                         
        public int       orderNo                 { get; set; }
        public decimal   itemNo                  { get; set; }
        public short?    unitNo                  { get; set; }
                         
        public string    aName                   { get; set; }
        public string?   eName                   { get; set; }
                         
        public decimal   quantity                { get; set; }
        public decimal   price                   { get; set; }
        public decimal?  discount                { get; set; }
        public decimal?  total                   { get; set; }
        
        public decimal?  taxRate1_Percentage     { get; set; }
        public decimal?  taxRate1_Total          { get; set; }
        public decimal?  totalPlusTax            { get; set; }

    }
}
