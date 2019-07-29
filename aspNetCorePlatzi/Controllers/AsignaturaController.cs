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
        [Route("asignatura/index")]
        [Route("asignatura/index/{asignaturaid}")]

        //public IActionResult Index() {
        //    ViewBag.Cosadinamica = "Cualquier vaina que quiere enviar a la vista";
        //    ViewBag.Fecha = DateTime.Now;

        //    return View(_context.Asignaturas.FirstOrDefault());
        //}

        public IActionResult Index(string asignaturaid) {

            if (!string.IsNullOrWhiteSpace(asignaturaid))
            {
                var asignatura = from asig in _context.Asignaturas
                                 where asig.Id == asignaturaid
                                 select asig;

                return View(asignatura.SingleOrDefault());
            } else
            {
                return View("multiasignatura", _context.Asignaturas);
            }
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