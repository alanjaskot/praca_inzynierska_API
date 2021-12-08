using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.PoliciesAndPermissions
{
    public class PermissionAuthorizationRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// zawartosc uprawnienia
        /// </summary>
        public string RequiredPermission { get; private set; }

        /// <summary>
        /// konstruktor
        /// </summary>
        /// <param name="requiredPermission">uprawnienie</param>
        public PermissionAuthorizationRequirement(string requiredPermission)
        {
            RequiredPermission = requiredPermission;
        }
    }
}
