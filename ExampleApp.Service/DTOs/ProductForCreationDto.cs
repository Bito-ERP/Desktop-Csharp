using Microsoft.AspNetCore.Http;

namespace ExampleApp.Service.DTOs;

public class ProductForCreationDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}