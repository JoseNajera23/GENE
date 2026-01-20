using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CamnionesWebMVCv1.Models.DTOs
{
    public class RutaDTO
    {
        public int IdRuta { get; set; }

        [Required (ErrorMessage ="Debe de seleccionar el chofer")]
        [Display(Name ="Chofer")]
        public int IdChofer { get; set; }


        [Required(ErrorMessage = "Debe de seleccionar el Camion")]
        [Display(Name = "Camion")]
        public int IdCamion { get; set; }


        [Required(ErrorMessage = "El Origen es Obligatorio")]
        [StringLength(200)]
        public string Origen { get; set; }

        [Required(ErrorMessage = "El Destino es Obligatorio")]
        [StringLength(200)]
        public string Destino { get; set; }

        [Required(ErrorMessage = "La fecha de Salida es Obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaSalida { get; set; }

        [Required(ErrorMessage = "La fecha de Llegada es Obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaLlegada { get; set; }

        [Display(Name = "Llego a Tiempo")]
        public bool ATiempo { get; set; }

        [Required(ErrorMessage = "La distancia es obliagatoria")]
        [Range(0.1, 10000, ErrorMessage = "Distancia entre 0.1 y 10000km")]
        [Display(Name = "Distancia (Km)")]
        public double Distancia { get; set; }

        [Display(Name = "Chofer")]
        public string NombreChofer { get; set; }


        [Display(Name = "Licencia")]
        public string LicenciaChofer { get; set; }

        [Display(Name = "Matricula")]
        public string MatriculaCamion { get; set; }

        [Display(Name = "Duracion (Horas)")]
        public double DuracionHoras
        {

            get
            {
                TimeSpan duracion = FechaLlegada - FechaSalida;
                return Math.Round(duracion.TotalHours, 2);
            }
        }



    }
}