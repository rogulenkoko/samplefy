using Samplefy.Core.Entities;
using Samplefy.Core.Repositories;

namespace Samplefy.Infrastructure.Data.Repositories;

internal class SongRepository : Repository<Song>, ISongRepository
{
    public SongRepository(ApplicationDbContext context) : base(context)
    {
    }
}