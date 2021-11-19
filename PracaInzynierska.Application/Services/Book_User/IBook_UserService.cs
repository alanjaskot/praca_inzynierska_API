using PracaInzynierska.Application.DTO.Book_User;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;


namespace PracaInzynierska.Application.Services.Book_User
{
    public interface IBook_UserService
    {
        public ResponseModel<List<Guid>> GetBooksByUser(Guid userId);
        public ResponseModel<Guid> AddBook_User(Book_UserDTO book_user);
        public ResponseModel<Guid> DeleteBook_User(Guid id);
    }
}
