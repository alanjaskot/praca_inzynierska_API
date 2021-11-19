using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.Policies
{
    public class PermissionAuthorizationRequirement: IAuthorizationRequirement
    {
        public string RequiredPermission { get; private set; }

        public PermissionAuthorizationRequirement(string requiredPermission)
        {
            RequiredPermission = requiredPermission;
        }
    }
}
