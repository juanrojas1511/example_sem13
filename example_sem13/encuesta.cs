using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_sem13
{
   internal class encuesta
    {
        private const int MaxRPTA = 100;
        private string[] rpta_Texto = new string[MaxRPTA];
        private int[] rpta_Contador = new int[5];
        private int Total_Rpta = 0;

        public void RealizarEncuesta()
        {
            Console.Clear();
            Mostrar_Encabezado("Nivel de Satisfacción");
            Console.WriteLine("¿Qué tan satisfecho está con la atención de nuestra tienda?");
            Console.WriteLine("1: Nada satisfecho");
            Console.WriteLine("2: No muy satisfecho");
            Console.WriteLine("3: Tolerable");
            Console.WriteLine("4: Satisfecho");
            Console.WriteLine("5: Muy satisfecho");
            Console.WriteLine("============================");
            Console.WriteLine("Ingrese una opción:");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion >= 1 && opcion <= 5)
            {
                rpta_Contador[opcion - 1]++;
                Total_Rpta++;
                rpta_Texto[Total_Rpta - 1] = OpcionATexto(opcion);

                Console.Clear();
                Mostrar_Encabezado("Nivel de Satisfacción");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("¡Gracias por participar!");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("============================");
                Mostrar_Mensaje("Presione una tecla para regresar al menú ...");
                Console.ReadKey();
            }
            else
            {
                Mostrar_Mensaje("Inténtelo de nuevo.");
                Mostrar_Mensaje("Presione una tecla para regresar al menú ...");
                Console.ReadKey();
            }
        }

        public void VerDatosRegistrados()
        {
            Console.Clear();
            Mostrar_Encabezado("Ver datos registrados");
            Mostrar_Datos();

            Console.WriteLine("\nPresione una tecla para regresar ...");
            Console.ReadKey();
        }

        public void Eliminar_Dato()
        {
            Console.Clear();
            Mostrar_Encabezado("Eliminar un dato");
            Mostrar_Datos();
            Console.WriteLine("===============================");
            Console.Write("Ingrese la posición a eliminar: ");
            int posicion = int.Parse(Console.ReadLine());

            if (EsPosicion_Valida(posicion))
            {
                int opcion = Texto_Opcion(rpta_Texto[posicion]);
                rpta_Contador[opcion - 1]--;
                Total_Rpta--;

                for (int i = posicion; i < Total_Rpta; i++)
                {
                    rpta_Texto[i] = rpta_Texto[i + 1];
                } 
                Mostrar_Encabezado($"Posición {posicion} eliminada.");
                Mostrar_Mensaje("Presione una tecla para regresar ...");
                Console.ReadKey();
            }
            else
            {
                Mostrar_Mensaje("Inténtelo de nuevo.");
                Mostrar_Mensaje("Presione una tecla para regresar ...");
                Console.ReadKey();
            }
        }

        public void Ordenar_Datos()
        {
            Console.Clear();
            Mostrar_Encabezado("Ordenar datos");
            Array.Sort(rpta_Texto, 0, Total_Rpta);
            Mostrar_Datos();

            Console.WriteLine("\nPresione una tecla para regresar ...");
            Console.ReadKey();
        }

        private static string OpcionATexto(int opcion)
        {
            switch (opcion)
            {
                case 1: return "Nada satisfecho";
                case 2: return "No muy satisfecho";
                case 3: return "Tolerable";
                case 4: return "Satisfecho";
                case 5: return "Muy satisfecho";
                default: return "";
            }
        }

        private static int Texto_Opcion(string texto)
        {
            switch (texto)
            {
                case "Nada satisfecho": return 1;
                case "No muy satisfecho": return 2;
                case "Tolerable": return 3;
                case "Satisfecho": return 4;
                case "Muy satisfecho": return 5;
                default: return -1;
            }
        }

        private bool EsPosicion_Valida(int posicion)
        {
            return posicion >= 0 && posicion < Total_Rpta;
        }

        private void Mostrar_Datos()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("Datos registrados");
            Console.WriteLine("===============================");

            for (int i = 0; i < Total_Rpta; i++)
            {
                Console.Write($"[{rpta_Texto[i]}] ");
                if ((i + 1) % 5 == 0)
                    Console.WriteLine();
            }

            Mostrar_Resumen();
        }

        private void Mostrar_Resumen()
        {
            Console.WriteLine("\nResumen:");
            for (int i = 0; i < rpta_Contador.Length; i++)
            {
                Console.WriteLine($"{rpta_Contador[i]:D2} personas: {rpta_Texto[i]}");
            }
        }

        private static void Mostrar_Encabezado(string titulo)
        {
            Console.WriteLine("===============================");
            Console.WriteLine(titulo);
            Console.WriteLine("===============================");
        }

        private static void Mostrar_Mensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}

