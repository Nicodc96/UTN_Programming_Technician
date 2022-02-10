using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Hace referencia a un vehículo grande de cuatro ruedas.
    /// </summary>
    public class Suv : Vehiculo
    {
        #region Constructor
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// SUV son de tamaño 'Grande'.
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region Método
        /// <summary>
        /// Muestra toda la información del Vehiculo SUV
        /// </summary>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("\n---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
