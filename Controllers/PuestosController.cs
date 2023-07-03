using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PARCIAL1.Data;
using PARCIAL1.Models;
using PARCIAL1.Services;

namespace PARCIAL1.Controllers
{
    public class PuestosController : Controller
    {

        private readonly IPuestosService _puestosService;
        private object  puestosView;
        private readonly object puestos;

        public PuestosController(IPuestosService puestosService)
        {
           _puestosService=puestosService;
        }

        // GET: Puestos
         public IActionResult Index(string buscar)
        {
           
           var list=_puestosService.GetAll(buscar);
           return View (list);
        }

        // GET: Puestos/Details/5
       public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestos = _puestosService.GetById(id.Value);
            if (puestos == null)
            {
                return NotFound();
            }

            return View(puestos);
        }

        // GET: Puestos/Create
        public IActionResult Create()
        {
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
                  _puestosService.Create(puestos);    
                return RedirectToAction(nameof(Index));
            }
           
            return View(puestos);
        }

        // GET: Puestos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            
            var empleados = _puestosService.GetById(id.Value);
            if (puestos == null)
            {
                return NotFound();
            }
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
                  _puestosService.Update(puestos);
                return RedirectToAction(nameof(Index));
            }
            
            return View(puestos);
        }

        // GET: Puestos/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var puestos = _puestosService.GetById(id.Value);
             
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
            if (id == null)
            {
                return NotFound();
            }
            var puestos = _puestosService.GetById(id);
            if (puestos != null)
            {
               _puestosService.Delete(puestos);
            }
        
            return RedirectToAction(nameof(Index));
        }

        private bool PuestosExists(int id)
        {
          return (_puestosService.GetById(id) !=null);
        }
    }
}
