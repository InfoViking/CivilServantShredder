using System.ComponentModel.DataAnnotations;


namespace Userbereich.Models
{
    static class HardCodedUser
    {
        static Guid Id = Guid.NewGuid();
        static string FirstName = "Herbert";
        static string LastName = "Schmidt";
        static string Street = "Hauptstrasse.12";
        static string PostalCode = "12345";
        static string Locality = "Hauptstadt";
        static Guid CommunityId = Guid.NewGuid();
        static Role UserRole = Role.User;

        [EmailAddress]
        static string Email = "herbert.schmidt@example.de";
    }
}
