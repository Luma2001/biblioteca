using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeccionesBiblioteca
{
    internal class Lector
    {
        // Atributos
        private string nombre;
        private string dni;
        private string direccion;
        private int prestamo;
        private List<Libro> librosPrestados;

        // Constructor
        public Lector(string nombre, string dni, string direccion, int prestamo)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.direccion = direccion;
            this.prestamo = prestamo;
            this.librosPrestados = new List<Libro>(); // Inicializar la lista
        }

        //Getters and Setters
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Dni { get { return dni; } set { dni = value; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }
        public int Prestamo { get { return prestamo; } set { prestamo = value; } }
        public List<Libro> LibrosPrestados { get { return librosPrestados; } }

        //ToString
        
        public override string ToString()
        {
            return $"\t\tNombre: {Nombre}, DNI: {Dni}, Dirección: {Direccion}, Libros Prestados: {Prestamo}";
        }

        //Métodos




    }//Fin classLectores
}
