using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flashcards.Models.Identity
{
    public class User : IdentityUser<Guid>
    {
        public User(string userName) : base(userName)
        {
        }

        public string DisplayName { get; set; }
        public List<UserRole> UsersRoles { get; set; }
    }
}
