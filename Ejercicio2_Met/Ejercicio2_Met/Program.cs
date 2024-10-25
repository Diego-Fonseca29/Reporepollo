using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 2. Escribir un programa que tenga una función que reciba un número entero entre 1 y 10 y
guarde en un fichero binario con el nombre tabla-n.dat la tabla de multiplicar de ese número,
donde n es el número introducido. A continuación, muestre lo muestre por pantalla. Si el
fichero no existe debe mostrar un mensaje por pantalla informando de ello.
 */

namespace Ejercicio2_Met
{
        class Program
        {
            // Función para generar la tabla de multiplicar y guardarla en un fichero binario
            static void GuardarTablaMultiplicar(int numero)
            {
                string fileName = $"tabla-{numero}.dat";

                // Crear una lista para almacenar la tabla de multiplicar
                List<string> tablaMultiplicar = new List<string>();

                for (int i = 1; i <= 10; i++)
                {
                    string linea = $"{numero} x {i} = {numero * i}";
                    tablaMultiplicar.Add(linea);
                }

                // Guardar la lista en un fichero binario
                using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                {
                    for (int i = 0; i < tablaMultiplicar.Count; i++)
                    {
                        writer.Write(tablaMultiplicar[i]);
                    }
                }
            }

            // Función para leer y mostrar la tabla de multiplicar desde el fichero binario
            static void MostrarTablaMultiplicar(int numero)
            {
                string fileName = $"tabla-{numero}.dat";

                if (File.Exists(fileName))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        Console.WriteLine($"Tabla de multiplicar del {numero}:");

                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            string linea = reader.ReadString();
                            Console.WriteLine(linea);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("El fichero no existe.");
                }
            }

            static void Main(string[] args)
            {
                while (true)
                {
                    Console.WriteLine("Introduce un número entero entre 1 y 10:");
                    int numero = Convert.ToInt32(Console.ReadLine());

                    if (numero < 1 || numero > 10)
                    {
                        Console.WriteLine("El número debe estar entre 1 y 10.");
                        continue;
                    }

                    // Guardar y mostrar la tabla de multiplicar
                    GuardarTablaMultiplicar(numero);
                    MostrarTablaMultiplicar(numero);

                    // Preguntar al usuario si desea continuar
                    Console.WriteLine("¿Quieres introducir otro número? (s/n)");
                    string respuesta = Console.ReadLine().ToLower();
                    if (respuesta != "s")
                    {
                        break;
                    }
                }
            }
        }
}