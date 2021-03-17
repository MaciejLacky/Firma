using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.CMS
{
    public class Strona
    {
        [Key]
        public int IdStrony { get; set; }
        [Required(ErrorMessage = "Wpisz tytuł linku")]

        [MaxLength(20, ErrorMessage = "Tytul linku moze miec max 20 znakow")]
        [Display(Name = "Tytuł linku")]
        public string LinkTytul { get; set; }

        [Required(ErrorMessage = "Wpisz tytul strony")]
        [MaxLength(50, ErrorMessage = "Tytul strony moze miec max 50 znakow")]
        [Display(Name = "Tytuł strony")]
        public string Tytul { get; set; }

        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Tresc { get; set; }

        [Required(ErrorMessage = "Wpisz pozycję strony w menu")]
        [Display(Name = "Pozycja strony w menu")]
        public int Pozycja { get; set; }

    }
}
