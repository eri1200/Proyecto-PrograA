using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoMvc.Models
{
    public class Encargado
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Tipo Identificación")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int TipoIdentificacionId { get; set; }

        [ForeignKey("TipoIdentificacionId")]
        [DisplayName("Tipo Identificación")]
        public TipoIdentificacion TipoIdentificacion { get; set; }

        [DisplayName("Identificación")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres.")]
        public string Identificacion { get; set; }

        [Required]
        [DisplayName("Nombre")]

        public string Nombre { get; set; }

        [Required]
        [DisplayName("Apellidos")]

        public string Apellidos { get; set; }

        [Required]
        [DisplayName("Telefono")]
        public string Telefono { get; set; }

        [Required]
        [DisplayName("Correo Electronico")]

        public string Correo { get; set; }

        [Required]
        [DisplayName("Tipo de Parentesco")]

        public string Parentesco { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        public string Imagen { get; set; }

        [NotMapped]
        public string NombreEncargado
        {
            get
            {
                return
                    string.Concat(Nombre, " ", Apellidos);
            }
        }


    }
}
