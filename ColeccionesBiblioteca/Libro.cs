using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeccionesBiblioteca
{
    internal class Libro
    {
        //Atributos
        private string titulo;
        private string autor;
        private string editorial;
        private string genero;
        


        //Constructor
        public Libro(string titulo, string autor, string editorial, string genero)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.editorial = editorial;
            this.genero = editorial;
        }

        //Getters and setters
        public string Titulo { get { return titulo; } set { titulo=value; } }           
        public string Autor { get { return autor; } set {  autor = value; } }   
        public string Editorial { get { return editorial; } set { editorial = value; } } 
        public string Genero { get { return genero; } set { genero = value; } }
        
        //ToString
        public override string ToString()
        {
            return $"Título: {Titulo} Autor: {Autor} Editorial: {Editorial} Genero: {Genero}";
        }
    }
}
