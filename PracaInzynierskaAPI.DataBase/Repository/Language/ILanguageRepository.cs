using PracaInzynierskaAPI.Entities.Language;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.Language
{
    public interface ILanguageRepository
    {
        public ResponseModel<List<LanguageDbModel>> GetAll();
        public ResponseModel<LanguageDbModel> GetById(Guid id);
        public ResponseModel<List<LanguageDbModel>> GetByName(string name);
        public ResponseModel<Guid> Add(LanguageDbModel language);
        public ResponseModel<Guid> Update(LanguageDbModel language);
        public ResponseModel<Guid> SoftDelete(LanguageDbModel language);
    }
}
