
using Microsoft.AspNetCore.Mvc;
using Grupo4.Models;

namespace Grupo4.Controllers
{
    public class VendedorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Vendedor());
        }

        [HttpPost]
        public IActionResult Index(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
                return View(vendedor);

            ViewBag.Mensaje =
                $"Vendedor {vendedor.Nombre} validado correctamente.";

            return View(new Vendedor());
        }
    }
}
