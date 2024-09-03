using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Clipping.WebApp.Models
{
    public class NoticiaViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; } = string.Empty;


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Texto { get; set; } = string.Empty;

        [DisplayName("Usuário")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int? UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public IEnumerable<TagViewModel> Tags { get; set; } = new List<TagViewModel>();

        public UsuarioViewModel Usuario { get; set; }

    }
}
