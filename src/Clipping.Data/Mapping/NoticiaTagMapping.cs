using Clipping.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clipping.Data.Mapping
{
    public class NoticiaTagMapping : IEntityTypeConfiguration<NoticiaTag>
    {
        public void Configure(EntityTypeBuilder<NoticiaTag> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.NoticiaId)
               .IsRequired();

            builder.Property(c => c.TagId)
                .IsRequired();

            builder.HasOne(c => c.Noticia)
              .WithMany(p => p.NoticiaTags)
              .HasForeignKey(p => p.NoticiaId);

            builder.HasOne(c => c.Tag)
                .WithMany(p => p.NoticiasTags)
                .HasForeignKey(p => p.TagId);

            builder.ToTable("NoticiaTag");
        }
    }
}
