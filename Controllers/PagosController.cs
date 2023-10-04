using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estacionamiento_C.Data;
using Estacionamiento_C.Models;

namespace Estacionamiento_C.Controllers
{
    public class PagosController : Controller
    {
        private readonly GarageContext _miDb;

        public PagosController(GarageContext context)
        {
            _miDb = context;
        }

        // GET: Pagos
        public async Task<IActionResult> Index()
        {
            var miDbContext = _miDb.Pagos.Include(p => p.Estancia);
            return View(await miDbContext.ToListAsync());
        }

        // GET: Pagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _miDb.Pagos == null)
            {
                return NotFound();
            }

            var pago = await _miDb.Pagos
                .Include(p => p.Estancia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // GET: Pagos/Create
        public IActionResult Create()
        {
            ViewData["EstanciaId"] = new SelectList(_miDb.Estancias, "Id", "Id");
            return View();
        }

        // POST: Pagos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EstanciaId,Monto")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                _miDb.Add(pago);
                await _miDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstanciaId"] = new SelectList(_miDb.Estancias, "Id", "Id", pago.EstanciaId);
            return View(pago);
        }

        // GET: Pagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _miDb.Pagos == null)
            {
                return NotFound();
            }

            var pago = await _miDb.Pagos.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }
            ViewData["EstanciaId"] = new SelectList(_miDb.Estancias, "Id", "Id", pago.EstanciaId);
            return View(pago);
        }

        // POST: Pagos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EstanciaId,Monto")] Pago pago)
        {
            if (id != pago.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _miDb.Update(pago);
                    await _miDb.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagoExists(pago.Id))
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
            ViewData["EstanciaId"] = new SelectList(_miDb.Estancias, "Id", "Id", pago.EstanciaId);
            return View(pago);
        }

        // GET: Pagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _miDb.Pagos == null)
            {
                return NotFound();
            }

            var pago = await _miDb.Pagos
                .Include(p => p.Estancia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // POST: Pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_miDb.Pagos == null)
            {
                return Problem("Entity set 'GarageContext.Pagos'  is null.");
            }
            var pago = await _miDb.Pagos.FindAsync(id);
            if (pago != null)
            {
                _miDb.Pagos.Remove(pago);
            }
            
            await _miDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagoExists(int id)
        {
          return _miDb.Pagos.Any(e => e.Id == id);
        }
    }
}
