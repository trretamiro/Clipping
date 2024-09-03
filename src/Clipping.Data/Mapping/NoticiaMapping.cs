using Clipping.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clipping.Data.Mapping
{
    public class NoticiaMapping : IEntityTypeConfiguration<Noticia>
    {
        public void Configure(EntityTypeBuilder<Noticia> builder)
        {

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Titulo)
               .HasColumnType("varchar(250)")
               .IsRequired();

            builder.Property(c => c.Texto)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder.HasMany(c => c.NoticiaTags)
                .WithOne(p => p.Noticia)
                .HasForeignKey(p => p.NoticiaId);

            builder.ToTable("Noticias");
        }
    }
}
