using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flashcards.Models.Dtos
{
    public class RoleIdWithClaimsDto
    {
        public Guid RoleId { get; set; }
        public List<Guid> ClaimIds { get; set; }
    }
}
