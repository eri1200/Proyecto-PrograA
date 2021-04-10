using Microsoft.EntityFrameworkCore;
using ProyectoMvc.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoMvc.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<TipoIdentificacion> TiposIdentificacion { get; set; }

        public DbSet<Encargado> Encargados { get; set; }

        public DbSet<Nino> Ninos { get; set; }




    }
}
