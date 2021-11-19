using PracaInzynierskaAPI.DataBase.Context;
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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IPInzDataBaseContext _context;

        private IAuthorRepository _authorRepo;
        private IBookRepository _bookRepo;
        private IBook_AuthorRepository _book_authorRepo;
        private IBook_UserRepository _book_userRepo;
        private ICommentRepository _commentRepo;
        private ICategoryRepository _categoryRepo;
        private IImageCoverRepository _imageCoverRepo;
        private ILanguageRepository _languageRepo;
        private INLogRepository _nlogRepo;
        private IPublisherRepository _publisherRepo;
        private IUserRepository _userRepo;
        private IUserPermissionRepository _userPermissionRepo;

        public UnitOfWork(IPInzDataBaseContext context,
            IAuthorRepository authorRepo,
            IBookRepository bookRepo,
            IBook_AuthorRepository book_authorRepo,
            IBook_UserRepository book_userRepo,
            ICategoryRepository categoryRepo,
            ICommentRepository commentRepo,
            IImageCoverRepository imageCoverRepo,
            ILanguageRepository languageRepo,
            INLogRepository nLogRepo,
            IPublisherRepository publisherRepo,
            IUserRepository userRepo,
            IUserPermissionRepository userPermissionRepo)
        {
            _context = context;
            _authorRepo = authorRepo;
            _bookRepo = bookRepo;
            _book_authorRepo = book_authorRepo;
            _book_userRepo = book_userRepo;
            _categoryRepo = categoryRepo;
            _commentRepo = commentRepo;
            _imageCoverRepo = imageCoverRepo;
            _languageRepo = languageRepo;
            _nlogRepo = nLogRepo;
            _publisherRepo = publisherRepo;
            _userRepo = userRepo;
            _userPermissionRepo = userPermissionRepo;
        }

        public IAuthorRepository GetAuthorRepository
        {
            get
            {
                if (_authorRepo == null)
                    _authorRepo = new AuthorRepository(_context);
                return _authorRepo;
            }
        }

        public IBookRepository GetBookRepository
        {
            get
            {
                if (_bookRepo == null)
                    _bookRepo = new BookRepository(_context);
                return _bookRepo;
            }
        }

        public IBook_AuthorRepository GetBook_AuthorRepository
        {
            get
            {
                if (_book_authorRepo == null)
                    _book_authorRepo = new Book_AuthorRepository(_context);
                return _book_authorRepo;
            }
        }

        public IBook_UserRepository GetBook_UserRepository
        {
            get
            {
                if (_book_userRepo == null)
                    _book_userRepo = new Book_UserRepository(_context);
                return _book_userRepo;
            }
        }

        public ICategoryRepository GetCategoryRepository
        {
            get
            {
                if (_categoryRepo == null)
                    _categoryRepo = new CategoryRepository(_context);
                return _categoryRepo;
            }
        }
        public ICommentRepository GetCommentRepository
        {
            get
            {
                if (_commentRepo == null)
                    _commentRepo = new CommentRepository(_context);
                return _commentRepo;
            }
        }

        public IImageCoverRepository GetImageCoverRepository
        {
            get
            {
                if (_imageCoverRepo == null)
                    _imageCoverRepo = new ImageCoverRepository(_context);
                return _imageCoverRepo;
            }
        }

        public ILanguageRepository GetLanguageRepository
        {
            get
            {
                if (_languageRepo == null)
                    _languageRepo = new LanguageRepository(_context);
                return _languageRepo;
            }
        }

        public INLogRepository GetNLogRepository
        {
            get
            {
                if (_nlogRepo == null)
                    _nlogRepo = new NLogRepository(_context);
                return _nlogRepo;
            }
        }

        public IPublisherRepository GetPublisherRepository
        {
            get
            {
                if (_publisherRepo == null)
                    _publisherRepo = new PublisherRepository(_context);
                return _publisherRepo;
            }
        }

        public IUserRepository GetUserRepository
        {
            get
            {
                if (_userRepo == null)
                    _userRepo = new UserRepository(_context);
                return _userRepo;
            }
        }

        public IUserPermissionRepository GetUserPermissionRepository
        {
            get
            {
                if (_userPermissionRepo == null)
                    _userPermissionRepo = new UserPermissionRepository(_context);
                return _userPermissionRepo;
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            _context.BeginTransaction();
        }

        public void RollBackTransaction()
        {
            _context.RollBackTransaction();
        }

        public void CommitTransaction()
        {
            _context.CommitTransaction();
        }
    }
}