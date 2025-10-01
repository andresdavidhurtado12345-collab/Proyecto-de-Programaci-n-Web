using System.ComponentModel.DataAnnotations;

namespace MicroservicioBase.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo no es válido")]
        public string Email { get; set; }
        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El teléfono solo debe contener números")]
        public string Telefono { get; set; }

        public bool Estado { get; set; } = true;
    }

}
