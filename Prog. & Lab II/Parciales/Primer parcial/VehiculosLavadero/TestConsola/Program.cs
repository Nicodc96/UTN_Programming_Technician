using System;
using System.Collections.Generic;
using Entidades;

namespace TestConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Test del lavadero - Lautaro Díaz";

            // ----------------------------------------------------------------------------------- //

            // Defino un nuevo lavadero y 12 vehiculos de distintos tipos

            Lavadero nuevoLavadero = new Lavadero(300f, 500f, 175f);
            List<Vehiculo> listaAux = new List<Vehiculo>();
            Vehiculo v1 = new Auto(4, "FA0003", 4, EMarcas.Ford);
            Vehiculo v2 = new Auto(2, "CG231A", 4, EMarcas.Fiat);
            Vehiculo v3 = new Camion(2345.13f, "LX013B", 10, EMarcas.Iveco);
            Vehiculo v4 = new Camion(3177.58f, "UY331K", 12, EMarcas.Scania);
            Vehiculo v5 = new Moto(125, "LA512A", 2, EMarcas.Honda);
            Vehiculo v6 = new Moto(50, "KL888L", 2, EMarcas.Zanella);
            // Vehiculos repetidos
            Vehiculo v7 = new Auto(5, "LL351A", 4, EMarcas.Ford);
            Vehiculo v8 = new Camion(3157, "KG583A", 10, EMarcas.Iveco);
            Vehiculo v9 = new Moto(250, "JJ531G", 2, EMarcas.Honda);
            //
            Vehiculo v10 = new Auto(2, "LX511A", 4, EMarcas.Honda);
            Vehiculo v11 = new Camion(2945.79f, "PL2331", 12, EMarcas.Scania);
            Vehiculo v12 = new Moto(500, "ZZ534L", 2, EMarcas.Zanella);

            // ----------------------------------------------------------------------------------- //                        
            Console.WriteLine("Agrego al lavadero todos los vehiculos execepto los 2 últimos: ");
            Console.WriteLine("\n");

            listaAux.Add(v1);
            listaAux.Add(v2);
            listaAux.Add(v3);
            listaAux.Add(v4);
            listaAux.Add(v5);
            listaAux.Add(v6);
            listaAux.Add(v7);
            listaAux.Add(v8);
            listaAux.Add(v9);
            listaAux.Add(v10);
            listaAux.Add(v11);
            listaAux.Add(v12);
            foreach (Vehiculo v in listaAux)
            {
                nuevoLavadero += v;
            }
            nuevoLavadero.Vehiculos.Remove(v11);
            nuevoLavadero.Vehiculos.Remove(v12);
            foreach (Vehiculo v in listaAux)
            {
                if (nuevoLavadero == v)
                {
                    Console.WriteLine("El vehiculo se encuentra en el lavadero!");
                } else
                {
                    Console.WriteLine("El vehiculo NO se encuentra en el lavadero.");
                }
            }

            Console.ReadKey();
            Console.Clear();
            // ----------------------------------------------------------------------------------- //
            Console.WriteLine("\n");
            Console.WriteLine("Muestro la información completa del lavadero: ");
            Console.WriteLine(nuevoLavadero.LavaderoInfo);
            Console.ReadKey();

            Console.WriteLine("\nMuestro lo recuadado total del lavadero: ");
            Console.WriteLine($"${nuevoLavadero.MostrarTotalFacturado()}");

            Console.WriteLine("\nMuestro lo recaudado segun vehiculo: ");
            Console.WriteLine($"Autos: ${nuevoLavadero.MostrarTotalFacturado(EVehiculos.Auto)}");
            Console.WriteLine($"Camiones: ${nuevoLavadero.MostrarTotalFacturado(EVehiculos.Camion)}");
            Console.WriteLine($"Motos: ${nuevoLavadero.MostrarTotalFacturado(EVehiculos.Moto)}");

            Console.ReadKey();
            Console.Clear();
            // ----------------------------------------------------------------------------------- //

            Console.WriteLine("Muestro la lista desordenada: ");
            Console.WriteLine(nuevoLavadero.LavaderoInfo);
            Console.ReadKey();
            Console.WriteLine("\nMuestro la lista de vehiculos del lavadero ordenado por Patentes: ");
            nuevoLavadero.Vehiculos.Sort(Lavadero.OrdenarVehiculosPorPatente);
            Console.WriteLine(nuevoLavadero.LavaderoInfo);
            Console.ReadKey();
            Console.WriteLine("\nMuestro la lista de vehiculos del lavadero ordenado por Marca: ");
            nuevoLavadero.Vehiculos.Sort(Lavadero.OrdenarVehiculosPorMarca);
            Console.WriteLine(nuevoLavadero.LavaderoInfo);

            Console.ReadKey();
            Console.Clear();
        }
    }
}
