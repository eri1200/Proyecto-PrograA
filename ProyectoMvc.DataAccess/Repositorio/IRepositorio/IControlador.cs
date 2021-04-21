using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoMvc.DataAccess.Repositorio.IRepositorio
{
    public interface IControlador : IDisposable
    {
        //IExpedienteRepositorio Expedientes { get; }

        ITipoIdentificacionRepositorio TiposIdentificacion { get; }

        IEncargadoRepositorio Encargados { get; }

        IEmpleadoRepositorio Empleados { get; }

        INinoRepositorio Ninos { get; }

        IBitacoraRepositorio Bitacoras { get; }

        void Guardar();
    }

    
}
