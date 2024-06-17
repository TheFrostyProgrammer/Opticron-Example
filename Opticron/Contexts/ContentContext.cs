namespace Opticron;
using Microsoft.EntityFrameworkCore;

public class ContentContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Carousel> Carousels { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<News> News { get; set; }
    public ContentContext(DbContextOptions<ContentContext> options) : base(options)
    {
    }

    // Define your entity DbSet properties here
    // For example:
    // public DbSet<User> Users { get; set; }
    // public DbSet<Post> Posts { get; set; }
}

