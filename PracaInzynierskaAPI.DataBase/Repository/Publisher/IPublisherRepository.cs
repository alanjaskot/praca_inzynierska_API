using PracaInzynierskaAPI.Entities.Publisher;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.Publisher
{
    public interface IPublisherRepository
    {
        public ResponseModel<List<PublisherDbModel>> GetAll();
        public ResponseModel<List<PublisherDbModel>> FindByName(List<String> name);
        public ResponseModel<PublisherDbModel> GetById(Guid id);
        public ResponseModel<Guid> Add(PublisherDbModel publisher);
        public ResponseModel<Guid> Update(PublisherDbModel publisher);
        public ResponseModel<Guid> SoftDelete(PublisherDbModel publisher);
    }
}
