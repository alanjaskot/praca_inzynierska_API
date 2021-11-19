using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.Policies
{

    //definicje listy uprawnien
    public static class Polices
    {
        public const string Prefix = "Policy.";

        public static class Authors
        {
            public const string Add = Prefix + nameof(Authors) + "." + nameof(Add);
            public const string Update = Prefix + nameof(Authors) + "." + nameof(Update);
            public const string Delete = Prefix + nameof(Authors) + "." + nameof(Delete);
        }

        public static class Books
        {
            public const string Add = Prefix + nameof(Books) + "." + nameof(Add);
            public const string Update = Prefix + nameof(Books) + "." + nameof(Update);
            public const string Delete = Prefix + nameof(Books) + "." + nameof(Delete);
        }

        public static class Book_Authors
        {
            public const string Add = Prefix + nameof(Book_Authors) + "." + nameof(Add);
            public const string Update = Prefix + nameof(Book_Authors) + "." + nameof(Update);
            public const string Delete = Prefix + nameof(Book_Authors) + "." + nameof(Delete);
        }

        public static class Book_Users
        {
            public const string Add = Prefix + nameof(Book_Users) + "." + nameof(Add);
            public const string Update = Prefix + nameof(Book_Users) + "." + nameof(Update);
            public const string Delete = Prefix + nameof(Book_Users) + "." + nameof(Delete);
        }

        public static class Categories
        {
            public const string Add = Prefix + nameof(Categories) + "." + nameof(Add);
            public const string Update = Prefix + nameof(Categories) + "." + nameof(Update);
            public const string Delete = Prefix + nameof(Categories) + "." + nameof(Delete);
        }

        public static class Comments
        {
            public const string Add = Prefix + nameof(Comments) + "." + nameof(Add);
            public const string Update = Prefix + nameof(Comments) + "." + nameof(Update);
            public const string Delete = Prefix + nameof(Comments) + "." + nameof(Delete);
        }

        public static class ImageCovers
        {
            public const string Add = Prefix + nameof(ImageCovers) + "." + nameof(Add);
            public const string Update = Prefix + nameof(ImageCovers) + "." + nameof(Update);
            public const string Delete = Prefix + nameof(ImageCovers) + "." + nameof(Delete);
        }

        public static class Languages
        {
            public const string Add = Prefix + nameof(Languages) + "." + nameof(Add);
            public const string Update = Prefix + nameof(Languages) + "." + nameof(Update);
            public const string Delete = Prefix + nameof(Languages) + "." + nameof(Delete);
        }

        public static class Logs
        {
            public const string Read = Prefix + nameof(Logs) + "." + nameof(Read);
        }

        public static class Publishers
        {
            public const string Add = Prefix + nameof(Publishers) + "." + nameof(Add);
            public const string Update = Prefix + nameof(Publishers) + "." + nameof(Update);
            public const string Delete = Prefix + nameof(Publishers) + "." + nameof(Delete);
        }

        public static class Users
        {
            public const string Update = Prefix + nameof(Users) + "." + nameof(Update);
            public const string Delete = Prefix + nameof(Users) + "." + nameof(Delete);
            public const string ReadAll = Prefix + nameof(Users) + "." + nameof(ReadAll);
        }

        public static class UserPermissions
        {
            public const string Read = Prefix + nameof(UserPermissions) + "." + nameof(Read);
            public const string Add = Prefix + nameof(UserPermissions) + "." + nameof(Add);
            public const string Update = Prefix + nameof(UserPermissions) + "." + nameof(Update);
            public const string Delete = Prefix + nameof(UserPermissions) + "." + nameof(Delete);
        }
    }
}
