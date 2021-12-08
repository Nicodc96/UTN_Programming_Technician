using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Trompeta : Instrumento
    {
        #region Atributos
        private string clave;
        #endregion

        #region Constructores
        public Trompeta(string marca, int codigo, EClasificacion clasificacion, string clave):base(codigo, marca, clasificacion)
        {
            this.clave = clave;
        }
        public Trompeta(string marca, int codigo):this(marca, codigo, EClasificacion.Vientos, "Clave de Sol")
        {
        }
        #endregion

        #region Métodos
        protected override string Mostrar()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine(base.Mostrar());
            sB.AppendLine($"Clave: {this.clave}");

            return sB.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
        #endregion
    }
}
