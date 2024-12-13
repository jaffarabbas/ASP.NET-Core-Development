using System.Text.Json;
using EDA_Inventory.RabbitMQ;
using EDA_Product.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EDA_Product.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(ProductDBContext dbContext,IRabbitMQUtils rabbitMqUtils) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await dbContext.Products.ToListAsync();
    }

    [HttpPut]
    public async Task<ActionResult<Product>> UpdateProduct(Product product)
    {
        dbContext.Products.Update(product);
        await dbContext.SaveChangesAsync();
        var _product = JsonSerializer.Serialize(new
        {
            product.id,
            product.Name,
            product.Quantity
        });
        return CreatedAtAction("GetProducts", new { product.id }, product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();
        var _product = JsonSerializer.Serialize(new
        {
            product.id,
            product.ProdcutID,
            product.Name,
            product.Quantity
        });
        await rabbitMqUtils.PublishMessageQueue("inventory.product",_product);
        return CreatedAtAction("GetProducts", new { product.id }, product);
    }
}