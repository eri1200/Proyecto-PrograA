using ProyectoMvc.DataAccess.Data;
using ProyectoMvc.DataAccess.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoMvc.DataAccess.Repositorio
{
    public class Controlador : IControlador
    {
        public Controlador(ApplicationDbContext db)
        {
            _db = db;
            //Expedientes = new ExpedienteRepositorio(_db);
            TiposIdentificacion = new TipoIdentificacionRepositorio(_db);
            Encargados = new EncargadoRepositorio(_db);
            Empleados = new EmpleadoRepositorio(_db);
            Ninos = new NinoRepositorio(_db);
        }

        readonly ApplicationDbContext _db;

        

        public ITipoIdentificacionRepositorio TiposIdentificacion { get; private set; }

        public IEncargadoRepositorio Encargados { get; private set; }

        public IEmpleadoRepositorio Empleados { get; private set; }

        public INinoRepositorio Ninos { get; private set; }



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
