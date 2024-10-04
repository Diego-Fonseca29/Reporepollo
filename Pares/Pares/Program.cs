using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace Numeros_pares
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rutaArchivo = "Numeros.dat";

            //Creacion de archivo binario y escritor de datos
            using (FileStream mArchivo = new FileStream(rutaArchivo, FileMode.Create)) //Abre o crea un flujo para el
                                                                                       //Archivo Numeros.dat en modo creacion, si el archivo ya existe, se sobreescribe
            using (BinaryWriter Escritor = new BinaryWriter(mArchivo, Encoding.UTF8))// Crea un BinaryWriter que permite escribir datos
                                                                                     // primitivos en el archivo utilizando codificacion UTF8. Esto facilita la escritura de datos como cqadenas, enteros, etc.
            {
                //Le pedimos al usuario que ingrese hasta donde desea registrar los numeros
                Console.WriteLine("Ingrese hasta donde desea registrar los numeros: ");
                int cantidad = int.Parse(Console.ReadLine());
                Console.WriteLine("Los numeros pares son: ");
                for (int i = 1; i < cantidad + 1; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine(i);
                        Escritor.Write(i);

                    }
                }
            }
                //Lectura de datos del archivo binario y guardamos los datos en un txt de formato legible
                Console.WriteLine("\nDatos almacenados: ");
                using (FileStream mArchivo = new FileStream(rutaArchivo, FileMode.Open))
                using (BinaryReader Lector = new BinaryReader(mArchivo, Encoding.UTF8))
                using (StreamWriter EscritorLegible = new StreamWriter("NumerosLegibles.txt"))
                {
                    while (mArchivo.Position < mArchivo.Length)
                    {
                         int datos = Lector.ReadInt32();
                         Console.WriteLine($"Datos: {datos}");
                         EscritorLegible.WriteLine(datos);
                    }

                }
                Console.ReadKey();
        }
    }
}