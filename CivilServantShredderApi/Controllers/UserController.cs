using CivilServantShredderApi.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Userbereich.Models;

namespace CivilServantShredderApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(ShredderDatabase database) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAll()
    {
        var result = await database.Users.ToListAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetById(Guid id)
    {
        var result = await database.Users.SingleOrDefaultAsync(x => x.Id == id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<User>> Create(User user)
    {
        if (!await CheckCommunity(user.CommunityId))
        {
            return NotFound("Community not found!");
        }


        database.Users.Add(user);
        await database.SaveChangesAsync();
        return Ok(user);
    }

    [HttpPut]
    public async Task<ActionResult> Update(User user)
    {
        if (!await CheckCommunity(user.CommunityId))
        {
            return NotFound("Community not found!");
        }

        var existing = await database.Users.SingleOrDefaultAsync(x => x.Id == user.Id);
        if (existing == null)
            return NotFound();

        existing.FirstName = user.FirstName;
        existing.LastName = user.LastName;
        existing.PostalCode = user.PostalCode;
        existing.Locality = user.Locality;
        existing.Street = user.Street;
        existing.CommunityId = user.CommunityId;
        existing.Email = user.Email;

        await database.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var existing = await database.Users.SingleOrDefaultAsync(x => x.Id == id);

        if (existing == null)
            return NotFound();

        database.Users.Remove(existing);
        await database.SaveChangesAsync();
        return NoContent();
    }

    private async Task<bool> CheckCommunity(Guid id)
    {
        var community = await database.Communities.SingleOrDefaultAsync(x => x.Id == id);
        if (community == null)
            return false;
        return true;
    }

}

