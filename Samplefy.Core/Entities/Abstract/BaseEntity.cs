using System;

namespace Samplefy.Core.Entities.Abstract;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedDate { get; set; }
}