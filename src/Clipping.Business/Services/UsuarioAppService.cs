using Clipping.Business.Interfaces;
using Clipping.Domain.Entities;
using Clipping.Domain.Interfaces;

namespace Clipping.Business.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioAppService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<Usuario>> ObterTodos() => await _usuarioRepository.ObterTodos();

        public async Task<Usuario> ObterPorId(int id) => await _usuarioRepository.ObterPorId(id);

        public async Task CriarUsuario(Usuario usuario) => await _usuarioRepository.Adicionar(usuario);         

        public async Task DeletarUsuario(int id) => await _usuarioRepository.Remover(id);         

        public async Task EditarUsuario(Usuario usuario) => await _usuarioRepository.Atualizar(usuario);

        public void Dispose() => _usuarioRepository.Dispose();
       
    }
}
