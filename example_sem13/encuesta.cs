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
        private string[] RptaTexto = new string[MaxRPTA];
        private int[] RptaContador = new int[5];
        private int totalRpta = 0;

        public void RealizarEncuesta()
        {
            Console.Clear();
            MostrarEncabezado("Nivel de Satisfacción");
            Console.WriteLine("¿Qué tan satisfecho está con la atención de nuestra tienda?");
            Console.WriteLine("1: Nada satisfecho");
            Console.WriteLine("2: No muy satisfech");
            Console.WriteLine("3: Tolerable");
            Console.WriteLine("4: Satisfecho");
            Console.WriteLine("5: Muy satisfecho");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion >= 1 && opcion <= 5)
            {
                RptaContador[opcion - 1]++;
                totalRpta++;
                RptaTexto[totalRpta - 1] = OpcionATexto(opcion);

                Console.Clear();
                MostrarEncabezado("¡Gracias por participar!");
                MostrarMensaje("Presione una tecla para regresar al menú ...");
                Console.ReadKey();
            }
            else
            {
                MostrarMensaje("Opción no válida. Inténtelo de nuevo.");
                MostrarMensaje("Presione una tecla para regresar al menú ...");
                Console.ReadKey();
            }
        }

        public void VerDatosRegistrados()
        {
            Console.Clear();
            MostrarEncabezado("Ver datos registrados");
            MostrarDatos();

            Console.WriteLine("\nPresione una tecla para regresar ...");
            Console.ReadKey();
        }

        public void EliminarDato()
        {
            Console.Clear();
            MostrarEncabezado("Eliminar un dato");
            MostrarDatos();
            Console.Write("Ingrese la posición a eliminar: ");
            int posicion = int.Parse(Console.ReadLine());

            if (EsPosicionValida(posicion))
            {
                int opcion = TextoAOpcion(RptaTexto[posicion]);
                RptaContador[opcion - 1]--;
                totalRpta--;

                for (int i = posicion; i < totalRpta; i++)
                {
                    RptaTexto[i] = RptaTexto[i + 1];
                }

                Console.Clear();
                MostrarEncabezado($"Posición {posicion} eliminada.");
                MostrarMensaje("Presione una tecla para regresar ...");
                Console.ReadKey();
            }
            else
            {
                MostrarMensaje("Posición no válida. Inténtelo de nuevo.");
                MostrarMensaje("Presione una tecla para regresar ...");
                Console.ReadKey();
            }
        }

        public void OrdenarDatos()
        {
            Console.Clear();
            MostrarEncabezado("Ordenar datos");
            Array.Sort(RptaTexto, 0, totalRpta);
            MostrarDatos();

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

        private static int TextoAOpcion(string texto)
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

        private bool EsPosicionValida(int posicion)
        {
            return posicion >= 0 && posicion < totalRpta;
        }

        private void MostrarDatos()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("Datos registrados");
            Console.WriteLine("===============================");

            for (int i = 0; i < totalRpta; i++)
            {
                Console.Write($"[{RptaTexto[i]}] ");
                if ((i + 1) % 5 == 0)
                    Console.WriteLine();
            }

            MostrarResumen();
        }

        private void MostrarResumen()
        {
            Console.WriteLine("\nResumen:");
            for (int i = 0; i < RptaContador.Length; i++)
            {
                Console.WriteLine($"{RptaContador[i]:D2} personas: {RptaTexto[i]}");
            }
        }

        private static void MostrarEncabezado(string titulo)
        {
            Console.WriteLine("===============================");
            Console.WriteLine(titulo);
            Console.WriteLine("===============================");
        }

        private static void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}

