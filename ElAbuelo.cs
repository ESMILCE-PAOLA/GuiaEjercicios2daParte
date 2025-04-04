using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GuiaEjercicios2daParte
{
    public class ElAbuelo
    {
        public static void Ejecutar()
        {
            Console.Clear();
            Console.WriteLine("=== El error del abuelo ===\n");

            int numeroObjetivo = 5423; // Número que escribió el abuelo

            // Recorremos todas las combinaciones posibles de un número de 4 cifras:
            // a^b * c^d = 5423
            for (int a = 1; a < 10; a++)         // base1
            {
                for (int b = 1; b < 10; b++)     // exponente1
                {
                    for (int c = 1; c < 10; c++) // base2
                    {
                        for (int d = 1; d < 10; d++) // exponente2
                        {
                            double resultado = Math.Pow(a, b) * Math.Pow(c, d);
                            if (resultado == numeroObjetivo)
                            {
                                Console.WriteLine($"El número correcto es: {a}{b}{c}{d}");
                                Console.WriteLine($"Porque: {a}^{b} * {c}^{d} = {numeroObjetivo}");
                                Console.WriteLine("\nPresione una tecla para volver al menú...");
                                Console.ReadKey();
                                return;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("No se encontró una combinación que coincida con 5423.");
            Console.WriteLine("\nPresione una tecla para volver al menú...");
            Console.ReadKey();
        }
    }
}
