using ProyectoMvc.DataAccess.Data;
using ProyectoMvc.DataAccess.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoMvc.DataAccess.Repositorio
{
    public class UnidadTrabajo: IUnidadTrabajo
    {
        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            ProcedimientoAlmacenado = new ProcedimientoAlmacenado(_db);

            Bitacoras = new BitacoraRepositorio(db);
            Ninos = new NinoRepositorio(db);
            Empleados = new EmpleadoRepositorio(db);
            TiposIdentificacion = new TipoIdentificacionRepositorio(db);
        }

        readonly ApplicationDbContext _db;

        public IProcedimientoAlmacenado ProcedimientoAlmacenado { get; private set; }

        public IBitacoraRepositorio Bitacoras { get; private set; }

        public INinoRepositorio Ninos { get; private set; }

        public IEmpleadoRepositorio Empleados { get; private set; }

        public ITipoIdentificacionRepositorio TiposIdentificacion { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Guardar() 
        {
            _db.SaveChanges();
        }
    }
}
