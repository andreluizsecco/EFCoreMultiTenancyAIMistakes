using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiTenancy.Data;
using MultiTenancy.Interfaces;
using MultiTenancy.Models;

namespace MultiTenancy.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ProductsController(AppDbContext dbContext, IUserContext userContext) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Price = request.Price,
            TenantId = userContext.GetTenantId()
        };

        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAll), new { }, product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await dbContext.Products.ToListAsync();
        return Ok(products);
    }
}

public record CreateProductRequest(string Name, decimal Price);
