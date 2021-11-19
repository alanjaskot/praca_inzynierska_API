using PracaInzynierskaAPI.DataBase.Repository.Author;
using PracaInzynierskaAPI.DataBase.Repository.Book;
using PracaInzynierskaAPI.DataBase.Repository.Book_Author;
using PracaInzynierskaAPI.DataBase.Repository.Book_User;
using PracaInzynierskaAPI.DataBase.Repository.Category;
using PracaInzynierskaAPI.DataBase.Repository.Comment;
using PracaInzynierskaAPI.DataBase.Repository.ImageCover;
using PracaInzynierskaAPI.DataBase.Repository.Language;
using PracaInzynierskaAPI.DataBase.Repository.NLog;
using PracaInzynierskaAPI.DataBase.Repository.Publisher;
using PracaInzynierskaAPI.DataBase.Repository.User;
using PracaInzynierskaAPI.DataBase.Repository.UserPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IAuthorRepository GetAuthorRepository { get; }
        public IBook_AuthorRepository GetBook_AuthorRepository { get; }
        public IBook_UserRepository GetBook_UserRepository { get; }
        public IBookRepository GetBookRepository { get; }
        public ICategoryRepository GetCategoryRepository { get; }
        public ICommentRepository GetCommentRepository { get; }
        public IImageCoverRepository GetImageCoverRepository { get; }
        public ILanguageRepository GetLanguageRepository { get; }
        public IPublisherRepository GetPublisherRepository { get; }
        public INLogRepository GetNLogRepository { get; }
        public IUserRepository GetUserRepository { get; }
        public IUserPermissionRepository GetUserPermissionRepository { get; }

        public int Save();
        public void BeginTransaction();
        public void CommitTransaction();
        public void RollBackTransaction();
    }
}
