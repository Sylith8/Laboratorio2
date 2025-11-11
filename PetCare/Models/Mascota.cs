using System;
using System.ComponentModel.DataAnnotations;

namespace PetCare.Models
{
    public class Mascota
    {
        [Required(ErrorMessage = "El nombre de la mascota es obligatorio.")]
        [MinLength(2, ErrorMessage = "El nombre debe tener al menos 2 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una especie.")]
        public string Especie { get; set; }

        public string Raza { get; set; }

        [Range(0, 25, ErrorMessage = "La edad debe estar entre 0 y 25 a�os.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El nombre del due�o es obligatorio.")]
        [MinLength(3, ErrorMessage = "El nombre del due�o debe tener al menos 3 caracteres.")]
        public string NombreDueno { get; set; }

        [Required(ErrorMessage = "El tel�fono es obligatorio.")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Formato inv�lido. Use 809-555-1234.")]
        public string Telefono { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Debe ingresar una fecha de ingreso.")]
        [CustomValidation(typeof(Mascota), nameof(ValidarFechaIngreso))]
        public DateTime FechaIngreso { get; set; }

        public static ValidationResult ValidarFechaIngreso(DateTime fecha, ValidationContext context)
        {
            if (fecha > DateTime.Now)
                return new ValidationResult("La fecha de ingreso no puede ser futura.");
            return ValidationResult.Success;
        }
    }
}