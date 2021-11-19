using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracaInzynierskaAPI.Entities.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.EntitiesConfig.Language
{
    public class LanguageModelEntityConfiguration : IEntityTypeConfiguration<LanguageDbModel>
    {
        public void Configure(EntityTypeBuilder<LanguageDbModel> builder)
        {
            builder.HasIndex(l => l.Language).IsUnique();

            builder.Property(l => l.Id).IsRequired();
            builder.Property(l => l.CreatedAt).IsRequired();
            builder.Property(l => l.Language).IsRequired();
        }
    }
}
