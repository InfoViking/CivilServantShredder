using Adminbereich.Interfaces;


namespace Adminbereich.Models;

public class BP_TextOnly
{
    //public BP_TextOnly() { }
    //public BP_TextOnly(string headLine, string text, DateTime? creationTime = null) : base(headLine, creationTime)
    //{
    //    Text = text;
    //}
    public Guid Id { get; set; }
    public string HeadLine { get; set; } = default!;
    public DateTime CreationTime { get; set; }
    public string Text { get; set; } = default!;
}
