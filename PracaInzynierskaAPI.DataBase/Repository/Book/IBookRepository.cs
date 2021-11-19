using PracaInzynierskaAPI.Entities.Book;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.Book
{
    public interface IBookRepository
    {
        public ResponseModel<List<BookDbModel>> GetAll();
        public ResponseModel<List<BookDbModel>> GetToApprove();
        public ResponseModel<List<BookDbModel>> GetByList(List<Guid> list);
        public ResponseModel<List<BookDbModel>> GetByCategory(Guid id);
        public ResponseModel<List<BookDbModel>> GetByPublisher(Guid id);
        public ResponseModel<List<BookDbModel>> GetHighlightedByMonth();
        public ResponseModel<List<BookDbModel>> GetHighlightedByYear();
        public ResponseModel<List<BookDbModel>> GetHighlighted();
        public ResponseModel<List<BookDbModel>> FindByName(List<string> name);
        public ResponseModel<BookDbModel> GetById(Guid id);
        public ResponseModel<Guid> Add(BookDbModel book);
        public ResponseModel<decimal> AddPlusOrMinus(Guid bookId, long plus);
        public ResponseModel<bool> Approve(List<BookDbModel> book);
        public ResponseModel<Guid> Update(BookDbModel book);
        public ResponseModel<List<Guid>> SoftDelete(List<BookDbModel> book);
        public ResponseModel<Guid> Delete(Guid id);
    }
}
