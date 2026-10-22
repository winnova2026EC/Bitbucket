
using System.ComponentModel.DataAnnotations;

namespace Grupo4.Models
{
    public class Vendedor
    {
        [Required(ErrorMessage = "El ID es obligatorio.")]
        public string IdVendedor { get; set; } = "";

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Introduce un correo válido.")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "El departamento es obligatorio.")]
        public string Departamento { get; set; } = "";

        public bool Activo { get; set; } = true;
    }
}
