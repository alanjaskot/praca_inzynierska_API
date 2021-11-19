using PracaInzynierska.Application.DTO.Publisher;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services.Publisher
{
    public interface IPublisherService
    {
        public ResponseModel<List<PublisherDTO>> GetAllPublishers();
        public ResponseModel<List<PublisherDTO>> FindPublishersByName(List<String> name);
        public ResponseModel<PublisherDTO> GetPublisherById(Guid id);
        public ResponseModel<Guid> AddPublisher(PublisherDTO publisher);
        public ResponseModel<Guid> UpdatePublisher(PublisherDTO publisher);
        public ResponseModel<Guid> SoftDeletePublisher(PublisherDTO publisher);
    }
}
