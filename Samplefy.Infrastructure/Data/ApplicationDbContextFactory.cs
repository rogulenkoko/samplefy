using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Samplefy.Infrastructure.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        
        // todo inject through env var
        optionsBuilder
            .UseNpgsql("Server=c-samplefy.6y2wv5vztlzoiq.postgres.cosmos.azure.com;Database=samplefy;Port=5432;User Id=citus;Password=rogulenkokoqQ!;Ssl Mode=Require;Integrated Security=True;TrustServerCertificate=True;")
            .UseSnakeCaseNamingConvention();
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}