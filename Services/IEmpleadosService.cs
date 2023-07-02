using PARCIAL1.Models;

namespace PARCIAL1.Services;

public interface IEmpleadosService
{
    void Create(Empleados obj);
    List<Empleados> GetAll(string buscar);
    void Update (Empleados obj);
    void Delete(Empleados obj);
    public Empleados GetById (int id);
}
   