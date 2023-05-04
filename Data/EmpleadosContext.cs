using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PARCIAL1.Models;

namespace PARCIAL1.Data
{
    public class EmpleadosContext : DbContext
    {
        public EmpleadosContext (DbContextOptions<EmpleadosContext> options)
            : base(options)
        {
        }

        public DbSet<PARCIAL1.Models.Empleados> Empleados { get; set; } = default!;

        public DbSet<PARCIAL1.Models.Puestos> Puestos { get; set; } = default!;
    }
    
}
