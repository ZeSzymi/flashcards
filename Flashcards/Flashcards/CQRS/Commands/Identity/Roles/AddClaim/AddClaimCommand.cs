using flashcards.Models.Db;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Commands.Identity.Roles.AddClaim
{
    public class AddClaimCommand : IRequest<bool>
    {
        public string ClaimName { get; }

        public AddClaimCommand(string claimName)
        {
            ClaimName = claimName;
        }
    }
}
