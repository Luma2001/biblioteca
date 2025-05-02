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

            Console.WriteLine("Cargando Libros a Biblioteca:");
                cargarLibros(20);

            Console.WriteLine("Probando retiro de Libro5: " + biblioteca.retirarLibro("Libro5"));//respuesta TRUE

            Console.WriteLine("Lista de Libros, sin Libro5");
                 biblioteca.listarLibros();//Verificamos que el libro 5 está retirado de la lista
            Console.WriteLine("Probando dar de alta a Lectores: ");
            Console.WriteLine("\t\tLector Agregado: " + biblioteca.altaLector("Pedro Vargas", "34222651", "Almirante Brown 700, Ciudad"));//La respuesta debe ser TRUE
            Console.WriteLine("\t\tLector Agregado: " + biblioteca.altaLector("Mariana Martinez", "23789834", "Viamonte 2118, Ciudad")); //La respuesta debe ser TRUE

            Console.WriteLine("Lista de Lectores:");
                 biblioteca.listarLectores(); //Debe mostrar lectores dados de alta
            
            Console.WriteLine("Probando Préstamos de Libros:");
                Console.WriteLine("\t\tRespuesta Esperada: LIBRO INEXISTENTE -- Respuesta Recibida: " + biblioteca.prestarLibro("Libro5", "34222651"));//La respuesta debe ser LIBRO INEXISTENTE
                Console.WriteLine("\t\tRespuesta Esperada: PRESTAMO EXITOSO -- Respuesta Recibida: " + biblioteca.prestarLibro("Libro6", "34222651"));//La respuesta debe ser "PRESTAMO EXITOSO"
                Console.WriteLine("\t\tRespuesta Esperada: PRESTAMO EXITOSO -- Respuesta Recibida: " + biblioteca.prestarLibro("Libro1", "34222651"));//La respuesta debe ser "PRESTAMO EXITOSO"
                Console.WriteLine("\t\tRespuesta Esperada: PRESTAMO EXITOSO -- Respuesta Recibida: " + biblioteca.prestarLibro("Libro7", "34222651"));//La respuesta debe ser "PRESTAMO EXITOSO"
            
            Console.WriteLine("Lista de Lectores:");
                biblioteca.listarLectores();//Debe mostrar ahora los mismos lectores con la lista de libros prestados
            
            Console.WriteLine("Probando Préstamos de Libros (otras respuestas):");
                Console.WriteLine("\t\tRespuesta Esperada: TOPE DE PRESTAMO ALCANZADO -- Respuesta Recibida: " + biblioteca.prestarLibro("Libro9", "34222651"));//La respuesta debe ser "TOPE DE PRESTAMO ALCANZADO"
                Console.WriteLine("\t\tRespuesta Esperada: LECTOR INEXISTENTE -- Respuesta Recibida: " + biblioteca.prestarLibro("Libro2", "34222234"));//La respuesta debe ser "LECTOR INEXISTENTE"
                Console.WriteLine("\t\tRespuesta Esperada: LIBRO INEXISTENTE -- Respuesta Recibida: " + biblioteca.prestarLibro("Libro6", "23789834"));//La respuesta debe ser "LIBRO INEXISTENTE"

            Console.WriteLine("Probando Devolución de Libros:");
            Console.WriteLine("\t\t Respuesta Esperada: EL LECTOR NO TIENE ESTE LIBRO PRESTADO -- Respuesta Recibida: Libro devuelto: " + biblioteca.devolverLibro("Libro2", "34222651"));//respuesta "EL LECTOR NO TIENE ESTE LIBRO PRESTADO"
            Console.WriteLine("\t\t Respuesta Esperada: LECTOR INEXISTENTE -- Respuesta Recibida: Libro devuelto: " + biblioteca.devolverLibro("Libro6", "342226888"));//respuesta "LECTOR INEXISTENTE"
            Console.WriteLine("\t\t Respuesta Esperada: DEVOLUCIÓN EXITOSA -- Respuesta Recibida: Libro devuelto: " + biblioteca.devolverLibro("Libro6", "34222651"));//respuesta "DEVOLUCIÓN EXITOSA"
            Console.WriteLine("Lista de Libros, con Libro6");
                    biblioteca.listarLibros();//Verificamos que Libro6 figura ahora en la lista de Libros
                Console.WriteLine("Lista de Lectores:");
                    biblioteca.listarLectores();//Y ya no figura en la lista de libros prestados

            Console.WriteLine("Probando Prestar Libro devuelto anteriormente:");
            Console.WriteLine("\t\tRespuesta Esperada: PRESTAMO EXITOSO -- Respuesta Recibida: " + biblioteca.prestarLibro("Libro6", "23789834"));//La respuesta debe ser "PRESTAMO EXITOSO"
            Console.WriteLine("\t\tRespuesta Esperada: PRESTAMO EXITOSO -- Respuesta Recibida: " + biblioteca.prestarLibro("Libro9", "34222651"));//La respuesta debe ser "PRESTAMO EXITOSO"
                Console.WriteLine("Lista de Libros, sin libros prestados");
                    biblioteca.listarLibros();
                Console.WriteLine("Lista de Lectores:");
                    biblioteca.listarLectores();

            //Metodo
            void cargarLibros(int cantidad)
            {
                bool pude;
                for (int i = 1; i <= cantidad; i++)
                {
                    pude = biblioteca.agregarLibro("Libro" + i, "Autor" + i, "Editorial" + i, "Género" + i);
                    if (pude)
                    {
                        Console.WriteLine("\t\tLibro" + i + " agregado correctamente.");
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
