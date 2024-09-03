using Clipping.Domain.Entities;

namespace Clipping.Business.Interfaces
{
    public interface INoticiaAppService : IDisposable
    {
        Task<IEnumerable<Noticia>> ObterTodos();
        Task<List<Noticia>> ObterNoticiasComTags();
        Task<Noticia> ObterPorId(int id);
        Task<Noticia> ObterDetalhesNoticia(int id);
        Task CriarNoticia(Noticia noticia);
        Task DeletarNoticia(int id);
        Task EditarNoticia(Noticia noticia);
    }
}
