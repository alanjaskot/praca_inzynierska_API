using PracaInzynierskaAPI.Entities.Book_User;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.Book_User
{
    public interface IBook_UserRepository
    {
        public ResponseModel<List<Guid>> GetBooksByUser(Guid userId);
        public ResponseModel<Guid> Add(Book_UserDbModel book_user);
        public ResponseModel<Guid> Delete(Guid id);
    }
}
