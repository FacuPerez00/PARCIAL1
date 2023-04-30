using System.ComponentModel.DataAnnotations;

namespace PARCIAL1.Models;

public class Empleados{
    public int id {get; set;}
    public string name {get;set;}
    public string apellido {get; set;}
    public int edad {get; set;}
    public int sueldo{get; set;}
    public int Ambiguedad {get;set;}
    public virtual List<Puestos> Puestos { get; set; }
}