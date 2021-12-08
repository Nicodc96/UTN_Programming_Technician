using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camion : Vehiculo
    {
        #region Atributos
        protected float tara;
        #endregion

        #region Constructor
        public Camion(float tara, string patente, byte cantRuedas, EMarcas marca):base(patente, cantRuedas, marca)
        {
            this.tara = tara;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Muestra la información completa del camión
        /// </summary>
        /// <returns></returns>
        protected override string Mostrar()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine("Tipo: Camión");
            sB.AppendLine(base.Mostrar());
            sB.AppendLine($"Tara: {this.tara} Kg");
            return sB.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
        #endregion
    }
}
