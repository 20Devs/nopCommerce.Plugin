using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Invoice.Domain;

namespace Nop.Plugin.Invoice.Migrations
{
    [NopMigration("2022/11/04 09:36:08:9037677", "Invoice.InvoiceSell base schema", MigrationProcessType.Update)]
    public class InvoiceSellMigration : AutoReversingMigration
    {
        public override void Up()
        {
            
            Create.TableFor<InvoiceSell>();
            Create.TableFor<InvoiceSellUnit>();

            Create
                .ForeignKey     ("FK_InvoiceSellUnit_InvoiceSell_2")
                .FromTable      (nameof(InvoiceSellUnit))
                .ForeignColumns (nameof(InvoiceSellUnit.buildingNo), nameof(InvoiceSellUnit.invoiceNo))
                .ToTable        (nameof(InvoiceSell))
                .PrimaryColumns (nameof(InvoiceSell.buildingNo), nameof(InvoiceSell.invoiceNo) );

        }
    }
}
