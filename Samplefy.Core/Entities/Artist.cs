using System.Collections.Generic;
using Samplefy.Core.Entities.Abstract;

namespace Samplefy.Core.Entities;

public class Artist : BaseEntity
{
    public string Name { get; set; }

    public List<Song> Songs { get; set; } = new();

    public List<Album> Albums { get; set; } = new();
}