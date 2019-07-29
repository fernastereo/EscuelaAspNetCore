using System;
using System.Collections.Generic;

namespace aspNetCorePlatzi.Models
{
    public class Asignatura:ObjetoEscuelaBase
    {
        public string cursoId { get; set; }
        public Curso curso { get; set; }

        public List<Evaluación> Evaluaciones { get; set; }
    }
}