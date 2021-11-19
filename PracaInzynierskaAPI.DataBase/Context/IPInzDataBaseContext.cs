using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PracaInzynierskaAPI.Entities.Author;
using PracaInzynierskaAPI.Entities.Book;
using PracaInzynierskaAPI.Entities.Book_Author;
using PracaInzynierskaAPI.Entities.Book_User;
using PracaInzynierskaAPI.Entities.Category;
using PracaInzynierskaAPI.Entities.Comment;
using PracaInzynierskaAPI.Entities.ImageCover;
using PracaInzynierskaAPI.Entities.Language;
using PracaInzynierskaAPI.Entities.NLog;
using PracaInzynierskaAPI.Entities.Publisher;
using PracaInzynierskaAPI.Entities.User;
using PracaInzynierskaAPI.Entities.UserPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Context
{
    public interface IPInzDataBaseContext
    {
        public DbSet<AuthorDbModel> Authors { get; set; }
        public DbSet<BookDbModel> Books { get; set; }
        public DbSet<Book_AuthorDbModel> Book_Authors { get; set; }
        public DbSet<Book_UserDbModel> User_Books { get; set; }
        public DbSet<CategoryDbModel> Categories { get; set; }
        public DbSet<ImageCoverDbModel> ImageCovers { get; set; }
        public DbSet<LanguageDbModel> Languages { get; set; }
        public DbSet<PublisherDbModel> Publishers { get; set; }
        public DbSet<CommentDbModel> Comments { get; set; }
        public DbSet<UserDbModel> Users { get; set; }
        public DbSet<UserPermissionDbModel> UserPermissions { get; set; }
        public DbSet<NLogDbModel> NLogs { get; set; }

        public EntityEntry Remove(object entity);
        public int SaveChanges();
        public void BeginTransaction();
        public void CommitTransaction();
        public void RollBackTransaction();
    }
}
