using PARCIAL1.Models;

namespace PARCIAL1.Services;

public interface IPuestosService
{
    void Create(Puestos obj);
    List<Puestos> GetAll(string buscar);
    void Update (Puestos obj);
    void Delete(Puestos obj);
    public Puestos GetById (int id);
}
   