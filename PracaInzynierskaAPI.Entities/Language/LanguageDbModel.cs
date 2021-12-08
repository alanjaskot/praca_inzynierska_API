using PracaInzynierskaAPI.Core.Abstraction;
using PracaInzynierskaAPI.Entities.Book;
using PracaInzynierskaAPI.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.Entities.Language
{
    public class LanguageDbModel : BaseCreatedLastModifiedDeletedEntity
    {
        public string Language { get; set; }

        //foreign key
        [JsonIgnore]
        public List<BookDbModel> Books { get; set; }

        public Guid AddedBy { get; set; }
        [JsonIgnore]
        public UserDbModel User {get; set; }
    }
}
