using Microsoft.AspNetCore.Authorization;
using PracaInzynierskaAPI.API.PInzPermissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.PoliciesAndPermissions
{
    public static class PolicesAndPermisionsInitiator
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="options"></param>
        public static void Init(AuthorizationOptions options)
        {
            options.AddPolicy(Policies.Author.Approve, policy => policy.RequirePermission(Permissions.Author.Approve));
            options.AddPolicy(Policies.Author.Update, policy => policy.RequirePermission(Permissions.Author.Update));
            options.AddPolicy(Policies.Author.SoftDelete, policy => policy.RequirePermission(Permissions.Author.SoftDelete));
            options.AddPolicy(Policies.Author.Delete, policy => policy.RequirePermission(Permissions.Author.Delete));

            options.AddPolicy(Policies.Book.Approve, policy => policy.RequirePermission(Permissions.Book.Approve));
            options.AddPolicy(Policies.Book.Update, policy => policy.RequirePermission(Permissions.Book.Update));
            options.AddPolicy(Policies.Book.SoftDelete, policy => policy.RequirePermission(Permissions.Book.SoftDelete));
            options.AddPolicy(Policies.Book.Delete, policy => policy.RequirePermission(Permissions.Book.Delete));

            options.AddPolicy(Policies.Book_Author.Delete, policy => policy.RequirePermission(Permissions.Book_Author.Delete));

            options.AddPolicy(Policies.Book_User.Delete, policy => policy.RequirePermission(Permissions.Book_User.Delete));

            options.AddPolicy(Policies.Category.Write, policy => policy.RequirePermission(Permissions.Category.Write));
            options.AddPolicy(Policies.Category.Update, policy => policy.RequirePermission(Permissions.Category.Update));
            options.AddPolicy(Policies.Category.SoftDelete, policy => policy.RequirePermission(Permissions.Category.SoftDelete));
            options.AddPolicy(Policies.Category.Delete, policy => policy.RequirePermission(Permissions.Category.Delete));

            options.AddPolicy(Policies.Comment.Update, policy => policy.RequirePermission(Permissions.Comment.Update));
            options.AddPolicy(Policies.Comment.SoftDelete, policy => policy.RequirePermission(Permissions.Comment.SoftDelete));

            options.AddPolicy(Policies.ImageCover.Update, policy => policy.RequirePermission(Permissions.ImageCover.Update));
            options.AddPolicy(Policies.ImageCover.Delete, policy => policy.RequirePermission(Permissions.ImageCover.Delete));

            options.AddPolicy(Policies.Language.Write, policy => policy.RequirePermission(Permissions.Language.Write));
            options.AddPolicy(Policies.Language.Update, policy => policy.RequirePermission(Permissions.Language.Write));
            options.AddPolicy(Policies.Language.SoftDelete, policy => policy.RequirePermission(Permissions.Language.Write));

            options.AddPolicy(Policies.NLogs.Read, policy => policy.RequirePermission(Permissions.NLogs.Read));

            options.AddPolicy(Policies.Publisher.Write, policy => policy.RequirePermission(Permissions.Publisher.Write));
            options.AddPolicy(Policies.Publisher.Update, policy => policy.RequirePermission(Permissions.Publisher.Update));
            options.AddPolicy(Policies.Publisher.SoftDelete, policy => policy.RequirePermission(Permissions.Publisher.SoftDelete));

            options.AddPolicy(Policies.User.Update, policy => policy.RequirePermission(Permissions.User.Update));
            options.AddPolicy(Policies.User.Delete, policy => policy.RequirePermission(Permissions.User.Delete));

            options.AddPolicy(Policies.UserPermission.Write, policy => policy.RequirePermission(Permissions.UserPermission.Write));
            options.AddPolicy(Policies.UserPermission.Update, policy => policy.RequirePermission(Permissions.UserPermission.Update));
            options.AddPolicy(Policies.UserPermission.Delete, policy => policy.RequirePermission(Permissions.UserPermission.Delete));
        }
    }
}
