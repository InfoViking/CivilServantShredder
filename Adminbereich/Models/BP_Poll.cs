using Adminbereich.Interfaces;

namespace Adminbereich.Models;

public record BP_Poll : IBlogPost
{
    public BP_Poll()
    { }

    public BP_Poll(string headLine, string text, List<PollSelection> pollSelections, DateTime? creationTime = null)
    {
        Id = Guid.NewGuid();
        HeadLine = headLine;
        Text = text;

        if (creationTime == null)
            CreationTime = DateTime.Now;
        else
            CreationTime = creationTime.Value;
    }

    public Guid Id { get; set; }
    public Guid CommunityId { get; set; }
    public string HeadLine { get; set; } = default!;
    public string Text { get; set; } = default!;
    public DateTime CreationTime { get; set; }

    public List<PollSelection> PollSelections { get; set; } = new List<PollSelection>();
}
