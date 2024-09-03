using Clipping.Data.Contexto;
using Clipping.Domain.Entities;
using Clipping.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clipping.Data.Repository
{
    public class NoticiaRepository : GenericRepository<Noticia>, INoticiaRepository
    {
        public NoticiaRepository(ClippingDbContext context) : base(context) { }

        public async Task<Noticia> ObterDetalhesNoticia(int id)
        {
            return await Db.Noticias.AsNoTracking()
                .Include(u => u.Usuario)
                .Include(nt => nt.NoticiaTags)
                .ThenInclude(t => t.Tag)
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<List<Noticia>> ObterNoticiasComTags()
        {
            return await Db.Noticias.AsNoTracking()
                .Include(u => u.Usuario)
                .Include(nt => nt.NoticiaTags)
                .ThenInclude(t => t.Tag)
                .ToListAsync();
        }
    }
}
