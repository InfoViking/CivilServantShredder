using System.ComponentModel.DataAnnotations;

namespace Userbereich.Models;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public string Locality { get; set; }
    public Guid CommunityId { get; set; }

    [EmailAddress]
    public string Email { get; set; }
}
