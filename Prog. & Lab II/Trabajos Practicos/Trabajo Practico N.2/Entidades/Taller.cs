using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Hace referencia a un taller que contendrá vehiculos de tipo Ciclomotor, SUV o Sedan.<br></br>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        #region Tipo anidado
        public enum ETipo { Ciclomotor, Sedan, SUV, Todos }
        #endregion

        #region Atributos
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;
        #endregion

        #region Constructores
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Taller(int espacioDisponible):this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region Sobreescritura
        /// <summary>
        /// Muestra el taller y la información de todos los vehículos contenidos.
        /// </summary>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Expone los datos del elemento y su lista (incluídas sus herencias) únicamente del tipo requerido.
        /// </summary>
        /// <param name="taller">Elemento a exponer.</param>
        /// <param name="tipo">Tipos de ítems de la lista a mostrar.</param>
        public static string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in taller.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.SUV:
                        if (v is Suv)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Ciclomotor:
                        if (v is Ciclomotor)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Sedan:
                        if (v is Sedan)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }
            return sb.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Agregará un elemento a la lista de vehículos del taller.<br></br><br></br>
        /// El elemento se agregará únicamente si la lista tiene espacios disponibles y si no se encuentra ya en la misma.
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento.</param>
        /// <param name="vehiculo">Objeto a agregar.</param>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in taller.vehiculos)
            {
                if (v == vehiculo)
                {
                    return taller;
                }                    
            }
            if (taller.vehiculos.Count() < taller.espacioDisponible)
            {
                taller.vehiculos.Add(vehiculo);
            }
            return taller;
        }
        /// <summary>
        /// Quitará un elemento a la lista de vehículos del taller.<br></br><br></br>
        /// El elemento se quitará únicamente si se encuentra en la lista.
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento.</param>
        /// <param name="vehiculo">Objeto a quitar.</param>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            for (int i = 0; i < taller.vehiculos.Count(); i++)
            {
                if (taller.vehiculos[i] == vehiculo)
                {
                    taller.vehiculos.Remove(taller.vehiculos[i]);
                }
            }
            return taller;
        }
        #endregion
    }
}
