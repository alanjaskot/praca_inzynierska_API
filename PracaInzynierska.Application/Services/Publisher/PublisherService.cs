using AutoMapper;
using NLog;
using PracaInzynierska.Application.DTO.Publisher;
using PracaInzynierskaAPI.DataBase.UnitOfWork;
using PracaInzynierskaAPI.Entities.Publisher;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services.Publisher
{
    public class PublisherService: IPublisherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private static ILogger _logger;
        private static IMapper _mapper;

        public PublisherService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ResponseModel<List<PublisherDTO>> GetAllPublishers()
        {
            try
            {
                var repoResponse = _unitOfWork.GetPublisherRepository.GetAll();
                if(repoResponse.Success)
                    return new ResponseModel<List<PublisherDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<List<PublisherDTO>>(repoResponse.Object)
                    };
                else
                    return new ResponseModel<List<PublisherDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "PublisherService.GetAllPublishers");
                throw;
            }
        }

        public ResponseModel<List<PublisherDTO>> FindPublishersByName(List<string> name)
        {
            try
            {
                var repoResponse = _unitOfWork.GetPublisherRepository.FindByName(name);
                if (repoResponse.Success)
                    return new ResponseModel<List<PublisherDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<List<PublisherDTO>>(repoResponse.Object)
                    };
                else
                    return new ResponseModel<List<PublisherDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "PublisherService.FindPublisherByName");
                throw;
            }
        }

        public ResponseModel<PublisherDTO> GetPublisherById(Guid id)
        {
            try
            {
                var repoResponse = _unitOfWork.GetPublisherRepository.GetById(id);
                if (repoResponse.Success)
                    return new ResponseModel<PublisherDTO>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<PublisherDTO>(repoResponse.Object)
                    };
                else
                    return new ResponseModel<PublisherDTO>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "PublisherService.GetPublisherById");
                throw;
            }
        }

        public ResponseModel<Guid> AddPublisher(PublisherDTO publisher)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetPublisherRepository.Add(_mapper.Map<PublisherDbModel>(publisher));
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
                            Message = "Nie udało się dodać wydawcy"
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
                _logger.Error(err, "PublisherService.AddPublishers");
                throw;
            }
        }

        public ResponseModel<Guid> UpdatePublisher(PublisherDTO publisher)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetPublisherRepository.Update(_mapper.Map<PublisherDbModel>(publisher));
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
                            Message = "Nie udało się dodać wydawcy"
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
                _logger.Error(err, "PublisherService.AddPublishers");
                throw;
            }
        }

        public ResponseModel<Guid> SoftDeletePublisher(PublisherDTO publisher)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetPublisherRepository.SoftDelete(_mapper.Map<PublisherDbModel>(publisher));
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
                            Message = "Nie udało się dodać wydawcy"
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
                _logger.Error(err, "PublisherService.AddPublishers");
                throw;
            }
        }
    }
}
