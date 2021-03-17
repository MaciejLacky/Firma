using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.CMS
{
    public class Aktualnosc
    {
        [Key]
        public int IdAktualnosci { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł linku")]
        [MaxLength(20, ErrorMessage = "Tytul linku moze miec max 20 znakow")]
        [Display(Name = "Tytuł linku")]
        public string LinkTytul { get; set; }

        [Required(ErrorMessage = "Wpisz tytul aktualności")]
        [MaxLength(50, ErrorMessage = "Tytul aktualności moze miec max 50 znakow")]
        [Display(Name = "Tytuł aktualności")]
        public string Tytul { get; set; }

        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Tekst { get; set; }

        [Required(ErrorMessage = "Wpisz pozycję aktualności")]
        [Display(Name = "Pozycja aktualności")]
        public int Pozycja { get; set; }

    }
}
