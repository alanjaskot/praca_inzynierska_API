using PracaInzynierskaAPI.Entities.Category;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.Category
{
    public interface ICategoryRepository
    {
        public ResponseModel<List<CategoryDbModel>> GetAll();
        public ResponseModel<CategoryDbModel> GetById(Guid id);
        public ResponseModel<List<CategoryDbModel>> GetByName(List<string> list);
        public ResponseModel<Guid> Add(CategoryDbModel category);
        public ResponseModel<Guid> Update(CategoryDbModel category);
        public ResponseModel<Guid> SoftDelete(CategoryDbModel category);
        public ResponseModel<Guid> Delete(Guid id);
    }
}
