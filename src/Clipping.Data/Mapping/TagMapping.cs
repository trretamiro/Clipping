using Clipping.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clipping.Data.Mapping
{
    public class TagMapping : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.HasMany(c => c.NoticiasTags)
                .WithOne(p => p.Tag)
                .HasForeignKey(p => p.TagId);

            builder.ToTable("Tags");
        }
    }
}
