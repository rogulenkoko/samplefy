using System.Collections.Generic;
using Samplefy.Core.Entities.Abstract;

namespace Samplefy.Core.Entities;

public class Album : BaseEntity
{
    public string Name { get; set; }

    public List<Artist> Artists { get; set; } = new();

    public List<Song> Songs { get; set; } = new ();
}