using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string rutaArchivo = "Cadenas.dat";

            //Creracion de archivos binarios y escritor de datos
            using (FileStream mArchivo = new FileStream(rutaArchivo, FileMode.Create))
            using (BinaryWriter Escritor = new BinaryWriter(mArchivo, Encoding.UTF8))

            {
                //agregamos la variable cantidad y la utilizamos para definir la cantidad de iteraciones dentro del ciclo for
                Console.WriteLine("Ingrese el número de personas a registrar");
                int cantidad = int.Parse(Console.ReadLine());

                //inicializamos un bucle for solicitando informacion al usuario y escribimos en el archivo dichos datos
                for (int i = 0; i < cantidad; i++)
                {
                    Console.WriteLine("Ingrese el nombre: ");
                    string nombre = Console.ReadLine();
                    Escritor.Write(nombre);

                    Console.WriteLine("Ingrese la edad: ");
                    int edad = int.Parse(Console.ReadLine());
                    Escritor.Write(edad);

                    Console.WriteLine("Ingrese la Nota: ");
                    float nota = float.Parse(Console.ReadLine());
                    Escritor.Write(nota);

                    Console.WriteLine("Ingrese el genero (M/F): ");
                    char genero = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine();
                    Escritor.Write(genero);

                    Console.Clear();
                }
            }

            Console.WriteLine("\nDatos almacenados: ");
            // este using abre el archivo
            using (FileStream mArchivo = new FileStream(rutaArchivo, FileMode.Open))
            //este using lee el contenido en binario añadido recientemente en el archivo
            using (BinaryReader lector = new BinaryReader(mArchivo, Encoding.UTF8))
            {
                // utilizamos un bucle while para imprimir en consola dicha informacion
                while (mArchivo.Position < mArchivo.Length)
                {
                    string nombre = lector.ReadString();
                    int edad = lector.ReadInt32();
                    float nota = lector.ReadSingle();
                    char genero = lector.ReadChar();

                    Console.WriteLine($"Nombre: {nombre} \nEdad: {edad} \nNota: {nota} \nGenero: {genero}");
                }
            }
            Console.ReadKey();
        }

    }
}

