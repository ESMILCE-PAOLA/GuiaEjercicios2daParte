using System;

namespace GuiaEjercicios2daParte
{
    class Program
    {
        static void Main()
        {
            while (true) // Bucle infinito para que el menú se repita
            {
                Console.Clear();
                Console.WriteLine("===== MENÚ PRINCIPAL =====");
                Console.WriteLine("1 - Primos Gemelos");
                Console.WriteLine("2 - El Abuelo");
                Console.WriteLine("3 - Piedra, Papel o Tijera");
                Console.WriteLine("4 - Juego del Ahorcado (Optativo)");
                Console.WriteLine("0 - Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine(); // Lee la entrada del usuario

                switch (opcion)
                {
                    case "1":
                        PrimosGemelos.Ejecutar();
                        break;
                    case "2":
                        ElAbuelo.Ejecutar();
                        break;
                    case "3":
                        PiedraPapelTijera.Ejecutar(); // Llama al juego de Piedra, Papel o Tijera
                        break;
                    case "4":
                        JuegoAhorcado.Ejecutar();
                        break;
                    case "0":
                        Console.WriteLine("Saliendo del programa...");
                        return; // Sale del Main y finaliza el programa
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        Console.ReadKey(); // Espera que el usuario presione una tecla para continuar
                        break;
                }
            }
        }
    }
}
