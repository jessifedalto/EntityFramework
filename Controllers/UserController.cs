using EntityFramework.DTO;
using EntityFramework.Model;
using EntityFramework.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers;

[ApiController]
[Route("user")]
public class UserController(IUserRepository repo, IRoleRepository roleRepo) : ControllerBase
{
    [HttpPost("add")]
    public async Task<ActionResult> CreateUser(UserDto payload)
    {
        var role = await roleRepo.GetById(payload.RoleId);
     
        var user = new User
        {
            Name = payload.Name,
            UserName = payload.UserName,
            BirthDate = payload.BirthDate,
            Email = payload.Email,
            Password = payload.Password,
            UserRole = payload.UserRole,
            RoleId = payload.RoleId,
            Role = role
        };

        await repo.Add(user);

        return Ok(user);
    }

    [HttpDelete("delete/{guid}")]
    public async Task<ActionResult> Delete(Guid guid)
    {
        var user = await repo.GetById(guid);

        if (user == null)
            return NotFound(new{message = "Usuário não encontrado."});

        await repo.Delete(guid);
        
        return Ok(new {message = "Usuário deletado com sucesso"});
    }

    [HttpGet("{guid}")]
    public async Task<ActionResult> GetById(Guid guid)
    {
        var user = await repo.GetById(guid);

        if (user is null)
            return NotFound();

        return Ok(user);

    }

    [HttpPut("{guid}")]
    public async Task<ActionResult> Update(Guid guid, UserDto payload)
    {
        var existingUser = await repo.GetById(guid);

        if (existingUser == null)
        {
            return NotFound();
        }

        await repo.Update(guid, payload);

        return NoContent();
    }

    [HttpGet("channels/{guid}")]
    public async Task<ActionResult> GetChannels(Guid guid)
    {
        var channels = await repo.GetChannels(guid);
        return Ok(channels);
    }

    [HttpGet("playlists/{guid}")]
    public async Task<ActionResult> GetPlaylists(Guid guid)
    {
        var playlists = await repo.GetPlaylists(guid);
        return Ok(playlists);
    }

    [HttpGet("subscribes/{guid}")]
    public async Task<ActionResult> GetSubscribed(Guid guid)
    {
        var subscribes = await repo.GetSubscribed(guid);
        return Ok(subscribes);
    }
}