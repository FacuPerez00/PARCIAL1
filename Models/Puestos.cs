using System.ComponentModel.DataAnnotations;

namespace PARCIAL1.Models;

public class Puestos{
    public int id {get; set;}
    public int EmpleadoId { get; set;}
    public string puesto {get;set;}
    public string sector {get;set;}
    public virtual Empleados ?Empleado { get; set; }
    
}