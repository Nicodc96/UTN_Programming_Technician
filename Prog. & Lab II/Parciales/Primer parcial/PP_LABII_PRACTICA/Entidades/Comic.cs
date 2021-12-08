using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comic : Publicacion
    {
        #region Atributos
        private bool esColor;
        #endregion

        #region Propiedades
        public override bool EsColor
        {
            get
            {
                return this.esColor;
            }
        }
        #endregion

        #region Constructor
        public Comic(string nombre, bool esColor, int stock, float valor):base(nombre, stock, valor)
        {
            this.esColor = esColor;
        }
        #endregion
    }
}
