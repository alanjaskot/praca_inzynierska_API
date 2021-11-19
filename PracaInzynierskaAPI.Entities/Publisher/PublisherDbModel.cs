using PracaInzynierskaAPI.Core.Abstraction;
using PracaInzynierskaAPI.Entities.Book;
using PracaInzynierskaAPI.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.Entities.Publisher
{
    public class PublisherDbModel: BaseCreatedLastModifiedDeletedEntity
    { 
        public string PublisherName { get; set; }
#nullable enable
        public string? City { get; set; }
        public string? PostCode { get; set; }
        public string? Street { get; set; }
        public string? Building { get; set; }
        public string? Premises { get; set; }
#nullable disable

        //foreign key
        [JsonIgnore]
        public List<BookDbModel> Books { get; set; }

        public Guid AddedBy { get; set; }
        [JsonIgnore]
        public UserDbModel User { get; set; }
    }
}
