using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracaInzynierskaAPI.EncryptorDecryptor.Decrypting;
using PracaInzynierskaAPI.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            /*builder.HasData(new UserDbModel
            {
                Id = Guid.Parse("efdc156b-dc40-43e7-a48b-09fffe5dcd69"),
                UserName = "Admin",
                Password = Decryptor.Decrypt("123"),
                Email = "none",
                CreatedAt = DateTime.Now,
                IsBuildIn = true
            });*/
        }
    }
}
