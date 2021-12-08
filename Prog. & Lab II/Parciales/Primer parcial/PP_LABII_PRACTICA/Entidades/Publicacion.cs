using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Publicacion
    {
        #region Atributos
        protected float importe;
        protected string nombre;
        protected int stock;
        #endregion

        #region Propiedades
        public float Importe
        {
            get
            {
                return this.importe;
            }
        }
        public virtual bool HayStock
        {
            get
            {
                if (this.stock > 0)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }
        public int Stock
        {
            get
            {
                return this.stock;
            }
            set
            {
                if (value > 0)
                {
                    this.stock = value;
                }
            }
        }
        public abstract bool EsColor
        {
            get;
        }
        #endregion

        #region Constructores
        public Publicacion(string nombre)
        {
            this.nombre = nombre;
        }
        public Publicacion(string nombre, int stock):this(nombre)
        {
            this.stock = stock;
        }
        public Publicacion(string nombre, int stock, float importe):this(nombre, stock)
        {
            this.importe = importe;
        }
        #endregion
        #region Métodos
        public string Informacion()
        {
            StringBuilder sB = new StringBuilder();
            sB.Append($"Nombre: {this.nombre} ");
            if (this.HayStock == true)
            {
                sB.Append($"Stock: SI ");
            } else
            {
                sB.Append($"Stock: NO ");
            }
            
            if (this.EsColor == true)
            {
                sB.Append($"Color: SI ");
            } else
            {
                sB.Append($"Color: NO ");
            }
            sB.AppendFormat("Valor: $" + this.Importe);
            return sB.ToString();
        }

        public override string ToString()
        {
            return this.Informacion();
        }
        #endregion
    }
}
