using PracaInzynierska.Application.DTO.Comment;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services.Comment
{
    public interface ICommentService
    {
        public ResponseModel<List<CommentDTO>> GetAllCommentsByBook(Guid bookId);
        public ResponseModel<List<CommentDTO>> GetAllCommentsByUser(Guid userId);
        public ResponseModel<List<CommentDTO>> GetAllCommentsByComment(Guid commentId);
        public ResponseModel<CommentDTO> GetCommentById(Guid id);
        public ResponseModel<Guid> AddComment(CommentDTO comment);
        public ResponseModel<Guid> UpdateComment(CommentDTO comment);
        public ResponseModel<Guid> SoftDeleteComment(CommentDTO comment);
    }
}
