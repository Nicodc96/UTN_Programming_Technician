using System;
using System.Text;

namespace Entidades
{
    public abstract class Vehiculo
    {
        #region Atributos
        protected string patente;
        protected byte cantRuedas;
        protected EMarcas marca;
        #endregion

        #region Propiedades
        public string Patente { get; }
        public EMarcas Marca { get; }
        #endregion

        #region Constructor
        public Vehiculo(string patente, byte cantRuedas, EMarcas marca)
        {
            this.patente = patente;
            this.cantRuedas = cantRuedas;
            this.marca = marca;
        }
        #endregion

        #region Métodos
        protected virtual string Mostrar()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine($"Patente: {this.Patente}");
            sB.AppendLine($"Cantidad de Ruedas: {this.cantRuedas}");
            sB.Append($"Marca: {this.Marca}");
            return sB.ToString();
        }
        #endregion

        #region Sobrecarga
        /// <summary>
        /// Verifica si los vehiculos poseen igual patente y marca
        /// </summary>
        /// <param name="v1">Objeto a comparar</param>
        /// <param name="v2">Objeto a comparar</param>
        /// <returns>True si cumple la condición. Caso contrario, devuelve false.</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            bool check = false;
            if (v1.Patente == v2.Patente && v1.Marca == v2.Marca)
            {
                check = true;
            }
            return check;
        }
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        #endregion

        #region Sobreescritura
        /// <summary>
        /// Verifica si el objeto es del tipo Vehiculo y si posee misma marca y patente que el actual
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>True si cumple dichas condiciones, caso contrario devuelve false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Vehiculo ? (Vehiculo)obj == this : false;
        }
        public override int GetHashCode()
        {
            //No hace nada
            return base.GetHashCode();
        }
        #endregion
    }
}
