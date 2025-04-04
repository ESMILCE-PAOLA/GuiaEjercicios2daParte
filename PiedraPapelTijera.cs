using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Definición de la clase PiedraPapelTijera
namespace GuiaEjercicios2daParte
{
    public class PiedraPapelTijera
    {
        public static void Ejecutar()
        {
            Console.Clear();
            Juego juego = new Juego(); // Crear una instancia de la clase Juego
            juego.Iniciar(); // Llamar al método que inicia el juego
        }
    }

    /// <summary>
    /// Clase que contiene la lógica del juego Piedra, Papel o Tijera.
    /// </summary>
    public class Juego
    {
        private static readonly string[] _opciones = { "PIEDRA", "PAPEL", "TIJERA" };
        /*
         * static: Todas las instancias de Juego compartirán la misma lista de opciones.
         * readonly: Hace que el array solo pueda ser asignado una vez (no se puede modificar después de inicializar).
         */

        private Random _random = new Random(); // Se usa para generar valores aleatorios, despues lo uso en la elecion de la pc

        /// <summary>
        /// Método para iniciar el juego y determinar el ganador.
        /// </summary>
        public void Iniciar()
        {
            Console.WriteLine("Bienvenido al juego Piedra, Papel o Tijera");
            Console.Write("Ingrese su elección (PIEDRA, PAPEL, TIJERA): ");
            string eleccionJugador = Console.ReadLine().ToUpper(); // Convierte el texto ingresado a mayúsculas.

            // Valida que la elección del usuario sea correcta
            if (Array.IndexOf(_opciones, eleccionJugador) == -1)//Array.IndexOf: busca la posición de eleccionJugador dentro del array _opciones.
                                                                //Si el elemento no está presente, devuelve -1.
            {
                Console.WriteLine("Opción no válida. Inténtelo nuevamente.");
                return;
            }

            // La PC elige una opción al azar
            string eleccionPC = _opciones[_random.Next(0, 3)]; //La función _random.Next(0, 3) genera un número entero aleatorio entre 0 y 2
                                                               //(el límite superior 3 no está incluido). Así, la PC elige aleatoriamente una opción de "PIEDRA", "PAPEL" o "TIJERA"
            Console.WriteLine($"La PC eligió: {eleccionPC}");

            // Determinar el ganador
            string resultado = DeterminarGanador(eleccionJugador, eleccionPC);
            Console.WriteLine(resultado);

            Console.WriteLine("Presione una tecla para volver al menú...");
            Console.ReadKey(); // Espera que el usuario presione una tecla antes de continuar
        }

        /// <summary>
        /// Determina el ganador según las reglas del juego.
        /// </summary>
        /// <param name="jugador1">Elección del jugador</param>
        /// <param name="jugador2">Elección de la PC</param>
        /// <returns>Mensaje con el resultado del juego</returns>
        private static string DeterminarGanador(string jugador1, string jugador2)
        {
            if (jugador1 == jugador2)
                return "Empate";

            if ((jugador1 == "PIEDRA" && jugador2 == "TIJERA") ||
                (jugador1 == "PAPEL" && jugador2 == "PIEDRA") ||
                (jugador1 == "TIJERA" && jugador2 == "PAPEL"))
            {
                return "¡GANASTE!";
            }
            else
            {
                return "GANÓ LA PC";
            }
        }
    }
}
