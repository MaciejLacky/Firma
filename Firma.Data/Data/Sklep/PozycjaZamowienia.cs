using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.Sklep
{
    public class PozycjaZamowienia
    {
        [Key]
        public int IdPozycjiZamowienia { get; set; }
        public decimal Ilosc { get; set; }
        public decimal Cena { get; set; }

        public int IdTowaru { get; set; }
        public virtual Towar Towar { get; set; }

        public int IdZamowienia { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }
    }
}
