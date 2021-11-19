using PracaInzynierskaAPI.Core.Abstraction;
using PracaInzynierskaAPI.Entities.Book;
using PracaInzynierskaAPI.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.Entities.Comment
{
    public class CommentDbModel: BaseCreatedLastModifiedDeletedEntity
    {
        public string Comment { get; set; }
        
        //foreign key
        public Guid AddedBy { get; set; }
        [JsonIgnore]
        public UserDbModel User { get; set; }

        public Guid? CommentId { get; set; }
        [JsonIgnore]
        public CommentDbModel ToComment { get; set; }

        public Guid BookId { get; set; }
        [JsonIgnore]
        public BookDbModel Book { get; set; }
    }
}
