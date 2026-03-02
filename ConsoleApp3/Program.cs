using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int cantidad = SolicitarCantidadPersonas();
        ProcesarRegistros(cantidad);
    }

    // Función 1: Solicita y valida la cantidad de personas
    static int SolicitarCantidadPersonas()
    {
        int cantidad;
        while (true)
        {
            Console.Write("¿Cuántas personas desea ingresar?: ");
            if (int.TryParse(Console.ReadLine(), out cantidad) && cantidad >= 1)
            {
                return cantidad;
            }
            Console.WriteLine("Error: Ingrese un número válido mayor o igual a 1");
        }
    }

    // Función 2: Solicita y valida los datos de una persona
    static (string nombre, int edad) SolicitarDatosPersona(int numeroRegistro)
    {
        Console.WriteLine($"\nRegistro #{numeroRegistro}:");
        
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        int edad;
        while (true)
        {
            Console.Write("Edad: ");
            if (int.TryParse(Console.ReadLine(), out edad) && edad >= 0)
            {
                break;
            }
            Console.WriteLine("Error: Ingrese una edad válida.");
        }

        return (nombre, edad);
    }

    // Procedimiento: Procesa todos los registros y muestra los resultados
    static void ProcesarRegistros(int cantidad)
    {
        List<string> nombresGen = new List<string>();
        List<int> edadesGen = new List<int>();
        List<string> nombresMayores = new List<string>();
        List<int> edadesMayores = new List<int>();
        List<string> nombresMenores = new List<string>();
        List<int> edadesMenores = new List<int>();

        // Registrar personas
        for (int i = 0; i < cantidad; i++)
        {
            var (nombre, edad) = SolicitarDatosPersona(i + 1);
            
            nombresGen.Add(nombre);
            edadesGen.Add(edad);

            if (edad >= 18)
            {
                nombresMayores.Add(nombre);
                edadesMayores.Add(edad);
            }
            else
            {
                nombresMenores.Add(nombre);
                edadesMenores.Add(edad);
            }
        }

        // Mostrar resultados
        MostrarResultados(cantidad, nombresGen, edadesGen, nombresMayores, edadesMayores, nombresMenores, edadesMenores);
    }

    // Procedimiento auxiliar para mostrar los resultados
    static void MostrarResultados(int cantidad, List<string> nombresGen, List<int> edadesGen, 
                                 List<string> nombresMayores, List<int> edadesMayores,
                                 List<string> nombresMenores, List<int> edadesMenores)
    {
        if (cantidad == 1)
        {
            string estado = (edadesGen[0] >= 18) ? "Mayor de edad" : "Menor de edad";
            Console.WriteLine($"\nResultado: {nombresGen[0]} es {estado}.");
        }
        else
        {
            Console.WriteLine("\n--- REGISTROS GENERALES ---");
            for (int i = 0; i < nombresGen.Count; i++)
            {
                Console.WriteLine($"{nombresGen[i]} - {edadesGen[i]} años");
            }

            if (nombresMayores.Count > 0)
            {
                Console.WriteLine("\n--- MAYORES DE EDAD ---");
                for (int i = 0; i < nombresMayores.Count; i++)
                {
                    Console.WriteLine($"{nombresMayores[i]} ({edadesMayores[i]} años)");
                }
            }

            if (nombresMenores.Count > 0)
            {
                Console.WriteLine("\n--- MENORES DE EDAD ---");
                for (int i = 0; i < nombresMenores.Count; i++)
                {
                    Console.WriteLine($"{nombresMenores[i]} ({edadesMenores[i]} años)");
                }
            }
        }
    }
}
