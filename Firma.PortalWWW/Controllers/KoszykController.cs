using Firma.Data.Data;
using Firma.PortalWWW.Models.BusinessLogic;
using Firma.PortalWWW.Models.Sklep;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.PortalWWW.Controllers
{
    public class KoszykController : Controller
    {
        private readonly FirmaContext _context;
        public KoszykController(FirmaContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            KoszykB koszyk = new KoszykB(this._context, this.HttpContext);
            var daneDoKoszyka = new DaneDoKoszyka
            {
                ElementyKoszyka = await koszyk.GetElementyKoszyka(),
                Razem = await koszyk.GetRazem()
            };
            return View(daneDoKoszyka);
        }
        public async Task<ActionResult> DodajDoKoszyka(int id)
        {
            KoszykB koszyk = new KoszykB(this._context, this.HttpContext);
            koszyk.DodajDoKoszyka(await _context.Towar.FindAsync(id));
            return RedirectToAction("Index");
        }

    }
}
