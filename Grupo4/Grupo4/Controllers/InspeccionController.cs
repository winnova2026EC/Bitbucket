
using Microsoft.AspNetCore.Mvc;
using Grupo4.Models;
using Grupo4.Services;

namespace Grupo4.Controllers
{
    public class InspeccionController : Controller
    {
        private readonly RegistroExportacionService _registro;

        public InspeccionController(RegistroExportacionService registro)
        {
            _registro = registro;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CargarPackingLists();

            return View(new InspeccionTemporal
            {
                FechaProduccion = DateTime.Today.AddDays(-10),
                FechaExportacion = DateTime.Today,
                CantidadPallets = 1
            });
        }

        [HttpPost]
        public IActionResult Index(InspeccionTemporal inspeccion)
        {
            var packingLists = _registro.ObtenerPackingLists();

            bool existePackingList = packingLists.Any(p =>
                p.IdPackingList == inspeccion.IdPackingList);

            if (!existePackingList)
            {
                ModelState.AddModelError(
                    nameof(inspeccion.IdPackingList),
                    "Selecciona un Packing List registrado."
                );
            }

            if (!ModelState.IsValid)
            {
                CargarPackingLists();
                return View(inspeccion);
            }

            inspeccion.EvaluarAntiguedad();

            if (inspeccion.Resultado.StartsWith("Error:"))
            {
                ModelState.AddModelError(
                    "",
                    "No se pudo evaluar la inspección. Verifica las fechas."
                );

                CargarPackingLists();
                return View(inspeccion);
            }

            _registro.RegistrarInspeccion(inspeccion);

            ViewBag.Mensaje =
                $"Inspección registrada. Resultado: {inspeccion.Resultado}";

            CargarPackingLists();
            return View(inspeccion);
        }

        private void CargarPackingLists()
        {
            ViewBag.PackingLists = _registro.ObtenerPackingLists();
        }
    }
}
