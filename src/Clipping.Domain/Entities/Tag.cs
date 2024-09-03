using Clipping.Domain.DomainObjects;

namespace Clipping.Domain.Entities
{
    public class Tag : Entity
    {
        public string Descricao { get; set; } = string.Empty;

        public ICollection<NoticiaTag> NoticiasTags { get; set; }
        
    }
}
