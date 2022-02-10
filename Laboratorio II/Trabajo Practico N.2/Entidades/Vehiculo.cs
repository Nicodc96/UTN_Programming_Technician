using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Hace referencia a un vehículo motorizado con una marca, un color y un tipo único de chásis.<br></br><br></br>
    /// Esta clase no puede instanciarse.
    /// </summary>
    public abstract class Vehiculo
    {
        #region Tipos anidados
        public enum EMarca { Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson }
        public enum ETamanio { Chico, Mediano, Grande }
        #endregion

        #region Atributos
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;
        #endregion

        #region Constructor
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Solo lectura: Retornará el tamaño.
        /// </summary>
        public abstract ETamanio Tamanio { get; }
        #endregion

        #region Método
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion
        
        #region Sobrecarga
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sB = new StringBuilder();

            sB.Append("CHASIS: " + p.chasis + "\r\n");
            sB.Append("MARCA : " + p.marca + "\r\n");
            sB.Append("COLOR : " + p.color + "\r\n");
            sB.AppendLine("---------------------");
            sB.AppendLine("TAMAÑO : " + p.Tamanio);

            return sB.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis.
        /// </summary>
        /// <param name="v1">Primer objeto (vehiculo) a comparar.</param>
        /// <param name="v2">Segundo objeto (vehiculo) a comparar.</param>
        /// <returns>True si poseen el mismo chásis, de lo contrario false.</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto.
        /// </summary>
        /// <param name="v1">Primer objeto (vehiculo) a comparar.</param>
        /// <param name="v2">Segundo objeto (vehiculo) a comparar.</param>
        /// <returns>True si poseen distinto chásis, de lo contrario false.</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        #endregion

        #region Sobreescritura
        /// <summary>
        /// Determina si el objeto recibido por parámetro es igual al actual (mismo chásis)
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>True si se verifica la condición, de lo contrario false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Vehiculo ? this == (Vehiculo)obj : false;
        }
        /// <summary>
        /// Obtengo el código hash del objeto utilizando sus atributos (Chasis, marca, color) como referencias.
        /// </summary>
        public override int GetHashCode()
        {
            return new { this.marca, this.color, this.chasis }.GetHashCode();
        }
        #endregion
    }
}
