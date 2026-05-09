using EFCoreMultiTenancy.Data;
using EFCoreMultiTenancy.Models;
using EFCoreMultiTenancy.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMultiTenancy.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ProductsController(AppDbContext dbContext, ITenantService tenantService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await dbContext.Products.ToListAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        product.TenantId = tenantService.GetTenantId();
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();
        return Created($"/products/{product.Id}", product);
    }
}
