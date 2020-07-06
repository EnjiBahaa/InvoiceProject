using AutoMapper;
using System.Linq;
using Wasmah.Entities;
using Wasmah.WebAPI.DTO;

namespace Wasmah.WebAPI.Mapping
{
    public class InvoiceMapping : Profile
    {
        public InvoiceMapping()
        {
            CreateMap<Invoice, InvoiceDTO>()
                .ForMember(dto => dto.Products, opt => opt.MapFrom(ct => ct.Product_Invoices.Select(cth => cth.Product)))
                .ReverseMap();
        }
    }
}
