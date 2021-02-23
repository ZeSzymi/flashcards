using flashcards.Contexts;
using flashcards.Models.Dtos;
using flashcards.Models.Identity;
using flashcards.Repositories.Interfaces;
using Flashcards.Models.Dtos.Request;
using Microsoft.EntityFrameworkCore;
using repetitio.Models.Dtos;
using repetitio.Models.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flashcards.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly FlashcardsContext _context;

        public UsersRepository(FlashcardsContext context)
        {
            _context = context;
        }

        public Task<List<UserResponseDto>> GetUsers() => _context.Users.Select(u =>
        new UserResponseDto
        {
            Id = u.Id,
            Username = u.UserName,
            DisplayName = u.DisplayName,
            Email = u.Email,
            Roles = u.UsersRoles.Select(r => new RoleDto { Name = r.Role.Name }).ToList()
        }).ToListAsync();

        public async Task UpdateUserRoles(UserWithRolesDto userWithRoles)
        {
            var user = await _context.Users.Include(user => user.UsersRoles).FirstAsync(user => user.Id == userWithRoles.UserId);
            _context.UserRoles.RemoveRange(user.UsersRoles);
            var roles = userWithRoles.RoleIds.Select(roleId => { var userRole = new UserRole { UserId = user.Id, RoleId = roleId }; _context.Attach(userRole); return userRole; });
            _context.UserRoles.AddRange(roles);
            await _context.SaveChangesAsync();
        }
    }
}
