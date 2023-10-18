using Estacionamiento_C.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Estacionamiento_C.Data
{
    public class GarageContext : IdentityDbContext<IdentityUser<int>,IdentityRole<int>,int>
    {
        public GarageContext(DbContextOptions options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<ClienteVehiculo>().HasKey(cv => new { cv.ClienteId,cv.VehiculoId});

            modelBuilder.Entity<IdentityUser<int>>().ToTable("Personas");



        }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<Estancia> Estancias { get; set; }

        public DbSet<Pago> Pagos { get; set; }

        public DbSet<ClienteVehiculo> ClientesVehiculos { get; set; }

    }
}
