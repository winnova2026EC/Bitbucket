
using Microsoft.AspNetCore.Mvc;
using Grupo4.Models;
using Grupo4.Services;

namespace Grupo4.Controllers
{
    public class PackingListController : Controller
    {
        private readonly RegistroExportacionService _registro;

        public PackingListController(RegistroExportacionService registro)
        {
            _registro = registro;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CargarRegistros();
            return View(new PackingList());
        }

        [HttpPost]
        public IActionResult Index(PackingList packingList)
        {
            if (!ModelState.IsValid)
            {
                CargarRegistros();
                return View(packingList);
            }

            _registro.RegistrarPackingList(packingList);

            ViewBag.Mensaje =
                $"Packing List {packingList.IdPackingList} registrado correctamente.";

            CargarRegistros();

            return View(new PackingList());
        }

        private void CargarRegistros()
        {
            ViewBag.PackingLists = _registro.ObtenerPackingLists();
        }
    }
}
