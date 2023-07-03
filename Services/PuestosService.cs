using Microsoft.EntityFrameworkCore;
using PARCIAL1.Data;
using PARCIAL1.Models;

namespace PARCIAL1.Services;

public class PuestosService : IPuestosService
{
    
    private readonly EmpleadosContext _context;

    public PuestosService(EmpleadosContext context)
    {
        _context=context;
    }

    public void Create(Puestos obj)
    {       
       
            _context.Add(obj);
            _context.SaveChanges();
    }

    public void Delete(Puestos obj)
    {
       _context.Remove(obj);
           _context.SaveChanges();
    }

    public List<Puestos> GetAll()
    {
      return _context.Puestos.ToList();
    }
    public List<Puestos> GetAll(string buscar)
    {
      var query = GetQuery();

        if (!string.IsNullOrEmpty(buscar))
        {
            query = query.Where(x => x.puesto.Contains(buscar)|| x.sector.Contains(buscar));
        }
        return query.ToList();
    }

    public Puestos GetById(int id)
    {
        var puestos =  _context.Puestos
       .FirstOrDefault(m => m.id == id);

       return puestos;
    }

    public void Update(Puestos obj)
    {
      
        _context.Update(obj);
        _context.SaveChanges();
               
    }
    private IQueryable<Puestos> GetQuery()
    {
        return from Puestos in _context.Puestos select Puestos;
    }
}
