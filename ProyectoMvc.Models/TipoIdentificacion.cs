using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoMvc.Models
{
    public class TipoIdentificacion
    {

            [Key]
            public int Id { get; set; }

            [DisplayName("Descripcion")]
            [Required(ErrorMessage = "Este campo es requerido.")]
            public string Descripcion { get; set; }

    }
}
