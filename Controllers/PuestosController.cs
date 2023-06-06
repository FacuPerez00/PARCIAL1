using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PARCIAL1.Data;
using PARCIAL1.Models;

namespace PARCIAL1.Controllers
{
    public class PuestosController : Controller
    {
        private readonly EmpleadosContext _context;

        public PuestosController(EmpleadosContext context)
        {
            _context = context;
        }

        // GET: Puestos
        public async Task<IActionResult> Index(string buscar)
        {
            var empleadosContext = _context.Puestos.Include(p => p.Empleado);
            return View(await empleadosContext.ToListAsync());
        }

        // GET: Puestos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Puestos == null)
            {
                return NotFound();
            }

            var puestos = await _context.Puestos
                .Include(p => p.Empleado)
                .FirstOrDefaultAsync(m => m.id == id);
            if (puestos == null)
            {
                return NotFound();
            }

            return View(puestos);
        }

        // GET: Puestos/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "id", "id");
            return View();
        }

        // POST: Puestos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,EmpleadoId,puesto,sector")] Puestos puestos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puestos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "id", "id", puestos.EmpleadoId);
            return View(puestos);
        }

        // GET: Puestos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Puestos == null)
            {
                return NotFound();
            }

            var puestos = await _context.Puestos.FindAsync(id);
            if (puestos == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "id", "id", puestos.EmpleadoId);
            return View(puestos);
        }

        // POST: Puestos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,EmpleadoId,puesto,sector")] Puestos puestos)
        {
            if (id != puestos.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puestos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuestosExists(puestos.id))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "id", "id", puestos.EmpleadoId);
            return View(puestos);
        }

        // GET: Puestos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Puestos == null)
            {
                return NotFound();
            }

            var puestos = await _context.Puestos
                .Include(p => p.Empleado)
                .FirstOrDefaultAsync(m => m.id == id);
            if (puestos == null)
            {
                return NotFound();
            }

            return View(puestos);
        }

        // POST: Puestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Puestos == null)
            {
                return Problem("Entity set 'EmpleadosContext.Puestos'  is null.");
            }
            var puestos = await _context.Puestos.FindAsync(id);
            if (puestos != null)
            {
                _context.Puestos.Remove(puestos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuestosExists(int id)
        {
          return (_context.Puestos?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
