using Nop.Web.Framework.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Nop.Plugin.Invoice.Models;

namespace Nop.Plugin.Invoice.Validators
{
    public class InvoiceSellValidator : BaseNopValidator<InvoiceSellViewModel>
    {
        public InvoiceSellValidator()
        {
            RuleFor(x => x.invoiceNo)
                .NotNull();
            //=== other validation


        }
    }
}
