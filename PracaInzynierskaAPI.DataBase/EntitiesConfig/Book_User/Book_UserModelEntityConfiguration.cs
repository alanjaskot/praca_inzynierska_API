using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracaInzynierskaAPI.Entities.Book;
using PracaInzynierskaAPI.Entities.Book_User;
using PracaInzynierskaAPI.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.EntitiesConfig.Book_User
{
    public class Book_UserModelEntityConfiguration : IEntityTypeConfiguration<Book_UserDbModel>
    {
        public void Configure(EntityTypeBuilder<Book_UserDbModel> builder)
        {
            builder.HasOne<BookDbModel>(ba => ba.Book)
                .WithMany(b => b.BookList)
                .HasForeignKey(ba => ba.BookId)
                .HasConstraintName("Fk_BookUser_Book")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne<UserDbModel>(ba => ba.User)
                .WithMany(a => a.BooksList)
                .HasForeignKey(ba => ba.UserId)
                .HasConstraintName("Fk_BookUSer_User")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(); ;
        }
    }
}
