
using EntityFramework.DTO;
using EntityFramework.Model;
using EntityFramework.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers;

[ApiController]
[Route("playlist")]
public class PlaylistController(IPlaylistRepository repo) : ControllerBase
{
    [HttpGet("{guid}")]
    public async Task<ActionResult> GetById(Guid guid)
    {
        var playlist = await repo.GetById(guid);

        if (playlist is null)
            return NotFound();

        return Ok(playlist);
    }

    [HttpPost("add")]
    public async Task<ActionResult> CreateChannel(PlaylistDto payload)
    {
        var playlist = new Playlist
        {
            PlaylistName = payload.PlaylistName
        };

        await repo.Add(playlist);

        return Ok(playlist);
    }

    [HttpDelete("{guid}")]
    public async Task Delete(Guid guid)
    {
        await repo.Delete(guid);
    }

    [HttpGet("videos/{guid}")]
    public async Task<ActionResult> GetVideos(Guid guid)
    {
        var videos = await repo.GetVideos(guid);

        return Ok(videos);
    }
}