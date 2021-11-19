using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracaInzynierskaAPI.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.EntitiesConfig.Category
{
    public class CategoryModelEntityConfiguration : IEntityTypeConfiguration<CategoryDbModel>
    {
        public void Configure(EntityTypeBuilder<CategoryDbModel> builder)
        {
            builder.HasIndex(c => c.Category).IsUnique(true);
            builder.Property(c => c.Category).IsRequired(true);
        }
    }
}
