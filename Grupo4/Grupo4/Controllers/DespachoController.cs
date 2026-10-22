
using Microsoft.AspNetCore.Mvc;
using Grupo4.Models;
using Grupo4.Services;

namespace Grupo4.Controllers
{
    public class DespachoController : Controller
    {
        private readonly RegistroExportacionService _registro;

        public DespachoController(RegistroExportacionService registro)
        {
            _registro = registro;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var despacho = new DespachoExportacion();
            CalcularResumen(despacho);
            return View(despacho);
        }

        [HttpPost]
        public IActionResult Index(DespachoExportacion despacho)
        {
            if (!ModelState.IsValid)
            {
                CalcularResumen(despacho);
                return View(despacho);
            }

            despacho.TemperaturaConfigurada = "-20 °C";
            CalcularResumen(despacho);

            return View(despacho);
        }

        private void CalcularResumen(DespachoExportacion despacho)
        {
            var inspecciones = _registro.ObtenerInspecciones();
            ViewBag.Inspecciones = inspecciones;

            despacho.TotalLotesInspeccionados = inspecciones.Count;
            despacho.TotalPalletsInspeccionados =
                inspecciones.Sum(x => x.CantidadPallets);

            despacho.LotesProductoOK = inspecciones.Count(x =>
                x.Resultado == "ProductoOK");

            despacho.LotesEnObservacion = inspecciones.Count(x =>
                x.Resultado == "Producto en Observación");

            despacho.LotesRechazados = inspecciones.Count(x =>
                x.Resultado.StartsWith("Rechazado"));

            despacho.PalletsAptosParaEmbarque = inspecciones
                .Where(x => x.Resultado == "ProductoOK" ||
                            x.Resultado == "Producto en Observación")
                .Sum(x => x.CantidadPallets);

            despacho.CapacidadSuperada =
                despacho.PalletsAptosParaEmbarque >
                despacho.CapacidadMaximaPallets;

            despacho.ListoParaZarpe =
     inspecciones.Count > 0 &&
     despacho.LotesRechazados == 0 &&
     !despacho.CapacidadSuperada &&
     despacho.PalletsAptosParaEmbarque > 0;

            if (despacho.CapacidadSuperada)
            {
                despacho.EstadoDespacho =
                    "ALERTA: se supera la capacidad configurada.";
            }
            else if (despacho.LotesRechazados > 0)
            {
                despacho.EstadoDespacho =
                    "CON ALERTA: hay lotes rechazados.";
            }
            else if (despacho.ListoParaZarpe)
            {
                despacho.EstadoDespacho =
                    "CONSOLIDADO Y LISTO PARA REVISIÓN DE ZARPE.";
            }
            else
            {
                despacho.EstadoDespacho =
                    "PENDIENTE: no hay inspecciones registradas.";
            }
        }
    }
}
