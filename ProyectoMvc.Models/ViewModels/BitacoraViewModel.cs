using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoMvc.Models.ViewModels
{
    public class BitacoraViewModel
    {
        public BitacoraViewModel()
        {
            Id = new List<SelectListItem>();
        }

        public Bitacora Bitacora { get; set; }

        public List<SelectListItem> Id { get; set; }
    }
}
