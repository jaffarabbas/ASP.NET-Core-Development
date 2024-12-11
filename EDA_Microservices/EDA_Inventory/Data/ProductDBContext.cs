using Microsoft.EntityFrameworkCore;

namespace EDA_Product.Data;

public class ProductDBContext : DbContext
{
    public ProductDBContext()
    {
        
    }

    public ProductDBContext(DbContextOptions options) : base(options)
    {
        
    } 
    
    public DbSet<Product> Products { get; set; }
}