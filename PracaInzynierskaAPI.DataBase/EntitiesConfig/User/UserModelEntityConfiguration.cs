using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracaInzynierskaAPI.Entities.User;

namespace PracaInzynierskaAPI.DataBase.EntitiesConfig.User
{
    public class UserModelEntityConfiguration : IEntityTypeConfiguration<UserDbModel>
    {
        public void Configure(EntityTypeBuilder<UserDbModel> builder)
        {
            builder.HasIndex(u => new { u.Id }).IsUnique(true);
            builder.HasIndex(u => new { u.UserName }).IsUnique(true);
            builder.HasIndex(u => new { u.Email }).IsUnique(true);
            builder.HasIndex(u => new { u.Id, u.UserName, u.Email }).IsUnique(true);

            builder.Property(u => u.Id).IsRequired(true);
            builder.Property(u => u.CreatedAt).IsRequired(true);
        }
    }
}
