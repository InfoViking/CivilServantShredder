using Adminbereich.Interfaces;

namespace Adminbereich.Models;

public record BP_TextAndPicture : IBlogPost
{
    public BP_TextAndPicture()
    { }

    public BP_TextAndPicture(string headLine, string text, string pictureBase64,  DateTime? creationTime = null)
    {
        PictureBase64 = pictureBase64;
        Text = text;
        Id = Guid.NewGuid();
        HeadLine = headLine;

        if (creationTime == null)
            CreationTime = DateTime.Now;
        else
            CreationTime = creationTime.Value;
    }
    public Guid Id { get; set; }
    public string HeadLine { get; set; } = default!;
    public DateTime CreationTime { get; set; }
    public string? Text { get; set; }
    public string? PictureBase64 { get; set; }
}
