using PracaInzynierskaAPI.Core.Abstraction;
using PracaInzynierskaAPI.Entities.Book;
using PracaInzynierskaAPI.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.Entities.Category
{
    public class CategoryDbModel : BaseCreatedLastModifiedDeletedEntity
    {
        public string Category { get; set; }

        //foreign key
        public Guid UserId { get; set; }
        [JsonIgnore]
        public UserDbModel User { get; set; }

        [JsonIgnore]
        public List<BookDbModel> Books { get; set; }
    }
}
