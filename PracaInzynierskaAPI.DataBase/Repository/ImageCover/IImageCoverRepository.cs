using PracaInzynierskaAPI.Entities.ImageCover;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.ImageCover
{
    public interface IImageCoverRepository
    {
        public ResponseModel<ImageCoverDbModel> GetById(Guid id);
        public ResponseModel<Guid> Add(ImageCoverDbModel imageCover);
        public ResponseModel<Guid> Update(ImageCoverDbModel imageCover);
        public ResponseModel<Guid> Delete(Guid id);
    }
}
