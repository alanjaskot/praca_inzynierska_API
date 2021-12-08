using AutoMapper;
using NLog;
using PracaInzynierska.Application.DTO.Book_Author;
using PracaInzynierskaAPI.DataBase.UnitOfWork;
using PracaInzynierskaAPI.Entities.Book_Author;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;


namespace PracaInzynierska.Application.Services.Book_Author
{
    public class Book_AuthorService: IBook_AuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private static IMapper _mapper;
        private ILogger _logger;

        public Book_AuthorService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = LogManager.GetCurrentClassLogger();
        }

        /*public Book_AuthorDTO GetBook_AuthorById(Guid id)
        {
            var result = default(Book_AuthorDbModel);
            try
            {
                result = _unitOfWork.GetBook_AuthorRepository.GetById(id);
            }
            catch (Exception err)
            {
                _logger.Error(err, "Book_AuthorService.GetBook_AuthorById");
                throw;
            }
            return _mapper.Map<Book_AuthorDTO>(result);
        }*/

        public ResponseModel<List<Guid>> GetAllBooksByAuthor(Guid authorId)
        {
            try
            {
                var repoResponse = _unitOfWork.GetBook_AuthorRepository.GetAllBooksByAuthor(authorId);
                if (repoResponse.Success)
                    return repoResponse;
                else
                    return repoResponse;
            }
            catch (Exception err)
            {
                _logger.Error(err, "Book_AuthorService.GetAllBooksByAuthor");
                throw;
            }
        }

        public ResponseModel<List<Guid>> GetAllAuthorsByBook(Guid bookId)
        {
            try
            {
                var repoResponse = _unitOfWork.GetBook_AuthorRepository.GetAllAuthorsByBook(bookId);
                if (repoResponse.Success)
                    return repoResponse;
                else
                    return repoResponse;
            }
            catch (Exception err)
            {
                _logger.Error(err, "Book_AuthorService.GetAllAuthorsByBook");
                throw;
            }
        }

        public ResponseModel<List<Guid>> AddBook_Authors(List<Book_AuthorDTO> book_author)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetBook_AuthorRepository.Add(_mapper.Map<List<Book_AuthorDbModel>>(book_author));
                if (repoResponse.Success)
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
                        return new ResponseModel<List<Guid>>
                        {
                            Success = false,
                            Message = "Dodanie autora/ów do książki nie powiodło się"
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
                _logger.Error(err, "Book_AuthorService.AddBook_Author");
                throw;
            }
        }

        public ResponseModel<bool> DeleteBook_Author(Guid bookId)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetBook_AuthorRepository.Delete(bookId);
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
                            Message = "Usuwanie nie powiodło się"
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
                _logger.Error(err, "Book_AuthorService.DeleteBook_Author");
                throw;
            }
        }
    }
}
