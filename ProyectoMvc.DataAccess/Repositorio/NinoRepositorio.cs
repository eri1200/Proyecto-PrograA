using ProyectoMvc.DataAccess.Data;
using ProyectoMvc.DataAccess.Repositorio.IRepositorio;
using ProyectoMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoMvc.DataAccess.Repositorio
{
    public class NinoRepositorio : Repositorio<Nino>, INinoRepositorio
    {
        public NinoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        readonly ApplicationDbContext _db;

        public void Actualizar(Nino nino)
        {
            var t = _db.Ninos.FirstOrDefault(s => s.Id == nino.Id);
            if (t != null)
            {
                t.Nombre = nino.Nombre;
                t.Apellidos = nino.Apellidos;
                t.FechaNacimiento = nino.FechaNacimiento;
                t.Horario = nino.Horario;
                t.Encargado = nino.Encargado;
            }
        }
    }
}
