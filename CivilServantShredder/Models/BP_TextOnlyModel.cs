

using Adminbereich.Models;

namespace CivilServantShredder.Models;

public class BP_TextOnlyModel
{

    public Guid Id { get; set; }
    public Guid CommunityId { get; set; }
    public string Text { get; set; } = default!;
    public string HeadLine { get; set; } = default!;
    public DateTime CreationTime { get; set; }

    public BP_TextOnlyModel(BP_TextOnly model)
    {
        Id = model.Id;
        CommunityId = model.CommunityId;
        Text = model.Text;
        HeadLine = model.HeadLine;
        CreationTime = model.CreationTime;    
    }
}
