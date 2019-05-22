using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspNetCorePlatzi.Models;

namespace aspNetCorePlatzi.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index() {
            ViewBag.Cosadinamica = "Cualquier vaina que quiere enviar a la vista";
            ViewBag.Fecha = DateTime.Now;

            return View(_context.Asignaturas.FirstOrDefault());
        }

        public IActionResult multiAsignatura()
        {
            ViewBag.Cosadinamica = "Cualquier vaina que quiere enviar a la vista";
            ViewBag.Fecha = DateTime.Now;

            return View(_context.Asignaturas);
        }

        private EscuelaContext _context;

        public AsignaturaController(EscuelaContext context) {
            _context = context;
        }
    }
}