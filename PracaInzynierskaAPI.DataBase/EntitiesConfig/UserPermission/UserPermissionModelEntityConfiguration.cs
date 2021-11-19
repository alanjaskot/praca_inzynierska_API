using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracaInzynierskaAPI.Entities.UserPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.EntitiesConfig.UserPermission
{
    public class UserPermissionModelEntityConfiguration : IEntityTypeConfiguration<UserPermissionDbModel>
    {
        public void Configure(EntityTypeBuilder<UserPermissionDbModel> builder)
        {
            builder.HasIndex(up => up.PermissionName);
            builder.Property(up => up.Id).IsRequired(true);
            builder.Property(up => up.CreatedAt).IsRequired(true);
        }
    }
}
