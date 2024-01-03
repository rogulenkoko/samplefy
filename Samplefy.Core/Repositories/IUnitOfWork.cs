using System;
using System.Threading.Tasks;

namespace Samplefy.Core.Repositories;

public interface IUnitOfWork : IDisposable
{
    IArtistRepository Artists { get; }
    
    ISongRepository Songs { get; }

    Task Save();
}