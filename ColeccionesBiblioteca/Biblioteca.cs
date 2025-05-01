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

        public bool eliminarLibro(string titulo) 
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
            Lector lectorBuscado = null;
            int i = 0;
            while (i < lectores.Count && !lectores[i].Dni.Equals(dni))
                i++;
            if(i != lectores.Count)
                lectorBuscado=lectores[i];
            return lectorBuscado;
        }
        public bool altaLector(string nombre,string dni, string direccion,int prestamo)
        {
            bool resultado = false;
            Lector lector;
            lector = buscarLector(dni);
            if (lector == null)
            {
                lector = new Lector(nombre, dni, direccion, prestamo);
                lectores.Add(lector);
                resultado = true;
            }
            return resultado;
        }

        
        public string prestarLibro(string titulo, string dni)
        {
            string resultado = "Libro o Lector inexistente";
            Libro libro;
            Lector lector;
            libro = buscarLibro(titulo);
            lector = buscarLector(dni);
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
                eliminarLibro(libro.Titulo);
                resultado = "PRESTAMO EXITOSO";
            }

                return resultado;
        }

        public string devolverLibro(string titulo, string autor, string editorial, string genero,string dni) {
            string resultado = "Libro o Lector inexistente";
            
            Lector lector;
            bool libroDevuelto;
             libroDevuelto= agregarLibro(titulo, autor, editorial, genero);

            lector = buscarLector(dni);

            if (lector == null)
            {
                resultado = "LECTOR INEXISTENTE";
            }
            else if(lector != null && libroDevuelto)
            {
                lector.Prestamo -= 1;
                resultado = "Devolución exitosa";
            }

            return resultado;
        }

    }
}
