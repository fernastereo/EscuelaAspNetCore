using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspNetCorePlatzi.Models;

namespace aspNetCorePlatzi.Controllers
{
    public class EscuelaController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.Cosadinamica = "Cualquier vaina que quiere enviar a la vista";

            var escuela =_context.Escuelas.FirstOrDefault();

            return View(escuela);
        }

        private EscuelaContext _context;

        public EscuelaController(EscuelaContext context) {

            _context = context;
        }
    }
}