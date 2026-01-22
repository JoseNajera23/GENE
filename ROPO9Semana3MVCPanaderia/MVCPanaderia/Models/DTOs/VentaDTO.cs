using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPanaderia.Models.DTOs
{
    public class VentaDTO
    {
        public int VentaID { get; set; }

        [Required(ErrorMessage = "El producto es obligatorio")]
        public int ProductoID { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, 1000, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 100000, ErrorMessage = "Precio inválido")]
        public decimal Precio { get; set; }

        [Display(Name = "Fecha de Venta")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
    }
}