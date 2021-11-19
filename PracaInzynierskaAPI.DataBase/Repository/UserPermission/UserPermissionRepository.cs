using Microsoft.EntityFrameworkCore;
using NLog;
using PracaInzynierskaAPI.DataBase.Context;
using PracaInzynierskaAPI.Entities.UserPermission;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.UserPermission
{
    public class UserPermissionRepository: IUserPermissionRepository
    {
        private readonly IPInzDataBaseContext _context;
        private ILogger _logger;

        public UserPermissionRepository(IPInzDataBaseContext context)
        {
            _context = context;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ResponseModel<List<UserPermissionDbModel>> GetAllByUserGuid(Guid userGuid)
        {
            if (userGuid == Guid.Empty)
                return new ResponseModel<List<UserPermissionDbModel>>
                {
                    Success = false,
                    Message = "Identyfikator użytkownika jest pusty"
                };

            var result = default(List<UserPermissionDbModel>);
            try
            {
                result = _context.UserPermissions
                    .Where(p => p.UserId == userGuid && p.IsDeleted != true)
                    .ToList();

                if (result == null)
                    return new ResponseModel<List<UserPermissionDbModel>>
                    {
                        Success = true,
                        Message = "Użytkownik nie posiada żadnych uprawnień"
                    };
                if (result != null)
                    return new ResponseModel<List<UserPermissionDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "UserPermissionRepository.GetByUserGuid");
                throw;
            }
            return new ResponseModel<List<UserPermissionDbModel>>
            {
                Success = false,
                Message = "Nie udało się pobrać żądanych danych"
            };
        }
        
        public ResponseModel<List<Guid>> AddAllByUserGuid(List<UserPermissionDbModel> permissions)
        {
            if (permissions == null)
                return new ResponseModel<List<Guid>>
                {
                    Success = false,
                    Message = "Wprowadzono puste uprawnienia"
                };

            var list = default(List<UserPermissionDbModel>);
            var result = default(List<Guid>);

            foreach(var permission in permissions)
            {
                if (permission.Id == Guid.Empty)
                    permission.Id = Guid.NewGuid();

                result.Add(permission.Id);

                list.Add(permission);
            }

            if(result.Count == permissions.Count)
            {
                try
                {
                    if(list != null)
                    {
                        _context.UserPermissions.AddRange(list);
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
                    _logger.Error(err, "UserPermissionRepository.GetByUserGuid");
                    throw;
                }
            }           

            return new ResponseModel<List<Guid>>
            {
                Success = false,
                Message = "Nie udało się dodać uprawnień"
            };
        }

        public ResponseModel<List<Guid>> DeleteAllByUserGuid(List<UserPermissionDbModel> permissions)
        {
            if (permissions == null)
                return new ResponseModel<List<Guid>>
                {
                    Success = false,
                    Message = "Wprowadzono puste uprawnienia"
                };

            var list = default(List<UserPermissionDbModel>);
            var result = default(List<Guid>);

            foreach (var permission in permissions)
            {
                if (permission.Id == Guid.Empty)
                    permission.Id = Guid.NewGuid();

                result.Add(permission.Id);

                list.Add(permission);
            }

            if (result.Count == permissions.Count)
            {
                try
                {
                    if (list != null)
                    {
                        _context.UserPermissions.RemoveRange(list);
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
                    _logger.Error(err, "UserPermissionRepository.GetByUserGuid");
                    throw;
                }
            }

            return new ResponseModel<List<Guid>>
            {
                Success = false,
                Message = "Nie udało się dodać uprawnień"
            };
        }

        public ResponseModel<UserPermissionDbModel> GetByUserGuidAndPermission(Guid userGuid, string permitionName)
        {
            if (userGuid == Guid.Empty)
                return new ResponseModel<UserPermissionDbModel>
                {
                    Success = false,
                    Message = "Wprowadzony identyfikator jest pusty"
                };

            if (permitionName == null || permitionName == "")
                return new ResponseModel<UserPermissionDbModel>
                {
                    Success = false,
                    Message = "Wprowadzone uprawnienie nie posiada nazwy"
                };

            var result = default(UserPermissionDbModel);
            try
            {
                result = _context
                    .UserPermissions
                    .Where(p => p.UserId == userGuid 
                        && p.PermissionName == permitionName 
                        && p.IsDeleted != true)
                    .FirstOrDefault();
                if (result == null)
                    return new ResponseModel<UserPermissionDbModel>
                    {
                        Success = true,
                        Message = "Użytkownik nie posiada danych uprawnień"
                    };
                if (result != null)
                    return new ResponseModel<UserPermissionDbModel>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "UserPermissionRepository.GetByUserGuidAndPermission");
                throw;
            }
            return new ResponseModel<UserPermissionDbModel>
            {
                Success = false,
                Message = "Nie udało się pobrać żądanych uprawnień"
            };
        }

        public ResponseModel<Guid> DeletePermissionForUser(Guid userGuid, string permissionName)
        {
            if (userGuid == Guid.Empty)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Wprowadzony identyfikator użytkownika jest pusty"
                };

            if (permissionName == null || permissionName == "")
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "wprowadzone uprawnienie nie może być puste"
                };
            try
            {
                var permissionToRemove = _context
                    .UserPermissions
                    .Where(p => p.UserId == userGuid 
                        && p.PermissionName == permissionName 
                        && p.IsDeleted != true)
                    .FirstOrDefault();

                if (permissionToRemove == null)
                {
                    return new ResponseModel<Guid>
                    {
                        Success = false,
                        Message = "Żądane uprawnienie nie istnieje"
                    };
                }

                var deleted = _context.UserPermissions.Remove(permissionToRemove);
                if (deleted.State == EntityState.Detached)
                    return new ResponseModel<Guid>
                    {
                        Success = true,
                        Message = null,
                        Object = permissionToRemove.Id
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "UserPermissionRepository.DeleteByUserGuidAndPermission");
                throw;
            }

            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Usunięcie uprawnień zakończone niepowodzeniem"
            };
        }
    }
}
