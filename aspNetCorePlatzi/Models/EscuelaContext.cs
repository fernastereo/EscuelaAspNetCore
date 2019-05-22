using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspNetCorePlatzi.Models {
    public class EscuelaContext: DbContext {

        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluación> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options){

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            var escuela = new Escuela();
            escuela.AñoDeCreación = 2001;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "Ferna School S.A.";
            escuela.Ciudad = "Vancouver";
            escuela.Pais = "Canadá";
            escuela.Dirección = "689 Old Weston Rd.";
            escuela.TipoEscuela = TiposEscuela.PreEscolar;

            modelBuilder.Entity<Escuela>().HasData(escuela);

            modelBuilder.Entity<Asignatura>().HasData(
                new Asignatura{Id=Guid.NewGuid().ToString(), Nombre="Matemáticas"} ,
                new Asignatura{Id=Guid.NewGuid().ToString(), Nombre="Educación Física"},
                new Asignatura{Id=Guid.NewGuid().ToString(), Nombre="Castellano"},
                new Asignatura{Id=Guid.NewGuid().ToString(), Nombre="Ciencias Naturales"}
            );

            modelBuilder.Entity<Alumno>().HasData(GenerarAlumnosAlAzar(10).ToArray());

        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad) {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }

    }
}
