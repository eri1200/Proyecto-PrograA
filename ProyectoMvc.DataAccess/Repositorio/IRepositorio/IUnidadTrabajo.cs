using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoMvc.DataAccess.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        IBitacoraRepositorio Bitacoras { get; }

        INinoRepositorio Ninos { get; }

        IEmpleadoRepositorio Empleados { get; }

        ITipoIdentificacionRepositorio TiposIdentificacion { get; }

        IProcedimientoAlmacenado ProcedimientoAlmacenado { get; }

        void Guardar();
    }
}
