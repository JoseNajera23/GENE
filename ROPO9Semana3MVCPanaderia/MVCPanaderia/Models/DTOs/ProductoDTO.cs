using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPanaderia.Models.DTOs
{
    public class ProductoDTO
    {
        public int ProductoID { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [Display(Name = "Producto")]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "El tipo de producto es obligatorio")]
        [StringLength(50)]
        [Display(Name = "Tipo de Producto")]
        public string TipoProducto { get; set; }

    }
}