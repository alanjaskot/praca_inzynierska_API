using PracaInzynierskaAPI.Core.Abstraction;
using PracaInzynierskaAPI.Entities.Author;
using PracaInzynierskaAPI.Entities.Book;
using PracaInzynierskaAPI.Entities.Book_User;
using PracaInzynierskaAPI.Entities.Comment;
using PracaInzynierskaAPI.Entities.UserPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.Entities.User
{
    public class UserDbModel: BaseCreatedLastModifiedDeletedEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public long Likes { get; set; }
        public long NumberOfBooks { get; set; }
        public long NumberOfComments { get; set; }

#nullable enable
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Sex { get; set; }
        public bool? Banned { get; set; }
        public string? Level { get { return SetLevel(); } }
#nullable disable

        //foreignKey
        [JsonIgnore]
        public  List<UserPermissionDbModel> UserPermissions { get; set; }

        [JsonIgnore]
        public List<CommentDbModel> Comments { get; set; }

        [JsonIgnore]
        public List<BookDbModel> Books { get; set; }

        [JsonIgnore]
        public List<Book_UserDbModel> BooksList { get; set; }

        [JsonIgnore]
        public List<AuthorDbModel> Authors { get; set; }

        public string SetLevel()
        {

            long sum = (Likes * 4) + NumberOfComments + (NumberOfBooks * 3);

            if (sum < 20 && sum >= 10)
                return "czytelnik";
            else if (sum < 50 && sum >= 20)
                return "oczytany";
            else if (sum < 99 && sum >= 20)
                return "znawca";
            else if (sum < 200 && sum >= 99)
                return "zjadacz książek";
            else if (sum >= 200)
                return "mól książkowy";
            else
                return "nowy";
        }
    }
}
