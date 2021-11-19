using PracaInzynierskaAPI.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.Core.Abstraction
{
    public abstract class BaseCreatedEntity : BaseEntity, ICreated
    {
        public DateTime CreatedAt { get; set; }
    }
}
