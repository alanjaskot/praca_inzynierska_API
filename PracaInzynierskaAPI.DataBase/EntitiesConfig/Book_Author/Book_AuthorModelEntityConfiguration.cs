using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracaInzynierskaAPI.Entities.Author;
using PracaInzynierskaAPI.Entities.Book;
using PracaInzynierskaAPI.Entities.Book_Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.EntitiesConfig.Book_Author
{
    public class Book_AuthorModelEntityConfiguration : IEntityTypeConfiguration<Book_AuthorDbModel>
    {
        public void Configure(EntityTypeBuilder<Book_AuthorDbModel> builder)
        {
            builder.HasOne<BookDbModel>(ba => ba.Book)
                .WithMany(b => b.Book_Author)
                .HasForeignKey(ba => ba.BookId)
                .HasConstraintName("Fk_BookAuthor_Book")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne<AuthorDbModel>(ba => ba.Author)
                .WithMany(a => a.Book_Author)
                .HasForeignKey(ba => ba.AuthorId)
                .HasConstraintName("Fk_BookAuthor_Author")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
