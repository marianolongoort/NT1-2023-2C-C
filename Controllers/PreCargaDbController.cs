using Estacionamiento_C.Data;
using Estacionamiento_C.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Linq;

namespace Estacionamiento_C.Controllers
{
    public class PreCargaDbController : Controller
    {
        private readonly GarageContext _micontexto;

        public PreCargaDbController(GarageContext contexto)
        {
            this._micontexto = contexto;
        }

        public IActionResult Seed()
        {
            
            if (!_micontexto.Personas.Any())
            {
                //no hay personas
                AddPersonas();                
            }
            if (!_micontexto.Clientes.Any())
            {
                AddClientes();
            }

            if (!_micontexto.Vehiculos.Any())
            {
                AddVehiculos();
            }


            return RedirectToAction("Index","Home", new {mensaje = "Se ejecutó la pre-carga" });
        }

        private void AddVehiculos()
        {
            Vehiculo vehiculo = new Vehiculo() { 
             AnioFabricacion = 1999,
             Color = "Negro",
             Foto = "default.jpg",
             Marca = "Citroen",
             Patente = "III3333"            
            };

            _micontexto.Vehiculos.Add(vehiculo);
            _micontexto.SaveChanges();

        }

        private void AddClientes()
        {
            Cliente cliente1 = new Cliente();
            cliente1.Nombre = "Vilma";
            cliente1.Apellido = "Picapiedra";
            cliente1.DNI = 55333444;
            cliente1.CUIT = 20553334440;
            cliente1.Email = "vilma@ort.edu.ar";
            cliente1.FechaNacimiento = new DateTime(1978,9,11);
            _micontexto.Clientes.Add(cliente1);

            Cliente cliente2 = new Cliente();
            cliente2.Nombre = "Betty";
            cliente2.Apellido = "Marmol";
            cliente2.DNI = 55333444;
            cliente2.CUIT = 20553334440;
            cliente2.Email = "betty@ort.edu.ar";
            cliente2.FechaNacimiento = new DateTime(1978, 9, 11);
            _micontexto.Clientes.Add(cliente2);


            _micontexto.SaveChanges();
        }

        public IActionResult Recreate()
        {
            _micontexto.Database.EnsureDeleted();
            _micontexto.Database.EnsureCreated();

            return RedirectToAction("Index", "Home", new { mensaje = "Se regeneró la DB" });
        }

        private void AddPersonas()
        {
            Persona persona1 = new Persona() {
                Nombre = "Pedro",
                Apellido = "Picapiedra",
                DNI = 22333444,
                Email = "pedro@ort.edu.ar",
                FechaNacimiento = new DateTime(1977,08,10)                
            };
            _micontexto.Personas.Add(persona1);
            _micontexto.SaveChanges();

        }
    }
}
