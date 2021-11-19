using Microsoft.EntityFrameworkCore;
using NLog;
using PracaInzynierskaAPI.DataBase.Context;
using PracaInzynierskaAPI.Entities.Author;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.Author
{
    public class AuthorRepository: IAuthorRepository
    {
        private readonly IPInzDataBaseContext _context;
        private ILogger _logger;

        public AuthorRepository(IPInzDataBaseContext context)
        {
            _context = context;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ResponseModel<List<AuthorDbModel>> GetAll()
        {
            var result = default(List<AuthorDbModel>);
            try
            {
                result = _context.Authors.Where(a => a.IsDeleted != true
                && a.IsApproved == true).ToList();
                if (result == null)
                    return new ResponseModel<List<AuthorDbModel>>
                    {
                        Success = true,
                        Message = "Baza danych nie posiada danych rekordów"
                    };
                if (result != null)
                    return new ResponseModel<List<AuthorDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorRepo.GetAll");
                throw;
            }
            return new ResponseModel<List<AuthorDbModel>>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<List<AuthorDbModel>> GetToApprove()
        {
            var result = default(List<AuthorDbModel>);
            try
            {
                result = _context.Authors.Where(a => a.IsDeleted != true
                && a.IsApproved == false).ToList();
                if (result == null)
                    return new ResponseModel<List<AuthorDbModel>>
                    {
                        Success = true,
                        Message = "Brak autorów do zatwierdzenia"
                    };
                if (result != null)
                    return new ResponseModel<List<AuthorDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorRepo.GetToApprove");
                throw;
            }
            return new ResponseModel<List<AuthorDbModel>>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<List<AuthorDbModel>> FindByName(List<string> list)
        {
            var result = default(List<AuthorDbModel>);
            var temp = default(List<AuthorDbModel>);
            try
            {
                foreach (var name in list)
                {
                    temp = _context.Authors.Where(a => (a.Surname.Contains(name)
                    || a.Name.Contains(name) || a.SecondName.Contains(name))
                    && a.IsDeleted != true && a.IsApproved == true).ToList();
                    result.AddRange(temp);
                }
                if (result == null)
                    return new ResponseModel<List<AuthorDbModel>>
                    {
                        Success = true,
                        Message = "Brak autorów do zatwierdzenia"
                    };
                if (result != null)
                    return new ResponseModel<List<AuthorDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorRepo.FindByName");
            }
            return new ResponseModel<List<AuthorDbModel>>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<List<AuthorDbModel>> GetByIds(List<Guid> list)
        {
            var result = default(List<AuthorDbModel>);
            try
            {
                foreach (var item in list)
                {
                    result.Add(GetById(item).Object);
                }
                if (result == null)
                    return new ResponseModel<List<AuthorDbModel>>
                    {
                        Success = true,
                        Message = "Brak autorów do zatwierdzenia"
                    };
                if (result != null)
                    return new ResponseModel<List<AuthorDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorRepo.GetIds");
                throw;
            }
            return new ResponseModel<List<AuthorDbModel>>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<AuthorDbModel> GetById(Guid id)
        {
            var result = default(AuthorDbModel);
            try
            {
                result = _context.Authors.Where(a => a.Id == id
                && a.IsDeleted != true)
                    .FirstOrDefault();
                if (result == null)
                    return new ResponseModel<AuthorDbModel>
                    {
                        Success = true,
                        Message = "Brak autorów do zatwierdzenia"
                    };
                if (result != null)
                    return new ResponseModel<AuthorDbModel>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorRepo.GetById");
                throw;
            }
            return new ResponseModel<AuthorDbModel>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<Guid> Add(AuthorDbModel author)
        {
            if (author.Id == Guid.Empty)
                author.Id = Guid.NewGuid();
            try
            {
                if (author != null)
                {
                    author.IsBuildIn = true;
                    var add = _context.Authors.Add(author);
                    if (add.State == EntityState.Added)
                        return new ResponseModel<Guid>
                        {
                            Success = true,
                            Message = null,
                            Object = author.Id
                        };
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorRepo.Add");
                throw;
            }
            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Zapis nie powiódł się"
            };
        }

        public ResponseModel<bool> Approve(AuthorDbModel author)
        {
            try
            {
                if (author.IsApproved == false)
                {
                    author.IsApproved = true;
                    var approve = _context.Authors.Update(author);
                    if (approve.State == EntityState.Modified)
                        return new ResponseModel<bool>
                        {
                            Success = true,
                            Message = null
                        };
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorRepo.Approve");
                throw;
            }
            return new ResponseModel<bool>
            {
                Success = false,
                Message = "potwierdzenie nie powiodło się"
            };
        }

        public ResponseModel<Guid> Update(AuthorDbModel author)
        {
            try
            {
                if (author != null)
                {
                    var update = _context.Authors.Update(author);
                    if (update.State == EntityState.Modified)
                        return new ResponseModel<Guid>
                        {
                            Success = true,
                            Message = null,
                            Object = author.Id
                        };
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorRepo.Update");
                throw;
            }
            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Edycja danych zakończona niepowodzeniem"
            };
        }

        public ResponseModel<List<Guid>> SoftDelete(List<AuthorDbModel> authors)
        {
            var list = default(List<Guid>);
            try
            {
                foreach(var author in authors)
                {
                    if (author.IsDeleted == false)
                    {
                        author.IsDeleted = true;
                        author.DeletedAt = DateTime.Now;
                        var softDelete = _context.Authors.Update(author);
                        if (softDelete.State == EntityState.Modified)
                            list.Add(author.Id);
                    }
                }
                if (authors.Count == list.Count)
                    return new ResponseModel<List<Guid>>
                    {
                        Success = true,
                        Message = null,
                        Object = list
                    };
                if (authors.Count != list.Count)
                    return new ResponseModel<List<Guid>>
                    {
                        Success = false,
                        Message = "Nie wszyscy autorzy zostali usunięci. Proszę spróbować jeszcze raz",
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorRepo.Update");
                throw;
            }
            return new ResponseModel<List<Guid>>
            {
                Success = false,
                Message = "błąd przy usuwaniu danych"
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
                var author = _context.Authors.Where(a => a.Id == id)
                    .FirstOrDefault();
                if (author != null)
                {
                    var delete = _context.Authors.Remove(author);
                    if (delete.State == EntityState.Deleted)
                        return new ResponseModel<Guid>
                        {
                            Success = true,
                            Message = null,
                            Object = id,
                        };

                    return new ResponseModel<Guid>
                    {
                        Success = false,
                        Message = "Nie udało się usunąc autora o podanym Id"
                    };
                }
                else
                    return new ResponseModel<Guid>
                    {
                        Success = false,
                        Message = "Autor o podanym adresie nie istnieje"
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorRepo.Delete");
                throw;
            }
        }
    }

}
