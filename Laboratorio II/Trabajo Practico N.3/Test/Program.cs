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
            return new Cliente("Claudio", "Diaz", "21493013", 51, p);
        }

        public static Presupuesto TestGenerarPresupuesto()
        {
            // Creacion de Componentes Clectrónicos
            ComponenteElectronico cE1 = new PlacaMadre(EMarcas.Gigabyte, "A520M-H", 73.5f, 70, 167);
            ComponenteElectronico cE2 = new FuenteDePoder(EMarcas.Thermaltake, "Smart BX1", 1000, 30, 215);
            ComponenteElectronico cE3 = new Procesador(EMarcas.Intel_Core, "i9-10900X", 4700, 97, 587);
            ComponenteElectronico cE4 = new Memoria(EMarcas.Corsair, "Vengeance LPX", 3200, 23, 70, ETipoMemoria.DIMM, ETecnologiaMemoria.DDR4);
            ComponenteElectronico cE5 = new Memoria(EMarcas.Corsair, "Vengeance LPX", 3200, 23, 70, ETipoMemoria.SODIMM, ETecnologiaMemoria.DDR4); ;
            ComponenteElectronico cE6 = new PlacaDeVideo(EMarcas.EVGA, "RTX 3080ti", 8096, 750, 1500, 10, ETipoPlaca.PlacaExterna);
            ComponenteElectronico cE7 = new Disco(EMarcas.Corsair, "MP400", 0, 34, 200, 1024, ETipoDisco.NVMeM_2);
            ComponenteElectronico cE8 = new Disco(EMarcas.Seagate, "Barracuda", 5400, 5, 90, 4096, ETipoDisco.HDD);

            // Creacion de un Presupuesto y agregado de componentes
            Presupuesto unPresupuesto = new Presupuesto(10, DateTime.Now);
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
                clienteInfo.GuardarDatos(c);
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
                preInfo.GuardarDatos(p);
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
            ComponenteElectronico cE1 = new PlacaMadre(EMarcas.Gigabyte, "A520M-H", 73.5f, 70, 167);
            ComponenteElectronico cE2 = new PlacaMadre(EMarcas.Biostar, "A5320M", 65.5f, 68, 115);
            ComponenteElectronico cE3 = new PlacaMadre(EMarcas.ASUS, "Prime B365M-A", 70.1f, 74, 172);
            ComponenteElectronico cE4 = new FuenteDePoder(EMarcas.Thermaltake, "Smart BX1", 1000, 30, 215);
            ComponenteElectronico cE5 = new FuenteDePoder(EMarcas.Sentey, "Solid Power SDP550", 650, 31, 86);
            ComponenteElectronico cE6 = new FuenteDePoder(EMarcas.CoolerMaster, "Master Elite v3", 500, 26, 78);
            ComponenteElectronico cE7 = new Procesador(EMarcas.Intel_Core, "i9-10900X", 4700, 97, 587);
            ComponenteElectronico cE8 = new Procesador(EMarcas.Ryzen, "5800X", 4500, 107, 542);
            ComponenteElectronico cE9 = new Procesador(EMarcas.Ryzen, "4650G", 3800, 85, 378);
            ComponenteElectronico cE10 = new Memoria(EMarcas.Corsair, "Vengeance LPX", 3200, 23, 70, ETipoMemoria.DIMM, ETecnologiaMemoria.DDR4);
            ComponenteElectronico cE11 = new Memoria(EMarcas.ADATA, "CL17 Single", 2666, 17, 43, ETipoMemoria.SODIMM, ETecnologiaMemoria.DDR3);
            ComponenteElectronico cE12 = new Memoria(EMarcas.HyperX, "Fury Black RGB", 3000, 20, 89, ETipoMemoria.DIMM, ETecnologiaMemoria.DDR4);
            ComponenteElectronico cE13 = new Memoria(EMarcas.HyperX, "Fury White HX", 2666, 18, 61, ETipoMemoria.SODIMM, ETecnologiaMemoria.DDR3);
            ComponenteElectronico cE14 = new Memoria(EMarcas.ADATA, "Spectrix XPG", 3200, 21, 57, ETipoMemoria.DIMM, ETecnologiaMemoria.DDR4);
            ComponenteElectronico cE15 = new PlacaDeVideo(EMarcas.EVGA, "RTX 3080ti", 8096, 750, 1500, 10, ETipoPlaca.PlacaExterna);
            ComponenteElectronico cE16 = new PlacaDeVideo(EMarcas.Intel_Core, "HD 860 Graphics", 3510, 125, 15, 1, ETipoPlaca.IntegradaCPU);
            ComponenteElectronico cE17 = new PlacaDeVideo(EMarcas.MSI, "RX 5700XT", 7890, 600, 1375, 8, ETipoPlaca.PlacaExterna);
            ComponenteElectronico cE18 = new Disco(EMarcas.Corsair, "MP400", 0, 34, 11, 1024, ETipoDisco.NVMeM_2);
            ComponenteElectronico cE19 = new Disco(EMarcas.Seagate, "Barracuda", 5400, 5, 90, 4096, ETipoDisco.HDD);
            ComponenteElectronico cE20 = new Disco(EMarcas.Gigabyte, "GFSTFS-31480", 0, 8, 86, 480, ETipoDisco.SSD);
            ComponenteElectronico cE21 = new Disco(EMarcas.ADATA, "SU630", 0, 7, 39, 256, ETipoDisco.SSD);

            Presupuesto p1 = new Presupuesto(5, DateTime.Now);
            p1 += cE1;
            p1 += cE9;
            p1 += cE11;
            p1 += cE19;
            p1 += cE20;
            Presupuesto p2 = new Presupuesto(4, DateTime.Now);
            p2 += cE16;
            p2 += cE13;
            p2 += cE4;
            p2 += cE5;
            Presupuesto p3 = new Presupuesto(1, DateTime.Now);
            p3 += cE15;
            Presupuesto p4 = new Presupuesto(7, DateTime.Now);
            p4 += cE5;
            p4 += cE21;
            p4 += cE20;
            p4 += cE12;
            p4 += cE11;
            p4 += cE7;
            p4 += cE9;
            List<Presupuesto> listaPresupuestos = new List<Presupuesto>()
            {
                p1,
                p2,
                p3,
                p4
            };

            Cliente c1 = new Cliente("Claudio", "Diaz", "21493013", 51, p3);
            Cliente c2 = new Cliente("Eugenia", "Kondratiuk", "24965001", 29, null);
            Cliente c3 = new Cliente("Maria", "Castellano", "37451123", 28, p1);
            Cliente c4 = new Cliente("Enrique", "Ramirez", "23373017", 46, p2);
            Cliente c5 = new Cliente("Nicolas", "Romero", "39468894", 25, null);
            Cliente c6 = new Cliente("Melisa", "Bentancour", "40351333", 26, p4);
            List<Cliente> listaClientes = new List<Cliente>()
            {
                c1,
                c2,
                c3,
                c4,
                c5,
                c6
            };

            SerializadorXML<List<Presupuesto>> seriaPresupuesto = new SerializadorXML<List<Presupuesto>>();
            SerializadorXML<List<Cliente>> seriaClientes = new SerializadorXML<List<Cliente>>();
            seriaPresupuesto.GuardarDatos(listaPresupuestos);
            seriaClientes.GuardarDatos(listaClientes);
        }
        #endregion
        #endregion
    }
}
