
using System.ComponentModel.DataAnnotations;

namespace Grupo4.Models
{
    public class PackingList
    {
        [Required(ErrorMessage = "El ID es obligatorio.")]
        public string IdPackingList { get; set; } = "";

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Descripcion { get; set; } = "";

        [Required(ErrorMessage = "El cliente consignatario es obligatorio.")]
        public string ClienteConsignatario { get; set; } = "";

        [Required(ErrorMessage = "El vendedor es obligatorio.")]
        public string Vendedor { get; set; } = "";

        [Required(ErrorMessage = "La fecha de emisión es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime? FechaEmision { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public string Estado { get; set; } = "Pendiente";

        [Required(ErrorMessage = "El puerto de embarque es obligatorio.")]
        public string PuertoEmbarque { get; set; } = "";

        [Required(ErrorMessage = "El país de destino es obligatorio.")]
        public string PaisDestino { get; set; } = "";
    }
}
