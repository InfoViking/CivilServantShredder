
using Adminbereich.Models;

namespace CivilServantShredder.Models;

public class Poll
{
    public Guid Id { get; set; }
    public Guid CommunityId { get; set; }
    public string HeadLine { get; set; } = default!;
    public string Text { get; set; } = default!;
    public DateTime CreationTime { get; set; }

    public List<PollSelectionModel> PollSelections { get; set; } = new List<PollSelectionModel>();

    public Poll(BP_Poll model)
    {
        Id = model.Id;
        CommunityId = model.CommunityId;
        HeadLine = model.HeadLine;
        Text = model.Text;
        CreationTime = model.CreationTime;
        PollSelections = model.PollSelections.Select(x => new PollSelectionModel() 
        { 
            Selected = x.Selected, 
            SelectionText = x.SelectionText  
        }).ToList();


    }
}
