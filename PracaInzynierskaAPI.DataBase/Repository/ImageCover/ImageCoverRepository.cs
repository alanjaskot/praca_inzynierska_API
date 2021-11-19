using Microsoft.EntityFrameworkCore;
using NLog;
using PracaInzynierskaAPI.DataBase.Context;
using PracaInzynierskaAPI.Entities.ImageCover;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.ImageCover
{
    public class ImageCoverRepository: IImageCoverRepository
    {
        private readonly IPInzDataBaseContext _context;
        private ILogger _logger;

        public ImageCoverRepository(IPInzDataBaseContext context)
        {
            _context = context;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ResponseModel<ImageCoverDbModel> GetById(Guid id)
        {
            var result = default(ImageCoverDbModel);
            try
            {
                result = _context.ImageCovers
                    .Where(ic => ic.Id == id
                    && ic.IsDeleted != true)
                    .FirstOrDefault();

                if (result == null)
                    return new ResponseModel<ImageCoverDbModel>
                    {
                        Success = true,
                        Message = "Brak żądanych danych w bazie danych"
                    };

                if (result != null)
                    return new ResponseModel<ImageCoverDbModel>
                    {
                        Success = true,
                        Message = null,
                        Object = result
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "ImageCoverRepository.GetById");
                throw;
            }
            return new ResponseModel<ImageCoverDbModel>
            {
                Success = false,
                Message = "Pobieranie danych z bazy danych nie powiodło się"
            };
        }

        public ResponseModel<Guid> Add(ImageCoverDbModel imageCover)
        {
            if (imageCover == null)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Wprowadzony obiekt jest pusty"
                };

            if (imageCover.Id == Guid.Empty)
                imageCover.Id = Guid.NewGuid();
            try
            {
                var added = _context.ImageCovers.Add(imageCover);
                if (added.State == EntityState.Added)
                    return new ResponseModel<Guid>
                    {
                        Success = true,
                        Message = null,
                        Object = imageCover.Id
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "ImageCoverRepository.Add");
                throw;
            }
            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Zapis do bazy danych nie powiódł się"
            };
        }

        public ResponseModel<Guid> Update(ImageCoverDbModel imageCover)
        {
            if (imageCover == null)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Wprowadzony obiekt jest pusty"
                };

            if (imageCover.Id == Guid.Empty)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Identyfikator obiektu nie może być pusty"
                };

            try
            {
                var updated = _context.ImageCovers.Update(imageCover);
                if (updated.State == EntityState.Modified)
                    return new ResponseModel<Guid>
                    {
                        Success = true,
                        Message = null,
                        Object = imageCover.Id
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "ImageCoverRepository.Update");
                throw;
            }
            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Modyfikacja nie powiódła się"
            };
        }

        public ResponseModel<Guid> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return new ResponseModel<Guid>
                {
                    Success = false,
                    Message = "Identyfikator nie może być pusty"
                };

            try
            {
                var imageCover = GetById(id);
                if (imageCover.Object == null)
                    return new ResponseModel<Guid>
                    {
                        Success = false,
                        Message = "Obiekt o podanym identyfikatorze nie istnieje"
                    };

                var deleted = _context.ImageCovers.Remove(imageCover.Object);
                if (deleted.State == EntityState.Deleted)
                    return new ResponseModel<Guid>
                    {
                        Success = true,
                        Message = null,
                        Object = id
                    };
            }
            catch (Exception err)
            {
                _logger.Error(err, "ImageCoverRepository.Update");
                throw;
            }
            return new ResponseModel<Guid>
            {
                Success = false,
                Message = "Usuwanie zdjęcia zakończone niepowodzeniem"
            };
        }
    }
}
