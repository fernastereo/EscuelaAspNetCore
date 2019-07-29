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
            escuela.Nombre = "Ferna School S.A.S.";
            escuela.Ciudad = "Toronto";
            escuela.Pais = "Canadá";
            escuela.Dirección = "689 Old Weston Rd.";
            escuela.TipoEscuela = TiposEscuela.PreEscolar;

            //Cargar cursos de la escuela
            var Cursos = CargarCursos(escuela);
            //Por cada curso cargar asignaturas
            var Asignaturas = CargarAsignaturas(Cursos);
            //Por cada curso cargar alumnos
            var Alumnos = CargarAlumnos(Cursos);

            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(Cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(Asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(Alumnos.ToArray());
        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> Cursos) {
            var listaCompleta = new List<Asignatura>();

            foreach (var curso in Cursos)
            {
                var tmpList = new List<Asignatura>() {
                    new Asignatura { Id= Guid.NewGuid().ToString(), Nombre = "Matemáticas", cursoId = curso.Id},
                    new Asignatura { Id = Guid.NewGuid().ToString(), Nombre = "Educación Física", cursoId = curso.Id },
                    new Asignatura { Id = Guid.NewGuid().ToString(), Nombre = "Castellano", cursoId = curso.Id },
                    new Asignatura { Id = Guid.NewGuid().ToString(), Nombre = "Ciencias Naturales", cursoId = curso.Id },
                    new Asignatura { Id = Guid.NewGuid().ToString(), Nombre = "Algoritmos", cursoId = curso.Id }
                };
                listaCompleta.AddRange(tmpList);
                //curso.Asignaturas = tmpList;
            }
            return listaCompleta;
        }

        private static List<Curso> CargarCursos(Escuela escuela) {
            return new List<Curso>(){
                new Curso() {
                    Id = Guid.NewGuid().ToString(),
                    escuelaId = escuela.Id,
                    Nombre = "Curso 101",
                    Jornada = TiposJornada.Mañana
                },
                new Curso() {
                    Id = Guid.NewGuid().ToString(),
                    escuelaId = escuela.Id,
                    Nombre = "Curso 201",
                    Jornada = TiposJornada.Tarde
                },
                new Curso() {
                    Id = Guid.NewGuid().ToString(),
                    escuelaId = escuela.Id,
                    Nombre = "Curso 301",
                    Jornada = TiposJornada.Noche
                },
                new Curso() {
                    Id = Guid.NewGuid().ToString(),
                    escuelaId = escuela.Id,
                    Nombre = "Curso 401",
                    Jornada = TiposJornada.Mañana
                },
                new Curso() {
                    Id = Guid.NewGuid().ToString(),
                    escuelaId = escuela.Id,
                    Nombre = "Curso 501",
                    Jornada = TiposJornada.Tarde
                },
            };
        }

        private List<Alumno> CargarAlumnos(List<Curso> cursos) {
            var listaAlumnos = new List<Alumno>();

            Random rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                var tmpAlumnos = GenerarAlumnosAlAzar(curso, cantRandom);
                //curso.Alumnos = tmpAlumnos;
                listaAlumnos.AddRange(tmpAlumnos);
            }
            return listaAlumnos;
        }

        private List<Alumno> GenerarAlumnosAlAzar(Curso curso, int cantidad) {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno {
                                   cursoId = curso.Id,
                                   Id = Guid.NewGuid().ToString(),
                                   Nombre = $"{n1} {n2} {a1}"
                               };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }

    }
}
