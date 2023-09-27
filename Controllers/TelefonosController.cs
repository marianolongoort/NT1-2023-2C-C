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
    public class TelefonosController : Controller
    {
        private readonly MiDbContext _miDb;

        public TelefonosController(MiDbContext context)
        {
            _miDb = context;
        }

        // GET: Telefonos
        public async Task<IActionResult> Index()
        {
            var miDbContext = _miDb.Telefonos.Include(t => t.Persona);
            return View(await miDbContext.ToListAsync());
        }

        // GET: Telefonos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _miDb.Telefonos == null)
            {
                return NotFound();
            }

            var telefono = await _miDb.Telefonos
                .Include(t => t.Persona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // GET: Telefonos/Create
        public IActionResult Create()
        {
            var personasEnDb = _miDb.Personas;
            //En lugar de usar ViewData usamos ViewBag
            ViewBag.PersonaId = new SelectList(personasEnDb, "Id", "NombreCompleto");

            return View();
        }

        // POST: Telefonos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodArea,Numero,Principal,Tipo,PersonaId")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                _miDb.Add(telefono);
                await _miDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonaId"] = new SelectList(_miDb.Personas, "Id", "Apellido");
            return View(telefono);
        }

        // GET: Telefonos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _miDb.Telefonos == null)
            {
                return NotFound();
            }

            var telefono = await _miDb.Telefonos.FindAsync(id);
            if (telefono == null)
            {
                return NotFound();
            }
            ViewData["PersonaId"] = new SelectList(_miDb.Personas, "Id", "NombreCompleto", telefono.PersonaId);

            return View(telefono);
        }

        // POST: Telefonos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodArea,Numero,Principal,Tipo,PersonaId")] Telefono telefono)
        {
            if (id != telefono.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _miDb.Update(telefono);
                    await _miDb.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonoExists(telefono.Id))
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
            ViewData["PersonaId"] = new SelectList(_miDb.Personas, "Id", "Apellido", telefono.PersonaId);
            return View(telefono);
        }

        // GET: Telefonos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _miDb.Telefonos == null)
            {
                return NotFound();
            }

            var telefono = await _miDb.Telefonos
                .Include(t => t.Persona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // POST: Telefonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_miDb.Telefonos == null)
            {
                return Problem("Entity set 'MiDbContext.Telefonos'  is null.");
            }
            var telefono = await _miDb.Telefonos.FindAsync(id);
            if (telefono != null)
            {
                _miDb.Telefonos.Remove(telefono);
            }
            
            await _miDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonoExists(int id)
        {
          return _miDb.Telefonos.Any(e => e.Id == id);
        }
    }
}
