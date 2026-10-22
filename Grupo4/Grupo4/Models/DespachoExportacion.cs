
using System.ComponentModel.DataAnnotations;

namespace Grupo4.Models
{
    public class DespachoExportacion
    {
        [Required(ErrorMessage = "El ID del contenedor es obligatorio.")]
        public string IdContenedor { get; set; } = "CONT001";

        public string TemperaturaConfigurada { get; set; } = "-20 °C";

        [Range(1, int.MaxValue,
            ErrorMessage = "La capacidad debe ser mayor que cero.")]
        public int CapacidadMaximaPallets { get; set; } = 100;

        public int TotalLotesInspeccionados { get; set; }

        public int TotalPalletsInspeccionados { get; set; }

        public int LotesProductoOK { get; set; }

        public int LotesEnObservacion { get; set; }

        public int LotesRechazados { get; set; }

        public int PalletsAptosParaEmbarque { get; set; }

        public bool CapacidadSuperada { get; set; }

        public bool ListoParaZarpe { get; set; }

        public string EstadoDespacho { get; set; } = "";
    }
}
