using Microsoft.EntityFrameworkCore;
using PARCIAL1.Data;
using PARCIAL1.Models;

namespace PARCIAL1.Services;

public class EmpleadosService : IEmpleadosService
{
    
    private readonly EmpleadosContext _context;

    public EmpleadosService (EmpleadosContext context)
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

      return _context.Empleados.Include(r=> r. Puestos). ToList();
    }
    
    public List<Empleados> GetAll(string buscar)
    {
      var query = GetQuery();

        if (!string.IsNullOrEmpty(buscar))
        {
            query = query.Where(x => x.name.Contains(buscar)|| x.apellido.Contains(buscar));
        }
        return query.ToList();
    }

    public Empleados GetById(int id)
    {
        var empleados =  _context.Empleados
       .FirstOrDefault(m => m.id == id);

       return empleados;
    }

    public void Update(Empleados obj)
    {
      
        _context.Update(obj);
        _context.SaveChanges();
               
    }

    private IQueryable<Empleados> GetQuery()
    {
        return from Empleados in _context.Empleados select Empleados;
    }
}