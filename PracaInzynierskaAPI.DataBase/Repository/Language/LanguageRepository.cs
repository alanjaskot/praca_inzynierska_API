using Microsoft.EntityFrameworkCore;
using NLog;
using PracaInzynierskaAPI.DataBase.Context;
using PracaInzynierskaAPI.Entities.Language;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.Language
{
    public class LanguageRepository: ILanguageRepository
    {
        private readonly IPInzDataBaseContext _context;
        private ILogger _logger;

        public LanguageRepository(IPInzDataBaseContext context)
        {
            _context = context;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ResponseModel<List<LanguageDbModel>> GetAll()
        {
            var result = default(List<LanguageDbModel>);
            try
            {
                result = _context.Languages
                    .Where(l => l.IsDeleted != true)
                    .ToList();
                if (result == null)
                    return new ResponseModel<List<LanguageDbModel>>
                    {
                        Success = true,
                        Message = "Brak żądanych danych w bazie danych"
                    };

                if (result != null)
                    return new ResponseModel<List<LanguageDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "LanguageRepo.GetAll");
                throw;
            }
            return new ResponseModel<List<LanguageDbModel>>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<LanguageDbModel> GetById(Guid id)
        {
            if (id == Guid.Empty)
                return new ResponseModel<LanguageDbModel>
                {
                    Success = false,
                    Message = "Podany identyfikator jest pusty"
                };

            var result = default(LanguageDbModel);
            try
            {
                result = _context.Languages
                    .Where(l => l.Id == id
                    && l.IsDeleted != true)
                    .FirstOrDefault();

                if (result == null)
                    return new ResponseModel<LanguageDbModel>
                    {
                        Success = true,
                        Message = "Brak żądanych danych w bazie danych"
                    };

                if (result != null)
                    return new ResponseModel<LanguageDbModel>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "LanguageRepo.GetById");
            }
            return new ResponseModel<LanguageDbModel>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<List<LanguageDbModel>> GetByName(string name)
        {
            var result = default(List<LanguageDbModel>);
            try
            {
                result = _context.Languages
                    .Where(l => l.Language.Contains(name) && l.IsDeleted != true)
                    .ToList();

                if (result == null)
                    return new ResponseModel<List<LanguageDbModel>>
                    {
                        Success = true,
                        Message = "Brak żądanych danych w bazie danych"
                    };

                if (result != null)
                    return new ResponseModel<List<LanguageDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "LanguageRepo.GetById");
            }
            return new ResponseModel<List<LanguageDbModel>>
            {
                Success = false,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<Guid> Add(LanguageDbModel language)
        {
            if (language == null)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Wprowadzony obiekt jest pusty"
                };

            if (language.Id == Guid.Empty)
                language.Id = Guid.NewGuid();
                
            try
            {
                if (language != null)
                {
                    var added = _context.Languages.Add(language);
                    if (added.State == EntityState.Added)
                        return new ResponseModel<Guid>
                        {
                            Success = true,
                            Message = null,
                            Object = language.Id
                        };
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "LanguageRepo.Add");
            }
            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Zapis do bazy danych nie powiódł się"
            };
        }

        public ResponseModel<Guid> Update(LanguageDbModel language)
        {
            if (language.Id == Guid.Empty)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Wprowadzony identyfikator jest pusty"
                };

            try
            {
                if (language != null)
                {
                    language.IsModified = true;
                    language.LastModifiedAt = DateTime.Now;
                    var updated = _context.Languages.Update(language);
                    if (updated.State == EntityState.Modified)
                        return new ResponseModel<Guid>
                        {
                            Success = true,
                            Message = null,
                            Object = language.Id
                        };
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "LanguageRepo.Update");
                throw;
            }
            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Modyfikacja języka nie powiodła się"
            };
        }

        public ResponseModel<Guid> SoftDelete(LanguageDbModel language)
        {
            if (language.Id == Guid.Empty)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Wprowadzony identyfikator nie może być pusty"
                };

            try
            {
                if (language != null)
                {
                    language.Language = $"Usunięto { DateTime.Now.ToString()}";
                    language.IsDeleted = true;
                    language.DeletedAt = DateTime.Now;
                    var softDeleted = _context.Languages.Update(language);
                    if (softDeleted.State == EntityState.Modified)
                        return new ResponseModel<Guid>
                        {
                            Success = true,
                            Message = null,
                            Object = language.Id
                        };
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "LanguageRepo.Delete");
            }

            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Modyfikacja języka nie powiodła się"
            };
        }
    }
}
