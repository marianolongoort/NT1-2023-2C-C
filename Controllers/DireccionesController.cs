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
    public class DireccionesController : Controller
    {
        private readonly GarageContext _miDb;

        public DireccionesController(GarageContext context)
        {
            _miDb = context;
        }

        // GET: Direcciones
        public async Task<IActionResult> Index()
        {
            var miDbContext = _miDb.Direcciones.Include(d => d.Cliente);
            return View(await miDbContext.ToListAsync());
        }

        // GET: Direcciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _miDb.Direcciones == null)
            {
                return NotFound();
            }

            var direccion = await _miDb.Direcciones
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        // GET: Direcciones/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_miDb.Clientes, "Id", "NombreCompleto");
            return View();
        }

        // POST: Direcciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Calle,Numero,Piso,Departamento,CodigoPostal,ClienteId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                _miDb.Add(direccion);
                await _miDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_miDb.Clientes, "Id", "NombreCompleto", direccion.ClienteId);
            return View(direccion);
        }

        // GET: Direcciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _miDb.Direcciones == null)
            {
                return NotFound();
            }

            var direccion = await _miDb.Direcciones.FindAsync(id);
            if (direccion == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_miDb.Clientes, "Id", "NombreCompleto", direccion.ClienteId);
            return View(direccion);
        }

        // POST: Direcciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Calle,Numero,Piso,Departamento,CodigoPostal,ClienteId")] Direccion direccion)
        {
            if (id != direccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _miDb.Update(direccion);
                    await _miDb.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccionExists(direccion.Id))
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
            ViewData["ClienteId"] = new SelectList(_miDb.Clientes, "Id", "Apellido", direccion.ClienteId);
            return View(direccion);
        }

        // GET: Direcciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _miDb.Direcciones == null)
            {
                return NotFound();
            }

            var direccion = await _miDb.Direcciones
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        // POST: Direcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_miDb.Direcciones == null)
            {
                return Problem("Entity set 'GarageContext.Direcciones'  is null.");
            }
            var direccion = await _miDb.Direcciones.FindAsync(id);
            if (direccion != null)
            {
                _miDb.Direcciones.Remove(direccion);
            }
            
            await _miDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccionExists(int id)
        {
          return _miDb.Direcciones.Any(e => e.Id == id);
        }
    }
}
