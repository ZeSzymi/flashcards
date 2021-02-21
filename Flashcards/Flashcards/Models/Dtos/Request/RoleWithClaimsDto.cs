using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Models.Dtos.Request
{
    public class RoleWithClaimsDto
    {
        public string Name { get; set; }
        public List<Guid> ClaimIds { get; set; }
    }
}
