using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspNetCorePlatzi.Models;

namespace aspNetCorePlatzi.Controllers
{
    public class AlumnoController : Controller
    {
        public IActionResult Index() {
            ViewBag.Cosadinamica = "Cualquier vaina que quiere enviar a la vista";
            ViewBag.Fecha = DateTime.Now;

            return View(_context.Alumnos.FirstOrDefault());
        }

        public IActionResult multiAlumno()
        {
            ViewBag.Cosadinamica = "Cualquier vaina que quiere enviar a la vista";
            ViewBag.Fecha = DateTime.Now;

            return View(_context.Alumnos);
        }


        private EscuelaContext _context;

        public AlumnoController(EscuelaContext context) {
            _context = context;
        }
    }
}