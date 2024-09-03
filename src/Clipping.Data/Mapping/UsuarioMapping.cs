
using Clipping.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clipping.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(c => c.Email)
               .HasColumnType("varchar(250)")
               .IsRequired();

            builder.Property(c => c.Senha)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasMany(c => c.Noticias)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.UsuarioId);

            builder.ToTable("Usuarios");
        }
    }
}
