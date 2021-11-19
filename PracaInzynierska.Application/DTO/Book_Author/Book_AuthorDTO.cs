using PracaInzynierskaAPI.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.DTO.Book_Author
{
    public class Book_AuthorDTO: BaseCreatedLastModifiedDeletedEntity
    {
        public Guid AuthorId { get; set; }
        public Guid BookId { get; set; }

    }
}
