using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PARCIAL_N_1.Models;

namespace PARCIAL1.Data
{
    public class EmpleadosContext : DbContext
    {
        public EmpleadosContext (DbContextOptions<EmpleadosContext> options)
            : base(options)
        {
        }

        public DbSet<PARCIAL_N_1.Models.Empleados> Empleados { get; set; } = default!;
    }
}
