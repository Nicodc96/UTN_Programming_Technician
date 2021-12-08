using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Guitarra : Instrumento
    {
        #region Atributos
        private int cantidadDeCuerdas;
        private ETipoGuitarra tipo;
        #endregion

        #region Propiedades
        public ETipoGuitarra TipoDeGuitarra
        {
            set { this.tipo = value; }
            get { return this.tipo; }
        }
        #endregion

        #region Constructores
        public Guitarra (string marca, int cantCuerdas, int codigo, EClasificacion clasificacion, ETipoGuitarra tipo) : base(codigo, marca, clasificacion)
        {
            this.cantidadDeCuerdas = cantCuerdas;
            this.tipo = tipo;
        }
        public Guitarra (string marca, int codigo, EClasificacion clasificacion):this(marca, 6, codigo, clasificacion, ETipoGuitarra.Criolla)
        {            
        }
        #endregion

        #region Métodos
        protected override string Mostrar()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine(base.Mostrar());
            sB.AppendLine($"Cantidad de cuerdas: {this.cantidadDeCuerdas}");
            sB.AppendLine($"Tipo de guitarra: {this.TipoDeGuitarra}");

            return sB.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
        #endregion
    }
}
