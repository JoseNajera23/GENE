using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CamnionesWebMVCv1.Models.DTOs
{
    public class ChoferDTO
    {
        public int IdChofer { get; set; }

        [Required(ErrorMessage ="El Nombre es Obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="El Apellido es Obigatorio")]
        [StringLength(100)]
        [Display(Name ="Apellido Paterno")]
        public string ApPaterno { get; set; }


        [Required(ErrorMessage = "El Apellido es Obigatorio")]
        [StringLength(100)]
        [Display(Name = "Apellido Materno")]
        public string ApMaterno { get; set;}


        [Required(ErrorMessage = "El Apellido es Obigatorio")]
        [StringLength(15)]
        [Phone(ErrorMessage = "Telefono es Obligatorio")]
        [Display(Name = "El Telefono es Obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La fecha de Nacimiento es Obliogatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La licencia es Obligatoria")]
        [StringLength(50)]
        public string Licencia { get; set; }

        [Display(Name = "Url Foto")]
        [Url(ErrorMessage = "Url Invalida")]
        public string UrlFoto { get; set; }

        [Display(Name = "Disponible")]
        public bool Disponibilidad { get; set; }

        [Display(Name = "Nombre Completo")]
        public string NombreCompleto => $" {Nombre} {ApPaterno} {ApMaterno}";

        [Display(Name ="Edad")]
        public int Edad
        {
            get
            {
                int edad = DateTime.Now.Year - FechaNacimiento.Year;
                if(FechaNacimiento > DateTime.Now.AddYears(-edad)) edad--;
                return edad;
            }
        }
    }
}