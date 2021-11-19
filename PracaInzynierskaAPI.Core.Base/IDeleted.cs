using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.Core.Base
{
    public interface IDeleted
    {
#nullable enable 
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
#nullable disable
    }
}
