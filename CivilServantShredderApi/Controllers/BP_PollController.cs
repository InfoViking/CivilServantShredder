using Adminbereich.Models;
using CivilServantShredderApi.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CivilServantShredderApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BP_PollController(ShredderDatabase datebase) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<BP_Poll>> GetAll()
    {
        var result = await datebase.BP_Polls.ToListAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BP_Poll>> GetById(Guid id)
    {
        var result = await datebase.BP_Polls.SingleOrDefaultAsync( x => x.Id == id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }


    [HttpPost]
    public async Task<ActionResult<BP_Poll>> Create(BP_Poll bp_poll)
    {
        datebase.BP_Polls.Add(bp_poll);
        await datebase.SaveChangesAsync();
        return Ok(bp_poll);
    }

    [HttpPut]
    public async Task<ActionResult<BP_Poll>> Update(BP_Poll bp_poll)
    {
        var existingModel = await datebase.BP_Polls.SingleOrDefaultAsync(x => x.Id == bp_poll.Id);
        if (existingModel == null)
            return NotFound();
        existingModel.HeadLine = bp_poll.HeadLine;
        existingModel.Text = bp_poll.Text;
        existingModel.CreationTime = bp_poll.CreationTime;
        existingModel.PollSelections = bp_poll.PollSelections;
        await datebase.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BP_Poll>> Delete(BP_Poll bp_poll)
    {
        var existingModel = await datebase.BP_Polls.SingleOrDefaultAsync(x => x.Id == bp_poll.Id);
        if (existingModel == null)
            return NotFound();

        datebase.BP_Polls.Remove(existingModel);
        await datebase.SaveChangesAsync();
        return NoContent();
    }
}
