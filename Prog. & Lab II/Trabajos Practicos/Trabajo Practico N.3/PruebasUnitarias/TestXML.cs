using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Entidades;
using Entidades.Serializador;
using System.IO;
using System;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestXML
    {
        [TestMethod]
        public void GuardarDatos_RecibeUnDatoGenericoCorrecto_DeberiaGenerarArchivo()
        {
            List<Cliente> listaClienteTesting = new List<Cliente>();
            SerializadorXML<List<Cliente>> serializadorDeListaClientes = new SerializadorXML<List<Cliente>>();

            serializadorDeListaClientes.GuardarDatos(listaClienteTesting);

            Assert.IsTrue(File.Exists(Path.Combine(serializadorDeListaClientes.RutaBase, @"Datos\ResumenClientes.xml")));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RecuperarDatos_RecibeUnRutaIncorrecta_DeberiaLanzarExcepcion()
        {
            SerializadorXML<List<Presupuesto>> serializadorDeListaPresupuesto = new SerializadorXML<List<Presupuesto>>();

            List<Presupuesto> listaPresupuestoTesting = serializadorDeListaPresupuesto.RecuperarDatos(@"C:\archivoInexistente.xml");
        }
    }
}
