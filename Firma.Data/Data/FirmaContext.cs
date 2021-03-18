using Firma.Data.Data.CMS;
using Firma.Data.Data.Sklep;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data
{
    public class FirmaContext : DbContext
    {
        public FirmaContext(DbContextOptions<FirmaContext> options)
            : base(options)
        {
        }

        public DbSet<Strona> Strona { get; set; }

        public DbSet<Aktualnosc> Aktualnosc { get; set; }

        public DbSet<Rodzaj> Rodzaj { get; set; }

        public DbSet<Towar> Towar { get; set; }

        public DbSet<ElementKoszyka> ElementKoszyka { get; set; }
        public DbSet<Zamowienie> Zamowienie { get; set; }
        public DbSet<PozycjaZamowienia> PozycjaZamowienia { get; set; }

    }
}
