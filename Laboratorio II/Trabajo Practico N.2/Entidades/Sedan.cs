using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    /// <summary>
    /// Hace referencia a un vehículo mediano de cuatro o cinco puertas.
    /// </summary>
    public class Sedan : Vehiculo
    {
        #region Tipo anidado
        public enum ETipo { CuatroPuertas, CincoPuertas }
        #endregion

        #region Atributo
        private ETipo tipo;
        #endregion

        #region Constructores
        /// <summary>
        /// Por defecto, el tipo será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            :this(marca, chasis, color, ETipo.CuatroPuertas)            
        {
        }
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            :base(chasis, marca, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Sedan son de tamaño 'Mediano'.
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Muestra toda la información del Vehiculo Sedan
        /// </summary>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("\n---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
