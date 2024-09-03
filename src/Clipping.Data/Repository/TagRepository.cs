using Clipping.Data.Contexto;
using Clipping.Domain.Entities;
using Clipping.Domain.Interfaces;

namespace Clipping.Data.Repository
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        private readonly ClippingDbContext _context;

        public TagRepository(ClippingDbContext context) : base(context) { }
    }
}
