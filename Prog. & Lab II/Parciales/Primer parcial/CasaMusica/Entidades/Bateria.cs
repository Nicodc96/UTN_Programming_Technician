using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Bateria : Instrumento
    {
        #region Atributos
        public int cuerpos;
        #endregion

        #region Constructores
        public Bateria(string marca, int codigo, EClasificacion clasificacion, int cuerpos):base(codigo, marca, clasificacion)
        {
            this.cuerpos = cuerpos;
        }
        public Bateria(string marca, int codigo):this(marca, codigo, EClasificacion.Percusion, 4)
        {
        }
        #endregion

        #region Métodos
        protected override string Mostrar()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine(base.Mostrar());
            sB.AppendLine($"Cuerpos: {this.cuerpos}");

            return sB.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
        #endregion
    }
}
