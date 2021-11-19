using PracaInzynierska.Application.DTO.Book;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services.Book
{
    public interface IBookService
    {
        public ResponseModel<List<BookDTO>> GetAllBooks();
        public ResponseModel<List<BookDTO>> GetBooksToApprove();
        public ResponseModel<List<BookDTO>> GetBooksByList(List<Guid> list);
        public ResponseModel<List<BookDTO>> GetBooksByCategory(Guid id);
        public ResponseModel<List<BookDTO>> GetBooksByPublisher(Guid id);
        public ResponseModel<List<BookDTO>> GetHighlightedBooksByMonth();
        public ResponseModel<List<BookDTO>> GetHighlightedBooksByYear();
        public ResponseModel<List<BookDTO>> GetHighlightedBooks();
        public ResponseModel<List<BookDTO>> FindBooksByName(List<string> name);
        public ResponseModel<BookDTO> GetBookById(Guid id);
        public ResponseModel<Guid> AddBook(BookDTO book);
        public ResponseModel<decimal> AddPlusOrMinusToBook(Guid bookId, long plus);
        public ResponseModel<bool> ApproveBooks(List<BookDTO> book);
        public ResponseModel<Guid> UpdateBook(BookDTO book);
        public ResponseModel<List<Guid>> SoftDeleteBooks(List<BookDTO> book);
        public ResponseModel<Guid> DeleteBook(Guid id);
    }
}
