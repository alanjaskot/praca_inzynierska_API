using AutoMapper;
using NLog;
using PracaInzynierska.Application.DTO.User;
using PracaInzynierskaAPI.DataBase.UnitOfWork;
using PracaInzynierskaAPI.Entities.User;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services.User
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private static IMapper _mapper;
        private ILogger _logger;

        public UserService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ResponseModel<IEnumerable<UserInfoDTO>> GetAllUsers()
        {
            try
            {
                var repoResponse = _unitOfWork.GetUserRepository.GetAll();
                if (repoResponse.Success)
                    return new ResponseModel<IEnumerable<UserInfoDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<IEnumerable<UserInfoDTO>>(repoResponse.Object)
                    };
                else
                    return new ResponseModel<IEnumerable<UserInfoDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "UserService.GetAllUsers");
                throw;
            }
        }

        public ResponseModel<UserInfoDTO> GetUserById(Guid id)
        {
            try
            {
                var repoResponse = _unitOfWork.GetUserRepository.GetById(id);
                if (repoResponse.Success)
                    return new ResponseModel<UserInfoDTO>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<UserInfoDTO>(repoResponse.Object)
                    };
                else
                    return new ResponseModel<UserInfoDTO>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "UserService.GetByUserId");
                throw;
            }
        }

        public ResponseModel<UserDTO> GetUserByIdForModAndAdmin(Guid id)
        {
            try
            {
                var repoResponse = _unitOfWork.GetUserRepository.GetById(id);
                if (repoResponse.Success)
                    return new ResponseModel<UserDTO>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<UserDTO>(repoResponse.Object)
                    };
                else
                    return new ResponseModel<UserDTO>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "UserService.GetByUserId");
                throw;
            }
        }


        public ResponseModel<UserInfoDTO> GetUserByEmail(string email)
        {
            try
            {
                var repoResponse = _unitOfWork.GetUserRepository.GetByEmail(email);
                if (repoResponse.Success)
                    return new ResponseModel<UserInfoDTO>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<UserInfoDTO>(repoResponse.Object)
                    };
                else
                    return new ResponseModel<UserInfoDTO>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "UserService.GetUserByEmail");
                throw;
            }
        }

        public ResponseModel<UserInfoDTO> GetUserByUserName(string userName)
        {
            try
            {
                var repoResponse = _unitOfWork.GetUserRepository.GetByUserName(userName);
                if (repoResponse.Success)
                    return new ResponseModel<UserInfoDTO>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<UserInfoDTO>(repoResponse.Object)
                    };
                else
                    return new ResponseModel<UserInfoDTO>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "UserService.GetUserByUserName");
                throw;
            }
        }

        public ResponseModel<UserDTO> Login(string userName, string password)
        {
            try
            {
                var repoResponse = _unitOfWork.GetUserRepository.Login(userName, password);
                if (repoResponse.Success)
                    return new ResponseModel<UserDTO>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<UserDTO>(repoResponse.Object)
                    };
                else
                    return new ResponseModel<UserDTO>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "UserService.GetUserByLoginPassword");
                throw;
            }
        }

        public ResponseModel<Guid> AddUser(UserDTO userModel)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetUserRepository.Add(_mapper.Map<UserDbModel>(userModel));
                if (repoResponse.Success)
                {
                    var save = _unitOfWork.Save();
                    if (save > -1)
                    {
                        _unitOfWork.CommitTransaction();
                        return repoResponse;
                    }
                    else
                    {
                        _unitOfWork.RollBackTransaction();
                        return new ResponseModel<Guid>
                        {
                            Success = false,
                            Message = "Rejestracja nie powiodła się"
                        };
                    }
                }
                else
                {
                    _unitOfWork.RollBackTransaction();
                    return repoResponse;
                }
            }
            catch (Exception err)
            {
                _unitOfWork.RollBackTransaction();
                _logger.Error(err, "UserService.AddUser");
                throw;
            }
        }

        public ResponseModel<Guid> UpdateUser(UserDTO userModel)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetUserRepository.Update(_mapper.Map<UserDbModel>(userModel));
                if (repoResponse.Success)
                {
                    var save = _unitOfWork.Save();
                    if (save > -1)
                    {
                        _unitOfWork.CommitTransaction();
                        return repoResponse;
                    }
                    else
                    {
                        _unitOfWork.RollBackTransaction();
                        return new ResponseModel<Guid>
                        {
                            Success = false,
                            Message = "Modyfikacja nie powiodła się"
                        };
                    }
                }
                else
                {
                    _unitOfWork.RollBackTransaction();
                    return repoResponse;
                }
            }
            catch (Exception err)
            {
                _unitOfWork.RollBackTransaction();
                _logger.Error(err, "UserService.UpdateUser");
                throw;
            }
        }

        public ResponseModel<bool> BanUser(UserDTO userModel)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetUserRepository.Ban(_mapper.Map<UserDbModel>(userModel));
                if (repoResponse.Success)
                {
                    var save = _unitOfWork.Save();
                    if (save > -1)
                    {
                        _unitOfWork.CommitTransaction();
                        return repoResponse;
                    }
                    else
                    {
                        _unitOfWork.RollBackTransaction();
                        return new ResponseModel<bool>
                        {
                            Success = false,
                            Message = "Nałożenie banu nie powiodło się"
                        };
                    }
                }
                else
                {
                    _unitOfWork.RollBackTransaction();
                    return repoResponse;
                }
            }
            catch (Exception err)
            {
                _unitOfWork.RollBackTransaction();
                _logger.Error(err, "UserService.BanUser");
                throw;
            }
        }

        public ResponseModel<Guid> DeleteUser(Guid id)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetUserRepository.Delete(id);
                if (repoResponse.Success)
                {
                    var save = _unitOfWork.Save();
                    if (save > -1)
                    {
                        _unitOfWork.CommitTransaction();
                        return repoResponse;
                    }
                    else
                    {
                        _unitOfWork.RollBackTransaction();
                        return new ResponseModel<Guid>
                        {
                            Success = false,
                            Message = "Usunięcie użytkownika nie powiodło się"
                        };
                    }
                }
                else
                {
                    _unitOfWork.RollBackTransaction();
                    return repoResponse;
                }
            }
            catch (Exception err)
            {
                _unitOfWork.RollBackTransaction();
                _logger.Error(err, "UserService.BanUser");
                throw;
            }
        }
    }
}
