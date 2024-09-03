using Clipping.Domain.DomainObjects;

namespace Clipping.Domain.Entities
{
    public class NoticiaTag : Entity
    {
        public int NoticiaId { get; set; }
        public int TagId { get; set; }
        public Noticia Noticia { get; set; }        
        public Tag Tag { get; set; }
    }
}
