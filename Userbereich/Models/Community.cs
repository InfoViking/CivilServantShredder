using System.ComponentModel.DataAnnotations;

namespace Userbereich.Models;

public class Community
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
}
