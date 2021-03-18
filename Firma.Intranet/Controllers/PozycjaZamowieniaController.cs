using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;
using Firma.Data.Data.Sklep;

namespace Firma.Intranet.Controllers
{
    public class PozycjaZamowieniaController : Controller
    {
        private readonly FirmaContext _context;
        public decimal _amount;
        public PozycjaZamowieniaController(FirmaContext context)
        {
            _context = context;
        }

        public ActionResult _OrderDetailPositionFromClient(int? id)
        {
            List<PozycjaZamowienia> logList = _context.PozycjaZamowienia.Where(x => x.IdZamowienia == id).ToList();
            _amount = 0;
            foreach (var item in logList)
            {
                _amount += item.Cena * item.Ilosc;
            }
            ViewData["Amount"] = _amount;
            return PartialView(logList);
        }

        // GET: PozycjaZamowienia
        public async Task<IActionResult> Index()
        {
            return View(await _context.PozycjaZamowienia.ToListAsync());
        }

        // GET: PozycjaZamowienia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozycjaZamowienia = await _context.PozycjaZamowienia
                .FirstOrDefaultAsync(m => m.IdPozycjiZamowienia == id);
            if (pozycjaZamowienia == null)
            {
                return NotFound();
            }

            return View(pozycjaZamowienia);
        }

        // GET: PozycjaZamowienia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PozycjaZamowienia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPozycjiZamowienia,Ilosc,Cena,IdTowaru,IdZamowienia")] PozycjaZamowienia pozycjaZamowienia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pozycjaZamowienia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pozycjaZamowienia);
        }

        // GET: PozycjaZamowienia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozycjaZamowienia = await _context.PozycjaZamowienia.FindAsync(id);
            if (pozycjaZamowienia == null)
            {
                return NotFound();
            }
            return View(pozycjaZamowienia);
        }

        // POST: PozycjaZamowienia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPozycjiZamowienia,Ilosc,Cena,IdTowaru,IdZamowienia")] PozycjaZamowienia pozycjaZamowienia)
        {
            if (id != pozycjaZamowienia.IdPozycjiZamowienia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pozycjaZamowienia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PozycjaZamowieniaExists(pozycjaZamowienia.IdPozycjiZamowienia))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pozycjaZamowienia);
        }

        // GET: PozycjaZamowienia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozycjaZamowienia = await _context.PozycjaZamowienia
                .FirstOrDefaultAsync(m => m.IdPozycjiZamowienia == id);
            if (pozycjaZamowienia == null)
            {
                return NotFound();
            }

            return View(pozycjaZamowienia);
        }

        // POST: PozycjaZamowienia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pozycjaZamowienia = await _context.PozycjaZamowienia.FindAsync(id);
            _context.PozycjaZamowienia.Remove(pozycjaZamowienia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PozycjaZamowieniaExists(int id)
        {
            return _context.PozycjaZamowienia.Any(e => e.IdPozycjiZamowienia == id);
        }
    }
}
