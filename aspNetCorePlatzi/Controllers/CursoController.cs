using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspNetCorePlatzi.Models;

namespace aspNetCorePlatzi.Controllers
{
    public class CursoController : Controller
    {
        //[Route("asignatura/index")]
        //[Route("asignatura/index/{asignaturaid}")]

        public IActionResult Index(string id) {

            if (!string.IsNullOrWhiteSpace(id))
            {
                var curso = from cur in _context.Cursos
                                 where cur.Id == id
                                 select cur;

                return View(curso.SingleOrDefault());
            } else
            {
                return View("multicurso", _context.Cursos);
            }
        }
        public IActionResult multiCurso()
        {
            ViewBag.Cosadinamica = "Cualquier vaina que quiere enviar a la vista";
            ViewBag.Fecha = DateTime.Now;

            return View(_context.Cursos);
        }


        private EscuelaContext _context;

        public CursoController(EscuelaContext context) {
            _context = context;
        }
    }
}