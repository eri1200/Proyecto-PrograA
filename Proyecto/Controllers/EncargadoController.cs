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
    public class EncargadoController : Controller
    {
        public EncargadoController(IControlador controlador)
        {
            _controlador = controlador;
        }
        readonly IControlador _controlador;

        public IActionResult Encargado()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EncargadoUpsert(int id = 0)
        {
            if (id == 0)
                return View(new Encargado());
            else
            {
                var t = _controlador.Encargados.Buscar(id);
                if (t == null)
                {
                    return NotFound();
                }
                return View(t);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EncargadoUpsert(int id, Encargado encargado)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _controlador.Encargados.Agregar(encargado);
                    _controlador.Guardar();
                }
                else
                {
                    try
                    {
                        _controlador.Encargados.Actualizar(encargado);
                        _controlador.Guardar();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (_controlador.Encargados.Buscar(encargado.Id) == null)
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
            return Json(new { success = true, data = _controlador.Encargados.Listar() });
        }

        [HttpDelete]
        public IActionResult Borrar(int id)
        {
            var t = _controlador.Encargados.Buscar(id);
            if (t == null)
            {
                return Json(new { success = false, message = "El registro no ha sido borrado." });
            }
            _controlador.Encargados.Remover(t);
            _controlador.Guardar();
            return Json(new { success = true, message = "Registro borrado con éxito." });
        }
    }
}
