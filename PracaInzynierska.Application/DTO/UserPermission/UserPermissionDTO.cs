using PracaInzynierskaAPI.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.DTO.UserPermission
{
    public class UserPermissionDTO: BaseCreatedLastModifiedDeletedEntity
    {
        public string PermissionName { get; set; }

        //foreign key
        public Guid UserId { get; set; }
    }
}
