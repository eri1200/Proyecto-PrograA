using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoMvc.Models
{
    public class Nino
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Nombre")]

        public string Nombre { get; set; }

        [Required]
        [DisplayName("Apellidos")]

        public string Apellidos { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [DisplayName("Edad")]
        public int Edad { get; set; }

        [Required]
        [DisplayName("Horario")]

        public string Horario { get; set; }

        public string Imagen { get; set; }

        [Required]
        [DisplayName("Encargado")]
        public int EncargoId { get; set; }

        [ForeignKey("EncargoId")]
        [DisplayName("Encargado")]
        public Encargado Encargado { get; set; }

        [NotMapped]
        public string NombreNino
        {
            get
            {
                return
                    string.Concat(Nombre, " ", Apellidos);
            }
        }
    }
}
