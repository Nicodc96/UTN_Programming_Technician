using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Hace referencia a un vehículo pequeño de dos ruedas.
    /// </summary>
    public class Ciclomotor : Vehiculo
    {
        #region Constructor
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color):base(chasis, marca, color)
        {
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Ciclomotor son de tamaño 'Chico'.
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        #endregion

        #region Método
        /// <summary>
        /// Muestra toda la información del Vehiculo Ciclomotor.
        /// </summary>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("\n---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
