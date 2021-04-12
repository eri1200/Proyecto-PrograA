using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoMvc.DataAccess.Repositorio.IRepositorio;
using ProyectoMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMvc.Controllers
{
    public class EmpleadoController : Controller
    {
  
        public EmpleadoController(IControlador controlador)
        {
            _controlador = controlador;
        }
        readonly IControlador _controlador;

        public IActionResult Empleado()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EmpleadoUpsert(int id = 0)
        {
            if (id == 0)
                return View(new Empleado());
            else
            {
                var t = _controlador.Empleados.Buscar(id);
                if (t == null)
                {
                    return NotFound();
                }
                return View(t);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EmpleadoUpsert(int id, Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _controlador.Empleados.Agregar(empleado);
                    _controlador.Guardar();
                }
                else
                {
                    try
                    {
                        _controlador.Empleados.Actualizar(empleado);
                        _controlador.Guardar();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (_controlador.Empleados.Buscar(empleado.Id) == null)
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return Json(new { success = true, message = "El registro se ha guardado exitosamente." });
            }

            return Json(new { success = false, message = "Ocurrió un error guardando el nuevo ingreso." });
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Json(new { success = true, data = _controlador.Empleados.Listar() });
        }

        [HttpDelete]
        public IActionResult Borrar(int id)
        {
            var t = _controlador.Empleados.Buscar(id);
            if (t == null)
            {
                return Json(new { success = false, message = "El registro no ha sido borrado." });
            }
            _controlador.Empleados.Remover(t);
            _controlador.Guardar();
            return Json(new { success = true, message = "Registro borrado con éxito." });
        }
    }
}
