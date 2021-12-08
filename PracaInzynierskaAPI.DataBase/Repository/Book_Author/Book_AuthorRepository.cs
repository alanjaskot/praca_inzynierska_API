using Microsoft.EntityFrameworkCore;
using NLog;
using PracaInzynierskaAPI.DataBase.Context;
using PracaInzynierskaAPI.Entities.Book_Author;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.Book_Author
{
    public class Book_AuthorRepository: IBook_AuthorRepository
    {
        private readonly IPInzDataBaseContext _context;
        private ILogger _logger;

        public Book_AuthorRepository(IPInzDataBaseContext context)
        {
            _context = context;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ResponseModel<List<Guid>> GetAllAuthorsByBook(Guid id)
        {
            if (id == Guid.Empty)
                return new ResponseModel<List<Guid>>
                {
                    Success = false,
                    Message = "Podane Id nie może być puste"
                };

            var result = default(List<Guid>);
            try
            {
                var temp = _context.Book_Authors.Where(b_a => b_a.BookId == id).ToList();
                if (temp == null)
                    return new ResponseModel<List<Guid>>
                    {
                        Success = false,
                        Message = "Żaden autor nie jest przypisany do podanej książki"
                    };
                foreach (var item in temp)
                {
                    result.Add(item.AuthorId);
                }
                if (result != null)
                    return new ResponseModel<List<Guid>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "Book_Author.GetAllAuthorsByBook");
                throw;
            }
            return new ResponseModel<List<Guid>>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<List<Guid>> GetAllBooksByAuthor(Guid id)
        {
            if(id == Guid.Empty)
                return new ResponseModel<List<Guid>>
                {
                    Success = false,
                    Message = "Podane Id nie może być puste"
                };

            var result = default(List<Guid>);
            try
            {
                var temp = _context.Book_Authors.Where(b_a => b_a.BookId == id).ToList();
                if (temp == null)
                    return new ResponseModel<List<Guid>>
                    {
                        Success = false,
                        Message = "Żadna ksiązka nie jest przypisana do podanego autora"
                    };
                foreach (var item in temp)
                {
                    result.Add(item.AuthorId);
                }
                if (result != null)
                    return new ResponseModel<List<Guid>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "Book_Author.GetAllBooksByAuthor");
                throw;
            }
            return new ResponseModel<List<Guid>>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<List<Guid>> Add(List<Book_AuthorDbModel> book_authors)
        {
            if (book_authors == null)
                return new ResponseModel<List<Guid>>
                {
                    Success = false,
                    Message = "Brak rekordów do zapisania"
                };
            var result = default(List<Guid>);
            foreach(var b_a in book_authors)
            {
                result.Add(b_a.Id);
            }
            try
            {
                if (book_authors != null)
                {
                    _context.Book_Authors.AddRange(book_authors);
                    return new ResponseModel<List<Guid>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "Book_Author.Add");
                throw;
            }
            return new ResponseModel<List<Guid>>
            {
                Success = false,
                Message = "Zapisywanie danych nie powiodło się"
            };
        }

        public ResponseModel<bool> Delete(Guid bookId)
        {
            if (bookId == Guid.Empty)
                return new ResponseModel<bool>
                {
                    Success = false,
                    Message = "Podany identyfikator jest pusty"
                };
            try
            {
                var temp = _context.Book_Authors
                    .Where(ba => ba.BookId == bookId)
                    .ToList();
                if (temp == null)
                    return new ResponseModel<bool>
                    {
                        Success = false,
                        Message = "Podana encja pośrednia nie istnieje"
                    };
                if (temp != null)
                {
                    _context.Book_Authors.RemoveRange(temp);
                    return new ResponseModel<bool>
                    {
                            Success = true,
                            Message = null,
                    };
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "Book_Author.Delete");
                throw;
            }
            return new ResponseModel<bool>
            {
                Success = false,
                Message = "Błąd podczas usuwania"
            };
        }
    }
}
