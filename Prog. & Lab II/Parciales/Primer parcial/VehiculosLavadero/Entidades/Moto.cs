using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        #region Atributos
        protected float cilindrada;
        #endregion

        #region Constructor
        public Moto(float cilindrada, string patente, byte cantRuedas, EMarcas marca):base(patente, cantRuedas, marca)
        {
            this.cilindrada = cilindrada;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Muestra la información completa de la Motocicleta
        /// </summary>
        /// <returns></returns>
        protected override string Mostrar()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine("Tipo: Moto");
            sB.AppendLine(base.Mostrar());
            sB.AppendLine($"Cilindrada: {this.cilindrada} cc");
            return sB.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
        #endregion
    }
}
