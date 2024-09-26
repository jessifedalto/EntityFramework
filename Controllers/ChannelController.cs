
using EntityFramework.DTO;
using EntityFramework.Model;
using EntityFramework.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers;

[ApiController]
[Route("channel")]
public class ChannelController(IChannelRepository repo, IUserRepository userRepo, IVideoRepository videoRepo) : ControllerBase
{
    [HttpGet("{guid}")]
    public async Task<ActionResult> GetById(Guid guid)
    {
        var channel = await repo.GetById(guid);

        if (channel is null)
            return NotFound();

        return Ok(channel);
    }

    [HttpPost("add/{guid}")]
    public async Task<ActionResult> CreateChannel(Guid guid, ChannelDto payload)
    {
        if (payload == null)
            return BadRequest(new { message = "Payload não pode ser nulo" });

        User user = await userRepo.GetById(guid);

        if (user is null)
            return NotFound(new { message = "Usuário não encontrado" });

        var channels = await repo.GetChannels();

        foreach (var ch in channels)
        {
            if (ch.ChannelName.Equals(payload.ChannelName))
                return Conflict(new{message = "Já existe um canal com esse nome"});
        }

        var channel = new Channel
        {
            ChannelName = payload.ChannelName,
            ChannelType = payload.ChannelType
        };

        await repo.Add(channel);

        await repo.AddUser(channel, user);

        return Ok(channel);
    }

    [HttpDelete("{guid}")]
    public async Task Delete(Guid guid)
    {
        await repo.Delete(guid);
    }

    [HttpGet("users/{guid}")]
    public async Task<ActionResult> GetUsers(Guid guid)
    {
        var users = await repo.GetUsers(guid);

        return Ok(users);
    }

    [HttpGet("videos/{guid}")]
    public async Task<ActionResult> GetVideos(Guid guid)
    {
        var videos = await repo.GetVideos(guid);

        return Ok(videos);
    }

    [HttpPatch("user/{guid}/{userGuid}")]
    public async Task<ActionResult> AddUser(Guid guid, Guid userGuid)
    {
        var channel = await repo.GetById(guid);

        var user = await userRepo.GetById(userGuid);

        if (channel is null)
            return NotFound(new{message = "Canal não encontrado"});

        if (user is null)
            return BadRequest(new {message = "Usuário não encontrado"});

        await repo.AddUser(channel, user);

        return Ok(channel);
    }

    [HttpPatch("video/{guid}/{videoGuid}")]
    public async Task<ActionResult> AddVideo(Guid guid, Guid videoGuid)
    {
        var channel = await repo.GetById(guid);

        var video = await videoRepo.GetById(videoGuid);

        if (channel is null)
            return NotFound(new { message = "Canal não encontrado" });

        if (video is null)
            return NotFound(new { message = "Video não encontrado" });

        await repo.AddVideo(channel, video);

        return Ok(channel);
    }
}