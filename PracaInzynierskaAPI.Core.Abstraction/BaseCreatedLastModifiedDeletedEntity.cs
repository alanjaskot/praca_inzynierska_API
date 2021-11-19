using PracaInzynierskaAPI.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.Core.Abstraction
{
    public abstract class BaseCreatedLastModifiedDeletedEntity : BaseCreatedLastModifiedEntity, IDeleted
    {
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
