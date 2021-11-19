using Microsoft.EntityFrameworkCore;
using NLog;
using PracaInzynierskaAPI.DataBase.Context;
using PracaInzynierskaAPI.Entities.Comment;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.Comment
{
    public class CommentRepository: ICommentRepository
    {
        private readonly IPInzDataBaseContext _context;
        private ILogger _logger;

        public CommentRepository(IPInzDataBaseContext context)
        {
            _context = context;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ResponseModel<List<CommentDbModel>> GetAllByBook(Guid bookId)
        {
            var result = default(List<CommentDbModel>);
            try
            {
                result = _context.Comments
                    .Where(c => c.BookId == bookId
                    && c.IsDeleted != true)
                    .ToList();

                if (result == null)
                    return new ResponseModel<List<CommentDbModel>>
                    {
                        Success = true,
                        Message = "Brak żądanych danych w bazie danych"
                    };

                if (result != null)
                    return new ResponseModel<List<CommentDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "CommentRepo.GetAllByBook");
                throw;
            }
            return new ResponseModel<List<CommentDbModel>>
            {
                Success = false,
                Message = "Pobieranie danych z bazy danych nie powiodło się"
            };
        }

        public ResponseModel<List<CommentDbModel>> GetAllByUser(Guid userId)
        {
            var result = default(List<CommentDbModel>);
            try
            {
                result = _context.Comments
                    .Where(c => c.AddedBy == userId
                    && c.IsDeleted != true)
                    .ToList();

                if (result == null)
                    return new ResponseModel<List<CommentDbModel>>
                    {
                        Success = true,
                        Message = "Brak żądanych danych w bazie danych"
                    };

                if (result != null)
                    return new ResponseModel<List<CommentDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "CommentRepo.GetAllByUser");
                throw;
            }

            return new ResponseModel<List<CommentDbModel>>
            {
                Success = false,
                Message = "Pobieranie danych z bazy danych nie powiodło się"
            };
        }

        public ResponseModel<List<CommentDbModel>> GetAllByComment(Guid commentId)
        {
            var result = default(List<CommentDbModel>);
            try
            {
                result = _context.Comments
                    .Where(c => (c.CommentId == commentId || c.Id == commentId) && c.IsDeleted != true)
                    .ToList();

                if (result == null)
                    return new ResponseModel<List<CommentDbModel>>
                    {
                        Success = true,
                        Message = "Brak żądanych danych w bazie danych"
                    };

                if (result != null)
                    return new ResponseModel<List<CommentDbModel>>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "CommentRepo.GetAllByUser");
                throw;
            }

            return new ResponseModel<List<CommentDbModel>>
            {
                Success = false,
                Message = "Pobieranie danych z bazy danych nie powiodło się"
            };
        }

        public ResponseModel<CommentDbModel> GetById(Guid id)
        {
            var result = default(CommentDbModel);
            try
            {
                result = _context.Comments
                    .Where(c => c.Id == id)
                    .FirstOrDefault();

                if (result == null)
                    return new ResponseModel<CommentDbModel>
                    {
                        Success = true,
                        Message = "Brak żądanych danych w bazie danych"
                    };

                if (result != null)
                    return new ResponseModel<CommentDbModel>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "CommentRepo.GetById");
                throw;
            }
            return new ResponseModel<CommentDbModel>
            {
                Success = false,
                Message = "Pobieranie danych z bazy danych nie powiodło się"
            };
        }

        public ResponseModel<Guid> Add(CommentDbModel comment)
        {
            if (comment == null)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Wprowadzony obiekt jest pusty"
                };

            if (comment.Id == Guid.Empty)
                comment.Id = Guid.NewGuid();

            try
            {
                if (comment != null)
                {
                    var added = _context.Comments.Add(comment);
                    if (added.State == EntityState.Added)
                        return new ResponseModel<Guid>
                        {
                            Success = true,
                            Message = null,
                            Object = comment.Id
                        };
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "CommentRepo.Add");
                throw;
            }
            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Zapisanie komentarza nie powiodło się"
            };
        }

        public ResponseModel<Guid> Update(CommentDbModel comment)
        {
            if (comment == null)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Wprowadzony obiekt jest pusty"
                };
            try
            {
                if ( comment != null)
                {
                    comment.IsModified = true;
                    var update = _context.Comments.Update(comment);
                    if (update.State == EntityState.Modified)
                        return new ResponseModel<Guid>
                        {
                            Success = true,
                            Message = null,
                            Object = comment.Id
                        };
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "CommentRepo.Update");
                throw;
            }
            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Modyfikacja komentarza nie powiodło się"
            };
        }

        public ResponseModel<Guid> SoftDelete(CommentDbModel comment)
        {
            if (comment == null)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Wprowadzony obiekt jest pusty"
                };

            try
            {
                if (comment != null)
                {
                    comment.Comment = "komentarz został usunięty";
                    comment.IsDeleted = true;
                    comment.DeletedAt = DateTime.Now;
                    var softDeleted = _context.Comments.Remove(comment);
                    if (softDeleted.State == EntityState.Deleted)
                        return new ResponseModel<Guid>
                        {
                            Success = true,
                            Message = null,
                            Object = comment.Id
                        };
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "CommentRepo.Delete");
                throw;
            }
            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Usuwanie komentarza nie powiodło się"
            };
        }
    }
}
