using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoMvc.Models
{
    public class Bitacora
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Encargado")]
        public int EncargoId { get; set; }

        [ForeignKey("EncargoId")]
        public Encargado Encargado { get; set; }

        [Required]
        [DisplayName("Nino")]
        public int NinoId { get; set; }

        [ForeignKey("NinoId")]
        public Nino Nino { get; set; }

        [Required]
        [DisplayName("Empleado")]
        public int EmpleadoId { get; set; }

        [ForeignKey("EmpleadoId")]
        public Empleado Empleado { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Entrada { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Salida { get; set; }

        [Required]
        [DisplayName("Motivo de la salida")]
        public string Motivo { get; set; }

    }
}
