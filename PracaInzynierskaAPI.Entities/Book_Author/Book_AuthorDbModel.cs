using PracaInzynierskaAPI.Core.Abstraction;
using PracaInzynierskaAPI.Entities.Author;
using PracaInzynierskaAPI.Entities.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.Entities.Book_Author
{
    public class Book_AuthorDbModel: BaseCreatedLastModifiedDeletedEntity
    {
        public Guid AuthorId { get; set; }
        [JsonIgnore]
        public AuthorDbModel Author { get; set; }

        public Guid BookId { get; set; }
        [JsonIgnore]
        public BookDbModel Book { get; set; }
    }
}
