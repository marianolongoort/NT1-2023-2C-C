using Estacionamiento_C.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Estacionamiento_C.Data
{
    public class MiDbContext : DbContext
    {
        public MiDbContext(DbContextOptions options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<ClienteVehiculo>().HasKey(cv => new { cv.ClienteId,cv.VehiculoId});
            

        }


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
