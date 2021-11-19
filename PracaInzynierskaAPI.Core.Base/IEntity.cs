using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.Core.Base
{
    public interface IEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }

    public interface IEntity: IEntity<Guid>
    {
        public bool IsBuildIn { get; set; }
    }
}
