using Nop.Data.Mapping.Builders;
using Nop.Plugin.Invoice.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator.Builders.Create.Table;
using Nop.Data.Extensions;

namespace Nop.Plugin.Invoice.Mapping.Builders
{
    public class InvoiceSellUnitBuilder : NopEntityBuilder<InvoiceSellUnit>
    {
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(InvoiceSellUnit.buildingNo))             .AsDecimal(28, 0)       .PrimaryKey()
                .WithColumn(nameof(InvoiceSellUnit.invoiceNo))              .AsInt64()              .PrimaryKey()
                .WithColumn(nameof(InvoiceSellUnit.orderNo))                .AsInt32()              .PrimaryKey()
                
                .WithColumn(nameof(InvoiceSellUnit.itemNo))                 .AsDecimal(28, 0)       .NotNullable()
                .WithColumn(nameof(InvoiceSellUnit.unitNo))                 .AsInt16()              .NotNullable()

                .WithColumn(nameof(InvoiceSellUnit.aName))                  .AsString(250)          .NotNullable()
                .WithColumn(nameof(InvoiceSellUnit.eName))                  .AsString(250)          .Nullable()

                .WithColumn(nameof(InvoiceSellUnit.quantity))               .AsDecimal(18, 6)       .NotNullable()
                .WithColumn(nameof(InvoiceSellUnit.price))                  .AsDecimal(18, 6)       .NotNullable()
                .WithColumn(nameof(InvoiceSellUnit.discount))               .AsDecimal(18, 6)       .Nullable()
                .WithColumn(nameof(InvoiceSellUnit.total))                  .AsDecimal(18, 6)       .Nullable()

                .WithColumn(nameof(InvoiceSellUnit.taxRate1_Percentage))    .AsDecimal(18, 6)       .Nullable()
                .WithColumn(nameof(InvoiceSellUnit.taxRate1_Total     ))    .AsDecimal(18, 6)       .Nullable()
                .WithColumn(nameof(InvoiceSellUnit.totalPlusTax))           .AsDecimal(18, 6)       .Nullable()

                ;
        }
    }
}
