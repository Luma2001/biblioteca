using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeccionesBiblioteca
{
    internal class Lector
    {
        //Atributos
        private string nombre;
        private string dni;
        private string direccion;
        private int prestamo;

        //Constructor
        public Lector(string nombre, string dni, string direccion, int prestamo)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.direccion = direccion;
            this.prestamo = prestamo;
        }

        //Getters and Setters
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Dni { get { return dni; } set { dni = value; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }
        public int Prestamo { get { return prestamo; } set { prestamo = value; } }

        //ToString
        public override string ToString()
        {
            return $"Nombre: {Nombre}, DNI: {Dni}, Dirección: {Direccion}, Libros Prestados: {Prestamo}";
        }

        //Métodos




    }//Fin classLectores
}
