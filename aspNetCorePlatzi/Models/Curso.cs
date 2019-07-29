using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aspNetCorePlatzi.Models
{
    public class Curso:ObjetoEscuelaBase
    {
        [Required(ErrorMessage = "Nombre Requerido")]
        [StringLength(10, ErrorMessage = "La longitud máxima es de 5 caracteres")]
        public override string Nombre { get; set; }

        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }

        [Display(Prompt = "Direccion Correspondencia", Name = "Address")]
        [Required]
        [MinLength(10)]
        public string Dirección { get; set; }

        public string escuelaId { get; set; }
        public Escuela escuela { get; set; }
    }
}