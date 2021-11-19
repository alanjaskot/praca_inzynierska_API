using Microsoft.EntityFrameworkCore;
using NLog;
using PracaInzynierskaAPI.DataBase.Context;
using PracaInzynierskaAPI.Entities.User;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.User
{
    public class UserRepository: IUserRepository
    {
        private readonly IPInzDataBaseContext _context;
        private ILogger _logger;

        public UserRepository(IPInzDataBaseContext context)
        {
            _context = context;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ResponseModel<Guid> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "wprowadzony identyfikator jest pusty"
                };
            try
            {
                var userToRemove = _context.Users
                    .Where(u => u.Id == id)
                    .FirstOrDefault();

                if (userToRemove == null)
                {
                    return new ResponseModel<Guid>
                    {
                        Success = false,
                        Message = "Obiekt o podanym identyfikatorze nie istnieje"
                    };
                }

                var delete = _context.Users.Remove(userToRemove);
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
                _logger.Error(err, "UserRepository.Delete");
                throw;
            }

            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Usuwanie użytkownika nie powiodło się"
            };
        }
       
        public ResponseModel<IEnumerable<UserDbModel>> GetAll()
        {
            var result = default(IEnumerable<UserDbModel>);
            try
            {
                result =  _context.Users
                    .Where(u => u.DeletedAt == null && u.IsDeleted != true);
                if (result == null)
                    return new ResponseModel<IEnumerable<UserDbModel>>
                    {
                        Success = true,
                        Message = "Brak żądanych danych w bazie danych"
                    };

                if (result != null)
                    return new ResponseModel<IEnumerable<UserDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "UserRepository.etAll");
                throw;
            }
            return new ResponseModel<IEnumerable<UserDbModel>>
            {
                Success = true,
                Message = "Pobieranie danych nie powiodło się"
            };
        }
        
        public ResponseModel<UserDbModel> GetById(Guid id)
        {
            if (id == Guid.Empty)
                return new ResponseModel<UserDbModel>
                {
                    Success = false,
                    Message = "Wprowadzony identyfikator jest pusty"
                };

            try
            {
                var result =  _context.Users
                    .Where(u => u.Id == id)
                    .FirstOrDefault();

                if (result == null)
                    return new ResponseModel<UserDbModel>
                    {
                        Success = true,
                        Message = "Brak żądanych danych w bazie danych"
                    };

                if (result != null)
                    return new ResponseModel<UserDbModel>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "UserRepository.GetByGuid");
                throw;
            }

            return new ResponseModel<UserDbModel>
            {
                Success = true,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<UserDbModel> GetByUserName(string login)
        {
            if (login == "" || login == null)
                return new ResponseModel<UserDbModel>
                {
                    Success = false,
                    Message = "Wprowadzone pole nie może być puste"
                };
            try
            {
                var result =  _context.Users
                    .Where(u => u.UserName == login 
                    && u.DeletedAt == null)
                    .FirstOrDefault();

                if (result == null)
                    return new ResponseModel<UserDbModel>
                    {
                        Success = false,
                        Message = "Brak żądanych danych w bazie danych"
                    };

                if (result != null)
                    return new ResponseModel<UserDbModel>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "UserRepository.GetByLogin");
                throw;
            }

            return new ResponseModel<UserDbModel>
            {
                Success = true,
                Message = "Pobieranie danych nie powiodło się"
            };
        }

        public ResponseModel<UserDbModel> GetByEmail(string email)
        {
            if (email == "" || email == null)
                return new ResponseModel<UserDbModel>
                {
                    Success = false,
                    Message = "Wprowadzone pole nie może być puste"
                };

            try
            {
                var result = _context.Users
                    .Where(u => u.Email == email && u.DeletedAt == null)
                    .FirstOrDefault();

                if (result == null)
                    return new ResponseModel<UserDbModel>
                    {
                        Success = false,
                        Message = "Brak żądanych danych w bazie danych"
                    };

                if (result != null)
                    return new ResponseModel<UserDbModel>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "UserRepository.GetByEmail");
                throw;
            }

            return new ResponseModel<UserDbModel>
            {
                Success = true,
                Message = "Pobieranie danych nie powiodło się"
            };
        }
        
        public ResponseModel<Guid> Add(UserDbModel user)
        {
            if (user == null)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Wprowadzony obiekt jest pusty"
                };

            if (user.Id == Guid.Empty)
                user.Id = Guid.NewGuid();

            try
            {
                var added = _context.Users.Add(user);
                if (added.State == EntityState.Added)
                    return new ResponseModel<Guid>
                    {
                        Success = true,
                        Message = null,
                        Object = user.Id
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "UserRepository.Add");
                throw;
            }

            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Rejestracja nie powiodła się"
            };
        }

        public ResponseModel<bool> Ban(UserDbModel user)
        {
            if (user != null)
                return new ResponseModel<bool>
                {
                    Success = false,
                    Message = "Wprowadzony obiekt jest pusty"
                };
            try
            {
                user.Banned = true;
                var banned = _context.Users.Update(user);
                if (banned.State == EntityState.Modified)
                    return new ResponseModel<bool>
                    {
                        Success = true,
                        Message = null,
                        Object = true
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "UserRepository.Ban");
                throw;
            }
            return new ResponseModel<bool>
            {
                Success = false,
                Message = "Zmiana statusu użytkownika nie powiodła się"
            };
        }

        public ResponseModel<long> AddLike(Guid userId, int plus = 1)
        {
            if (userId == Guid.Empty)
                return new ResponseModel<long>
                {
                    Success = false,
                    Message = "Identyfikator użytkownika jest pusty"
                };

            try
            {
                var user = _context.Users
                    .Where(u => u.Id == userId)
                    .FirstOrDefault();

                if (user == null)
                    return new ResponseModel<long>
                    {
                        Success = false,
                        Message = "Nie ma takiego użytkownika"
                    };

                user.Likes += 1;

                var updated = _context.Users.Update(user);
                if (updated.State == EntityState.Modified)
                    return new ResponseModel<long>
                    {
                        Success = true,
                        Message = null,
                        Object = user.Likes
                    };

                return new ResponseModel<long>()
                {
                    Success = false,
                    Message = "Nie udało się zmienić oceny użytkownika"
                };
            }
            catch (Exception err)
            {
                _logger.Error(err, "UserRepository.AddLike");
                throw;
            }
        }

        public ResponseModel<Guid> Update(UserDbModel user)
        {
            if (user == null)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Wprowadzony użytkownik jest pusty"
                };
            try 
            { 
                var update = _context.Users.Update(user);
                if (update.State == EntityState.Modified)
                    return new ResponseModel<Guid>
                    {
                        Success = true,
                        Message = null,
                        Object = user.Id
                    };

            
            }
            catch (Exception err)
            {
                _logger.Error(err, "UserRepository.Update");
                throw;
            }

            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Zmiana danych użytkownika nie powiodła się"
            };
        }

        public ResponseModel<UserDbModel> Login(string emailOrUserName, string password)
        {
            var result = default(UserDbModel);
            try
            {
                result = _context.Users
                   .Where(u => (u.UserName == emailOrUserName && u.Password == password)
                   || (u.Email == emailOrUserName && u.Password == password))
                  .FirstOrDefault();
                if (result == null)
                    return new ResponseModel<UserDbModel>
                    {
                        Success = false,
                        Message = "Użytkownik o podanym loginie/emailu oraz haśle nie istnieje"
                    };
                if (result != null)
                    return new ResponseModel<UserDbModel>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "UserRepository.GetByLoginPassword");
                throw;
            }
            return new ResponseModel<UserDbModel>
            {
                Success = false,
                Message = "Próba logowania nie powiodła się"
            };
        }
    }
}
