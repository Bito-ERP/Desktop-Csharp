using AutoMapper;
using ExampleApp.Domain.Entities.Products;
using ExampleApp.Service.DTOs;

namespace ExampleApp.Service.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<ProductForCreationDto, Product>().ReverseMap();
    }
}