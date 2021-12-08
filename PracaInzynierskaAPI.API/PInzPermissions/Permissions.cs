using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.PInzPermissions
{
    public static class Permissions
    {
        public static class Author
        {
            //[Display(ResourceType = typeof(Tests), Name = "Zapis", GroupName = "Tests")]
            public const string Approve = nameof(Author) + "." + nameof(Approve);
            public const string Update = nameof(Author) + "." + nameof(Update);
            public const string SoftDelete = nameof(Author) + "." + nameof(SoftDelete);
            public const string Delete = nameof(Author) + "." + nameof(Delete);
        }

        public static class Book
        {
            public const string Approve = nameof(Book) + "." + nameof(Approve);
            public const string Update = nameof(Book) + "." + nameof(Update);
            public const string SoftDelete = nameof(Book) + "." + nameof(SoftDelete);
            public const string Delete = nameof(Book) + "." + nameof(Delete);
        }

        public static class Book_Author
        {
            public const string Delete = nameof(Book_Author) + "." + nameof(Delete);
        }

        public static class Book_User
        {
            public const string Delete = nameof(Book_User) + "." + nameof(Delete);
        }

        public static class Category
        {
            public const string Write = nameof(Category) + "." + nameof(Write);
            public const string Update = nameof(Category) + "." + nameof(Update);
            public const string SoftDelete = nameof(Category) + "." + nameof(SoftDelete);
            public const string Delete = nameof(Category) + "." + nameof(Delete);
        }

        public static class Comment
        {
            public const string Update = nameof(Comment) + "." + nameof(Update);
            public const string SoftDelete = nameof(Comment) + "." + nameof(SoftDelete);   
        }

        public static class ImageCover
        {
            public const string Update = nameof(ImageCover) + "." + nameof(Update);
            public const string Delete = nameof(ImageCover) + "." + nameof(Delete);
        }

        public static class Language
        {
            public const string Write = nameof(Language) + "." + nameof(Write);
            public const string Update = nameof(Language) + "." + nameof(Update);
            public const string SoftDelete = nameof(Language) + "." + nameof(SoftDelete);
        }

        public static class NLogs
        {
            public const string Read = nameof(NLogs) + "." + nameof(Read);
        }

        public static class Publisher
        {
            public const string Write = nameof(Language) + "." + nameof(Write);
            public const string Update = nameof(Language) + "." + nameof(Update);
            public const string SoftDelete = nameof(Language) + "." + nameof(SoftDelete);
        }

        public static class User
        {
            public const string Update = nameof(User) + "." + nameof(Update);
            public const string Delete = nameof(User) + "." + nameof(Delete);
        }

        public static class UserPermission
        {
            public const string Write = nameof(UserPermission) + "." + nameof(Write);
            public const string Update = nameof(UserPermission) + "." + nameof(Update);
            public const string Delete = nameof(UserPermission) + "." + nameof(Delete);
        }
    }
}
