using Microsoft.AspNetCore.Authorization;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.Policies
{
    public class PermissionHandler : IAuthorizationHandler
    {
        private readonly ILogger _logger;

        public PermissionHandler()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            var pendingRequirements = context.PendingRequirements.ToList();

            foreach (var requirement in pendingRequirements)
            {
                if (requirement is PermissionAuthorizationRequirement)
                {
                    var x = (requirement as PermissionAuthorizationRequirement).RequiredPermission;

                    var user = context.User;
                    if (string.IsNullOrEmpty(user.Identity.Name)) 
                        break;

                    context.Succeed(requirement);
                    _logger.Info($"Szukanie uprawnień: {user.Identity.Name}: {x}");
                }
            }

            return Task.CompletedTask;
        }
    }
}
