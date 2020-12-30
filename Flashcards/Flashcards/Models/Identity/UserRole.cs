using Microsoft.AspNetCore.Identity;

namespace flashcards.Models.Identity
{
    public class UserRole : IdentityUserRole<string>
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
