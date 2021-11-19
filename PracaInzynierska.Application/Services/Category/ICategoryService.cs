using PracaInzynierska.Application.DTO.Category;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services.Category
{
    public interface ICategoryService
    {
        public ResponseModel<List<CategoryDTO>> GetAllCategories();
        public ResponseModel<CategoryDTO> GetCategoryById(Guid id);
        public ResponseModel<List<CategoryDTO>> GetCategoriesByName(List<string> list);
        public ResponseModel<Guid> AddCategory(CategoryDTO category);
        public ResponseModel<Guid> UpdateCategory(CategoryDTO category);
        public ResponseModel<Guid> SoftDeleteCategory(CategoryDTO category);
        public ResponseModel<Guid> DeleteCategory(Guid id);
    }
}
