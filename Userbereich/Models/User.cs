using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

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
    public Role UserRole {  get; set; }

    [EmailAddress]
    public string Email { get; set; }
}
