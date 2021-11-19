using Microsoft.EntityFrameworkCore;
using NLog;
using PracaInzynierskaAPI.DataBase.Context;
using PracaInzynierskaAPI.Entities.Publisher;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.Publisher
{
    public class PublisherRepository: IPublisherRepository
    {
        private readonly IPInzDataBaseContext _context;
        private ILogger _logger;

        public PublisherRepository(IPInzDataBaseContext context)
        {
            _context = context;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ResponseModel<List<PublisherDbModel>> GetAll()
        {
            var result = default(List<PublisherDbModel>);
            try
            {
                result = _context.Publishers
                    .Where(p => p.IsDeleted != true)
                    .ToList();

                if (result == null)
                    return new ResponseModel<List<PublisherDbModel>>
                    {
                        Success = true,
                        Message = "Brak żądanych danych w bazie danych"
                    };

                if (result != null)
                    return new ResponseModel<List<PublisherDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "PublisherRepo.GetAll");
                throw;
            }
            return new ResponseModel<List<PublisherDbModel>>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<List<PublisherDbModel>> FindByName(List<string> list)
        {
            var result = default(List<PublisherDbModel>);
            var temp = default(List<PublisherDbModel>);
            try
            {
                foreach (var name in list)
                {
                    temp = _context.Publishers
                        .Where(p => p.PublisherName.Contains(name)
                        && p.IsDeleted != true)
                        .ToList();
                    result.AddRange(temp);
                }
                if (result == null)
                    return new ResponseModel<List<PublisherDbModel>>
                    {
                        Success = true,
                        Message = "Brak żądanych danych w bazie danych"
                    };

                if (result != null)
                    return new ResponseModel<List<PublisherDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };

            }
            catch (Exception err)
            {
                _logger.Error(err, "PublisherRepo.GetAll");
                throw;
            }
            return new ResponseModel<List<PublisherDbModel>>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<PublisherDbModel> GetById(Guid id)
        {
            var result = default(PublisherDbModel);
            try
            {
                result = _context.Publishers
                    .Where(p => p.Id == id
                    && p.IsDeleted != true)
                    .FirstOrDefault();

                if (result == null)
                    return new ResponseModel<PublisherDbModel>
                    {
                        Success = true,
                        Message = "Brak żądanych danych w bazie danych"
                    };

                if (result != null)
                    return new ResponseModel<PublisherDbModel>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "PublisherRepo.GetById");
                throw;
            }
            return new ResponseModel<PublisherDbModel>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<Guid> Add(PublisherDbModel publisher)
        {
            if (publisher == null)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Wprowadzony wydawca jest pusty"
                };

            if (publisher.Id == Guid.Empty)
                publisher.Id = Guid.NewGuid();

            try
            {
                if (publisher != null)
                {
                    publisher.IsBuildIn = true;
                    publisher.CreatedAt = DateTime.Now;
                    var added = _context.Publishers.Add(publisher);
                    if (added.State == EntityState.Added)
                        return new ResponseModel<Guid>
                        {
                            Success = true,
                            Message = null,
                            Object = publisher.Id
                        };
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "PublisherRepo.Add");
                throw;
            }
            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Zapis do bazy danych nie powiódł się"
            };
        }

        public ResponseModel<Guid> Update(PublisherDbModel publisher)
        {
            if (publisher == null)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Wprowadzony obiekt jest pusty"
                };

            if (publisher.Id == Guid.Empty)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Wprowadzony identyfikator jest pusty"
                };

            try
            {
                if (publisher != null)
                {
                    publisher.IsModified = true;
                    publisher.LastModifiedAt = DateTime.Now;
                    var updated = _context.Publishers.Update(publisher);
                    if (updated.State == EntityState.Modified)
                        return new ResponseModel<Guid>
                        {
                            Success = true,
                            Message = null,
                            Object = publisher.Id
                        };
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "PublisherRepo.Update");
                throw;
            }
            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Modyfikacja wydawcy nie powiodła się"
            };
        }

        public ResponseModel<Guid> SoftDelete(PublisherDbModel publisher)
        {
            if (publisher == null)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Wprowadzony obiekt jest pusty"
                };

            if (publisher.Id == Guid.Empty)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Wprowadzony identyfikator jest pusty"
                };
            try
            {
                if (publisher != null)
                {
                    publisher.IsDeleted = true;
                    publisher.DeletedAt = DateTime.Now;
                    publisher.PublisherName = $"Usunięto {DateTime.Now.ToString()}";
                    var softDeleted = _context.Publishers.Update(publisher);
                    if(softDeleted.State == EntityState.Deleted)
                        return new ResponseModel<Guid>
                        {
                            Success = true,
                            Message = null,
                            Object = publisher.Id
                        };
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "PublisherRepo.Update");
                throw;
            }
            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Usunięcie wydawcy nie powiodło się"
            };
        }
    }
}
