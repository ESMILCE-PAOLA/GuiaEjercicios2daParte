using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercicios2daParte
{
    public class PrimosGemelos
        {
            public static void Ejecutar()
            {
                Console.Clear(); //borra todo lo que había antes, dejando la pantalla en blanco para mostrar solo el contenido relevante de la opción seleccionada
                Console.Write("Ingrese un número entero m: ");
                int m = int.Parse(Console.ReadLine());

                int[] primosGemelos = EncontrarPrimosGemelos(m);

                Console.WriteLine($"Los primos gemelos son: {primosGemelos[0]} y {primosGemelos[1]}");
                Console.WriteLine("Presione una tecla para volver al menú...");
                Console.ReadKey();
            }
            /// <summary>
            /// Función para verificar si un número es primo
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            /// 
            static bool EsPrimo(int num)
        {
            if (num < 2) return false; // Los números menores a 2 no son primos
            for (int i = 2; i * i <= num; i++)// Iteramos desde 2 hasta la raíz cuadrada del número
            //teorema de los divisores menores o iguales a la raíz cuadrada (Si tiene un divisor, su menor divisor no es mayor que su raíz cuadrada.)
            {
                if (num % i == 0) return false; // Si num es divisible por i, no es primo (Un número es primo si solo tiene dos divisores: 1 y él mismo.)
            }
            return true; //Si no encontramos divisores, el número es primo
        }

        /// <summary>
        /// Función para encontrar el primer par de primos gemelos a partir de m
        /// </summary>
        static  int[] EncontrarPrimosGemelos( int m)
        {
            int p = m; // Empezamos a buscar desde m

            while (true) // Bucle infinito hasta encontrar el par de primos gemelos
            {
                if (EsPrimo(p) && EsPrimo(p + 2)) // Verifica si p y p+2 son primos
                {
                    return new int[] { p, p + 2 }; // Retorna el par encontrado en un array
                }
                p++; // Incrementa p para seguir buscando
            }

        }
    }
}
