using flashcards.Models.Db;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.CQRS.Queries.Identity.Roles.GetClaims
{
    public class GetClaimsQuery : IRequest<List<ClaimDb>>
    {
    }
}
