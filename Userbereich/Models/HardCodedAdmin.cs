using System.ComponentModel.DataAnnotations;


namespace Userbereich.Models
{
    static class HardCodedAdmin
    {
        static Guid Id = Guid.NewGuid();
        static string FirstName = "Detlef";
        static string LastName = "Mueller";
        static string Street = "Hauptweg.24";
        static string PostalCode = "67890 ";
        static string Locality = "Hauptdorf";
        static Guid CommunityId = Guid.NewGuid();
        static Role UserRole = Role.Admin;

        [EmailAddress]
        static string Email = "detlef.müller@example.de";
    }
}
