using System;
using System.Collections.Generic;
using Samplefy.Core.Entities.Abstract;

namespace Samplefy.Core.Entities;

public class Song : BaseEntity
{
    public string Name { get; set; }
    
    public Guid? AlbumId { get; set; }
    
    public Album Album { get; set; }
    
    public List<Artist> Artists { get; set; } = new ();
}