using Microsoft.EntityFrameworkCore;
using Samplefy.Core.Entities;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Song> Songs { get; set; }
    
    public DbSet<Album> Albums { get; set; }
    
    public DbSet<Artist> Artist { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
    }
}