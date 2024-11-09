using Adminbereich.Models;
using CivilServantShredderApi.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CivilServantShredderApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BP_TextAndPictureController(ShredderDatabase datebase) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<BP_TextAndPicture>> GetAll()
    {
        var result = await datebase.BP_TextAndPictures.ToListAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BP_TextAndPicture>> GetById(Guid id)
    {
        var result = await datebase.BP_TextAndPictures.SingleOrDefaultAsync(x => x.Id == id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<BP_Poll>> Create(BP_TextAndPicture bP_TextAndPicture)
    {
        datebase.BP_TextAndPictures.Add(bP_TextAndPicture);
        await datebase.SaveChangesAsync();
        return Ok(bP_TextAndPicture);
    }

    [HttpPut]
    public async Task<ActionResult<BP_TextAndPicture>> Update(BP_TextAndPicture bP_TextAndPicture)
    {
        var existingModel = await datebase.BP_TextAndPictures.SingleOrDefaultAsync(x => x.Id == bP_TextAndPicture.Id);
        if (existingModel == null)
            return NotFound();
        existingModel.HeadLine = bP_TextAndPicture.HeadLine;
        existingModel.CreationTime = bP_TextAndPicture.CreationTime;
        existingModel.Text = bP_TextAndPicture.Text;
        existingModel.PictureBase64 = bP_TextAndPicture.PictureBase64;
        await datebase.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BP_TextAndPicture>> Delete(BP_TextAndPicture bP_TextAndPicture)
    {
        var existingModel = await datebase.BP_TextAndPictures.SingleOrDefaultAsync(x => x.Id == bP_TextAndPicture.Id);
        if (existingModel == null)
            return NotFound();

        datebase.Remove(existingModel);
        await datebase.SaveChangesAsync();
        return NoContent();
    }
}
