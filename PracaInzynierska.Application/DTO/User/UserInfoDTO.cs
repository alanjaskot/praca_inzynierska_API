using PracaInzynierskaAPI.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.DTO.User
{
    public class UserInfoDTO: BaseCreatedLastModifiedDeletedEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public long Likes { get; set; }
        public long NumberOfBooks { get; set; }
        public long NumberOfComments { get; set; }

#nullable enable
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Sex { get; set; }
        public DateTime? Suspended { get; set; }
        public bool? Banned { get; set; }
        public string? Level { get; }
    }
}
