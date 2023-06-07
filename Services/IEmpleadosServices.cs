using PARCIAL1.Models;

namespace Parcial1.Services;

public interface IEmpleadosService
{
   
void Create (Empleados obj);
List<Empleados> GetAll();
void Update (Empleados obj);
void Delete(Empleados obj);
Empleados GetById(int id);

}