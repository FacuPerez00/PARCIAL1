using PARCIAL1.Data;
using PARCIAL1.Models;
using Microsoft.EntityFrameworkCore;

namespace Parcial1.Services;

public class EmpleadosServices : IEmpleadosService
{
     private readonly EmpleadosContext _context;

     public EmpleadosServices (EmpleadosContext context)
     {
        _context=context;
     }
    public void Create(Empleados obj)
    {
         _context.Add(obj);
        _context.SaveChanges();
    }

    public void Delete(Empleados obj)
    {
       _context.Remove(obj);
        _context.SaveChanges();
    }

    public List<Empleados> GetAll()
    {
        
        return _context.Empleados.Include(r => r.Puestos).ToList();
    }

    public Empleados GetById(int id)
    {
         var empleados = _context.Empleados
                .Include(r => r.Puestos)
                .FirstOrDefault(m => m.id == id);

        return empleados;
    }



    public void Update(Empleados obj)
    {
       _context.Update(obj);
        _context.SaveChanges();
    }
}
