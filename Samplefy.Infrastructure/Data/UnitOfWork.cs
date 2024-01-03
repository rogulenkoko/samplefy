using System.Threading.Tasks;
using Samplefy.Core.Repositories;
using Samplefy.Infrastructure.Data.Repositories;

namespace Samplefy.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    private IArtistRepository _artistsRepository;
    private ISongRepository _songRepository;

    public IArtistRepository Artists
    {
        get
        {
            _artistsRepository ??= new ArtistRepository(_context);
            return _artistsRepository;
        }
    }

    public ISongRepository Songs
    {
        get
        {
            _songRepository ??= new SongRepository(_context);
            return _songRepository;
        }
    }

    public Task Save()
    {
        return _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}