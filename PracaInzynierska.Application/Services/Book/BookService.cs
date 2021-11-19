using AutoMapper;
using NLog;
using PracaInzynierska.Application.DTO.Book;
using PracaInzynierskaAPI.DataBase.UnitOfWork;
using PracaInzynierskaAPI.Entities.Book;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services.Book
{
    public class BookService: IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private static IMapper _mapper;
        private ILogger _logger;

        public BookService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ResponseModel<List<BookDTO>> GetAllBooks()
        {
            try
            {
                var repoResponse = _unitOfWork.GetBookRepository.GetAll();
                if (!repoResponse.Success)
                    return new ResponseModel<List<BookDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };

                if (repoResponse.Success)
                    return new ResponseModel<List<BookDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<List<BookDTO>>(repoResponse.Object)
                    };

                return new ResponseModel<List<BookDTO>>
                {
                    Success = repoResponse.Success,
                    Message = repoResponse.Message
                };
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookService.GetAllBooks");
                throw;
            }
        }

        public ResponseModel<List<BookDTO>> GetBooksToApprove()
        {
            try
            {
                var repoResponse = _unitOfWork.GetBookRepository.GetToApprove();
                if (!repoResponse.Success)
                    new ResponseModel<List<BookDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };

                if (repoResponse.Success)
                    return new ResponseModel<List<BookDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<List<BookDTO>>(repoResponse.Object)
                    };

                return new ResponseModel<List<BookDTO>>
                {
                    Success = false,
                    Message = "Nie udało się pobrać żądanych danych"
                };

            }
            catch (Exception err)
            {
                _logger.Error(err, "BookService.GetBooksToApprove");
                throw;
            }
        }

        public ResponseModel<List<BookDTO>> GetBooksByList(List<Guid> list)
        {
            try
            {
                var repoResponse = _unitOfWork.GetBookRepository.GetByList(list);
                if (!repoResponse.Success)
                    new ResponseModel<List<BookDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };

                if (repoResponse.Success)
                    return new ResponseModel<List<BookDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<List<BookDTO>>(repoResponse.Object)
                    };

                return new ResponseModel<List<BookDTO>>
                {
                    Success = false,
                    Message = "Nie udało się pobrać żądanych danych"
                };
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookService.GetBooksByList");
                throw;
            }
        }

        public ResponseModel<List<BookDTO>> GetBooksByCategory(Guid categoryId)
        {
            try
            {
                var repoResponse = _unitOfWork.GetBookRepository.GetByCategory(categoryId);
                if (!repoResponse.Success)
                    new ResponseModel<List<BookDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };

                if (repoResponse.Success)
                    return new ResponseModel<List<BookDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<List<BookDTO>>(repoResponse.Object)
                    };

                return new ResponseModel<List<BookDTO>>
                {
                    Success = false,
                    Message = "Nie udało się pobrać żądanych danych"
                };
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookService.GetBooksByCategory");
                throw;
            }
        }

        public ResponseModel<List<BookDTO>> GetBooksByPublisher(Guid publisherId)
        {
            try
            {
                var repoResponse = _unitOfWork.GetBookRepository.GetByPublisher(publisherId);
                if (!repoResponse.Success)
                    new ResponseModel<List<BookDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };

                if (repoResponse.Success)
                    return new ResponseModel<List<BookDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<List<BookDTO>>(repoResponse.Object)
                    };

                return new ResponseModel<List<BookDTO>>
                {
                    Success = false,
                    Message = "Nie udało się pobrać żądanych danych"
                };
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookService.GetBooksByPublisher");
                throw;
            }
        }

        public ResponseModel<List<BookDTO>> FindBooksByName(List<string> name)
        {
            try
            {
                var repoResponse = _unitOfWork.GetBookRepository.FindByName(name);
                if (!repoResponse.Success)
                    new ResponseModel<List<BookDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };

                if (repoResponse.Success)
                    return new ResponseModel<List<BookDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<List<BookDTO>>(repoResponse.Object)
                    };

                
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookService.FindBooksByName");
            }
           
            return new ResponseModel<List<BookDTO>>
            {
                Success = false,
                Message = "Nie udało się pobrać żądanych danych"
            };
        }

        public ResponseModel<List<BookDTO>> GetHighlightedBooksByMonth()
        {
            try
            {
                var repoResponse = _unitOfWork.GetBookRepository.GetHighlightedByMonth();
                if (!repoResponse.Success)
                    new ResponseModel<List<BookDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };

                if (repoResponse.Success)
                    return new ResponseModel<List<BookDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<List<BookDTO>>(repoResponse.Object)
                    };

                return new ResponseModel<List<BookDTO>>
                {
                    Success = false,
                    Message = "Nie udało się pobrać żądanych danych"
                };
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookService.GetHighlightedBooksByMonth");
                throw;
            }
        }

        public ResponseModel<List<BookDTO>> GetHighlightedBooksByYear()
        {
            try
            {
                var repoResponse = _unitOfWork.GetBookRepository.GetHighlightedByYear();
                if (!repoResponse.Success)
                    new ResponseModel<List<BookDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };

                if (repoResponse.Success)
                    return new ResponseModel<List<BookDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<List<BookDTO>>(repoResponse.Object)
                    };

                return new ResponseModel<List<BookDTO>>
                {
                    Success = false,
                    Message = "Nie udało się pobrać żądanych danych"
                };
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookService.GetHighlightedBooksByYear");
                throw;
            }
        }

        public ResponseModel<List<BookDTO>> GetHighlightedBooks()
        {
            try
            {
                var repoResponse = _unitOfWork.GetBookRepository.GetHighlighted();
                if (!repoResponse.Success)
                    new ResponseModel<List<BookDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };

                if (repoResponse.Success)
                    return new ResponseModel<List<BookDTO>>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<List<BookDTO>>(repoResponse.Object)
                    };

                return new ResponseModel<List<BookDTO>>
                {
                    Success = false,
                    Message = "Nie udało się pobrać żądanych danych"
                };
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookService.GetHighlightedBooks");
                throw;
            }
        }

        public ResponseModel<BookDTO> GetBookById(Guid id)
        {
            try
            {
                var repoResponse = _unitOfWork.GetBookRepository.GetById(id);
                if (!repoResponse.Success)
                    new ResponseModel<BookDTO>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message
                    };

                if (repoResponse.Success)
                    return new ResponseModel<BookDTO>
                    {
                        Success = repoResponse.Success,
                        Message = repoResponse.Message,
                        Object = _mapper.Map<BookDTO>(repoResponse.Object)
                    };

                return new ResponseModel<BookDTO>
                {
                    Success = false,
                    Message = "Nie udało się pobrać żądanych danych"
                };
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookService.GetBookById");
                throw;
            }
        }

        public ResponseModel<Guid> AddBook(BookDTO book)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetBookRepository.Add(_mapper.Map<BookDbModel>(book));
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
                            Message = "Dodanie nowej książki nie powiodło się"
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
                _logger.Error(err, "BookService.AddBook");
                throw;
            }
        }

        public ResponseModel<decimal> AddPlusOrMinusToBook(Guid bookId, long plus)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetBookRepository.AddPlusOrMinus(bookId, plus);
                if(repoResponse.Success)
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
                        return new ResponseModel<decimal>
                        {
                            Success = false,
                            Message = "Zmiana oceny książki nie powiodła się"
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
                _logger.Error(err, "BookService.AddPlusOrMinusToBook");
                throw;
            }
        }

        public ResponseModel<bool> ApproveBooks(List<BookDTO> book)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoRespone = _unitOfWork.GetBookRepository.Approve(_mapper.Map<List<BookDbModel>>(book));
                if (repoRespone.Success)
                {
                    var save = _unitOfWork.Save();
                    if (save > -1)
                    {
                        _unitOfWork.CommitTransaction();
                        return repoRespone;
                    }
                    else
                    {
                        _unitOfWork.RollBackTransaction();
                        return new ResponseModel<bool>
                        {
                            Success = false,
                            Message = "Zatwierdzenie książek nie udało sie"
                        };
                    }
                }
                else
                {
                    _unitOfWork.RollBackTransaction();
                    return repoRespone;
                }        
            }
            catch (Exception err)
            {
                _logger.Error(err, "BookService.ApproveBooks");
                throw;
            }
        }

        public ResponseModel<Guid> UpdateBook(BookDTO book)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetBookRepository.Update(_mapper.Map<BookDbModel>(book));
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
                            Message = "Aktualizacja książki nie powiodła się"
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
                _logger.Error(err, "BookService.UpdateBook");
                throw;
            }
        }

        public ResponseModel<List<Guid>> SoftDeleteBooks(List<BookDTO> book)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetBookRepository.SoftDelete(_mapper.Map<List<BookDbModel>>(book));
                if(repoResponse.Success)
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
                        return new ResponseModel<List<Guid>>
                        {
                            Success = false,
                            Message = "Nie udało się usunąć wybranych książek"
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
                _logger.Error(err, "BookService.SoftDeleteBooks");
                throw;
            }
        }

        public ResponseModel<Guid> DeleteBook(Guid id)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetBookRepository.Delete(id);
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
                            Message = "Nie udało się usunąć wybranej książki"
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
                _logger.Error(err, "BookService.DeleteBook");
                throw;
            }
        }
    }
}
