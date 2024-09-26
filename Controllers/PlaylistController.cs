
using EntityFramework.DTO;
using EntityFramework.Model;
using EntityFramework.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers;

[ApiController]
[Route("playlist")]
public class PlaylistController(IPlaylistRepository repo, IUserRepository userRepo) : ControllerBase
{
    [HttpGet("{guid}")]
    public async Task<ActionResult> GetById(Guid guid)
    {
        var playlist = await repo.GetById(guid);

        if (playlist is null)
            return NotFound(new{message = "Playlist não encontrada."});

        return Ok(playlist);
    }

    [HttpPost("add/{guid}")]
    public async Task<ActionResult> CreatePlaylist(Guid guid, PlaylistDto payload)
    {
        var user = await userRepo.GetById(guid);

        if (user is null)
            return NotFound(new {message = "Usuário não encontrado"});

        var playlist = new Playlist
        {
            PlaylistName = payload.PlaylistName,
            UserId = user.UserId
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