using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace CamnionesWebMVCv1.Models.DTOs
{
    public class CamionDTO
    {

        public int IdCamion { get; set; }

        [Required(ErrorMessage ="La matricula es obligatoria")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
            [Display (Name ="Matricula")]
            public string Matricula { get; set; }

        [Required(ErrorMessage = "El Tipo de Camion es obigatorio")]
        [Display(Name = "Tipo de Camion")]
        public string TipoCamion { get; set; }

        [Required(ErrorMessage = "El Modelo es obligatorio")]
        [Range(1900, 2030, ErrorMessage = "Modelo Invalido")]
        public int Modelo { get; set; }

        [Required (ErrorMessage = "La Marca es obligatoria")]
        [StringLength(50)]
        public string  Marca { get; set; }

        [Required(ErrorMessage = "La Capacidad es Obligatoria")]
        [Range(1, 100000, ErrorMessage = "Capacidad entre 1 y 100000kg Invalido")]
        [Display(Name = "Disponible(Kg)")]
        public int Capacidad { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Kilometraje Invalido")]
        public double Kilometraje { get; set; }

        [Display(Name = "Disponible")]
        public double Disponibilidad { get; set; }

        [Display(Name = "Url Foto")]
        [Url(ErrorMessage = "Url Invalido")]
        public string UrlFoto { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }






    }
}