using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracaInzynierskaAPI.Entities.Book;
using PracaInzynierskaAPI.Entities.Comment;
using PracaInzynierskaAPI.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.EntitiesConfig.Comment
{
    public class CommentModelEntityConfiguration : IEntityTypeConfiguration<CommentDbModel>
    {
        public void Configure(EntityTypeBuilder<CommentDbModel> builder)
        {
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.CreatedAt).IsRequired();
            builder.Property(c => c.Comment).HasMaxLength(500).IsRequired();

            builder.HasOne<BookDbModel>(c => c.Book)
                .WithMany(b => b.Comments)
                .HasForeignKey(c => c.BookId)
                .HasConstraintName("Fk_Comment_Boook")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne<UserDbModel>(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.AddedBy)
                .HasConstraintName("Fk_Comment_User")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
