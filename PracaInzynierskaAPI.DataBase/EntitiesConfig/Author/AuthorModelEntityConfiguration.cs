using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracaInzynierskaAPI.Entities.Author;
using PracaInzynierskaAPI.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.EntitiesConfig.Author
{
    public class AuthorModelEntityConfiguration : IEntityTypeConfiguration<AuthorDbModel>
    {
        public void Configure(EntityTypeBuilder<AuthorDbModel> builder)
        {
            builder.HasIndex(a => a.Surname);
            builder.HasIndex(a => a.AddedBy);

            builder.HasOne<UserDbModel>(a => a.User)
                .WithMany(u => u.Authors)
                .HasForeignKey(a => a.AddedBy)
                .HasConstraintName("Fk_Author_User")
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
        }
    }
}
