using flashcards.Contexts;
using flashcards.Models.Dtos;
using flashcards.Repositories.Interfaces;
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
        private readonly RepetitioContext _context;

        public UsersRepository(RepetitioContext context)
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
    }
}
