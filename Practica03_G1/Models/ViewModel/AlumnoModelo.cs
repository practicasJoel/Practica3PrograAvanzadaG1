using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Practica03_G1.Models;
using System.Web;

namespace Practica03_G1.Models.ViewModel
{
    public class AlumnoModelo
    {
        [Required]
        [Display(Name = "Carnet Alumno")]
        [StringLength(6, ErrorMessage = "El tamaño máximo es de 6 caracteres")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo letras de la A a la Z")]
        [CarnetExiste]
        public string carnet { get; set; }

        [Required]
        [Display(Name = "Nombre Alumno")]
        [StringLength(30, ErrorMessage = "El tamaño máximo es de 30 caracteres")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Apellido Alumno")]
        [StringLength(30, ErrorMessage = "El tamaño máximo es de 30 caracteres")]
        public string apellido { get; set; }

        [Required]
        [Display(Name = "Genero del Alumno")]
        [StringLength(1, ErrorMessage = "El tamaño máximo es de 1 caracteres, favor digitar: F o M")]
        public string genero { get; set; }

        [Required]
        [Display(Name = "Direccion de Correo")]
        [StringLength(40, ErrorMessage = "El tamaño máximo es de 40 caracteres")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Numero de Telefono")]
        [StringLength(8, ErrorMessage = "El telefono debe ser de 8 caracteres")]
        public string telefono { get; set; }

        [Required]
        [Display(Name = "Fecha Nacimiento")]
        //[DataType(DataType.Date)] // no lo pongo por el tipo de dato que tiene la bd, pero es asi de simple
        [StringLength(20, ErrorMessage = "El tamaño máximo es de 20 caracteres")]
        public string fecha_nacimiento { get; set; }
    }

    public class CarnetExiste : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (Practica03Entities db = new Practica03Entities())
            {
                string carne = (string)value;

                if (db.Alumno.Where(d => d.carnet == carne).Count() > 0)
                {
                    return new ValidationResult("El carnet ya existe.");
                }

                return ValidationResult.Success;
            }
        }

    }
}