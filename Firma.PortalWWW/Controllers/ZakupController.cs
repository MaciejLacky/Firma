using Firma.Data.Data;
using Firma.Data.Data.Sklep;
using Firma.PortalWWW.Models.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.PortalWWW.Controllers
{
    public class ZakupController : Controller
    {
        private readonly FirmaContext _context;
        public ZakupController(FirmaContext context)
        {
            _context = context;
        }
        public IActionResult Dane()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Dane([Bind("Login,Imie,Nazwisko,Ulica,Miasto,Wojewodztwo,KodPocztowy,Panstwo,NumerTelefonu,Email")] Zamowienie zamowienie)
        {
            if (ModelState.IsValid)
            {
                zamowienie.DataZamowienia = DateTime.Now;
                await _context.AddAsync(zamowienie);

                KoszykB koszykB = new KoszykB(this._context, this.HttpContext);
                var elementyKoszyka = await koszykB.GetElementyKoszyka();

                foreach (var element in elementyKoszyka)
                {
                    var pozycjaZamowienia = new PozycjaZamowienia
                    {
                        IdTowaru = element.IdTowaru,
                        IdZamowienia = zamowienie.IdZamowienia,
                        Cena = element.Towar.Cena,
                        Ilosc = element.Ilosc

                    };
                    await _context.PozycjaZamowienia.AddAsync(pozycjaZamowienia);
                }

                zamowienie.Razem = await koszykB.GetRazem();
                await _context.SaveChangesAsync();
                return RedirectToAction("Podsumowanie", new { id = zamowienie.IdZamowienia });
            }
            return View();
        }
        public async Task<ActionResult> Podsumowanie(int id)
        {
            var zamowienie = await _context.Zamowienie.FirstOrDefaultAsync(z => z.IdZamowienia == id);
            if (zamowienie == null)
            {
                return View("Error");
            }
            return View(zamowienie);
        }
    }
}
