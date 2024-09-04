using Clipping.Domain.Entities;

namespace Clipping.Business.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        Task<List<Usuario>> ObterTodos();
        Task<Usuario> ObterPorId(int id);
        Task CriarUsuario(Usuario usuario);
        Task EditarUsuario(Usuario usuario);   
        Task DeletarUsuario(int id);
    }
}
