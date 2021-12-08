using System;
using System.Collections.Generic;
using System.Linq;
using Entidades.BaseDeDatos;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestBD
    {
        // Estos métodos de prueba sólo se aplican si existe la base de datos brindada //
        [TestMethod]
        public void LlenarListaComponentesDePresupuesto_SiExisteLaBDPeroNoElIDDelPresupuesto_LaListaDeberiaEstarVacia()
        {
            Presupuesto p = new Presupuesto(5, DateTime.Now, -1, -1);
            DAO.LlenarListaComponentesDePresupuesto(p);
            Assert.AreEqual(0, p.ListaDeComponentes.Count);
        }

        [TestMethod]
        public void ObtenerComponentes_SiExisteLaBD_DeberiaTraerLaListaYNoDebeSerNull()
        {
            List<ComponenteElectronico> listaComponentesTest = DAO.ObtenerComponentes();
            Assert.IsNotNull(listaComponentesTest);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Data.SqlClient.SqlException))]
        public void EliminarComponente_SiExisteLaBDYHayElementos_DeberiaDevolverExcepcionAlNoEliminarDespensasAntes()
        {
            List<ComponenteElectronico> componenteElectronicos = DAO.ObtenerComponentes();
            DAO.RemoverComponente(componenteElectronicos.First().ID);
        }

        [TestMethod]
        public void AgregarCliente_SiExisteLaBDYNoExisteElID_DeberiaAgregarElCliente()
        {
            Random testRandom = new Random();
            Cliente testCliente = new Cliente("TestNombre", "TestApellido", "20-00000001-1", 20, 'f', testRandom.Next(0, 99999), -1);
            Assert.IsTrue(DAO.GuardarCliente(testCliente));
        }
    }
}
