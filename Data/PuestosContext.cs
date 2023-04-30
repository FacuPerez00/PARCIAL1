using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PARCIAL1.Models;

namespace PARCIAL1.Data
{
    public class PuestosContext : DbContext
    {
        public PuestosContext (DbContextOptions<PuestosContext> options)
            : base(options)
        {
        }

        public DbSet<PARCIAL1.Models.Puestos> Puestos { get; set; } = default!;
        public DbSet<PARCIAL1.Models.Empleados> Empleados{get;set;}=default!;
    }
}

/*   {
       public MenuContext (DbContextOptions<MenuContext> options)
            : base(options)
        {
        }

        public DbSet<Clase6.Models.Menu> Menu { get; set; } = default!;
        public DbSet<Clase6.Models.Restaurant> Restaurant { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
            .HasMany(p=> p.Restaurants)
            .WithOne(p=> p.Menu)
            .HasForeignKey(p => p.MenuId);
        }
    }*/