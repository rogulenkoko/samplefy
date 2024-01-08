using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Samplefy.Playlists.Entities;
using Samplefy.Playlists.Models;

namespace Samplefy.Playlists.Controllers;

[ApiController]
[Route("playlist")]
public class PlaylistController : ControllerBase
{
    private readonly IMongoCollection<Playlist> _playlistsCollection;
    
    public PlaylistController(IMongoCollection<Playlist> playlistsCollection)
    {
        _playlistsCollection = playlistsCollection;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlaylist(Guid id)
    {
        var playlist = await _playlistsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        if (playlist == null)
        {
            return NotFound();
        }

        return Ok(playlist);
    }

    [HttpPost]
    public async Task<IActionResult> AddPlaylist([FromBody] PlaylistModel playlistModel)
    {
        var playlist = new Playlist
        {
            Name = playlistModel.Name,
        };

        await _playlistsCollection.InsertOneAsync(playlist);

        return Ok(playlist.Id);
    }

    [HttpPost("{id}/song/{songId}")]
    public async Task<IActionResult> AddSong(Guid id, Guid songId)
    {
        var playlist = await _playlistsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        if (playlist == null)
        {
            return NotFound();
        }

        var filter = Builders<Playlist>.Filter
            .Eq(restaurant => restaurant.Id, id);

        var song = new Song
        {
            Id = songId,
        };
        
        var update = Builders<Playlist>.Update
            .Push(restaurant => restaurant.Songs, song);

        var result = await _playlistsCollection.UpdateOneAsync(filter, update);
        
        return result.IsAcknowledged ? Ok() : BadRequest();
    }
}