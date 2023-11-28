using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_sem13
{
    internal class Program
    {
        static void Main()
        {
            encuesta encuestas = new encuesta();
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("Encuestas de Calidad");
                Console.WriteLine("===============================");
                Console.WriteLine("1: Realizar Encuesta\n2: Ver datos registrados\n3: Eliminar un dato\n4: Ordenar datos de menor a mayor\n5: Salir");
                Console.WriteLine("===============================");
                Console.Write("Ingrese una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        encuestas.RealizarEncuesta();
                        break;
                    case 2:
                        encuestas.VerDatosRegistrados();
                        break;
                    case 3:
                        encuestas.Eliminar_Dato();
                        break;
                    case 4:
                        encuestas.Ordenar_Datos();
                        break;
                    case 5:
                        Console.WriteLine("¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Inténtelo de nuevo.");
                        Console.WriteLine("Presione una tecla para regresar al menú ...");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 5);
        }
    }
}

