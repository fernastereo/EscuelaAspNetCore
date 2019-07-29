using System;

namespace aspNetCorePlatzi.Models
{
    public class Evaluación:ObjetoEscuelaBase
    {
        public string alumnoId { get; set; }
        public Alumno Alumno { get; set; }

        public string asignaturaId { get; set; }
        public Asignatura Asignatura  { get; set; }

        public float Nota { get; set; }

        public override string ToString()
        {
            return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        }
    }
}