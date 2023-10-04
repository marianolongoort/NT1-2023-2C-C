using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estacionamiento_C.Data;
using Estacionamiento_C.Models;
using Microsoft.AspNetCore.Routing;

namespace Estacionamiento_C.Controllers
{
    public class ClientesVehiculosController : Controller
    {
        private readonly GarageContext _context;

        public ClientesVehiculosController(GarageContext context)
        {
            _context = context;
        }

        // GET: ClientesVehiculos
        public async Task<IActionResult> Index()
        {
            var miDbContext = _context.ClientesVehiculos.Include(c => c.Cliente).Include(c => c.Vehiculo);
            return View(await miDbContext.ToListAsync());
        }

        // GET: ClientesVehiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClientesVehiculos == null)
            {
                return NotFound();
            }

            var clienteVehiculo = await _context.ClientesVehiculos
                .Include(c => c.Cliente)
                .Include(c => c.Vehiculo)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clienteVehiculo == null)
            {
                return NotFound();
            }

            return View(clienteVehiculo);
        }

        // GET: ClientesVehiculos/Create
        public IActionResult Create(int? idCliente)
        {
            if(idCliente != null && _context.Clientes.Any(clt => clt.Id == idCliente.Value))
            {
                //definir la asociación para un cliente especifico
                ViewBag.IdCliente = idCliente.Value;
                
            }
            else
            {
                //Necesito definir a que cliente.
                ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto");
            }

            
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "Id", "Patente");
            return View();
        }

        // POST: ClientesVehiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,VehiculoId")] ClienteVehiculo clienteVehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteVehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto", clienteVehiculo.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "Id", "Patente", clienteVehiculo.VehiculoId);
            return View(clienteVehiculo);
        }

        // GET: ClientesVehiculos/Edit/5
        public async Task<IActionResult> Edit(int? idCliente, int? idVehiculo)
        {
            if (idCliente == null || idVehiculo == null || _context.ClientesVehiculos == null)
            {
                return NotFound();
            }

            var clienteVehiculo = await _context.ClientesVehiculos.FindAsync(idCliente,idVehiculo);
            if (clienteVehiculo == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto", clienteVehiculo.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "Id", "Patente", clienteVehiculo.VehiculoId);
            return View(clienteVehiculo);
        }

        // POST: ClientesVehiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int clienteId,int vehiculoId, [Bind("ClienteId,VehiculoId")] ClienteVehiculo clienteVehiculo)
        {
            if (clienteId != clienteVehiculo.ClienteId || vehiculoId != clienteVehiculo.VehiculoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteVehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteVehiculoExists(clienteVehiculo.ClienteId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto", clienteVehiculo.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "Id", "Patente", clienteVehiculo.VehiculoId);
            return View(clienteVehiculo);
        }

        // GET: ClientesVehiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClientesVehiculos == null)
            {
                return NotFound();
            }

            var clienteVehiculo = await _context.ClientesVehiculos
                .Include(c => c.Cliente)
                .Include(c => c.Vehiculo)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clienteVehiculo == null)
            {
                return NotFound();
            }

            return View(clienteVehiculo);
        }

        // POST: ClientesVehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClientesVehiculos == null)
            {
                return Problem("Entity set 'GarageContext.ClientesVehiculos'  is null.");
            }
            var clienteVehiculo = await _context.ClientesVehiculos.FindAsync(id);
            if (clienteVehiculo != null)
            {
                _context.ClientesVehiculos.Remove(clienteVehiculo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteVehiculoExists(int id)
        {
          return _context.ClientesVehiculos.Any(e => e.ClienteId == id);
        }
    }
}
