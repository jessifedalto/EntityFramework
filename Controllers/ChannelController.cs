
using EntityFramework.DTO;
using EntityFramework.Model;
using EntityFramework.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers;

[ApiController]
[Route("channel")]
public class ChannelController(IChannelRepository repo, IUserRepository userRepo) : ControllerBase
{
    [HttpGet("{guid}")]
    public async Task<ActionResult> GetById(Guid guid)
    {
        var channel = await repo.GetById(guid);

        if (channel is null)
            return NotFound();

        return Ok(channel);
    }

    [HttpPost("add")]
    public async Task<ActionResult> CreateChannel(ChannelDto payload)
    {
        var channel = new Channel
        {
            ChannelName = payload.ChannelName,
            ChannelType = payload.ChannelType
        };

        await repo.Add(channel);

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

        if (channel is null || user is null)
            return BadRequest("Os ids são obrigatórios");

        await repo.AddUser(channel, user);

        return Ok(channel);
    }
}