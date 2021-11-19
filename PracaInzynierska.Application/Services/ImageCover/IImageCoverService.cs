using PracaInzynierska.Application.DTO.ImageCover;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services.ImageCover
{
    public interface IImageCoverService
    {
        public ResponseModel<ImageCoverDTO> GetImageCoverById(Guid id);
        public ResponseModel<Guid> AddImageCover(ImageCoverDTO imageCover);
        public ResponseModel<Guid> UpdateImageCover(ImageCoverDTO imageCover);
        public ResponseModel<Guid> Delete(Guid id);
    }
}
