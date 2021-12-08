using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.PoliciesAndPermissions
{
    /// <summary>
    /// rozszezenie do obslugi polic uprawnien
    /// </summary>
    public static class AuthorizationPolicyBuilderExtension
    {
        /// <summary>
        /// metoda ??
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public static AuthorizationPolicyBuilder RequirePermission(this AuthorizationPolicyBuilder builder, string permission)
        {
            builder.Requirements.Add(new PermissionAuthorizationRequirement(permission));

            return builder;
        }
    }
}
