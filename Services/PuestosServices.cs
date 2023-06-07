using PARCIAL1.Data;
using PARCIAL1.Models;
using Microsoft.EntityFrameworkCore;

namespace Parcial1.Services;

public class PuestosService : IPuestosService
{
    private readonly EmpleadosContext _context;

    public PuestosService(Empleados context)
    {
        _context = _context;
    }

    public void Create(Puestos obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var obj = GetById(id);
        
        if (obj != null){
            _context.Remove(obj);
            _context.SaveChanges();
        }
    }
    public List<Puestos> GetAll()
    {
        var query = GetQuery();
        return query.ToList();
    }

    public List<Puestos> GetAll(string filter)
    {
        var query = GetQuery();

      

        return query.ToList();
    }

    public Puestos? GetById(int id)
    {

        var puestos = GetQuery()
                .Include(x=> x.Empleado)
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