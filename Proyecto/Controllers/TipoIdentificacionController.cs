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
    public class TipoIdentificacionController : Controller
    {
        public TipoIdentificacionController(IControlador controlador)
        {
            _controlador = controlador;
        }
        readonly IControlador _controlador;

        public IActionResult TipoIdentificacion()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TipoIdentificacionUpsert(int id = 0)
        {
            if (id == 0)
                return View(new TipoIdentificacion());
            else
            {
                var t = _controlador.TiposIdentificacion.Buscar(id);
                if (t == null)
                {
                    return NotFound();
                }
                return View(t);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TipoIdentificacionUpsert(int id, TipoIdentificacion tipoIdentificacion)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _controlador.TiposIdentificacion.Agregar(tipoIdentificacion);
                    _controlador.Guardar();
                }
                else
                {
                    try
                    {
                        _controlador.TiposIdentificacion.Actualizar(tipoIdentificacion);
                        _controlador.Guardar();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (_controlador.TiposIdentificacion.Buscar(tipoIdentificacion.Id) == null)
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
            return Json(new { success = true, data = _controlador.TiposIdentificacion.Listar() });
        }

        [HttpDelete]
        public IActionResult Borrar(int id)
        {
            var t = _controlador.TiposIdentificacion.Buscar(id);
            if (t == null)
            {
                return Json(new { success = false, message = "El registro no ha sido borrado." });
            }
            _controlador.TiposIdentificacion.Remover(t);
            _controlador.Guardar();
            return Json(new { success = true, message = "Registro borrado con éxito." });
        }
    }
}
