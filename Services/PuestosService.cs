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
      //No se como hacer el return de getall por que yo utilize el filtro de buscador en esta parte del controller
      return _context.Puestos.ToList();
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
}