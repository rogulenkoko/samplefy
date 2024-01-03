using Microsoft.AspNetCore.Mvc;
using Samplefy.Core.Repositories;

namespace Samplefy.Controllers;

[ApiController]
[Route("song")]
public class SongsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public SongsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var song = await _unitOfWork.Songs.Get(id);

        if (song == null)
        {
            return NotFound();
        }

        return Ok(song);
    }
}