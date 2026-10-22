
using System.ComponentModel.DataAnnotations;

namespace Grupo4.Models
{
    public class InspeccionTemporal
    {
        [Required(ErrorMessage = "El ID de inspección es obligatorio.")]
        public string IdInspeccion { get; set; } = "";

        [Required(ErrorMessage = "La fecha de producción es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime? FechaProduccion { get; set; }

        [Required(ErrorMessage = "La fecha de exportación es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime? FechaExportacion { get; set; }

        [Required(ErrorMessage = "El código de lote es obligatorio.")]
        public string CodigoLote { get; set; } = "";

        [Required(ErrorMessage = "Selecciona un Packing List.")]
        public string IdPackingList { get; set; } = "";

        [Range(1, int.MaxValue,
            ErrorMessage = "La cantidad de pallets debe ser mayor que cero.")]
        public int CantidadPallets { get; set; } = 1;

        public string Resultado { get; set; } = "";

        public bool AprobadoSanitario { get; set; }

        public int DiasTranscurridos { get; set; }

        public void EvaluarAntiguedad()
        {
            if (!FechaProduccion.HasValue ||
                !FechaExportacion.HasValue)
            {
                Resultado = "Error: faltan fechas.";
                AprobadoSanitario = false;
                return;
            }

            DiasTranscurridos =
                (FechaExportacion.Value.Date -
                 FechaProduccion.Value.Date).Days;

            if (DiasTranscurridos < 0)
            {
                Resultado = "Rechazado: fechas incorrectas.";
                AprobadoSanitario = false;
            }
            else if (DiasTranscurridos < 30)
            {
                Resultado = "ProductoOK";
                AprobadoSanitario = true;
            }
            else if (DiasTranscurridos <= 60)
            {
                Resultado = "Producto en Observación";
                AprobadoSanitario = true;
            }
            else
            {
                Resultado = "Rechazado";
                AprobadoSanitario = false;
            }
        }
    }
}
