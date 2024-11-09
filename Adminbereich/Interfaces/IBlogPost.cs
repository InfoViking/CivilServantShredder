
namespace Adminbereich.Interfaces;

public interface IBlogPost
{
    Guid Id { get; set; }
    string HeadLine { get; set; }
    DateTime CreationTime { get; set; }
}
