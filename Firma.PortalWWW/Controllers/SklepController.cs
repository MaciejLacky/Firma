using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.PortalWWW.Controllers
{
    public class SklepController : Controller
    {
        private readonly FirmaContext _context;
        public SklepController(FirmaContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            //uwaga dodaj using Microsoft.EntityFrameworkCore;
            ViewBag.Rodzaje = await _context.Rodzaj.ToListAsync();
            if (id == null)
            {
                var pierwszy = await _context.Rodzaj.FirstAsync();
                id = pierwszy.IdRodzaju;
            }
            return View(await _context.Towar.Where(t => t.IdRodzaju == id).ToListAsync());
        }
        public async Task<IActionResult> Szczegoly(int id)
        {
            ViewBag.Rodzaje = await _context.Rodzaj.ToListAsync();
            return View(await _context.Towar.Where(t => t.IdTowaru == id).FirstOrDefaultAsync());
        }
        public async Task<IActionResult> Promocje()
        {
            return View(await _context.Towar.Where(t => t.Promocja == true).ToListAsync());
        }

    }
}

