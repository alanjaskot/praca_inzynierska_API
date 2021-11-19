using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.DTO.User
{
    public class RegisterUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public long Likes { get; set; }

#nullable enable
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Sex { get; set; }
#nullable disable
        
    }
}
