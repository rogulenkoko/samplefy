using Samplefy.Core.Entities;
using Samplefy.Core.Repositories;

namespace Samplefy.Infrastructure.Data.Repositories;

internal class ArtistRepository : Repository<Artist>, IArtistRepository
{
    public ArtistRepository(ApplicationDbContext context) : base(context)
    {
    }
}