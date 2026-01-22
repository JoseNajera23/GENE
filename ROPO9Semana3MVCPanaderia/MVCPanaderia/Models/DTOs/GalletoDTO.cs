using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPanaderia.Models.DTOs
{
    public class GalletoDTO
    {
        public int EmpleadoID { get; set; }

        [Required(ErrorMessage = "El producto es obligatorio")]
        public int? ProductoID { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La ocupación es obligatoria")]
        [StringLength(50)]
        public string Ocupacion { get; set; }

        [Required(ErrorMessage = "El tipo de galleta es obligatorio")]
        [StringLength(50)]
        [Display(Name = "Tipo de Galleta")]
        public string TipoGalleta { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, 1000)]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio")]
        [Range(0, 5000)]
        public int Stock { get; set; }
    }
}