using PracaInzynierskaAPI.Core.Abstraction;
using PracaInzynierskaAPI.Entities.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.Entities.ImageCover
{
    public class ImageCoverDbModel: BaseCreatedLastModifiedDeletedEntity
    {
        public string ImageTitle { get; set; }
        public byte[] ImageFile { get; set; }

        //foreign key
        [JsonIgnore]
        public BookDbModel Book { get; set; }
    }
}
