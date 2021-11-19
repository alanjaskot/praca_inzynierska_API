using Microsoft.EntityFrameworkCore;
using NLog;
using PracaInzynierskaAPI.DataBase.Context;
using PracaInzynierskaAPI.Entities.Category;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.Category
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly IPInzDataBaseContext _context;
        private ILogger _logger;

        public CategoryRepository(IPInzDataBaseContext context)
        {
            _context = context;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ResponseModel<List<CategoryDbModel>> GetAll()
        {
            var result = default(List<CategoryDbModel>);
            try
            {
                result = _context.Categories
                    .Where(c => c.IsDeleted == false).ToList();
                if (result != null)
                    return new ResponseModel<List<CategoryDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "CategoryRepo.GetAll");
                throw;
            }
            return new ResponseModel<List<CategoryDbModel>>
            {
                Success = false,
                Message = "Pobieranie danych z bazy danych nie powiodło się"
            };
        }

        public ResponseModel<CategoryDbModel> GetById(Guid id)
        {
            if (id == Guid.Empty)
                return new ResponseModel<CategoryDbModel>
                {
                    Success = false,
                    Message = "Podany identyfikator jest pusty"
                };

            var result = default(CategoryDbModel);
            try
            {
                result = _context.Categories.Where(c => c.Id == id
                && c.IsDeleted == false).FirstOrDefault();
                if (result != null)
                    return new ResponseModel<CategoryDbModel>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
                if (result == null)
                    return new ResponseModel<CategoryDbModel>
                    {
                        Success = false,
                        Message = "Kategoria o podanym identyfikatorze nie istnieje"
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "CategoryRepo.GetById");
                throw;
            }
            return new ResponseModel<CategoryDbModel>
            {
                Success = false,
                Message = "Pobieranie żądanych danych nie powiodło się"
            };
        }

        public ResponseModel<List<CategoryDbModel>> GetByName(List<string> list)
        {
            var result = default(List<CategoryDbModel>);
            var temp = default(List<CategoryDbModel>);
            try
            {
                foreach (var item in list)
                {
                    temp = _context.Categories.Where(c => c.Category.Contains(item)
                    && c.IsDeleted == false).ToList();
                    result.AddRange(temp);
                }
                if (result == null)
                    return new ResponseModel<List<CategoryDbModel>>
                    {
                        Success = true,
                        Message = "Brak wyników"
                    };
                if (result != null)
                    return new ResponseModel<List<CategoryDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "CategoryRepo.GetByName");
                throw;
            }
            return new ResponseModel<List<CategoryDbModel>>
            {
                Success = false,
                Message = "Pobieranie żądanych danych nie powiodło się"
            };
        }

        public ResponseModel<Guid> Add(CategoryDbModel category)
        {
            if (category == null)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Obiekt jest pusty"
                };

            if (category.Id == Guid.Empty)
                category.Id = Guid.NewGuid();

            try
            {
                var temp = GetById(category.Id);
                if (category != null && temp.Message != null)
                {
                    var added = _context.Categories.Add(category);
                    if (added.State == EntityState.Added)
                        return new ResponseModel<Guid>
                        {
                            Success = true,
                            Message = null,
                            Object = category.Id
                        };
                }
            }
            catch (Exception)
            {
                throw;
            }
            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Zapis w bazie danych zakończony niepowodzeniem"
            };
        }

        public ResponseModel<Guid> Update(CategoryDbModel category)
        {
            if (category == null)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Podany obiek jest pusty"
                };
            try
            {
                var updated = _context.Categories.Update(category);
                if (updated.State == EntityState.Modified)
                    return new ResponseModel<Guid>
                    {
                        Success = true,
                        Message = null,
                        Object = category.Id
                    };
            }
            catch (Exception)
            {
                throw;
            }

            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Modyfikacja kategorii zakończona niepowodzeniem"
            };
        }

        public ResponseModel<Guid> SoftDelete(CategoryDbModel category)
        {
            if (category == null)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Podany obiekt jest pusty"
                };

            try
            {
                if (category != null)
                {
                    category.IsDeleted = true;
                    category.DeletedAt = DateTime.Now;
                    category.Category = DateTime.Now.ToString();
                    var softDelete = _context.Categories.Update(category);
                    if (softDelete.State == EntityState.Modified)
                        return new ResponseModel<Guid>
                        {
                            Success = true,
                            Message = null,
                            Object = category.Id
                        };
                }
            }
            catch (Exception)
            {
                throw;
            }

            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Usuwanie kategorii zakończone niepowodzeniem"
            };
        }

        public ResponseModel<Guid> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Wprowadzony obiekt jest pusty"
                };

            try
            {
                var temp = _context.Categories.Where(c => c.Id == id).FirstOrDefault();
                if (temp != null)
                {
                    var deleted =  _context.Categories.Remove(temp);
                    if (deleted.State == EntityState.Deleted)
                        return new ResponseModel<Guid>
                        {
                            Success = true,
                            Message = null,
                            Object = id
                        };
                }
            }
            catch (Exception)
            {
                throw;
            }

            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Zapis w bazie danych zakończony niepowodzeniem"
            };
        }
    }
}
