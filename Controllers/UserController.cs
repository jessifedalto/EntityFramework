using EntityFramework.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    readonly IUserRepository userRepository;
    readonly IChannelRepository channelRepository;

    public UserController(IUserRepository repo)
        => this.userRepository = repo;

    [HttpGet]
    public async Task<ActionResult> GetChannels(Guid guid)
    {
        var channels = GetChannels(guid);
        return Ok(channels);
    }
}