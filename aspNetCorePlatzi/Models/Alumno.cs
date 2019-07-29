using System;
using System.Collections.Generic;

namespace aspNetCorePlatzi.Models
{
    public class Alumno: ObjetoEscuelaBase
    {
        public List<Evaluación> Evaluaciones { get; set; } //= new List<Evaluación>();

        public string cursoId { get; set; }
        public Curso curso { get; set; }
    }
}