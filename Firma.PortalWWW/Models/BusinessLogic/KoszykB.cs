using Firma.Data.Data;
using Firma.Data.Data.Sklep;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.PortalWWW.Models.BusinessLogic
{
    public class KoszykB
    {
        private readonly FirmaContext _context;
        private string IdSesjiKoszyka;
        public KoszykB(FirmaContext context, HttpContext httpContext)
        {
            _context = context;
            this.IdSesjiKoszyka = GetIdSesjiKoszyka(httpContext);
        }
        private string GetIdSesjiKoszyka(HttpContext httpContext)
        {
            //Jeżeli w Sesji IdSesjiKoszyka jest null-em
            if (httpContext.Session.GetString("IdSesjiKoszyka") == null)
            {
                //Jeżeli context.User.Identity.Name nie jest puste i nie posiada białych zanków
                if (!string.IsNullOrWhiteSpace(httpContext.User.Identity.Name))
                {
                    httpContext.Session.SetString("IdSesjiKoszyka", httpContext.User.Identity.Name);
                }
                else
                {
                    // W przeciwnym wypadku wygeneruj przy pomocy random Guid IdSesjiKoszyka
                    Guid tempIdSesjiKoszyka = Guid.NewGuid();
                    // Wyślij wygenerowane IdSesjiKoszyka jako cookie
                    httpContext.Session.SetString("IdSesjiKoszyka", tempIdSesjiKoszyka.ToString());
                }
            }
            return httpContext.Session.GetString("IdSesjiKoszyka").ToString();
        }
        public void DodajDoKoszyka(Towar towar)
        {
            //Najpierw sprawdzamy czy dany towar już istnieje w koszyku danego klienta
            var elementKoszyka =
               (
                   from element in _context.ElementKoszyka
                   where element.IdSesjiKoszyka == this.IdSesjiKoszyka && element.IdTowaru == towar.IdTowaru
                   select element
               ).FirstOrDefault();
            // jeżeli brak tego towaru w koszyku
            if (elementKoszyka == null)
            {
                // Wtedy tworzymy nowy element w koszyku
                elementKoszyka = new ElementKoszyka()
                {
                    IdSesjiKoszyka = this.IdSesjiKoszyka,
                    IdTowaru = towar.IdTowaru,
                    Towar = _context.Towar.Find(towar.IdTowaru),
                    Ilosc = 1,
                    DataUtworzenia = DateTime.Now
                };
                //i dodajemy do kolekcji lokalne
                _context.ElementKoszyka.Add(elementKoszyka);
            }
            else
            {
                // Jeżeli dany towar istnieje już w koszyku to liczbe sztuk zwiekszamy o 1
                elementKoszyka.Ilosc++;
            }
            // Zapisujemy zmiany do bazy
            _context.SaveChanges();
        }
        public async Task<List<ElementKoszyka>> GetElementyKoszyka()
        {
            return await
               _context.ElementKoszyka.Where(e => e.IdSesjiKoszyka == this.IdSesjiKoszyka).Include(e => e.Towar).ToListAsync();
        }
        public async Task<decimal> GetRazem()
        {
            var item =
                (
                from element in _context.ElementKoszyka
                where element.IdSesjiKoszyka == this.IdSesjiKoszyka
                select (decimal?)element.Ilosc * element.Towar.Cena
                );
            return await item.SumAsync() ?? decimal.Zero;
        }
    }
}
