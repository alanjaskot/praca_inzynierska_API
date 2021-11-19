using PracaInzynierskaAPI.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.DTO.Publisher
{
    public class PublisherDTO: BaseCreatedLastModifiedDeletedEntity
    {
        public string PublisherName { get; set; }
#nullable enable
        public string? City { get; set; }
        public string? PostCode { get; set; }
        public string? Street { get; set; }
        public string? Building { get; set; }
        public string? Premises { get; set; }
#nullable disable

        //foreign key
        public Guid AddedBy { get; set; }
    }
}
