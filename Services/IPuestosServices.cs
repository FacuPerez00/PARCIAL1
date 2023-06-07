using PARCIAL1.Models;

namespace Parcial1.Services;

public interface IPuestosService
{
    void Create(Puestos obj);
    List<Puestos> GetAll(string filter);
    List<Puestos> GetAll();
    void Update(Puestos obj);
    void Delete(int id);
    Puestos? GetById(int id);

}