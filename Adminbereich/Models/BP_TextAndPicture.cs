namespace Adminbereich.Models;

public record BP_TextAndPicture
{
    //public BP_TextAndPicture()
    //{

    //}
    //public BP_TextAndPicture(string headLine, string text, string pictureBase64,  DateTime? creationTime = null) : base(headLine, text, creationTime)
    //{
    //    PictureBase64 = pictureBase64;
    //}
    public Guid Id { get; set; }
    public string HeadLine { get; set; } = default!;
    public DateTime CreationTime { get; set; }
    public string? Text { get; set; }
    public string? PictureBase64 { get; set; }
}
