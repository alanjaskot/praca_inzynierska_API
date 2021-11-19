using Microsoft.EntityFrameworkCore;
using NLog;
using PracaInzynierskaAPI.DataBase.Context;
using PracaInzynierskaAPI.Entities.Book;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.Book
{
    public class BookRepository: IBookRepository
    {
        private readonly IPInzDataBaseContext _context;
        private ILogger _logger;

        public BookRepository(IPInzDataBaseContext context)
        {
            _context = context;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ResponseModel<List<BookDbModel>> GetAll()
        {
            var result = default(List<BookDbModel>);
            try
            {
                result = _context.Books.Where(b => b.Approved == true
                && b.IsDeleted != true).ToList();
                if (result == null)
                    return new ResponseModel<List<BookDbModel>>
                    {
                        Success = true,
                        Message = "Baza danych nie posiada danych rekordów"
                    };
                if (result != null)
                    return new ResponseModel<List<BookDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookRepo.GetAll");
                throw;
            }
            return new ResponseModel<List<BookDbModel>>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<List<BookDbModel>> GetToApprove()
        {
            var result = default(List<BookDbModel>);
            try
            {
                result = _context.Books.Where(b => b.Approved == false
                && b.IsDeleted == false).ToList();
                if (result == null)
                    return new ResponseModel<List<BookDbModel>>
                    {
                        Success = true,
                        Message = "Baza danych nie posiada danych rekordów"
                    };
                if (result != null)
                    return new ResponseModel<List<BookDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookRepo.GetToApprove");
                throw;
            }
            return new ResponseModel<List<BookDbModel>>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<List<BookDbModel>> GetByList(List<Guid> list)
        {
            var result = default(List<BookDbModel>);
            try
            {
                foreach (var item in list)
                {
                    result.Add(GetById(item).Object);
                }
                if (result.Count == list.Count)
                    return new ResponseModel<List<BookDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
                if (result.Count != list.Count)
                    return new ResponseModel<List<BookDbModel>>
                    {
                        Success = false,
                        Message = "nie udało się pobrać wszystkich danych",
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookRepo.GetByList");
                throw;
            }
            return new ResponseModel<List<BookDbModel>>
            {
                Success = false,
                Message = "Pobieranie nie powiodło się"
            };
        }

        public ResponseModel<List<BookDbModel>> FindByName(List<string> name)
        {
            var result = default(List<BookDbModel>);
            var temp = default(List<BookDbModel>);
            try
            {
                foreach (var item in name)
                {
                    temp = _context.Books.Where(b => (b.Title.Contains(item)
                    || b.Series.Contains(item) || b.Subtitle.Contains(item))
                    && b.Approved == true && b.IsDeleted != true).ToList();
                    result.AddRange(temp);
                }
                if(result == null)
                    return new ResponseModel<List<BookDbModel>>
                    {
                        Success = true,
                        Message = "Baza danych nie posiada żądanych rekordów"
                    };
                if (result != null)
                    return new ResponseModel<List<BookDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };

            }
            catch (Exception err)
            {
                _logger.Error(err, "BookRepo.FindByName");
            }
            return new ResponseModel<List<BookDbModel>>
            {
                Success = false,
                Message = "Pobieranie nie powiodło się"
            };
        }

        public ResponseModel<List<BookDbModel>> GetByCategory(Guid id)
        {
            var result = default(List<BookDbModel>);
            try
            {
                result = _context.Books.Where(b => b.CategoryId == id
                && b.Approved == true && b.IsDeleted != true).ToList();
                if (result == null)
                    return new ResponseModel<List<BookDbModel>>
                    {
                        Success = true,
                        Message = "Baza danych nie posiada żądanych rekordów"
                    };
                if (result != null)
                    return new ResponseModel<List<BookDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookRepo.GetByCategory");
                throw;
            }

            return new ResponseModel<List<BookDbModel>>
            {
                Success = false,
                Message = "Pobieranie nie powiodło się"
            };
        }

        public ResponseModel<List<BookDbModel>> GetByPublisher(Guid id)
        {
            var result = default(List<BookDbModel>);
            try
            {
                result = _context.Books.Where(b => b.PublisherId == id
                && b.Approved == true && b.IsDeleted != true).ToList();
                if (result == null)
                    return new ResponseModel<List<BookDbModel>>
                    {
                        Success = true,
                        Message = "Baza danych nie posiada żądanych rekordów"
                    };
                if (result != null)
                    return new ResponseModel<List<BookDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookRepo.GetByPublisher");
                throw;
            }
            return new ResponseModel<List<BookDbModel>>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<BookDbModel> GetById(Guid id)
        {
            var result = default(BookDbModel);
            try
            {
                result = _context.Books.Where(b => b.Id == id
                && b.Approved == true && b.IsDeleted != true).FirstOrDefault();
                if (result == null)
                    return new ResponseModel<BookDbModel>
                    {
                        Success = false,
                        Message = $"Nie ma książki o podanym Id {id}"
                    };
                if (result != null)
                    return new ResponseModel<BookDbModel>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookRepo.GetById");
                throw;
            }
            return new ResponseModel<BookDbModel>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<List<BookDbModel>> GetHighlighted()
        {
            var result = default(List<BookDbModel>);
            try
            {
                result = _context.Books.Where(b => b.Approved == true
                && b.IsDeleted != true).OrderByDescending(b => b.LikesPercentage)
                .Take(30).ToList();

                var tempList = (from b in result orderby b.LikesPercentage select b).ToList();
                result = Shuffle(tempList);

                if (result == null)
                    return new ResponseModel<List<BookDbModel>>
                    {
                        Success = true,
                        Message = "Baza danych nie posiada żądanych rekordów"
                    };
                if (result != null)
                    return new ResponseModel<List<BookDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookRepo.GetHighlighted");
                throw;
            }
            
            return new ResponseModel<List<BookDbModel>>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<List<BookDbModel>> GetHighlightedByMonth()
        {
            DateTime lastMonth = DateTime.Now;
            lastMonth = lastMonth.AddMonths(-1);
            var result = default(List<BookDbModel>);
            try
            {
                result = _context.Books
                    .Where(b => b.CreatedAt >= lastMonth
                    && b.Approved == true && b.IsDeleted != true)
                    .OrderByDescending(b => b.LikesPercentage)
                    .Take(30).ToList();

                result = Shuffle(result);
                if (result == null)
                    return new ResponseModel<List<BookDbModel>>
                    {
                        Success = true,
                        Message = "Baza danych nie posiada żądanych rekordów"
                    };
                if (result != null)
                    return new ResponseModel<List<BookDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookRepo.GetHighlightedByMonth");
                throw;
            }

            return new ResponseModel<List<BookDbModel>>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<List<BookDbModel>> GetHighlightedByYear()
        {
            DateTime lastYear = DateTime.Now;
            lastYear = lastYear.AddYears(-1);
            var result = default(List<BookDbModel>);
            try
            {
                result = _context.Books.Where(b => b.CreatedAt >= lastYear
                    && b.Approved == true)
                    .OrderByDescending(b => b.LikesPercentage)
                    .Take(30).ToList();

                var tempList = (from b in result orderby b.LikesPercentage select b).ToList();
                result = Shuffle(tempList);

                if (result == null)
                    return new ResponseModel<List<BookDbModel>>
                    {
                        Success = true,
                        Message = "Baza danych nie posiada żądanych rekordów"
                    };
                if (result != null)
                    return new ResponseModel<List<BookDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookRepo.GetHighlitedByYear");
                throw;
            }

            return new ResponseModel<List<BookDbModel>>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<Guid> Add(BookDbModel book)
        {
            if (book.Id == Guid.Empty)
                book.Id = Guid.NewGuid();
            
            try
            {
                if (book != null)
                {
                    var add = _context.Books.Add(book);
                    if (add.State == EntityState.Added)
                        return new ResponseModel<Guid>
                        {
                            Success = true,
                            Message = null,
                            Object = book.Id
                        };                        
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookRepo.Add");
                throw;
            }
            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Zapis w bazie danych zakończony niepowodzeniem"
            };
        }

        public ResponseModel<decimal> AddPlusOrMinus(Guid bookId, long plus)
        {
            if (bookId == Guid.Empty)
                return new ResponseModel<decimal>
                {
                    Success = false,
                    Message = "Identyfikator książki jest pusty"
                };

            if (plus != 1 || plus != -1)
                return new ResponseModel<decimal>
                {
                    Success = false,
                    Message = "Wprowadzono nieprawidłową wartość"
                };

            try
            {
                var book = _context.Books
                    .Where(b => b.Id == bookId)
                    .FirstOrDefault();

                if (book == null)
                    return new ResponseModel<decimal>
                    {
                        Success = false,
                        Message = "Książka o podanym identyfikatorze nie istnieje"
                    };

                if (plus == 1)
                    book.Likes += 1;

                if (plus == -1)
                    book.Dislikes += 1;

                var updated = _context.Books.Update(book);
                if (updated.State == EntityState.Modified)
                    return new ResponseModel<decimal>
                    {
                        Success = true,
                        Message = null,
                        Object = book.LikesPercentage
                    };

                return new ResponseModel<decimal>
                {
                    Success = false,
                    Message = "Zmiana oceny książki nie powiodła się"
                };
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookRepository.AddPlusOrMinus");
                throw;
            }
        }

        public ResponseModel<bool> Approve(List<BookDbModel> books)
        {
            var list = default(List<BookDbModel>);
            try
            {
                foreach(var book in books)
                {
                    if (book != null && book.Approved == false)
                    {
                        book.Approved = true;
                        list.Add(book);
                    }
                }
                if(list != null)
                {
                    _context.Books.UpdateRange(list);
                    return new ResponseModel<bool>
                    {
                        Success = true,
                        Message = null
                    };
                }                
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookRepo.Approve");
                throw;
            }
            return new ResponseModel<bool>
            {
                Success = false,
                Message = "Zatwierdzenie książek zakończone niepowodzeniem"
            };
        }

        public ResponseModel<Guid> Update(BookDbModel book)
        {
            try
            {
                if (book != null)
                {
                    var update = _context.Books.Update(book);
                    if (update.State == EntityState.Modified)
                        return new ResponseModel<Guid>
                        {
                            Success = true,
                            Message = null,
                            Object = book.Id
                        };
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookRepo.Update");
                throw;
            }
            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Modyfikacja książki zakończona niepowodzeniem"
            };
        }

        public ResponseModel<List<Guid>> SoftDelete(List<BookDbModel> books)
        {
            if (books == null)
                return new ResponseModel<List<Guid>>
                {
                    Success = false,
                    Message = "brak książek do usunięcia"
                };

            var list = default(List<BookDbModel>);
            var guids = default(List<Guid>);
            try
            {
                foreach(var book in books)
                {
                    if (book.IsDeleted == false)
                    {
                        book.IsDeleted = true;
                        book.DeletedAt = DateTime.Now;
                        list.Add(book);
                        guids.Add(book.Id);
                    }
                }

                if (list.Count == guids.Count)
                    return new ResponseModel<List<Guid>>
                    {
                        Success = true,
                        Message = null,
                        Object = guids
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookRepo.SoftDelete");
                throw;
            }
            return new ResponseModel<List<Guid>>
            {
                Success = false,
                Message = "Usuwanie zakończone niepowodzeniem"
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
                var temp = _context.Books
                    .Where(b => b.Id == id)
                    .FirstOrDefault();

                if (temp == null)
                    return new ResponseModel<Guid>
                    {
                        Success = false,
                        Message = "Podana książka nie istnieje w bazie danych"
                    };

                var delete = _context.Books.Remove(temp);
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
                _logger.Error(err, "BookRepo.Delete");
                throw;
            }
            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Usuwanie książki nie powiodło się"
            };
        }

        private static List<BookDbModel> Shuffle(List<BookDbModel> list)
        {
            list = list.OrderBy(x => Guid.NewGuid()).ToList();
            var result = default(List<BookDbModel>);
            for (int i = 0; i < 10; i++)
            {
                result.Add(list[i]);
            }
            return result;
        }
    }
}
