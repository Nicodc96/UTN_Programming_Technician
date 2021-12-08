using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Marvel
    {
        #region Atributos
        private static List<Personaje> listaDePersonajes;
        #endregion

        #region Propiedades
        public static Personaje Personaje
        {
            set
            {
                listaDePersonajes += value;
            }
        }
        #endregion

        #region Constructores
        static Marvel()
        {
            listaDePersonajes = new List<Personaje>();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Muestra la información completa de los personajes incluidos en la lista
        /// </summary>
        /// <exception cref="Exception"></exception>
        /// <returns></returns>
        public static string MostrarInformacion()
        {
            StringBuilder sB = new StringBuilder();
            foreach(Personaje p in Marvel.listaDePersonajes)
            {
                if (p is Avenger)
                {
                    sB.AppendLine("****** AVENGER ******");
                    sB.AppendLine(p.ToString());
                } else
                {
                    sB.AppendLine("****** ENEMIGO ******");
                    sB.AppendLine(p.ToString());
                }
            }
            return sB.ToString();
        }
        #endregion
    }
}
