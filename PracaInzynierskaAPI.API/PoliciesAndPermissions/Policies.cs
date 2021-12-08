using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.PoliciesAndPermissions
{
    public static class Policies
    {
        private const string Prefix = "Policy.";


        /// <summary>
        /// obsluga autorow
        /// </summary>
        public static class Author
        {
            /// <summary>
            /// zatwierdzanie
            /// </summary>
            public const string Approve = Prefix + nameof(Author) + "." + nameof(Approve);

            /// <summary>
            /// modyfikacja
            /// </summary>
            public const string Update = Prefix + nameof(Author) + "." + nameof(Update);

            /// <summary>
            /// miekkie usuniecie
            /// </summary>
            public const string SoftDelete = Prefix + nameof(Author) + "." + nameof(SoftDelete);

            /// <summary>
            /// twarde usuniecie
            /// </summary>
            public const string Delete = Prefix + nameof(Author) + "." + nameof(Delete);
        }

        /// <summary>
        /// obsluga ksiazek
        /// </summary>
        public static class Book
        {
            /// <summary>
            /// zatwierdzanie
            /// </summary>
            public const string Approve = Prefix + nameof(Book) + "." + nameof(Approve);

            /// <summary>
            /// modyfikacja
            /// </summary>
            public const string Update = Prefix + nameof(Book) + "." + nameof(Update);

            /// <summary>
            /// miękkie usuwanie
            /// </summary>
            public const string SoftDelete = Prefix + nameof(Book) + "." + nameof(SoftDelete);

            /// <summary>
            /// twarde usuwanie
            /// </summary>
            public const string Delete = Prefix + nameof(Book) + "." + nameof(Delete);
        }


        /// <summary>
        /// obsluga polaczenia ksiazek i autorow
        /// </summary>
        public static class Book_Author
        {
            /// <summary>
            /// twarde usuniecie
            /// </summary>
            public const string Delete = Prefix + nameof(Book_Author) + "." + nameof(Delete);
        }

        /// <summary>
        /// obsluga listy ksiazek uzytkownikow
        /// </summary>
        public static class Book_User
        {
            /// <summary>
            /// twarde usuniecie
            /// </summary>
            public const string Delete = Prefix + nameof(Book_User) + "." + nameof(Delete);
        }

        /// <summary>
        /// obsluga kategorii
        /// </summary>
        public static class Category
        {
            /// <summary>
            /// zapis
            /// </summary>
            public const string Write = Prefix + nameof(Category) + "." + nameof(Write);

            /// <summary>
            /// modyfikacja
            /// </summary>
            public const string Update = Prefix + nameof(Category) + "." + nameof(Update);

            /// <summary>
            /// miękkie usuwanie
            /// </summary>
            public const string SoftDelete = Prefix + nameof(Category) + "." + nameof(SoftDelete);

            /// <summary>
            /// twarde usuwanie
            /// </summary>
            public const string Delete = Prefix + nameof(Category) + "." + nameof(Delete);
        }

        /// <summary>
        /// obsluga komentarzy
        /// </summary>
        public static class Comment
        {
            /// <summary>
            /// modyfikacja
            /// </summary>
            public const string Update = Prefix + nameof(Comment) + "." + nameof(Update);

            /// <summary>
            /// miękkie usuwanie
            /// </summary>
            public const string SoftDelete = Prefix + nameof(Comment) + "." + nameof(SoftDelete);
        }

        /// <summary>
        /// obsluga okladek
        /// </summary>
        
        public static class ImageCover
        {


            /// <summary>
            /// modyfikacja
            /// </summary>
            public const string Update = Prefix + nameof(ImageCover) + "." + nameof(Update);

            /// <summary>
            /// twarde usuwanie
            /// </summary>
            public const string Delete = Prefix + nameof(ImageCover) + "." + nameof(Delete);
        }

        /// <summary>
        /// obsluga jezykow
        /// </summary>
        public static class Language
        {
            /// <summary>
            /// zapis
            /// </summary>
            public const string Write = Prefix + nameof(Language) + "." + nameof(Write);

            /// <summary>
            /// modyfikacja
            /// </summary>
            public const string Update = Prefix + nameof(Language) + "." + nameof(Update);

            /// <summary>
            /// miękkie usuwanie
            /// </summary>
            public const string SoftDelete = Prefix + nameof(Language) + "." + nameof(SoftDelete);
        }

        /// <summary>
        /// obsluga logów
        /// </summary>
        public static class NLogs
        {
            /// <summary>
            /// odczyt
            /// </summary>
            public const string Read = Prefix + nameof(NLogs) + "." + nameof(Read); 
        }

        /// <summary>
        /// obsluga wydawcow
        /// </summary>
        public static class Publisher
        {
            /// <summary>
            /// zapis
            /// </summary>
            public const string Write = Prefix + nameof(Publisher) + "." + nameof(Write);

            /// <summary>
            /// modyfikacja
            /// </summary>
            public const string Update = Prefix + nameof(Publisher) + "." + nameof(Update);

            /// <summary>
            /// miękkie usuwanie
            /// </summary>
            public const string SoftDelete = Prefix + nameof(Publisher) + "." + nameof(SoftDelete);
        }

        /// <summary>
        /// obsluga użytkowników
        /// </summary>
        public static class User
        {
            /// <summary>
            /// modyfikacja
            /// </summary>
            public const string Update = Prefix + nameof(User) + "." + nameof(Update);

            /// <summary>
            /// twarde usuwanie
            /// </summary>
            public const string Delete = Prefix + nameof(User) + "." + nameof(Delete);
        }

        /// <summary>
        /// obsluga uprawnien
        /// </summary>
        public static class UserPermission
        {
            /// <summary>
            /// zapis
            /// </summary>
            public const string Write = Prefix + nameof(UserPermission) + "." + nameof(Write);

            /// <summary>
            /// modyfikacja
            /// </summary>
            public const string Update = Prefix + nameof(UserPermission) + "." + nameof(Update);

            /// <summary>
            /// twarde usuwanie
            /// </summary>
            public const string Delete = Prefix + nameof(UserPermission) + "." + nameof(Delete);
        }
    }
}
