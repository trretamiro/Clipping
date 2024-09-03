using Clipping.Domain.DomainObjects;

namespace Clipping.Domain.Entities
{
    public class Noticia : Entity
    {
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public int UsuarioId { get; set;}
        public virtual Usuario Usuario { get; set; }        
        public virtual ICollection<NoticiaTag> NoticiaTags { get; set; } = new HashSet<NoticiaTag>();

        public Noticia() { }

        public Noticia(string titulo, string texto, int usuarioId, Usuario usuario, ICollection<NoticiaTag> noticiasTags)
        {
            Titulo = titulo;
            Texto = texto;
            UsuarioId = usuarioId;
            Usuario = usuario;
            NoticiaTags = noticiasTags;

            Validar();
        }

        private string ObterPorTitulo()
        {
            return "Noticia de São Paulo";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Titulo, "O campo Titulo não pode estar vazio.");
            Validacoes.ValidarSeVazio(Texto, "O campo Texto não pode estar vazio.");
            Validacoes.ValidarSeNulo(UsuarioId, "O campo Usuario não pode estar vazio.");
            Validacoes.ValidarSeIgual(Titulo, ObterPorTitulo(), "Já existe uma Noticia com essse Titulo.");

            if (NoticiaTags == null || NoticiaTags.Count == 0)
            {
                throw new ArgumentException("A Noticia deve conter pelo menos uma Tag.");
            }
        }
    }
}
