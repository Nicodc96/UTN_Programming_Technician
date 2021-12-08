using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;
using Entidades.Componentes;
using Entidades.Enumerado;
using System.Collections.Generic;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestPresupuesto
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void InfoComponentes_RecibeUnPresupuestoSinComponentes_DeberiaArrojarUnaNullException()
        {
            Presupuesto presupuestoTesting = new Presupuesto();
            presupuestoTesting.InfoComponentes();
        }
        [TestMethod]
        public void ListaDeComponentes_RecibeUnPresupuestoCorrecto_DeberiaAlmacenarComponentes()
        {
            Presupuesto presupuestoTesting = new Presupuesto(2, DateTime.Now, 5, 71);
            ComponenteElectronico componenteDePruebaUno = new Memoria(EMarcas.ADATA, "DDX", 50, 15, 35, 44);
            ComponenteElectronico componenteDePruebaDos = new PlacaMadre(EMarcas.ASUS, "A320M", 15, 10, 75, 96);
            List<ComponenteElectronico> listaComponenteTesting = new List<ComponenteElectronico>()
            {
                componenteDePruebaUno,
                componenteDePruebaDos
            };

            presupuestoTesting.ListaDeComponentes = listaComponenteTesting;

            Assert.AreEqual(presupuestoTesting.ListaDeComponentes, listaComponenteTesting);
        }
    }
}
            


