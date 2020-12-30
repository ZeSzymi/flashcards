using flashcards.Models.Db;
using flashcards.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace flashcards.Repositories.Interfaces
{
    public interface IIdentityRepository
    {
        public string CreateToken(IList<Claim> claims);
        public Task AddClaim(string claimValue);
        public Task<List<ClaimDb>> GetClaims();
        public Task RemoveClaims(Guid id);
        public Task<List<RoleDto>> GetRoles();
        public Task AddClaimsToRole(RoleWithClaimsDto roleWithClaims);
    }
}
