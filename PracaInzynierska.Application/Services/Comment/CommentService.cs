using AutoMapper;
using NLog;
using PracaInzynierska.Application.DTO.Comment;
using PracaInzynierskaAPI.DataBase.UnitOfWork;
using PracaInzynierskaAPI.Entities.Comment;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services.Comment
{
    public class CommentService: ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private static IMapper _mapper;
        private ILogger _logger;

        public CommentService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ResponseModel<List<CommentDTO>> GetAllCommentsByBook(Guid bookId)
        {
            try
            {
                var repoResponse = _unitOfWork.GetCommentRepository.GetAllByBook(bookId);
                if (repoResponse.Success)
                    return new ResponseModel<List<CommentDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<List<CommentDTO>>(repoResponse.Object)
                    };
                else
                    return new ResponseModel<List<CommentDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "CommentService.GetAllCommentsByBook");
                throw;
            }
        }

        public ResponseModel<List<CommentDTO>> GetAllCommentsByUser(Guid userId)
        {
            try
            {
                var repoResponse = _unitOfWork.GetCommentRepository.GetAllByUser(userId);
                if (repoResponse.Success)
                    return new ResponseModel<List<CommentDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<List<CommentDTO>>(repoResponse.Object)
                    };
                else
                    return new ResponseModel<List<CommentDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "CommentService.GetAllCommentsByUser");
                throw;
            }
        }

        public ResponseModel<List<CommentDTO>> GetAllCommentsByComment(Guid commentId)
        {
            try
            {
                var repoResponse = _unitOfWork.GetCommentRepository.GetAllByComment(commentId);
                if (repoResponse.Success)
                    return new ResponseModel<List<CommentDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<List<CommentDTO>>(repoResponse.Object)
                    };
                else
                    return new ResponseModel<List<CommentDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "CommentService.GetAllCommentsByUser");
                throw;
            }
        }

        public ResponseModel<CommentDTO> GetCommentById(Guid id)
        {
            try
            {
                var repoResponse = _unitOfWork.GetCommentRepository.GetById(id);
                if (repoResponse.Success)
                    return new ResponseModel<CommentDTO>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<CommentDTO>(repoResponse.Object)
                    };
                else
                    return new ResponseModel<CommentDTO>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "CommentService.GetCommentById");
                throw;
            }
        }

        public ResponseModel<Guid> AddComment(CommentDTO comment)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetCommentRepository.Add(_mapper.Map<CommentDbModel>(comment));
                if(repoResponse.Success)
                {
                    var save = _unitOfWork.Save();
                    if(save > -1)
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
                            Message = "Nie udało się dodać komentarza"
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
                _logger.Error(err, "CommentService.AddComment");
                throw;
            }
        }

        public ResponseModel<Guid> UpdateComment(CommentDTO comment)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetCommentRepository.Update(_mapper.Map<CommentDbModel>(comment));
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
                            Message = "Nie udało się zmodyfikować komentarza"
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
                _logger.Error(err, "CommentService.UpdateComment");
                throw;
            }
        }

        public ResponseModel<Guid> SoftDeleteComment(CommentDTO comment)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetCommentRepository.SoftDelete(_mapper.Map<CommentDbModel>(comment));
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
                            Message = "Nie udało się usunąć komentarza"
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
                _logger.Error(err, "CommentService.SoftDeleteComment");
                throw;
            }
        }
    }
}
