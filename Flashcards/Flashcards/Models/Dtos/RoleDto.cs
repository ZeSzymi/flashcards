using flashcards.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace flashcards.Models.Dtos
{
    public class RoleDto : Role
    {
        public List<IdentityRoleClaim<Guid>> Claims { get; set; }
    }
}
