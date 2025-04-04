using System;
using System.IO; // Para poder leer el archivo con las palabras
using System.Linq; // Para usar Contains() en arrays

namespace GuiaEjercicios2daParte
{
    public class JuegoAhorcado
    {
        // Clase principal que controla el flujo del juego
        public static void Ejecutar()
        {
            Console.Clear(); // Limpia la consola
            Console.Write("Ingrese su nombre: ");
            string nombre = Console.ReadLine();

            Jugador jugador = new Jugador(nombre); // Crea el jugador
            Adivinanza adivinanza = new Adivinanza(); // Crea la adivinanza (elige palabra)

            // Bucle que se repite mientras el jugador no pierda ni gane
            while (!jugador.Perdio() && !adivinanza.EstaCompleta())
            {
                Console.Clear();
                Console.WriteLine($"Jugador: {jugador.Nombre}");
                Console.WriteLine($"Errores restantes: {jugador.Intentos}");
                Console.WriteLine($"Progreso: {adivinanza.Progreso}");

                Console.Write("Ingrese una letra o una palabra completa: ");
                string entrada = Console.ReadLine().ToUpper();

                if (entrada.Length == 1)
                {
                    // Si se ingresó una letra
                    char letra = entrada[0];
                    bool acerto = adivinanza.ArriesgarLetra(letra);
                    if (!acerto)
                        jugador.RestarIntento(); // Si falló, se resta intento
                }
                else
                {
                    // Si se ingresó una palabra completa
                    bool adivino = adivinanza.ArriesgarPalabra(entrada);
                    if (adivino)
                    {
                        Console.WriteLine("¡Correcto! Has adivinado la palabra.");
                        break;
                    }
                    else
                        jugador.RestarIntento(); // Si no adivinó la palabra, resta intento
                }
            }

            // Resultado final
            Console.Clear();
            Console.WriteLine($"Palabra secreta: {adivinanza.PalabraSecreta}");
            if (adivinanza.EstaCompleta())
                Console.WriteLine("¡Felicidades, ganaste!");
            else
                Console.WriteLine("Perdiste, se acabaron los intentos.");

            Console.WriteLine("Presione una tecla para volver al menú...");
            Console.ReadKey();
        }
    }

    public class Jugador
    {
        // Atributos privados
        private int _intentos;
        private string _nombre;

        // Propiedades públicas (getter y setter automáticos)
        public int Intentos
        {
            get { return _intentos; }
            private set { _intentos = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        // Constructor: inicializa nombre e intentos
        public Jugador(string nombre)
        {
            Nombre = nombre;
            Intentos = 5; // Empieza con 5 errores posibles
        }

        // Método que descuenta un intento
        public void RestarIntento()
        {
            if (_intentos > 0)
                _intentos--;
        }

        // Método que indica si perdió
        public bool Perdio()
        {
            return _intentos == 0;
        }
    }

    public class Adivinanza
    {
        private string _palabraSecreta; // Palabra que hay que adivinar
        private char[] _progreso;       // Guiones y letras acertadas

        // Propiedad solo lectura para mostrar la palabra secreta al final
        public string PalabraSecreta => _palabraSecreta;

        // Propiedad que muestra el progreso separado con espacios
        public string Progreso => string.Join(" ", _progreso);

        // Constructor
        public Adivinanza()
        {
            _palabraSecreta = CargarPalabraDeArchivo();
            _progreso = new string('_', _palabraSecreta.Length).ToCharArray();
        }

        // Lee una palabra aleatoria del archivo
        private string CargarPalabraDeArchivo()
        {
            string[] palabras = File.ReadAllLines("palabras.txt");
            Random rnd = new Random();
            return palabras[rnd.Next(palabras.Length)].ToUpper();
        }

        // Método para intentar adivinar una letra
        public bool ArriesgarLetra(char letra)
        {
            bool acierto = false;
            for (int i = 0; i < _palabraSecreta.Length; i++)
            {
                if (_palabraSecreta[i] == letra && _progreso[i] == '_')
                {
                    _progreso[i] = letra;
                    acierto = true;
                }
            }
            return acierto;
        }

        // Método para intentar adivinar toda la palabra
        public bool ArriesgarPalabra(string palabra)
        {
            if (palabra.ToUpper() == _palabraSecreta)
            {
                // Si adivinó, mostrar toda la palabra en el progreso
                for (int i = 0; i < _palabraSecreta.Length; i++)
                    _progreso[i] = _palabraSecreta[i];
                return true;
            }
            return false;
        }

        // Retorna true si se adivinó toda la palabra
        public bool EstaCompleta()
        {
            return !_progreso.Contains('_');
        }
    }
}
