using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Clipping.WebApp.Models
{
    public class TagViewModel
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Descricao { get; set; } = string.Empty;

    }
}
