using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Instrumento
    {
        #region Atributos
        protected int codigo;
        protected string marca;
        protected EClasificacion clasificacion;
        #endregion

        #region Propiedades
        protected EClasificacion Clasificacion
        {
            //set
            //{
            //    this.clasificacion = value;
            //}
            //get
            //{
            //    return this.clasificacion;
            //}
            set;
            get;
        }
        #endregion

        #region Constructores
        protected Instrumento(int codigo, string marca)
        {
            this.codigo = codigo;
            this.marca = marca;
        }
        protected Instrumento(int codigo, string marca, EClasificacion clasificacion) : this(codigo, marca)
        {
            this.Clasificacion = clasificacion;
        }
        #endregion

        #region Métodos
        protected virtual string Mostrar()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine($"Codigo: {this.codigo}");
            sB.AppendLine($"Marca: {this.marca}");
            sB.Append($"Clasificacion: {this.Clasificacion}");

            return sB.ToString();
        }
        #endregion

        #region Sobrecarga
        public static bool operator ==(Instrumento i1, Instrumento i2)
        {
            return i1.codigo == i2.codigo;
        }
        public static bool operator !=(Instrumento i1, Instrumento i2)
        {
            return !(i1 == i2);
        }
        public override string ToString()
        {
            return this.Mostrar();
        }
        /// <summary>
        /// Comprueba si el objeto pasado por parámetro es un instrumento y si es igual al objeto actual
        /// </summary>
        /// <param name="obj">Objeto a ser comparado</param>
        /// <returns>True si obj es del tipo Instrumento y poseen mismo código. Caso contrario, devuelve false.</returns>
        public override bool Equals(object obj)
        {
            bool check = false;
            if (obj is Instrumento)
            {
                check = (Instrumento)obj == this;
            }
            return check;
        }
        #endregion
    }
}
