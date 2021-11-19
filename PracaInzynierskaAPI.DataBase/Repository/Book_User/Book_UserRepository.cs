using Microsoft.EntityFrameworkCore;
using NLog;
using PracaInzynierskaAPI.DataBase.Context;
using PracaInzynierskaAPI.Entities.Book_User;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.Book_User
{
    public class Book_UserRepository: IBook_UserRepository
    {
        private readonly IPInzDataBaseContext _context;
        private ILogger _logger;

        public Book_UserRepository(IPInzDataBaseContext context)
        {
            _context = context;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ResponseModel<List<Guid>> GetBooksByUser(Guid userId)
        {
            if (userId == Guid.Empty)
                return new ResponseModel<List<Guid>>
                {
                    Success = false,
                    Message = "Identyfikator jest pusty"
                };

            var result = default(List<Guid>);
            try
            {
                var temp = _context.User_Books
                    .Where(ub => ub.UserId == userId)
                    .ToList();
                if (temp == null)
                    return new ResponseModel<List<Guid>>
                    {
                        Success = false,
                        Message = "Baza danych nie posiada żądanych rekordów"
                    };

                foreach (var item in temp)
                    result.Add(item.BookId);
                if (temp.Count != result.Count)
                    return new ResponseModel<List<Guid>>
                    {
                        Success = false,
                        Message = "Nie wszystkie żądane dane zostały pobrane"
                    };
                if (temp.Count == result.Count)
                    return new ResponseModel<List<Guid>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch(Exception err)
            {
                _logger.Error(err, "Book_UserRepository.GetBooksByUser");
                throw;
            }
            return new ResponseModel<List<Guid>>
            {
                Success = false,
                Message = "Pobieranie żądanych danych nie powiodło się"
            };
        }

        public ResponseModel<Guid> Add(Book_UserDbModel book_user)
        {
            if (book_user == null)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Wprowadzony obiekt jest pusty"
                };

            if (book_user.Id == Guid.Empty)
                book_user.Id = Guid.NewGuid();

            try
            {
                if(book_user != null)
                {
                    var add = _context.User_Books.Add(book_user);
                    if (add.State == EntityState.Added)
                        return new ResponseModel<Guid>
                        {
                            Success = true,
                            Message = null,
                            Object = book_user.Id
                        };
                }
            }
            catch(Exception err)
            {
                _logger.Error(err, "Book_UserRepository.Add");
                throw;
            }
            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Zapis w bazie danych zakończony niepowodzeniem"
            };
        }

        public ResponseModel<Guid> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Podany identyfikator jest pusty"
                };

            try
            {
                var temp = _context.User_Books
                    .Where(ub => ub.Id == id)
                    .FirstOrDefault();

                if (temp == null)
                    return new ResponseModel<Guid>
                    {
                        Success = false,
                        Message = "Żądany obiekt nie istnieje w bazie danych"
                    };

                    var delete = _context.User_Books.Remove(temp);
                if (delete.State == EntityState.Deleted)
                    return new ResponseModel<Guid>
                    {
                        Success = true,
                        Message = null,
                        Object = id
                    };
                
            }
            catch (Exception err)
            {
                _logger.Error(err, "Book_UserRepository.Add");
                throw;
            }
            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Usuwanie nie powiodło się"
            };
        }  
    }
}
