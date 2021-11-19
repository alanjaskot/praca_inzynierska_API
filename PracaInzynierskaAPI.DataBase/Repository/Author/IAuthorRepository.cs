using PracaInzynierskaAPI.Entities.Author;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.Author
{
    public interface IAuthorRepository
    {
        public ResponseModel<List<AuthorDbModel>> GetAll();
        public ResponseModel<List<AuthorDbModel>> GetToApprove();
        public ResponseModel<List<AuthorDbModel>> FindByName(List<string> list);
        public ResponseModel<List<AuthorDbModel>> GetByIds(List<Guid> list);
        public ResponseModel<AuthorDbModel> GetById(Guid id);
        public ResponseModel<Guid> Add(AuthorDbModel author);
        public ResponseModel<bool> Approve(AuthorDbModel author);
        public ResponseModel<Guid> Update(AuthorDbModel author);
        public ResponseModel<List<Guid>> SoftDelete(List<AuthorDbModel> authors);
        public ResponseModel<Guid> Delete(Guid id);
    }
}
