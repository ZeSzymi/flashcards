using flashcards.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace flashcards.Models.Dtos
{
    public class RoleDto : Role
    {
        public List<IdentityRoleClaim<string>> Claims { get; set; }
    }
}
