using PracaInzynierskaAPI.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.DTO.ImageCover
{
    public class ImageCoverDTO: BaseCreatedLastModifiedDeletedEntity
    {
        public string ImageTitle { get; set; }
        public byte[] ImageFile { get; set; }
    }
}
