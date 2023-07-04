using PARCIAL1.Models;

namespace PARCIAL1.ViewsModels;

public class EmpleadosSueldoViewModel{
    public int id {get; set;}
    public string name {get;set;}
    public int sueldo{get; set;}
    public decimal CalcularSueldo {get;set;}
}