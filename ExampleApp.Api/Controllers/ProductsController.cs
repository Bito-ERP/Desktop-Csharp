using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExampleApp.Domain.Configurations;
using ExampleApp.Domain.Entities.Products;
using ExampleApp.Service.DTOs;
using ExampleApp.Service.Interfaces;

namespace ExampleApp.Api.Controllers;

[Authorize]
public class ProductsController : BaseController
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Product CRUD
    /// </summary>
    /// <param name="params"></param>
    /// <returns></returns>
    [HttpGet, AllowAnonymous]
    public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _productService.GetAllAsync(@params));

    [HttpGet("{Id}"), AllowAnonymous]
    public async ValueTask<IActionResult> GetAsync([FromRoute(Name = "Id")] int id)
        => Ok(await _productService.GetAsync(p => p.Id == id));

    [HttpPost]
    public async Task<ActionResult<Product>> AddAsync([FromForm] ProductForCreationDto dto)
        => Ok(await _productService.AddAsync(dto));

    [HttpPut("{Id}")]
    public async Task<ActionResult<Product>> UpdateAsync([FromRoute(Name = "Id")] int id, [FromForm] ProductForCreationDto dto)
        => Ok(await _productService.UpdateAsync(id, dto));

    [HttpDelete("{Id}")]
    public async Task<ActionResult<bool>> DeleteAsync([FromRoute(Name = "Id")] int id)
        => Ok(await _productService.DeleteAsync(p => p.Id == id));

    /// <summary>
    /// CRUD of Category of product
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
}