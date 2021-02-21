using flashcards.Models.Db;
using flashcards.Models.Dtos;
using flashcards.Models.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace flashcards.Repositories.Interfaces
{
    public interface IIdentityRepository
    {
        public string CreateToken(IList<Claim> claims);
        public Task<bool> AddClaim(string claimValue);
        public Task<List<ClaimDb>> GetClaims();
        public Task<bool> RemoveClaims(Guid id);
        public Task<List<RoleDto>> GetRoles();
        public Task<Role> GetRole(string roleName);
        public Task<bool> AddClaimsToRole(Guid roleId, List<Guid> claimIds);
        public Task<bool> AddRole(string roleName);

    }
}
