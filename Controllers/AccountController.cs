using Estacionamiento_C.Models;
using Estacionamiento_C.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Estacionamiento_C.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Persona> _userManager;

        public AccountController(UserManager<Persona> userManager)
        {
            this._userManager = userManager;
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(RegistrarVM datosDesdeElCliente)
        {
            if (ModelState.IsValid)
            {
                //aca hacemos la registracion
                Cliente cliente = new Cliente() { 
                    Email = datosDesdeElCliente.Email,
                    UserName = datosDesdeElCliente.Email
                };

                var resultado = await _userManager.CreateAsync(cliente,datosDesdeElCliente.Password);

                if (resultado.Succeeded)
                {
                    //continuo con lo que sean necesario 
                    return RedirectToAction("Edit", "Clientes", new { id=cliente.Id});
                }

                //Procesar los errores
                foreach(var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(datosDesdeElCliente);
        }
    }
}
