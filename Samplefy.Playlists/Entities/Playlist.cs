using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Samplefy.Playlists.Entities;

public class Playlist
{
    [BsonId(IdGenerator = typeof(GuidGenerator))]
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public List<Song> Songs { get; set; } = new();
}