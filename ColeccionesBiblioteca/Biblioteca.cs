using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeccionesBiblioteca
{
    internal class Biblioteca
    {
        //atributos
        private List<Libro> libros;
        private List<Lector> lectores;

        //Constructor
        public Biblioteca()
        {
            this.libros = new List<Libro>();
            this.lectores = new List<Lector>();
        }

        //Métodos
        private Libro buscarLibro(string titulo)
        {
            Libro libroBuscado = null;
            int i = 0;
            while (i < libros.Count && !libros[i].Titulo.Equals(titulo))
                i++;
            if (i != libros.Count)
                libroBuscado = libros[i];
            return libroBuscado;
        }

        

        public bool agregarLibro(string titulo, string autor, string editorial, string genero)
        {
            bool resultado = false;
            Libro libro;
            libro = buscarLibro(titulo);
            if (libro == null)
            {
                libro = new Libro(titulo,autor,editorial,genero);
                libros.Add(libro);
                resultado= true;
            }
            return resultado;
        }

        public void listarLibros() 
        { 
            foreach (var libro in libros)
                Console.WriteLine(libro.ToString());
        }
        public void listarLectores()
        {
            
            foreach (var lector in lectores)
            {
                string libroInfo = string.Join(", \n\t", lector.LibrosPrestados.Select(lp => lp.ToString()));
                Console.WriteLine($"{lector.ToString()} \n\t\tLista de Libros Prestados: \n\t{libroInfo}");
            }
                
        }


        public bool retirarLibro(string titulo) 
        {
            bool resultado = false;
            Libro libro;
            libro= buscarLibro(titulo);
            if (libro != null)
            {
                libros.Remove(libro);
                resultado = true;
            }
            return resultado;
        }

        private Lector buscarLector(string dni)
        {
            if (lectores == null || lectores.Count == 0)
                return null;

            Lector lectorBuscado = null;
            int i = 0;

            while (i < lectores.Count && (lectores[i].Dni == null || !lectores[i].Dni.Equals(dni)))
                i++;

            if (i < lectores.Count)
                lectorBuscado = lectores[i];

            return lectorBuscado;
        }


        public bool altaLector(string nombre,string dni, string direccion)
        {
            bool resultado = false;
            Lector lector;
            lector = buscarLector(dni);
            if (lector == null)
            {
                lector = new Lector(nombre, dni, direccion, 0);
                lectores.Add(lector);
                resultado = true;
            }
            return resultado;
        }

        
        public string prestarLibro(string titulo, string dni)
        {
            string resultado = "Libro o Lector inexistente";
            Libro libro= buscarLibro(titulo);
            Lector lector= buscarLector(dni);
            
            
            if (libro == null)
            {
                resultado = "LIBRO INEXISTENTE";
            }else if(lector == null)
            {
                resultado = "LECTOR INEXISTENTE";
            }
            else if (lector!= null && lector.Prestamo == 3)
            {
                resultado = "TOPE DE PRESTAMO ALCANZADO";
            }
            else if(lector != null && libro!=null)
            {
                lector.Prestamo += 1;
                retirarLibro(libro.Titulo);
                lector.LibrosPrestados.Add(libro);

                resultado = "PRESTAMO EXITOSO";
            }

                return resultado;
        }

        public string devolverLibro(string titulo, string dni) 
        {
                        
            Lector lector=buscarLector(dni);
            

            if(lector == null)
            {
                return "LECTOR INEXISTENTE";
            }

            Libro libroDevuelto = lector.LibrosPrestados.FirstOrDefault(libro => libro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

            if (libroDevuelto == null)
            {
                return "El LECTOR NO TIENE ESTE LIBRO PRESTADO";
            }

            
            else 
            {
                lector.LibrosPrestados.Remove(libroDevuelto);
                libros.Add(libroDevuelto);
                lector.Prestamo -= 1;
                return "DEVOLUCIÓN EXITOSA"; 
            }

            
        }

    }
}
