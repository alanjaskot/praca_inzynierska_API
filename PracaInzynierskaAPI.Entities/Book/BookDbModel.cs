using PracaInzynierskaAPI.Core.Abstraction;
using PracaInzynierskaAPI.Entities.Author;
using PracaInzynierskaAPI.Entities.Book_Author;
using PracaInzynierskaAPI.Entities.Book_User;
using PracaInzynierskaAPI.Entities.Category;
using PracaInzynierskaAPI.Entities.Comment;
using PracaInzynierskaAPI.Entities.ImageCover;
using PracaInzynierskaAPI.Entities.Language;
using PracaInzynierskaAPI.Entities.Publisher;
using PracaInzynierskaAPI.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.Entities.Book
{
    public class BookDbModel: BaseCreatedLastModifiedDeletedEntity
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public string Description { get; set; }
        public long Likes { get; set; }
        public long Dislikes { get; set; }
        public decimal LikesPercentage { get { return SetPercentageLikes(); } }
        public bool Approved { get; set; }

#nullable enable
        public string? Subtitle { get; set; }
        public string? Series { get; set; }
        public int? Pages { get; set; }
#nullable disable

        //foreign key

        public Guid CreatedBy { get; set; }
        [JsonIgnore]
        public UserDbModel AddedBy { get; set; }

        [JsonIgnore]
        public List<Book_AuthorDbModel> Book_Author { get; set; }

        public Guid CategoryId { get; set; }
        [JsonIgnore]
        public CategoryDbModel Category { get; set; }

        public Guid LanguageId { get; set; }
        [JsonIgnore]
        public LanguageDbModel Language { get; set; }

        public Guid PublisherId { get; set; }
        [JsonIgnore]
        public PublisherDbModel Publisher { get; set; }

        [JsonIgnore]
        public List<CommentDbModel> Comments { get; set; }

        [JsonIgnore]
        public List<Book_UserDbModel> BookList { get; set; }

        public Guid ImageCoverId { get; set; }
        public ImageCoverDbModel ImageCover { get; set; }


        private decimal SetPercentageLikes()
        {
            long sum = Likes + Dislikes;
            return ((Likes * 100) / sum);
        }
    }
}
