using System;
using System.Threading.Tasks;
using Samplefy.Core.Entities.Abstract;

namespace Samplefy.Core.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> Get(Guid id);
    
    void Add(T entity);
    
    T Update(T entity);
    
    Task<T> Delete(Guid id);
}