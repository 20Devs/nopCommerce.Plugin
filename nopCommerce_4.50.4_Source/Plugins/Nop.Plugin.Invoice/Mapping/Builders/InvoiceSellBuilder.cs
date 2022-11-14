using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator.Builders.Create.Table;
using Nop.Data.Extensions;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Invoice.Domain;

namespace Nop.Plugin.Invoice.Mapping.Builders
{
    public class InvoiceSellBuilder :   NopEntityBuilder<InvoiceSell>
    {
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(InvoiceSell.buildingNo))     .AsDecimal(28, 0)   .PrimaryKey()
                
                .WithColumn(nameof(InvoiceSell.invoiceNo))      .AsInt64()          .PrimaryKey()


                .WithColumn(nameof(InvoiceSell.dateG))          .AsDateTime()       .NotNullable()
                .WithColumn(nameof(InvoiceSell.dateH))          .AsString(20)       .Nullable()

                .WithColumn(nameof(InvoiceSell.aName))          .AsString(250)      .NotNullable()
                .WithColumn(nameof(InvoiceSell.eName))          .AsString(250)      .Nullable()

                .WithColumn(nameof(InvoiceSell.mainContact1))   .AsString(50)       .Nullable()
                .WithColumn(nameof(InvoiceSell.invoiceVATID))   .AsString(50)       .Nullable()
                .WithColumn(nameof(InvoiceSell.clientVendorNo)) .AsDecimal(21, 0)   .Nullable();

        }
    }
}
