using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Enemigo : Personaje
    {
        #region Atributos
        private string objetivo;
        #endregion

        #region Propiedades
        protected override string Nombre
        {
            get
            {
                return $"Soy {base.nombre} y los voy a hacer puré!";
            }
        }
        #endregion

        #region Constructores
        public Enemigo(string nombre, List<EHabilidades> hab, string objetivo):base(nombre, hab)
        {
            this.objetivo = objetivo;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Muestra la información completa del Objeto Enemigo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine(base.ToString());
            sB.AppendLine($"Objetivo: {this.objetivo}");
            return sB.ToString();
        }
        #endregion
    }
}
