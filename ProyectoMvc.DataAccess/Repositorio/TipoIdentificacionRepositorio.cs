using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoMvc.DataAccess.Data;
using ProyectoMvc.DataAccess.Repositorio.IRepositorio;
using ProyectoMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoMvc.DataAccess.Repositorio
{
    public class TipoIdentificacionRepositorio : Repositorio<TipoIdentificacion>, ITipoIdentificacionRepositorio
    {
        public TipoIdentificacionRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        readonly ApplicationDbContext _db;

        public void Actualizar(TipoIdentificacion tipoIdentificacion)
        {
            var t = _db.TiposIdentificacion.FirstOrDefault(s => s.Id == tipoIdentificacion.Id);
            if (t != null)
            {
                t.Descripcion = tipoIdentificacion.Descripcion;
            }
        }

        public IEnumerable<SelectListItem> Listar()
        {
            return _db.TiposIdentificacion.Select(i => new SelectListItem()
            {
                Text = i.Descripcion,
                Value = i.Id.ToString()
            });;
        }
    }
}
