using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Botella
    {
        #region Atributos
        protected float capacidadML;
        protected float contenidoML;
        protected string marca;
        #endregion

        #region Enumeracion de botellas
        public enum Tipo
        {
            Vidrio,
            Plastico
        }
        #endregion
        #region Propiedades
        public float CapacidadLitros
        {
            get
            {
                return this.capacidadML / 1000;
            }
        }

        public float Contenido
        {
            get
            {
                return this.contenidoML;
            }
            set
            {
                this.contenidoML = value;
            }
        }

        public float PorcentajeContenido
        {
            get
            {
                return contenidoML / capacidadML * 100;
            }
        }
        #endregion

        #region Constructor
        protected Botella(string marca, int capacidadML, int contenidoML)
        {
            this.contenidoML = contenidoML;
            if (capacidadML < contenidoML)
            {
                this.contenidoML = capacidadML;
            }
            this.marca = marca;
            this.capacidadML = capacidadML;            
        }
        #endregion

        #region Métodos
        protected virtual string GenerarInforme()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine($"La marca de la botella es: {this.marca}");
            sB.AppendLine($"La capacidad de la botella es: {this.CapacidadLitros}L");
            sB.AppendLine($"El contenido total es: {this.contenidoML}mL");
            sB.AppendLine($"El porcentaje de contenido es: {this.PorcentajeContenido}%");
            return sB.ToString();
        }

        public abstract float ServirMedida();

        public override string ToString()
        {
            return this.GenerarInforme();
        }
        #endregion
    }
}
