using Flashcards.Models.Dtos.Request;
using repetitio.Models.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flashcards.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        public Task<List<UserResponseDto>> GetUsers();
        public Task UpdateUserRoles(UserWithRolesDto userWithRoles)
    }
}
