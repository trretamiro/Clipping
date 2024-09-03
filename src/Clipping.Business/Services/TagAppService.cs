using Clipping.Business.Interfaces;
using Clipping.Domain.Entities;
using Clipping.Domain.Interfaces;

namespace Clipping.Business.Services
{
    public class TagAppService : ITagAppService
    {
        private readonly ITagRepository _tagRepository;

        public TagAppService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }   

        public async Task<IEnumerable<Tag>> ObterTodos() => await _tagRepository.ObterTodos();

        public async Task<Tag> ObterPorId(int id) => await _tagRepository.ObterPorId(id);

        //public async Task<IEnumerable<Tag>> ObterPorNoticias(List<int> noticias) => await _tagRepository.ObterPorNoticias(noticias);

        public async Task CriarTag(Tag tag) => await _tagRepository.Adicionar(tag);

        public async Task DeletarTag(int id) => await _tagRepository.Remover(id);        

        public async Task EditarTag(Tag tag) => await _tagRepository.Atualizar(tag);        

        public void Dispose() => _tagRepository.Dispose();
        
    }
}
