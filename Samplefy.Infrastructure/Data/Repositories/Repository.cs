using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Samplefy.Core.Entities.Abstract;
using Samplefy.Core.Repositories;

namespace Samplefy.Infrastructure.Data.Repositories;

internal abstract class Repository<TEntity> : IRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly ApplicationDbContext _context;

    protected Repository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public async Task<TEntity> Delete(Guid id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity == null)
        {
            return null;
        }

        entity.IsDeleted = true;
        
        _context.Set<TEntity>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;

        return entity;
    }

    public async Task<TEntity> Get(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public TEntity Update(TEntity entity)
    {
        _context.Set<TEntity>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        return entity;
    }
}