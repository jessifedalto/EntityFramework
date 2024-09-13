using EntityFramework.DTO;
using EntityFramework.Model;
using EntityFramework.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers;

[ApiController]
[Route("user")]
public class UserController(IUserRepository repo) : ControllerBase
{
    [HttpGet("/")]
    public async Task<ActionResult> GetChannels(Guid guid)
    {
        var channels = await repo.GetChannels(guid);
        return Ok(channels);
    }

    public async Task<ActionResult> GetById(Guid guid)
    {
        var user = await repo.GetById(guid);

        if (user is null)
            return NotFound();

        return Ok(user);

    }

    public async Task<ActionResult> CreateUser(UserDto payload)
    {
        var user = new User {
            Name = payload.Name,
            UserName = payload.UserName,
            BirthDate = payload.BirthDate,
            Email = payload.Email,
            Password = payload.Password,
            UserRole = payload.UserRole
        };

        await repo.Add(user);

        return Created("/user", user);
    }

    
}