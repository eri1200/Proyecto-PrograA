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
    public class BitacoraController : Controller
    { 

    public BitacoraController(IControlador controlador)
    {
        _controlador = controlador;
    }

    readonly IControlador _controlador;

    public IActionResult Bitacora()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BitacoraUpsert(int id = 0)
        {
            if (id == 0)
                return View(new Bitacora());
            else
            {
                var t = _controlador.Bitacoras.Buscar(id);
                if (t == null)
                {
                    return NotFound();
                }
                return View(t);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BitacoraUpsert(int id, Bitacora bitacora)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _controlador.Bitacoras.Agregar(bitacora);
                    _controlador.Guardar();
                }
                else
                {
                    try
                    {
                        _controlador.Bitacoras.Actualizar(bitacora);
                        _controlador.Guardar();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (_controlador.Bitacoras.Buscar(bitacora.Id) == null)
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return Json(new { success = true, message = "El nuevo ingreso ha sido guardada." });
            }

            return Json(new { success = false, message = "Ocurrió un error guardando el nuevo ingreso." });
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Json(new { success = true, data = _controlador.Bitacoras.Listar() });
        }

        [HttpDelete]
        public IActionResult Borrar(int id)
        {
            var t = _controlador.Bitacoras.Buscar(id);
            if (t == null)
            {
                return Json(new { success = false, message = "No se borro la bitacora." });
            }
            _controlador.Bitacoras.Remover(t);
            _controlador.Guardar();
            return Json(new { success = true, message = "La bitacora ha sido borrada." });
        }
    }
}
