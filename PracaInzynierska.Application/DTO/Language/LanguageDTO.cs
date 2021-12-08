using PracaInzynierskaAPI.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.DTO.Language
{
    public class LanguageDTO: BaseCreatedLastModifiedDeletedEntity
    {
        public string Language { get; set; }

        //foreign key
        public Guid AddedBy { get; set; }
    }
}
