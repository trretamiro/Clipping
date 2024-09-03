using Clipping.Data.Contexto;
using Clipping.Domain.Entities;
using Clipping.Domain.Interfaces;

namespace Clipping.Data.Repository
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly ClippingDbContext _context;

        public UsuarioRepository(ClippingDbContext context) : base(context) { }

    }
}
