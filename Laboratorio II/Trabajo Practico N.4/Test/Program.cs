using System;
using System.Collections.Generic;
using System.IO;
using Entidades;
using Entidades.Componentes;
using Entidades.Enumerado;
using Entidades.Interfaces;
using Entidades.Serializador;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Presupuesto presupuestoPrueba = Program.TestGenerarPresupuesto();
            Cliente clientePrueba = Program.TestGenerarCliente(presupuestoPrueba);
            Program.Testeo(clientePrueba, presupuestoPrueba);
            Program.TestSerializacion(clientePrueba, presupuestoPrueba);
            Program.TestDeserealizacion();
            //HarcodeoDatos(); // <- Este método tiene la única finalidad de generar datos harcodeados en archivos .xml
        }

        #region Seccion de pruebas de métodos y clases
        private static void Testeo(Cliente c, Presupuesto p)
        {
            // Muestro el presupuesto y únicamente los nombres de los componentes
            Console.WriteLine(p.ResumenPresupuesto);
            Console.ReadKey();

            // Muestro el presupuesto con sus componentes detallados
            Console.WriteLine(p.ToString());
            Console.ReadKey();

            // Comparo dos componentes si son iguales con ==
            Console.WriteLine($"Primer componente: {p.ListaDeComponentes[0].Marca} {p.ListaDeComponentes[0].Modelo} {typeof(PlacaMadre).Name}");
            Console.WriteLine($"Segundo componente: {p.ListaDeComponentes[1].Marca} {p.ListaDeComponentes[1].Modelo} {typeof(FuenteDePoder).Name}");
            if (p.ListaDeComponentes[0] == p.ListaDeComponentes[1])
            {
                Console.WriteLine("Los componentes son iguales.");
            }
            else
            {
                Console.WriteLine("Los componentes son distintos.");
            }
            Console.ReadKey();

            // Comparo dos componentes del mismo tipo con Equals y verifico si son iguales
            Console.WriteLine($"Primer componente: {p.ListaDeComponentes[3].Marca} {p.ListaDeComponentes[3].Modelo} {((Memoria)p.ListaDeComponentes[3]).TipoMemoria} {typeof(Memoria).Name}");
            Console.WriteLine($"Segundo componente: {p.ListaDeComponentes[4].Marca} {p.ListaDeComponentes[4].Modelo} {((Memoria)p.ListaDeComponentes[4]).TipoMemoria} {typeof(Memoria).Name}");

            if (p.ListaDeComponentes[5].Equals(p.ListaDeComponentes[4]))
            {
                Console.WriteLine("Los componentes son iguales.");
            }
            else
            {
                Console.WriteLine("Los componentes son distintos.");
            }
            Console.ReadKey();

            // Compruebo rendimiento técnico en 3 componentes distintos
            IBenchmark pruebaMemoria = (IBenchmark)p.ListaDeComponentes[3];
            IBenchmark pruebaPlacaVideo = (IBenchmark)p.ListaDeComponentes[5];
            IBenchmark pruebaFuente = (IBenchmark)p.ListaDeComponentes[1];
            Console.WriteLine(pruebaMemoria.RendimientoTecnico() + " MB/s velocidad Lectura/Escritura");
            Console.WriteLine(pruebaPlacaVideo.RendimientoTecnico() + " TFLOPS");
            Console.WriteLine(pruebaFuente.RendimientoTecnico() + " Watts reales");

            Console.WriteLine("\n\n" + c.ToString());
        }

        public static Cliente TestGenerarCliente(Presupuesto p)
        {
            return new Cliente("Claudio", "Diaz", "21493013", 51, p, 'm', 15, 5);
        }

        public static Presupuesto TestGenerarPresupuesto()
        {
            // Creacion de Componentes Clectrónicos
            ComponenteElectronico cE1 = new PlacaMadre(EMarcas.Gigabyte, "A520M-H", 73.5f, 70, 167, 44);
            ComponenteElectronico cE2 = new FuenteDePoder(EMarcas.Thermaltake, "Smart BX1", 1000, 30, 215, 33);
            ComponenteElectronico cE3 = new Procesador(EMarcas.Intel_Core, "i9-10900X", 4700, 97, 587, 12);
            ComponenteElectronico cE4 = new Memoria(EMarcas.Corsair, "Vengeance LPX", 3200, 23, 70, ETipoMemoria.DIMM, ETecnologiaMemoria.DDR4, 64);
            ComponenteElectronico cE5 = new Memoria(EMarcas.Corsair, "Vengeance LPX", 3200, 23, 70, ETipoMemoria.SODIMM, ETecnologiaMemoria.DDR4, 15); ;
            ComponenteElectronico cE6 = new PlacaDeVideo(EMarcas.EVGA, "RTX 3080ti", 8096, 750, 1500, 10, ETipoPlaca.PlacaExterna, 55);
            ComponenteElectronico cE7 = new Disco(EMarcas.Corsair, "MP400", 0, 34, 200, 1024, ETipoDisco.NVMeM_2, 88);
            ComponenteElectronico cE8 = new Disco(EMarcas.Seagate, "Barracuda", 5400, 5, 90, 4096, ETipoDisco.HDD, 23);

            // Creacion de un Presupuesto y agregado de componentes
            Presupuesto unPresupuesto = new Presupuesto(10, DateTime.Now, 5, 15);
            unPresupuesto += cE1;
            unPresupuesto += cE2;
            unPresupuesto += cE3;
            unPresupuesto += cE4;
            unPresupuesto += cE5;
            unPresupuesto += cE6;
            unPresupuesto += cE7;
            unPresupuesto += cE8;
            return unPresupuesto;
        }

        private static void TestSerializacion(Cliente c, Presupuesto p)
        {
            //Serializo en un archivo XML un Cliente y muestro
            
            SerializadorXML<Cliente> clienteInfo = new SerializadorXML<Cliente>();
            SerializadorXML<Presupuesto> preInfo = new SerializadorXML<Presupuesto>();
            try
            {
                clienteInfo.GuardarDatos(c, "ConsoleTestClientes");
                Console.WriteLine("\n\n");
                Console.WriteLine(c.ToString());
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            // Serializo en un archivo XML un Presupuesto y muestro
            try
            {
                preInfo.GuardarDatos(p, "ConsoleTestPresupuesto");
                Console.WriteLine("\n\n");
                Console.WriteLine(p.ToString());
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        private static void TestDeserealizacion()
        {
            SerializadorXML<Cliente> clienteInfo = new SerializadorXML<Cliente>();
            SerializadorXML<Presupuesto> preInfo = new SerializadorXML<Presupuesto>();
            Cliente cAux;
            Presupuesto pAux;
            //Deserealizo un archivo XML de un Cliente y un presupuesto y muestro
            try
            {
                cAux = clienteInfo.RecuperarDatos(Path.Combine(Environment.CurrentDirectory, @"Datos\ClientesPrueba.xml"));
                Console.WriteLine(cAux.ToString());
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Archivo no encontrado.\n{e.Message}");
            }
            try
            {
                pAux = preInfo.RecuperarDatos(Path.Combine(Environment.CurrentDirectory, @"Datos\PresupuestosPrueba.xml"));
                Console.WriteLine(pAux.ResumenPresupuesto);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Archivo no encontrado.\n{e.Message}");
            }
        }

        #region Harcodeo de datos para testing
        public static void HarcodeoDatos()
        {
            ComponenteElectronico cE1 = new PlacaMadre(EMarcas.Gigabyte, "A520M-H", 73.5f, 70, 167, 1);
            ComponenteElectronico cE2 = new PlacaMadre(EMarcas.Biostar, "A5320M", 65.5f, 68, 115, 2);
            ComponenteElectronico cE3 = new PlacaMadre(EMarcas.ASUS, "Prime B365M-A", 70.1f, 74, 172, 3);
            ComponenteElectronico cE4 = new FuenteDePoder(EMarcas.Thermaltake, "Smart BX1", 1000, 30, 215, 4);
            ComponenteElectronico cE5 = new FuenteDePoder(EMarcas.Sentey, "Solid Power SDP550", 650, 31, 86, 5);
            ComponenteElectronico cE6 = new FuenteDePoder(EMarcas.CoolerMaster, "Master Elite v3", 500, 26, 78, 6);
            ComponenteElectronico cE7 = new Procesador(EMarcas.Intel_Core, "i9-10900X", 4700, 97, 587, 7);
            ComponenteElectronico cE8 = new Procesador(EMarcas.Ryzen, "5800X", 4500, 107, 542, 8);
            ComponenteElectronico cE9 = new Procesador(EMarcas.Ryzen, "4650G", 3800, 85, 378, 9);
            ComponenteElectronico cE10 = new Memoria(EMarcas.Corsair, "Vengeance LPX", 3200, 23, 70, ETipoMemoria.DIMM, ETecnologiaMemoria.DDR4, 10);
            ComponenteElectronico cE11 = new Memoria(EMarcas.ADATA, "CL17 Single", 2666, 17, 43, ETipoMemoria.SODIMM, ETecnologiaMemoria.DDR3, 11);
            ComponenteElectronico cE12 = new Memoria(EMarcas.HyperX, "Fury Black RGB", 3000, 20, 89, ETipoMemoria.DIMM, ETecnologiaMemoria.DDR4, 12);
            ComponenteElectronico cE13 = new Memoria(EMarcas.HyperX, "Fury White HX", 2666, 18, 61, ETipoMemoria.SODIMM, ETecnologiaMemoria.DDR3, 13);
            ComponenteElectronico cE14 = new Memoria(EMarcas.ADATA, "Spectrix XPG", 3200, 21, 57, ETipoMemoria.DIMM, ETecnologiaMemoria.DDR4, 14);
            ComponenteElectronico cE15 = new PlacaDeVideo(EMarcas.EVGA, "RTX 3080ti", 8096, 750, 1500, 10, ETipoPlaca.PlacaExterna, 15);
            ComponenteElectronico cE16 = new PlacaDeVideo(EMarcas.Intel_Core, "HD 860 Graphics", 3510, 125, 15, 1, ETipoPlaca.IntegradaCPU, 16);
            ComponenteElectronico cE17 = new PlacaDeVideo(EMarcas.MSI, "RX 5700XT", 7890, 600, 1375, 8, ETipoPlaca.PlacaExterna, 17);
            ComponenteElectronico cE18 = new Disco(EMarcas.Corsair, "MP400", 0, 34, 11, 1024, ETipoDisco.NVMeM_2, 18);
            ComponenteElectronico cE19 = new Disco(EMarcas.Seagate, "Barracuda", 5400, 5, 90, 4096, ETipoDisco.HDD, 19);
            ComponenteElectronico cE20 = new Disco(EMarcas.Gigabyte, "GFSTFS-31480", 0, 8, 86, 480, ETipoDisco.SSD, 20);
            ComponenteElectronico cE21 = new Disco(EMarcas.ADATA, "SU630", 0, 7, 39, 256, ETipoDisco.SSD, 21);

            Presupuesto p1 = new Presupuesto(5, DateTime.Now, 41, 51);
            p1 += cE1;
            p1 += cE9;
            p1 += cE11;
            p1 += cE19;
            p1 += cE20;
            Presupuesto p2 = new Presupuesto(4, DateTime.Now, 66, 74);
            p2 += cE16;
            p2 += cE13;
            p2 += cE4;
            p2 += cE5;
            Presupuesto p3 = new Presupuesto(1, DateTime.Now, 15, 25);
            p3 += cE15;
            Presupuesto p4 = new Presupuesto(7, DateTime.Now, 21, 107);
            p4 += cE5;
            p4 += cE21;
            p4 += cE20;
            p4 += cE12;
            p4 += cE11;
            p4 += cE7;
            p4 += cE9;
            Presupuesto p5 = new Presupuesto(6, DateTime.Now, 8, 12);
            p5 += cE5;
            p5 += cE19;
            p5 += cE20;
            p5 += cE15;
            p5 += cE10;
            Presupuesto p6 = new Presupuesto(3, DateTime.Now, 10, 19);
            p6 += cE1;
            p6 += cE4;
            p6 += cE6;
            List <Presupuesto> listaPresupuestos = new List<Presupuesto>()
            {
                p1,
                p2,
                p3,
                p4,
                p5,
                p6
            };

            Cliente c1 = new Cliente("Claudio", "Diaz", "21493013", 51, p3, 'm', 25, 15);
            Cliente c2 = new Cliente("Eugenia", "Kondratiuk", "24965001", 29, null, 'f', 65, -1);
            Cliente c3 = new Cliente("Maria", "Castellano", "37451123", 28, p1, 'f', 51, 41);
            Cliente c4 = new Cliente("Enrique", "Ramirez", "23373017", 46, p2, 'x', 74, 66);
            Cliente c5 = new Cliente("Nicolas", "Romero", "39468894", 25, null, 'm', 93, -1);
            Cliente c6 = new Cliente("Melisa", "Bentancour", "40351333", 26, p4, 'f', 107, 21);
            Cliente c7 = new Cliente("Roberto", "Bolañoz", "21599421", 51, p5, 'm', 12, 8);
            Cliente c8 = new Cliente("Ángel", "Correa", "40539322", 23, p6, 'x', 19, 10);
            Cliente c9 = new Cliente("Micaela", "González", "34591344", 31, null, 'f', 42, -1);
            Cliente c10 = new Cliente("Alejandra", "Ponce", "39952111", 25, null, 'f', 100, -1);
            List<Cliente> listaClientes = new List<Cliente>()
            {
                c1,
                c2,
                c3,
                c4,
                c5,
                c6,
                c7,
                c8,
                c9,
                c10
            };
            List<ComponenteElectronico> listaComponentes = new List<ComponenteElectronico>()
            {
                cE1,
                cE2,
                cE3,
                cE4,
                cE5,
                cE6,
                cE7,
                cE8,
                cE9,
                cE10,
                cE11,
                cE12,
                cE13,
                cE14,
                cE15,
                cE16,
                cE17,
                cE18,
                cE19,
                cE20,
                cE21
            };

            SerializadorXML<List<Presupuesto>> seriaPresupuesto = new SerializadorXML<List<Presupuesto>>();
            SerializadorXML<List<Cliente>> seriaClientes = new SerializadorXML<List<Cliente>>();
            SerializadorXML<List<ComponenteElectronico>> seriaComponentes = new SerializadorXML<List<ComponenteElectronico>>();
            seriaComponentes.GuardarDatos(listaComponentes, "DatosComponentes");
            seriaPresupuesto.GuardarDatos(listaPresupuestos, "DatosPresupuestos");
            seriaClientes.GuardarDatos(listaClientes, "DatosClientes");
        }
        #endregion
        #endregion
    }
}
