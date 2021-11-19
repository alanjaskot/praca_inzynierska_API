using PracaInzynierskaAPI.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.DTO.Book_User
{
    public class Book_UserDTO: BaseCreatedLastModifiedDeletedEntity
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
