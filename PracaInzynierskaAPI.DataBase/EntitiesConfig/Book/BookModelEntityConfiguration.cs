using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracaInzynierskaAPI.Entities.Author;
using PracaInzynierskaAPI.Entities.Book;
using PracaInzynierskaAPI.Entities.Book_Author;
using PracaInzynierskaAPI.Entities.Category;
using PracaInzynierskaAPI.Entities.ImageCover;
using PracaInzynierskaAPI.Entities.Language;
using PracaInzynierskaAPI.Entities.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.EntitiesConfig.Book
{
    public class BookModelEntityConfiguration : IEntityTypeConfiguration<BookDbModel>
    {
        public void Configure(EntityTypeBuilder<BookDbModel> builder)
        {
            builder.HasIndex(b => b.Title);
            builder.Property(b => b.Title).IsRequired(true);

            builder.HasOne<ImageCoverDbModel>(b => b.ImageCover)
                .WithOne(ic => ic.Book)
                .HasForeignKey<BookDbModel>(b => b.ImageCoverId)
                .HasConstraintName("Fk_Book_ImageCover")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<CategoryDbModel>(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .HasConstraintName("Fk_Book_Category")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne<LanguageDbModel>(b => b.Language)
                .WithMany(l => l.Books)
                .HasForeignKey(b => b.LanguageId)
                .HasConstraintName("Fk_Book_Language")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne<PublisherDbModel>(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId)
                .HasConstraintName("Fk_Book_Publisher")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
