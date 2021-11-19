using PracaInzynierskaAPI.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.DTO.Category
{
    public class CategoryDTO : BaseCreatedLastModifiedDeletedEntity
    {
        public string Category { get; set; }

        //foreign key
        public Guid UserId { get; set; }
    }
}
