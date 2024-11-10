using Adminbereich.Models;
using CivilServantShredderApi.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CivilServantShredderApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BP_TextOnlyController(ShredderDatabase datebase) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<BP_TextOnly>> GetAll()
    {
        var result = await datebase.BP_TextOnlys.ToListAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BP_TextOnly>> GetById(Guid id)
    {
        var result = await datebase.BP_TextOnlys.SingleOrDefaultAsync(x => x.Id == id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("byCommunity/{communityId}")]
    public async Task<ActionResult<List<BP_TextOnly>>> GetByCommunityId(Guid communityId)
    {
        var result = await datebase.BP_TextOnlys.Where(x => x.CommunityId == communityId).ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<BP_TextOnly>> Create(BP_TextOnly bP_TextOnly)
    {
        datebase.BP_TextOnlys.Add(bP_TextOnly);
        await datebase.SaveChangesAsync();
        return Ok(bP_TextOnly);
    }

    [HttpPut]
    public async Task<ActionResult<BP_TextOnly>> Update(BP_TextOnly bP_TextOnly)
    {
        var existingModel = await datebase.BP_TextOnlys.SingleOrDefaultAsync(x => x.Id == bP_TextOnly.Id);
        if (existingModel == null)
            return NotFound();
        existingModel.HeadLine = bP_TextOnly.HeadLine;
        existingModel.CreationTime = bP_TextOnly.CreationTime;
        existingModel.Text = bP_TextOnly.Text;
        await datebase.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BP_TextOnly>> Delete(BP_TextOnly bP_TextOnly)
    {
        var existingModel = await datebase.BP_TextOnlys.SingleOrDefaultAsync(x => x.Id == bP_TextOnly.Id);
        if (existingModel == null)
            return NotFound();

        datebase.BP_TextOnlys.Remove(existingModel);
        await datebase.SaveChangesAsync();
        return NoContent();
    }
}
