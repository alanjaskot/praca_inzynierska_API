using PracaInzynierskaAPI.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.DTO.Comment
{
    public class CommentDTO: BaseCreatedLastModifiedDeletedEntity
    {
        public string Comment { get; set; }

        //foreign key
        public Guid AddedBy { get; set; }
        public Guid CommentId { get; set; }
        public Guid BookId { get; set; }
    }
}
