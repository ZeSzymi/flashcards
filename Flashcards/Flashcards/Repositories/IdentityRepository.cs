using flashcards.Contexts;
using flashcards.Models.Db;
using flashcards.Models.Dtos;
using flashcards.Models.Identity;
using flashcards.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace flashcards.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly FlashcardsContext _context;
        private readonly IConfiguration _configuration;

        public IdentityRepository(RoleManager<Role> roleManager, FlashcardsContext context, IConfiguration configuration)
        {
            _roleManager = roleManager;
            _context = context;
            _configuration = configuration;
        }

        public async Task<bool> AddClaim(string claimValue)
        {
            var claim = new ClaimDb { Id = Guid.NewGuid(), ClaimType = "Privilege", ClaimValue = claimValue };
            await _context.Claims.AddAsync(claim);
            return (await _context.SaveChangesAsync()) > 0;
        } 

        public async Task<List<ClaimDb>> GetClaims() => await _context.Claims.ToListAsync();

        public async Task<Role> GetRole(string roleName) => await _context.Roles.SingleOrDefaultAsync(role => role.Name == roleName);

        public async Task<bool> AddClaimsToRole(Guid roleId, List<Guid> claimIds)
        {
            var claims = await _context.Claims.Where(c => claimIds.Contains(c.Id)).ToListAsync();
            var claimsToAdd = claims.Select(c => new IdentityRoleClaim<Guid> { RoleId = roleId, ClaimType = c.ClaimType, ClaimValue = c.ClaimValue }).ToList();
            await _context.RoleClaims.AddRangeAsync(claimsToAdd);
            return (await _context.SaveChangesAsync()) > 0;
        }
        
        public async Task<bool> AddRole(string roleName)
        {
            var role = new Role
            {
                Name = roleName
            };
            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Code);
            }

            return result.Succeeded;
        }

        public async Task<bool> RemoveClaims(Guid id)
        {
            var claim = await _context.Claims.FirstOrDefaultAsync(c => c.Id == id);
            _context.Remove(claim);
            return (await _context.SaveChangesAsync()) > 0;
        }
        
        public async Task<List<RoleDto>> GetRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            var roleIds = roles.Select(r => r.Id).ToList();
            var claims = await _context.RoleClaims.Where(r => roleIds.Contains(r.RoleId)).ToListAsync();
            var roleDtos = new List<RoleDto>();
            foreach (var role in roles)
            {
                roleDtos.Add(new RoleDto { Name = role.Name, Id = role.Id, Claims = claims.Where(c => c.RoleId == role.Id).ToList() });
            }
            return roleDtos;
        }

        public string CreateToken(IList<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Security:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
