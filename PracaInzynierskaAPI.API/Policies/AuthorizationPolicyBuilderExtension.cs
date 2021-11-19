using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.Policies
{
    public static class AuthorizationPolicyBuilderExtension
    {
        public static AuthorizationPolicyBuilder RequirePermission(this AuthorizationPolicyBuilder builder, string permission)
        {
            builder.Requirements.Add(new PermissionAuthorizationRequirement(permission));

            return builder;
        }
    }
}
