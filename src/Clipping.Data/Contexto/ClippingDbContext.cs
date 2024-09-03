using Clipping.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clipping.Data.Contexto
{
    public class ClippingDbContext : DbContext
    {
        public ClippingDbContext(DbContextOptions<ClippingDbContext> options) : base(options) 
        {
            //Database.EnsureDeleted();
            if (!Database.CanConnect())
            {                
                Database.EnsureCreated();
            }
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<NoticiaTag> NoticiaTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClippingDbContext).Assembly);

        }

    }
}
