using CivilServantShredderApi.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Userbereich.Models;

namespace CivilServantShredderApi.Controllers;


[ApiController]
[Route("[controller]")]
public class CommunityController(ShredderDatabase database) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Community>>> GetAll()
    {
        List<Community> result = await database.Communities.ToListAsync();

        return Ok(result);
    }
    // http://localhost:8888/Community/jdffdgjdafngkj
    [HttpGet("{id}")]
    public async Task<ActionResult<Community>> GetbyId(Guid id)
    {
        Community result = await database.Communities.SingleOrDefaultAsync(x => x.Id == id);

        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Community>> Create(Community community)
    {
        database.Communities.Add(community);
        await database.SaveChangesAsync();
        return Ok(community);
    }

    [HttpPut]
    public async Task<ActionResult> Update(Community community)
    {
        var existing = await database.Communities.SingleOrDefaultAsync(x => x.Id == community.Id);

        if (existing == null)
            return NotFound();

        existing.Name = community.Name;
        await database.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var existing = await database.Communities.SingleOrDefaultAsync(x => x.Id == id);

        if (existing == null)
            return NotFound();

        database.Communities.Remove(existing);
        await database.SaveChangesAsync();
        return NoContent();
    }
}
