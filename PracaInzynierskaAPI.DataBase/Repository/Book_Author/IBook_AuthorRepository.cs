using PracaInzynierskaAPI.Entities.Book_Author;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.Book_Author
{
    public interface IBook_AuthorRepository
    {
        public ResponseModel<List<Guid>> GetAllBooksByAuthor(Guid id);
        public ResponseModel<List<Guid>> GetAllAuthorsByBook(Guid id);
        public ResponseModel<List<Guid>> Add(List<Book_AuthorDbModel> book_author);
        public ResponseModel<bool> Delete(Guid bookId);
    }
}
