using AutoMapper;
using BitoDesktop.Domain.Entities.Products;
using BitoDesktop.Service.DTOs;

namespace BitoDesktop.Service.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<ProductForCreationDto, Product>().ReverseMap();
        
    }
}