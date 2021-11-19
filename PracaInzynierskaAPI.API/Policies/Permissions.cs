using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.Policies
{
    public static class Permissions
    {
        public static class Authors
        {
            public const string Add = nameof(Authors) + "." + nameof(Add);
            public const string Update = nameof(Authors) + "." + nameof(Update);
            public const string Delete = nameof(Authors) + "." + nameof(Delete);
        }

        public static class Books
        {
            public const string Add = nameof(Books) + "." + nameof(Add);
            public const string Update = nameof(Books) + "." + nameof(Update);
            public const string Delete = nameof(Books) + "." + nameof(Delete);
        }

        public static class Book_Authors
        {
            public const string Add = nameof(Book_Authors) + "." + nameof(Add);
            public const string Update = nameof(Book_Authors) + "." + nameof(Update);
            public const string Delete = nameof(Book_Authors) + "." + nameof(Delete);
        }

        public static class Book_Users
        {
            public const string Add = nameof(Book_Users) + "." + nameof(Add);
            public const string Update = nameof(Book_Users) + "." + nameof(Update);
            public const string Delete = nameof(Book_Users) + "." + nameof(Delete);
        }

        public static class Categories
        {
            public const string Add = nameof(Categories) + "." + nameof(Add);
            public const string Update = nameof(Categories) + "." + nameof(Update);
            public const string Delete = nameof(Categories) + "." + nameof(Delete);
        }

        public static class Comments
        {
            public const string Add = nameof(Comments) + "." + nameof(Add);
            public const string Update = nameof(Comments) + "." + nameof(Update);
            public const string Delete = nameof(Comments) + "." + nameof(Delete);
        }

        public static class ImageCovers
        {
            public const string Add = nameof(ImageCovers) + "." + nameof(Add);
            public const string Update = nameof(ImageCovers) + "." + nameof(Update);
            public const string Delete = nameof(ImageCovers) + "." + nameof(Delete);
        }

        public static class Languages
        {
            public const string Add = nameof(Languages) + "." + nameof(Add);
            public const string Update = nameof(Languages) + "." + nameof(Update);
            public const string Delete = nameof(Languages) + "." + nameof(Delete);
        }

        public static class Logs
        {
            public const string Read = nameof(Logs) + "." + nameof(Read);
        }

        public static class Publishers
        {
            public const string Add = nameof(Publishers) + "." + nameof(Add);
            public const string Update = nameof(Publishers) + "." + nameof(Update);
            public const string Delete = nameof(Publishers) + "." + nameof(Delete);
        }

        public static class Users
        {          
            public const string Update = nameof(Users) + "." + nameof(Update);
            public const string Delete = nameof(Users) + "." + nameof(Delete);
            public const string ReadAll = nameof(Users) + "." + nameof(ReadAll);
        }

        public static class UserPermissions
        {
            public const string Read = nameof(UserPermissions) + "." + nameof(Read);
            public const string Update = nameof(UserPermissions) + "." + nameof(Update);
            public const string Delete = nameof(UserPermissions) + "." + nameof(Delete);
            public const string Add = nameof(UserPermissions) + "." + nameof(Add);
        }
    }
}
