using Clipping.Business.Interfaces;
using Clipping.Domain.Entities;
using Clipping.Domain.Interfaces;

namespace Clipping.Business.Services
{
    public class NoticiaAppService : INoticiaAppService
    {
        private readonly INoticiaRepository _noticiaRepository;

        public NoticiaAppService(INoticiaRepository noticiaRepository)
        {
            _noticiaRepository = noticiaRepository;
        }

        public async Task<IEnumerable<Noticia>> ObterTodos() => await _noticiaRepository.ObterTodos();

        public async Task<List<Noticia>> ObterNoticiasComTags() => await _noticiaRepository.ObterNoticiasComTags();        

        public async Task<Noticia> ObterPorId(int id) => await _noticiaRepository.ObterPorId(id);

        public async Task<Noticia> ObterDetalhesNoticia(int id) => await _noticiaRepository.ObterDetalhesNoticia(id);

        public async Task CriarNoticia(Noticia noticia)
        {
            await _noticiaRepository.Adicionar(noticia);
        }

        public async Task EditarNoticia(Noticia noticia)
        {
            await _noticiaRepository.Atualizar(noticia);
        }

        public async Task DeletarNoticia(int id)
        {
            await _noticiaRepository.Remover(id);
        }

        public void Dispose()
        {
            _noticiaRepository?.Dispose();
        }
    }
}
