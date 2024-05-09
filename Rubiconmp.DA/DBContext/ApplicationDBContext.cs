using Microsoft.EntityFrameworkCore;
using Rubiconmp.DA.Models;

namespace Rubiconmp.DA.DBContext;

public class ApplicationDBContext : DbContext
{
    public DbSet<Rectangle> Rectangles { get; set; }
    
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Rectangle>().HasIndex(r => new {r.X, r.Y}).IsUnique(false);
        
        base.OnModelCreating(builder);
    }
}