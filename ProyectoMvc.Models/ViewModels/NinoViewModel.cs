using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoMvc.Models.ViewModels
{
    public class NinoViewModel
    {
        public NinoViewModel()
        {
            TiposIdentificacion = new List<SelectListItem>();
        }
        public Nino Nino { get; set; }

        public List<SelectListItem> TiposIdentificacion { get; set; }
        
    }
}
