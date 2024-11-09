namespace Adminbereich.Models;

public class Poll
{

    public Poll(string headLine, string text)
    {
        HeadLine = headLine;
        Text = text;
    }
    public string HeadLine { get; set; }
    public string Text { get; set; }
    private List<PollSelection> pollSelections = new List<PollSelection>();

    public void AddSelection(string selectionText, bool selected = false)
    { pollSelections.Add(new PollSelection(selectionText, selected)); }
}
