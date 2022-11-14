using AutoMapper;
using Nop.Core.Infrastructure.Mapper;
using Nop.Plugin.Invoice.Domain;
using Nop.Plugin.Invoice.Models;

namespace Nop.Plugin.Invoice.Infrastructure.Mapper
{
    public class MapperConfiguration : Profile, IOrderedMapperProfile
    {

        public MapperConfiguration()
        {
            CreateMap<InvoiceSell, InvoiceSellViewModel>();
            CreateMap<InvoiceSellViewModel, InvoiceSell>()
                .ForMember(entity => entity.invoiceNo,  options => options.Ignore())
                .ForMember(entity => entity.buildingNo, options => options.Ignore());



            CreateMap<InvoiceSellUnit, InvoiceSellUnitViewModel>();
            CreateMap<InvoiceSellUnitViewModel, InvoiceSellUnit>()
                .ForMember(entity => entity.itemNo, options => options.Ignore())
                ;
        }

        public int Order => 0;

    }
}
