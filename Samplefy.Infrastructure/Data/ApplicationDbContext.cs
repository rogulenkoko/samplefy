using Microsoft.EntityFrameworkCore;
using Samplefy.Core.Entities;

namespace Samplefy.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Song> Songs { get; set; }
    
    public DbSet<Album> Albums { get; set; }
    
    public DbSet<Artist> Artist { get; set; }
}