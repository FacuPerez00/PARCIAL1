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
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadosService _empleadosService;
        private object empleadosView;
      

        public EmpleadosController( IEmpleadosService empleadosService)
        {
           _empleadosService=empleadosService;
        }
        
        // GET: Empleados
      //     public IActionResult Index()
      //  {
      //      var list = _empleadosService.GetAll();
      //      
      //      return View(list);
      //  }
           public IActionResult Index(string buscar)
        {
           
           var list=_empleadosService.GetAll(buscar);
           return View (list);
        }


        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = _empleadosService.GetById(id.Value);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,apellido,edad,sueldo,Ambiguedad")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
           
                _empleadosService.Create(empleados);    
                return RedirectToAction(nameof(Index));
            }
            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var empleados = _empleadosService.GetById(id.Value);
            if (empleados == null)
            {
                return NotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,apellido,edad,sueldo,Ambiguedad")] Empleados empleados)
        {
            if (id != empleados.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _empleadosService.Update(empleados);
                return RedirectToAction(nameof(Index));
            }
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var empleados= _empleadosService.GetById(id.Value);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return NotFound(); 
            }
            var empleados = _empleadosService.GetById(id);
            if (empleados != null)
            {
               _empleadosService.Delete(empleados);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadosExists(int id)
        {
          return (_empleadosService.GetById(id) !=null);
        }
    }
}
