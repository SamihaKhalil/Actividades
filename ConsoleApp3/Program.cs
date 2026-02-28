using System;

class Program
{
    static int ObtenerNumero(string mensaje)
    {
        int numero;
        bool esValido = false;

        do
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();

            // Intentar parsear la entrada
            esValido = int.TryParse(entrada, out numero);

            if (!esValido)
            {
                Console.WriteLine("Entrada inválida. Por favor, ingresa un número entero válido.");
            }
        } while (!esValido);  

        return numero;
    }

    static int Sumar(int a, int b)
    {
        return a + b;
    }

    static void ImprimirResultado(int resultado)
    {
        Console.WriteLine("La suma es: " + resultado);
    }

    static void Main()
    {
        // Obtener los números usando la función validada
        int num1 = ObtenerNumero("Ingresa el primer número: ");
        int num2 = ObtenerNumero("Ingresa el segundo número: ");

        int res = Sumar(num1, num2);

        ImprimirResultado(res);
    }
}
