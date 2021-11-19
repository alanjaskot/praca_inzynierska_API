using PracaInzynierskaAPI.Core.Abstraction;
using PracaInzynierskaAPI.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.Entities.UserPermission
{
    public class UserPermissionDbModel: BaseCreatedLastModifiedDeletedEntity
    {
        public string PermissionName { get; set; }
        
        //foreign ket
        public Guid UserId { get; set; }
        public UserDbModel User { get; set; }
    }
}
