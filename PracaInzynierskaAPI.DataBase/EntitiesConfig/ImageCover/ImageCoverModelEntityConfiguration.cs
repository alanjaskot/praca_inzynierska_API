using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracaInzynierskaAPI.Entities.ImageCover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.EntitiesConfig.ImageCover
{
    public class ImageCoverModelEntityConfiguration : IEntityTypeConfiguration<ImageCoverDbModel>
    {
        public void Configure(EntityTypeBuilder<ImageCoverDbModel> builder)
        {
            builder.Property(ic => ic.ImageTitle).IsRequired(true);
            builder.Property(ic => ic.ImageFile).IsRequired(true);
        }
    }
}
