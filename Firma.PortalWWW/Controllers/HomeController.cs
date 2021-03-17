using Firma.Data.Data;
using Firma.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly FirmaContext _context;
        public HomeController(FirmaContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? id)
        {
            ViewBag.ModelStrony =
                  (
                      from strona in _context.Strona
                      orderby strona.Pozycja
                      select strona
                  ).ToList();
            ViewBag.ModelAktualnosci =
                (from aktualnosc in _context.Aktualnosc
                 orderby aktualnosc.Pozycja
                 select aktualnosc
                ).ToList();
            if (id == null)
                id = _context.Strona.First().IdStrony;
            var item = _context.Strona.Find(id);
            return View(item);
        }

    
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
