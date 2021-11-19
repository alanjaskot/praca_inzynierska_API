using AutoMapper;
using NLog;
using PracaInzynierska.Application.DTO.Author;
using PracaInzynierskaAPI.DataBase.UnitOfWork;
using PracaInzynierskaAPI.Entities.Author;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services.Author
{
    public class AuthorService: IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private static IMapper _mapper;
        private ILogger _logger;

        public AuthorService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ResponseModel<List<AuthorDTO>> GetAllAuthors()
        {
            try
            {
                var responseRepo = _unitOfWork.GetAuthorRepository.GetAll();
                if (responseRepo.Success == true && responseRepo.Message == null)
                    return new ResponseModel<List<AuthorDTO>>
                    {
                        Success = responseRepo.Success,
                        Message = responseRepo.Message,
                        Object = _mapper.Map<List<AuthorDTO>>(responseRepo.Object)
                    };
                if (responseRepo.Success == true && responseRepo.Message != null)
                    return new ResponseModel<List<AuthorDTO>>
                    {
                        Success = responseRepo.Success,
                        Message = responseRepo.Message
                    };
                if (!responseRepo.Success)
                    return new ResponseModel<List<AuthorDTO>>
                    {
                        Success = responseRepo.Success,
                        Message = responseRepo.Message
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorService.GetAllAuthors");
                throw;
            }
            return new ResponseModel<List<AuthorDTO>>
            {
                Success = false,
                Message = "Nie udało się pobrać żądanych danych"
            };
        }

        public ResponseModel<List<AuthorDTO>> GetAuthorsToApprove()
        {
            try
            {
                var responseRepo = _unitOfWork.GetAuthorRepository.GetToApprove();
                if (responseRepo.Success == true && responseRepo.Message == null)
                    return new ResponseModel<List<AuthorDTO>>
                    {
                        Success = responseRepo.Success,
                        Message = responseRepo.Message,
                        Object = _mapper.Map<List<AuthorDTO>>(responseRepo.Object)
                    };
                if (responseRepo.Success == true && responseRepo.Message != null)
                    return new ResponseModel<List<AuthorDTO>>
                    {
                        Success = responseRepo.Success,
                        Message = responseRepo.Message
                    };
                if (!responseRepo.Success)
                    return new ResponseModel<List<AuthorDTO>>
                    {
                        Success = responseRepo.Success,
                        Message = responseRepo.Message
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorService.GetAuthorsToApprove");
                throw;
            }
            return new ResponseModel<List<AuthorDTO>>
            {
                Success = false,
                Message = "Nie udało się pobrać żądanych danych"
            };
        }

        public ResponseModel<List<AuthorDTO>> FindAuthorsByName(List<string> list)
        {
            try
            {
                var responseRepo = _unitOfWork.GetAuthorRepository.FindByName(list);
                if (responseRepo.Success == true && responseRepo.Message == null)
                    return new ResponseModel<List<AuthorDTO>>
                    {
                        Success = responseRepo.Success,
                        Message = responseRepo.Message,
                        Object = _mapper.Map<List<AuthorDTO>>(responseRepo.Object)
                    };
                if (responseRepo.Success == true && responseRepo.Message != null)
                    return new ResponseModel<List<AuthorDTO>>
                    {
                        Success = responseRepo.Success,
                        Message = responseRepo.Message
                    };
                if (!responseRepo.Success)
                    return new ResponseModel<List<AuthorDTO>>
                    {
                        Success = responseRepo.Success,
                        Message = responseRepo.Message
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorService.GetAuthorsByName");
                throw;
            }
            return new ResponseModel<List<AuthorDTO>>
            {
                Success = false,
                Message = "Nie udało się pobrać żądanych danych"
            };
        }

        public ResponseModel<List<AuthorDTO>> GetAuthorsByIds(List<Guid> list)
        {
            try
            {
                var responseRepo = _unitOfWork.GetAuthorRepository.GetByIds(list);
                if (responseRepo.Success == true && responseRepo.Message == null)
                    return new ResponseModel<List<AuthorDTO>>
                    {
                        Success = responseRepo.Success,
                        Message = responseRepo.Message,
                        Object = _mapper.Map<List<AuthorDTO>>(responseRepo.Object)
                    };
                if (responseRepo.Success == true && responseRepo.Message != null)
                    return new ResponseModel<List<AuthorDTO>>
                    {
                        Success = responseRepo.Success,
                        Message = responseRepo.Message
                    };
                if (!responseRepo.Success)
                    return new ResponseModel<List<AuthorDTO>>
                    {
                        Success = responseRepo.Success,
                        Message = responseRepo.Message
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorService.GetAllAuthorsByList");
                throw;
            }
            return new ResponseModel<List<AuthorDTO>>
            {
                Success = false,
                Message = "Nie udało się pobrać żądanych danych"
            };
        }

        public ResponseModel<AuthorDTO> GetAuthorById(Guid id)
        {
            try
            {
                var responseRepo = _unitOfWork.GetAuthorRepository.GetById(id);
                if (responseRepo.Success == true && responseRepo.Message == null)
                    return new ResponseModel<AuthorDTO>
                    {
                        Success = responseRepo.Success,
                        Message = responseRepo.Message,
                        Object = _mapper.Map<AuthorDTO>(responseRepo.Object)
                    };
                if (responseRepo.Success == true && responseRepo.Message != null)
                    return new ResponseModel<AuthorDTO>
                    {
                        Success = responseRepo.Success,
                        Message = responseRepo.Message
                    };
                if (!responseRepo.Success)
                    return new ResponseModel<AuthorDTO>
                    {
                        Success = responseRepo.Success,
                        Message = responseRepo.Message
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorService.GetAuthorById");
                throw;
            }
            return new ResponseModel<AuthorDTO>
            {
                Success = false,
                Message = "Nie udało się pobrać żądanych danych"
            };
        }

        public ResponseModel<Guid> AddAuthor(AuthorDTO author)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var responseRepo = _unitOfWork.GetAuthorRepository.Add(_mapper.Map<AuthorDbModel>(author));
                if (responseRepo.Success)
                {
                    var save = _unitOfWork.Save();
                    if (save > -1)
                    {
                        _unitOfWork.CommitTransaction();
                        return responseRepo;
                    }
                    else
                    {
                        _unitOfWork.RollBackTransaction();
                        return new ResponseModel<Guid>
                        {
                            Success = false,
                            Message = "Błąd zapisu. Wprowadzone zmiany zostaną anulowane"
                        };
                    }
                        
                }
                else
                {
                    _unitOfWork.RollBackTransaction();
                    return responseRepo;
                }
                
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorService.AddAuthor");
                throw;
            }
        }

        public ResponseModel<bool> ApproveAuthor(AuthorDTO author)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var responseRepo = _unitOfWork.GetAuthorRepository.Approve(_mapper.Map<AuthorDbModel>(author));
                if(responseRepo.Success)
                {
                    var save = _unitOfWork.Save();
                    if(save > -1)
                    {
                        _unitOfWork.CommitTransaction();
                        return responseRepo;
                    }
                    else
                    {
                        _unitOfWork.RollBackTransaction();
                        return new ResponseModel<bool>
                        {
                            Success = false,
                            Message = "Błąd zapisu. Wprowadzone zmiany zostaną anulowane"
                        };
                    }
                }
                else
                {
                    _unitOfWork.RollBackTransaction();
                    return responseRepo;
                }                  
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorService.UpdateAuthor");
                throw;
            }
        }

        public ResponseModel<Guid> UpdateAuthor(AuthorDTO author)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var responseRepo = _unitOfWork.GetAuthorRepository.Update(_mapper.Map<AuthorDbModel>(author));
                if (responseRepo.Success)
                {
                    var save = _unitOfWork.Save();
                    if (save > -1)
                    {
                        _unitOfWork.CommitTransaction();
                        return responseRepo;
                    }
                    else
                    {
                        _unitOfWork.RollBackTransaction();
                        return new ResponseModel<Guid>
                        {
                            Success = false,
                            Message = "Błąd zapisu. Wprowadzone zmiany zostaną anulowane"
                        };
                    }
                }
                else
                {
                    _unitOfWork.RollBackTransaction();
                    return responseRepo;
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorService.UpdateAuthor");
                throw;
            }
        }

        public ResponseModel<List<Guid>> SoftDeleteAuthors(List<AuthorDTO> authors)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var responseRepo = _unitOfWork.GetAuthorRepository.SoftDelete(_mapper.Map<List<AuthorDbModel>>(authors));
                if(responseRepo.Success)
                {
                    var save = _unitOfWork.Save();
                    if (save > -1)
                    {
                        _unitOfWork.CommitTransaction();
                        return responseRepo;
                    }
                    else
                    {
                        _unitOfWork.RollBackTransaction();
                        return new ResponseModel<List<Guid>>
                        {
                            Success = false,
                            Message = "Błąd zapisu. Wprowadzone zmiany zostaną anulowane"
                        };
                    }
                }
                else
                {
                    _unitOfWork.RollBackTransaction();
                    return responseRepo;
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorService.SoftDeleteAuthor");
                throw;
            }
        }

        public ResponseModel<Guid> DeleteAuthor(Guid id)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var responseRepo = _unitOfWork.GetAuthorRepository.Delete(id);
                if (responseRepo.Success)
                {
                    var save = _unitOfWork.Save();
                    if (save > -1)
                    {
                        _unitOfWork.CommitTransaction();
                        return responseRepo;
                    }
                    else
                    {
                        _unitOfWork.RollBackTransaction();
                        return new ResponseModel<Guid>
                        {
                            Success = false,
                            Message = "Błąd zapisu. Wprowadzone zmiany zostaną anulowane"
                        };
                    }
                }
                else
                {
                    _unitOfWork.RollBackTransaction();
                    return responseRepo;
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "AuthorService.DeleteAuthor");
                throw;
            }
        }
    }
}
