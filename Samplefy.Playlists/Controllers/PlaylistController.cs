using Microsoft.AspNetCore.Mvc;

namespace Samplefy.Playlists.Controllers;

[ApiController]
[Route("playlist")]
public class PlaylistController : ControllerBase
{
    public PlaylistController(ILogger<PlaylistController> logger)
    {
    }

    [HttpPost("{id}/song/{songId}")]
    public IActionResult AddSong(Guid id, Guid songId)
    {
        return Ok();
    }
}