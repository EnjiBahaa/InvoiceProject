using AutoMapper;
using Wasmah.Entities;
using Wasmah.WebAPI.DTO;

namespace Wasmah.WebAPI.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
