using Microsoft.AspNetCore.Mvc;
using Samplefy.Core.Entities;

namespace Samplefy.Controllers;

[ApiController]
[Route("[controller]")]
public class SongsController : ControllerBase
{
    private readonly ILogger<SongsController> _logger;

    public SongsController(ILogger<SongsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<Song> Get()
    {
        return new List<Song>();
    }
}