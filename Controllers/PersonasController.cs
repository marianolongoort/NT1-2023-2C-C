using Estacionamiento_C.Data;
using Estacionamiento_C.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Estacionamiento_C.Controllers
{
    public class PersonasController : Controller
    {
        

        public IActionResult Index()
        {
            //listar todos los objetos de la entidad.
            //listar todas las personas.

            return View(PersonasRepository.Personas);
        }

        //atiende las peticiones del usuario para poder ofrecer 
        //el formulario de creación de personas

        public IActionResult Create(string nombre, string apellido)
        {
            Persona persona = new Persona()
            {                
                Apellido = apellido,
                Nombre = nombre
            };
            return View(persona);
        }

        //Este action method resuelve el proceso de la info recibida del cliente
        [HttpPost]
        public IActionResult Create(int id,string apellido,string nombre)
        {
            Persona persona = new Persona();
            persona.Nombre = nombre;
            persona.Apellido = apellido;
            persona.Id = id;
            
            
            PersonasRepository.Personas.Add(persona);

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            List<int> numeros = new List<int>();
            numeros.Add(id);

            return View("Index", numeros);
        }

        public int DameNumero(int numero)
        {
            return numero;
        }

        public IActionResult Test()
        {
            return View("index", 4);
        }

    }
}
