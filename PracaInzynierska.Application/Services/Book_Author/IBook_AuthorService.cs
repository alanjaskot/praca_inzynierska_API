using PracaInzynierska.Application.DTO.Book_Author;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services.Book_Author
{
    public interface IBook_AuthorService
    {
        public ResponseModel<List<Guid>> GetAllBooksByAuthor(Guid authorId);
        public ResponseModel<List<Guid>> GetAllAuthorsByBook(Guid bookId);
        public ResponseModel<List<Guid>> AddBook_Author(List<Book_AuthorDTO> book_author);
        public ResponseModel<Guid> DeleteBook_Author(Guid id);
    }
}
