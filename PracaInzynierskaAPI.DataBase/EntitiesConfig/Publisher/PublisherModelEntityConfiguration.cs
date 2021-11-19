using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracaInzynierskaAPI.Entities.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.EntitiesConfig.Publisher
{
    public class PublisherModelEntityConfiguration : IEntityTypeConfiguration<PublisherDbModel>
    {
        public void Configure(EntityTypeBuilder<PublisherDbModel> builder)
        {
            builder.HasIndex(p => p.PublisherName).IsUnique(true);

            builder.Property(p => p.Id).IsRequired(true);
            builder.Property(p => p.CreatedAt).IsRequired(true);
            builder.Property(p => p.PublisherName).IsRequired(true);
        }
    }
}
