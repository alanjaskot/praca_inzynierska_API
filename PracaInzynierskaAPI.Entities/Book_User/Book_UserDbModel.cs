using PracaInzynierskaAPI.Core.Abstraction;
using PracaInzynierskaAPI.Entities.Book;
using PracaInzynierskaAPI.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.Entities.Book_User
{
    public class Book_UserDbModel: BaseCreatedLastModifiedDeletedEntity
    {
        public Guid UserId { get; set; }
        [JsonIgnore]
        public UserDbModel User { get; set; }

        public Guid BookId { get; set; }
        [JsonIgnore]
        public BookDbModel Book { get; set; }
    }
}
