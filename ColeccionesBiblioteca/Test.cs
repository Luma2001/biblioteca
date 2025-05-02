using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeccionesBiblioteca
{
    internal class Test
    {
        static void Main(string[] args)
        {
            
        
            Biblioteca biblioteca = new Biblioteca();
            cargarLibros(20);
            biblioteca.listarLibros();
            Console.WriteLine(biblioteca.eliminarLibro("Libro5"));
            biblioteca.listarLibros();

            Console.WriteLine("Lector Agregado: " + biblioteca.altaLector("Pedro Vargas", "34222651", "Almirante Brown 700, Ciudad"));
            Console.WriteLine("Lector Agregado: " + biblioteca.altaLector("Mariana Martinez", "23789834", "Viamonte 2118, Ciudad"));
            biblioteca.listarLectores();
            Console.WriteLine(biblioteca.prestarLibro("Libro5", "34222651"));//La respuesta debe ser LIBRO INEXISTENTE
            Console.WriteLine(biblioteca.prestarLibro("Libro6", "34222651"));//La respuesta debe ser "PRESTAMO EXITOSO"
            Console.WriteLine(biblioteca.prestarLibro("Libro1", "34222651"));//La respuesta debe ser "PRESTAMO EXITOSO"
            Console.WriteLine(biblioteca.prestarLibro("Libro7", "34222651"));//La respuesta debe ser "PRESTAMO EXITOSO"
            biblioteca.listarLectores();
            Console.WriteLine(biblioteca.prestarLibro("Libro9", "34222651"));//La respuesta debe ser "TOPE DE PRESTAMO ALCANZADO
            Console.WriteLine(biblioteca.prestarLibro("Libro2", "34222234"));//La respuesta debe ser "LECTOR INEXISTENTE
            Console.WriteLine(biblioteca.prestarLibro("Libro6", "23789834"));//La respuesta debe ser "LIBRO INEXISTENTE
            Console.WriteLine("Libro devuelto: "+biblioteca.devolverLibro("Libro6", "Autor6", "Editorial6", "Genero6","34222651"));//respuesta TRUE
            Console.WriteLine(biblioteca.prestarLibro("Libro6", "23789834"));//La respuesta debe ser "PRESTAMO EXITOSO"
            Console.WriteLine(biblioteca.prestarLibro("Libro9", "34222651"));//La respuesta debe ser "PRESTAMO EXITOSO"
            
            //Metodo
            void cargarLibros(int cantidad)
            {
                bool pude;
                for (int i = 1; i <= cantidad; i++)
                {
                    pude = biblioteca.agregarLibro("Libro" + i, "Autor" + i, "Editorial" + i, "Género" + i);
                    if (pude)
                    {
                        Console.WriteLine("Libro" + i + " agregado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("Libro" + i + " ya existe en la biblioteca.");
                    }
                }
            }
        }
    }
}
