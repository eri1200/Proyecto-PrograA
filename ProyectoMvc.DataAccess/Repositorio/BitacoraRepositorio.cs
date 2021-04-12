using ProyectoMvc.DataAccess.Data;
using ProyectoMvc.DataAccess.Repositorio.IRepositorio;
using ProyectoMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoMvc.DataAccess.Repositorio
{
    public class BitacoraRepositorio : Repositorio<Bitacora>, IBitacoraRepositorio
    {
        public BitacoraRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        readonly ApplicationDbContext _db;

        public void Actualizar(Bitacora bitacora)
        {
            var t = _db.Bitacoras.FirstOrDefault(s => s.Id == bitacora.Id);
            if (t != null)
            {
                t.Entrada = bitacora.Entrada;
                t.Salida = bitacora.Salida;
                t.Motivo = bitacora.Motivo;
                t.Empleado = bitacora.Empleado;
                t.Nino = bitacora.Nino;
                t.Encargado = bitacora.Encargado;
            }
        }
    }
}

