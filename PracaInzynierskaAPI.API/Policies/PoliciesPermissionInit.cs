using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.Policies
{
    public static class PoliciesPermissionInit
    {
        public static void Init(AuthorizationOptions options)
        {
            options.AddPolicy(Polices.Authors.Add, policy => policy.RequirePermission(Permissions.Authors.Add));
            options.AddPolicy(Polices.Authors.Update, policy => policy.RequirePermission(Permissions.Authors.Update));
            options.AddPolicy(Polices.Authors.Delete, policy => policy.RequirePermission(Permissions.Authors.Delete));

            options.AddPolicy(Polices.Books.Add, policy => policy.RequirePermission(Permissions.Books.Add));
            options.AddPolicy(Polices.Books.Update, policy => policy.RequirePermission(Permissions.Books.Update));
            options.AddPolicy(Polices.Books.Delete, policy => policy.RequirePermission(Permissions.Books.Delete));

            options.AddPolicy(Polices.Book_Authors.Add, policy => policy.RequirePermission(Permissions.Book_Authors.Add));
            options.AddPolicy(Polices.Book_Authors.Update, policy => policy.RequirePermission(Permissions.Book_Authors.Update));
            options.AddPolicy(Polices.Book_Authors.Delete, policy => policy.RequirePermission(Permissions.Book_Authors.Delete));

            options.AddPolicy(Polices.Book_Users.Add, policy => policy.RequirePermission(Permissions.Book_Users.Add));
            options.AddPolicy(Polices.Book_Users.Update, policy => policy.RequirePermission(Permissions.Book_Users.Update));
            options.AddPolicy(Polices.Book_Users.Delete, policy => policy.RequirePermission(Permissions.Book_Users.Delete));

            options.AddPolicy(Polices.Categories.Add, policy => policy.RequirePermission(Permissions.Categories.Add));
            options.AddPolicy(Polices.Categories.Update, policy => policy.RequirePermission(Permissions.Categories.Update));
            options.AddPolicy(Polices.Categories.Delete, policy => policy.RequirePermission(Permissions.Categories.Delete));

            options.AddPolicy(Polices.Comments.Add, policy => policy.RequirePermission(Permissions.Comments.Add));
            options.AddPolicy(Polices.Comments.Update, policy => policy.RequirePermission(Permissions.Comments.Update));
            options.AddPolicy(Polices.Comments.Delete, policy => policy.RequirePermission(Permissions.Comments.Delete));

            options.AddPolicy(Polices.ImageCovers.Add, policy => policy.RequirePermission(Permissions.ImageCovers.Add));
            options.AddPolicy(Polices.ImageCovers.Update, policy => policy.RequirePermission(Permissions.ImageCovers.Update));
            options.AddPolicy(Polices.ImageCovers.Delete, policy => policy.RequirePermission(Permissions.ImageCovers.Delete));

            options.AddPolicy(Polices.Languages.Add, policy => policy.RequirePermission(Permissions.Languages.Add));
            options.AddPolicy(Polices.Languages.Update, policy => policy.RequirePermission(Permissions.Languages.Update));
            options.AddPolicy(Polices.Languages.Delete, policy => policy.RequirePermission(Permissions.Languages.Delete));

            options.AddPolicy(Polices.Logs.Read, policy => policy.RequirePermission(Permissions.Logs.Read));

            options.AddPolicy(Polices.Publishers.Add, policy => policy.RequirePermission(Permissions.Publishers.Add));
            options.AddPolicy(Polices.Publishers.Update, policy => policy.RequirePermission(Permissions.Publishers.Update));
            options.AddPolicy(Polices.Publishers.Delete, policy => policy.RequirePermission(Permissions.Publishers.Delete));

            options.AddPolicy(Polices.Users.Update, policy => policy.RequirePermission(Permissions.Users.Update));
            options.AddPolicy(Polices.Users.Delete, policy => policy.RequirePermission(Permissions.Users.Delete));
            options.AddPolicy(Polices.Users.ReadAll, policy => policy.RequirePermission(Permissions.Users.ReadAll));

            options.AddPolicy(Polices.UserPermissions.Read, policy => policy.RequirePermission(Permissions.UserPermissions.Read));
            options.AddPolicy(Polices.UserPermissions.Add, policy => policy.RequirePermission(Permissions.UserPermissions.Add));
            options.AddPolicy(Polices.UserPermissions.Update, policy => policy.RequirePermission(Permissions.UserPermissions.Update));
            options.AddPolicy(Polices.UserPermissions.Delete, policy => policy.RequirePermission(Permissions.UserPermissions.Delete));
        }
    }
}
