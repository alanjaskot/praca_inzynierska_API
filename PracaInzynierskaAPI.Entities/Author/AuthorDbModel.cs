using PracaInzynierskaAPI.Core.Abstraction;
using PracaInzynierskaAPI.Entities.Book_Author;
using PracaInzynierskaAPI.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.Entities.Author
{
    public class AuthorDbModel: BaseCreatedLastModifiedDeletedEntity
    {
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsApproved { get; set; }
#nullable enable
        public string? Name { get; set; }
        public string? SecondName { get; set; }
        public DateTime? DeathDate { get; set; }
        public string? Biography { get; set; }
#nullable disable

        //foreign key
        public Guid AddedBy { get; set; }
        [JsonIgnore]
        public UserDbModel User { get; set; }

        [JsonIgnore]
        public List<Book_AuthorDbModel> Book_Author { get; set; }
    }
}
