using Clipping.Domain.DomainObjects;

namespace Clipping.Domain.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public virtual ICollection<Noticia>? Noticias { get; set; }
    }
}
