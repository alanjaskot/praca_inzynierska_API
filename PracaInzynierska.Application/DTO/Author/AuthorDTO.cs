using PracaInzynierskaAPI.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.DTO.Author
{
    public class AuthorDTO: BaseCreatedLastModifiedDeletedEntity
    {
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsApproved { get; set; }
#nullable enable
        public string? Name { get; set; }
        public string? SecondName { get; set; }
        public DateTime? DeathDate { get; set; }
        public string? Biography { get; set; }
#nullable disable

        //foreign key
        public Guid AddedBy { get; set; }
    }
}
