using Clipping.Domain.Entities;

namespace Clipping.Domain.Interfaces
{
    public interface INoticiaRepository : IGenericRepository<Noticia>
    {
        Task<List<Noticia>> ObterNoticiasComTags();
        Task<Noticia> ObterDetalhesNoticia(int id);
    }
}
