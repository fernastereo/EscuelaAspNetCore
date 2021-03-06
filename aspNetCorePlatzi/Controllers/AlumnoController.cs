﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspNetCorePlatzi.Models;

namespace aspNetCorePlatzi.Controllers
{
    public class AlumnoController : Controller
    {
        //[Route("asignatura/index")]
        //[Route("asignatura/index/{asignaturaid}")]

        public IActionResult Index(string id) {

            if (!string.IsNullOrWhiteSpace(id))
            {
                var alumno = from alumn in _context.Alumnos
                                 where alumn.Id == id
                                 select alumn;

                return View(alumno.SingleOrDefault());
            } else
            {
                return View("multialumno", _context.Alumnos);
            }
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