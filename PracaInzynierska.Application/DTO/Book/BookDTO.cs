using PracaInzynierskaAPI.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.DTO.Book
{
    public class BookDTO: BaseCreatedLastModifiedDeletedEntity
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public string Description { get; set; }
        public long Likes { get; set; }
        public long Dislikes { get; set; }
        public decimal LikesPercentage { get; }
        public bool Approved { get; set; }


#nullable enable
        public string? Subtitle { get; set; }
        public string? Series { get; set; }
        public int? Pages { get; set; }
#nullable disable

        //foreign key
        public Guid CreatedBy { get; set; }
        public Guid CategoryId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid PublisherId { get; set; }
        public Guid ImageCoverId { get; set; }
    }
}
