using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoMvc.Models
{
    public class Expediente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Nino")]
        public int NinoId { get; set; }

        [ForeignKey("NinoId")]
        [DisplayName("Nino")]
        public Nino Nino { get; set; }

        [Required]
        [DisplayName("Alergia")]
        public string Alergia { get; set; }

        [Required]
        [DisplayName("Encargado")]
        public int EncargoId { get; set; }

        [ForeignKey("EncargoId")]
        [DisplayName("Encargado")]
        public Encargado Encargado { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [DisplayName("Residencia")]

        public string Residencia { get; set; }

        [DisplayName("Medicamento")]

        public string Medicamento { get; set; }


    }
}
