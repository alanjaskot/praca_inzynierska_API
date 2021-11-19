using AutoMapper;
using NLog;
using PracaInzynierska.Application.DTO.Book_User;
using PracaInzynierskaAPI.DataBase.UnitOfWork;
using PracaInzynierskaAPI.Entities.Book_User;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;


namespace PracaInzynierska.Application.Services.Book_User
{
    public class Book_UserService: IBook_UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private static IMapper _mapper;
        private ILogger _logger;

        public Book_UserService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ResponseModel<List<Guid>> GetBooksByUser(Guid userId)
        {
            try
            {
                var repoResponse = _unitOfWork.GetBook_UserRepository.GetBooksByUser(userId);
                if (repoResponse.Success)
                    return repoResponse;
                else
                    return repoResponse;
            }
            catch (Exception err)
            {
                _logger.Error(err, "Book_UserService.GetBooksByUser");
                throw;
            }
        }

        public ResponseModel<Guid> AddBook_User(Book_UserDTO book_user)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetBook_UserRepository.Add(_mapper.Map<Book_UserDbModel>(book_user));
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
                        return new ResponseModel<Guid>
                        {
                            Success = false,
                            Message = "Przypisanie książki do użytkownika nie powiodło się"
                        };
                    }                      
                }
                else
                {
                    _unitOfWork.RollBackTransaction();
                    return repoResponse;
                }
            }
            catch(Exception err)
            {
                _unitOfWork.RollBackTransaction();
                _logger.Error(err, "Book_UserService.AddBook_User");
                throw;
            }
        }

        public ResponseModel<Guid> DeleteBook_User(Guid id)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var repoResponse = _unitOfWork.GetBook_UserRepository.Delete(id);
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
                            Message = "Usunięcie książki z listy użytkownika nie powiodło się"
                        };
                    }     
                }
                return repoResponse;
            }
            catch (Exception err)
            {
                _unitOfWork.RollBackTransaction();
                _logger.Error(err, "Book_UserService.DeleteBook_User");
                throw;
            }
        }
    }
}
