using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto : Vehiculo
    {
        #region Atributos
        protected int cantidadAsientos;
        #endregion

        #region Constructor
        public Auto(int cantAsientos, string patente, byte cantRuedas, EMarcas marca):base(patente, cantRuedas, marca)
        {
            this.cantidadAsientos = cantAsientos;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Muestra la información completa del automóvil
        /// </summary>
        /// <returns></returns>
        protected override string Mostrar()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine("Tipo: Auto");
            sB.AppendLine(base.Mostrar());
            sB.AppendLine($"Cantidad de Asientos: {this.cantRuedas}");
            return sB.ToString();
        }
        public override string ToString()
        {
            return this.Mostrar();
        }
        #endregion
    }
}
