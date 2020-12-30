using flashcards.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repetitio.Models.Dtos.Response
{
    public class UserResponseDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public List<RoleDto> Roles { get; set; }
    }
}
