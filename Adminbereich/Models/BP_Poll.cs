using Adminbereich.Interfaces;


namespace Adminbereich.Models;

public record BP_Poll : BlogPost
{
    public BP_Poll()
    {
    }

    public BP_Poll(string headLine, Poll poll, DateTime? creationTime = null) : base(headLine, creationTime)
    { _poll = poll; }

    private Poll _poll;
    private Poll Poll { get { return _poll; } }
}
