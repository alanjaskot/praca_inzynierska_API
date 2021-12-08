using Autofac;
using Microsoft.AspNetCore.Authorization;
using PracaInzynierska.Application.Services.User;
using PracaInzynierska.Application.Services.UserPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.PoliciesAndPermissions
{
    public class PermissionHandler : IAuthorizationHandler
    {
        private readonly IUserPermissionService permitsService;
        private readonly IUserService userService;
        public PermissionHandler()
        {
            var container = Startup.Container;
            this.permitsService = container.Resolve<IUserPermissionService>();
            this.userService = container.Resolve<IUserService>();

        }

        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            var pendingRequirements = context.PendingRequirements.ToList();

            foreach (var requirement in pendingRequirements)
            {
                if (requirement is PermissionAuthorizationRequirement)
                {
                    var requiredPermission = (requirement as PermissionAuthorizationRequirement).RequiredPermission;

                    var user = context.User;
                    if (string.IsNullOrEmpty(user.Identity.Name))
                        break;

                    var userFromDB = userService.GetAllUsers().Object.Where(p => p.Id == Guid.Parse(user.Identity.Name)).FirstOrDefault();
                    if (userFromDB == null)
                        break;

                    var perrFormDB = permitsService.GetAllPermissionsByUserGuid(userFromDB.Id).Object.Where(p => p.PermissionName == requiredPermission).FirstOrDefault();
                    if (perrFormDB == null)
                        break;

                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }

    }
}
