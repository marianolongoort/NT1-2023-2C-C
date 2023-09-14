using Estacionamiento_C.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Estacionamiento_C.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewResult result = View();

            return result;
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
    }
}