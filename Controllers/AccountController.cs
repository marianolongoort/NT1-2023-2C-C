using Estacionamiento_C.Models;
using Estacionamiento_C.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Estacionamiento_C.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Persona> _userManager;
        private readonly SignInManager<Persona> _signInManager;
        private readonly RoleManager<Rol> _roleManager;

        public AccountController(UserManager<Persona> userManager,
            SignInManager<Persona> signInManager,
            RoleManager<Rol> roleManager
            )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
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
                    var resultadoRol = await _userManager.AddToRoleAsync(cliente,"ClienteRol");
                    if (resultadoRol.Succeeded)
                    {
                        //continuo 
                        return RedirectToAction("Edit", "Clientes", new { id = cliente.Id });
                    }
                    //sino, algo

                    
                }

                //Procesar los errores
                foreach(var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(datosDesdeElCliente);
        }

        //Darme un formulario de inicio de sesión
        public IActionResult IniciarSesion(string returnurl)
        {   
            TempData["ReturnUrl"] = returnurl;
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(Login modelo)
        {
            if (ModelState.IsValid)
            {
                //Avanzo con el inicio 
                var resultado = await _signInManager.PasswordSignInAsync(modelo.Email,modelo.Password,modelo.Recordarme,false);
                if (resultado.Succeeded)
                {
                    //hago lo que necesito
                    string returnUrl = TempData["ReturnUrl"] as string;
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError(string.Empty,"Inicio de sesión inválido");
            }

            return View(modelo);
        }

        [Authorize]
        public async Task<IActionResult> CerrarSesion()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("IniciarSesion","Account");
        }

        public IActionResult AccesoDenegado()
        {
            return Content("No tenes permisos");
        }
    }
}
