using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PARCIAL1.Models;

namespace PARCIAL1.Data
{
    public class EmpleadosContext : IdentityDbContext
    {
        public EmpleadosContext (DbContextOptions<EmpleadosContext> options)
            : base(options)
        {
        }

        public DbSet<PARCIAL1.Models.Empleados> Empleados { get; set; } = default!;

        public DbSet<PARCIAL1.Models.Puestos> Puestos { get; set; } = default!;
       //  protected override void OnModelCreating(ModelBuilder modelBuilder)
       // {
       //     modelBuilder.Entity<Empleados>()
       //     .HasMany(p=> p.Puestos)
       //     .WithMany(p=> p.Empleados)
       //     .UsingEntity("MenuRestaurant");
       // }
    }
    
}
