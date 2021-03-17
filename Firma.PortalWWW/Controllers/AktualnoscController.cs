using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;

namespace Firma.PortalWWW.Controllers
{
    public class AktualnoscController : Controller
    {
        private readonly FirmaContext _context;

        public AktualnoscController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Aktualnoscs
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.ModelStrony =
               (
                   from strona in _context.Strona
                   orderby strona.Pozycja
                   select strona
               ).ToList();
            ViewBag.ModelAktualnosci =
                (
                    from aktualnosc in _context.Aktualnosc
                    orderby aktualnosc.Pozycja
                    select aktualnosc
                ).ToList();

            var item = await _context.Aktualnosc.FirstOrDefaultAsync(a => a.IdAktualnosci == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

    }
}
