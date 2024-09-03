using Clipping.Domain.Entities;

namespace Clipping.Business.Interfaces
{
    public interface ITagAppService : IDisposable
    {
        Task<IEnumerable<Tag>> ObterTodos();
        Task<Tag> ObterPorId(int id);
        //Task<IEnumerable<Tag>> ObterPorNoticias(List<int> noticias);
        Task CriarTag(Tag tag);
        Task EditarTag(Tag tag);
        Task DeletarTag(int tag);
    }
}
