using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using Nop.Data;
using Nop.Plugin.Invoice.Domain;
using Nop.Plugin.Invoice.Models;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Nop.Plugin.Invoice.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IRepository<InvoiceSell> _invoiceSellRepository;
        private readonly IRepository<InvoiceSellUnit> _invoiceSellUnitRepository;

        public InvoiceService
            (
                IRepository<InvoiceSell>        invoiceSellRepository,
                IRepository<InvoiceSellUnit>    invoiceSellUnitRepository
            )
        {
            _invoiceSellRepository = invoiceSellRepository;
            _invoiceSellUnitRepository = invoiceSellUnitRepository;
        }

        public async Task<IList<InvoiceSell>>       GetInvoiceSells ()
        {
            return await 
                _invoiceSellRepository
                    .GetAllAsync
                        (
                            query => query.OrderBy(x=>x.invoiceNo)
                        );
             
        }
 
        public async Task<InvoiceSellViewModel>     GetInvoiceSell  (long? invoiceNo)
        {

            var invoiceSell = await _invoiceSellRepository
                                    .Table
                                    .FirstOrDefaultAsync(x => x.invoiceNo == invoiceNo);

            var invoiceModel = AutoMapperConfiguration.Mapper.Map<InvoiceSellViewModel>(invoiceSell);

            if (invoiceNo != null)
            {
                var sellUnits = await GetInvoiceSellUnits(invoiceNo);
                invoiceModel.sellUnits =
                    AutoMapperConfiguration.Mapper.Map<IList<InvoiceSellUnitViewModel>>(sellUnits);
            }

            return invoiceModel;
        }
        
        public async Task<IList<InvoiceSellUnit>>   GetInvoiceSellUnits(long? InvoiceId)
        {

            return await
                _invoiceSellUnitRepository
                    .GetAllAsync
                    (
                        query => query.Where(x => x.invoiceNo == InvoiceId).OrderBy(x => x.invoiceNo)
                    );
        }

        public async Task                           SaveInvoice     (InvoiceSellViewModel InvoiceForm)
        {
            using (var transaction = new CommittableTransaction(
                       new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
            {
                try
                {
                    // save Head
                    InvoiceSell Head;

                    Head = await _invoiceSellRepository
                        .Table
                        .FirstOrDefaultAsync(x => x.invoiceNo == InvoiceForm.invoiceNo);

                    if(Head != null) //update existing
                    {
                        AutoMapperConfiguration.Mapper.Map(source:InvoiceForm,destination: Head);
                        await _invoiceSellRepository.UpdateAsync(Head);
                    }
                    else // add new one
                    {
                        Head            = AutoMapperConfiguration.Mapper.Map<InvoiceSell>(InvoiceForm);
                        Head.invoiceNo  = InvoiceForm.invoiceNo;
                        Head.buildingNo = await GetMaxBuildingNo() +1;

                        await _invoiceSellRepository.InsertAsync(Head);
                    }


                    //=== save items ======

                    //1.Remove all items
                    await _invoiceSellUnitRepository.DeleteAsync(query => query.buildingNo == Head.buildingNo);

                    //2. Insert All Rows
                    if (!string.IsNullOrWhiteSpace(InvoiceForm.Rows))
                    {
                        var sellUnits = JsonSerializer.Deserialize<List<InvoiceSellUnit>>(InvoiceForm.Rows);

                        sellUnits = sellUnits.Select(x =>
                        {
                            x.buildingNo = Head.buildingNo;
                            x.invoiceNo = Head.invoiceNo;
                            return x;
                        }).ToList();

                        await _invoiceSellUnitRepository.InsertAsync(sellUnits);
                    }



                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    
                    transaction.Rollback();
                    throw;
                }
            }
        }

        private async Task<int>                     GetMaxBuildingNo ()
        {
            return await _invoiceSellRepository.Table.MaxAsync(x => (int?)x.buildingNo) ?? 0;
        }

    }
}
