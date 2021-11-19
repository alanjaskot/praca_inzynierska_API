using AutoMapper;
using NLog;
using PracaInzynierska.Application.DTO.ImageCover;
using PracaInzynierskaAPI.DataBase.UnitOfWork;
using PracaInzynierskaAPI.Entities.ImageCover;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services.ImageCover
{
    public class ImageCoverService: IImageCoverService
    {
        private readonly IUnitOfWork _unitOfWork;
        private static IMapper _mapper;
        private ILogger _logger;

        public ImageCoverService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ResponseModel<ImageCoverDTO> GetImageCoverById(Guid id)
        {
            try
            {
                var repoResponse = _unitOfWork.GetImageCoverRepository.GetById(id);
                if (repoResponse.Success)
                    return new ResponseModel<ImageCoverDTO>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<ImageCoverDTO>(repoResponse.Object)
                    };
                else
                    return new ResponseModel<ImageCoverDTO>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "ImageCoverService.GetImageCoverById");
                throw;
            }
        }

        public ResponseModel<Guid> AddImageCover(ImageCoverDTO imageCover)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetImageCoverRepository.Add(_mapper.Map<ImageCoverDbModel>(imageCover));
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
                            Message = "Nie udało się dodać okładki"
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
                _logger.Error(err, "ImageCoverService.AddImageCover");
                throw;
            }
        }

        public ResponseModel<Guid> UpdateImageCover(ImageCoverDTO imageCover)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetImageCoverRepository.Update(_mapper.Map<ImageCoverDbModel>(imageCover));
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
                            Message = "Nie udało się zmodyfikować okładki"
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
                _logger.Error(err, "ImageCoverService.AddImageCover");
                throw;
            }
        }

        public ResponseModel<Guid> Delete(Guid id)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetImageCoverRepository.Delete(id);
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
                            Message = "Nie udało się usunąć okładki"
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
                _logger.Error(err, "ImageCoverService.AddImageCover");
                throw;
            }
        }
    }
}
