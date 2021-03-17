using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Intranet.Models.Sklep
{
    public class Rodzaj
    {
        [Key]
        public int IdRodzaju { get; set; }

        [Required(ErrorMessage = "Podaj nazwę rodzaju")]
        [MaxLength(30, ErrorMessage = "Nazwa kategori powinna mieć max 30 znaków")]
        public string Nazwa { get; set; }

        public string Opis { get; set; }
        public virtual ICollection<Towar> Towar { get; set; }

    }
}
