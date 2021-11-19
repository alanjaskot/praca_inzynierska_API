using PracaInzynierskaAPI.Entities.Comment;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.Comment
{
    public interface ICommentRepository
    {
        public ResponseModel<List<CommentDbModel>> GetAllByBook(Guid bookId);
        public ResponseModel<List<CommentDbModel>> GetAllByUser(Guid userId);
        public ResponseModel<List<CommentDbModel>> GetAllByComment(Guid commentId);
        public ResponseModel<CommentDbModel> GetById(Guid id);
        public ResponseModel<Guid> Add(CommentDbModel comment);
        public ResponseModel<Guid> Update(CommentDbModel comment);
        public ResponseModel<Guid> SoftDelete(CommentDbModel comment);
    }
}
