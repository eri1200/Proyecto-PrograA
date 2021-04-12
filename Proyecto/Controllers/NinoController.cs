using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoMvc.DataAccess.Repositorio.IRepositorio;
using ProyectoMvc.Models;

namespace ProyectoMvc.Controllers
{
    public class NinoController : Controller
    {
        public NinoController(IControlador controlador)
        {
            _controlador = controlador;
        }

        readonly IControlador _controlador;

        public IActionResult Nino()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NinoUpsert(int id = 0)
        {
            if (id == 0)
                return View(new Nino());
            else
            {
                var t = _controlador.Ninos.Buscar(id);
                if (t == null)
                {
                    return NotFound();
                }
                return View(t);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NinoUpsert(int id, Nino nino)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _controlador.Ninos.Agregar(nino);
                    _controlador.Guardar();
                }
                else
                {
                    try
                    {
                        _controlador.Ninos.Actualizar(nino);
                        _controlador.Guardar();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (_controlador.Ninos.Buscar(nino.Id) == null)
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
            return Json(new { success = true, data = _controlador.Ninos.Listar() });
        }

        [HttpDelete]
        public IActionResult Borrar(int id)
        {
            var t = _controlador.Ninos.Buscar(id);
            if (t == null)
            {
                return Json(new { success = false, message = "Niño o niña no borrado." });
            }
            _controlador.Ninos.Remover(t);
            _controlador.Guardar();
            return Json(new { success = true, message = "El niño ha sido borrado." });
        }
    }
}

