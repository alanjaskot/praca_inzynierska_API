using PracaInzynierska.Application.DTO.Language;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services.Language
{
    public interface ILanguageService
    {
        public ResponseModel<List<LanguageDTO>> GetAllLanguages();
        public ResponseModel<LanguageDTO> GetLanguageById(Guid id);
        public ResponseModel<List<LanguageDTO>> GetLanguageByName(string name);
        public ResponseModel<Guid> AddLanguage(LanguageDTO language);
        public ResponseModel<Guid> UpdateLanguage(LanguageDTO language);
        public ResponseModel<Guid> SoftDeleteLanguage(LanguageDTO language);
    }
}
