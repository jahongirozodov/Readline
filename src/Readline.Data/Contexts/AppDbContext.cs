using Microsoft.EntityFrameworkCore;
using Readline.Domain.Entites.Assets;
using Readline.Domain.Entites.Books;
using Readline.Domain.Entites.Categories;
using Readline.Domain.Entites.Users;

namespace Readline.Data.Contexts;

public class AppDbContext : DbContext 
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Asset> Assets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>()
            .HasOne(x=> x.Category)
            .WithMany()
            .HasForeignKey(x=> x.CategoryId);

        modelBuilder.Entity<Book>()
            .HasOne(x => x.Genre)
            .WithMany()
            .HasForeignKey(x=> x.GenreId);
    }
}
