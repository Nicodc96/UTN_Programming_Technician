using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cerveza : Botella
    {
        #region Atributos
        private const int MEDIDA = 330;
        private Tipo tipo;
        #endregion

        #region Constructores
        public Cerveza(int capacidadML, string marca, int contenidoML):this(capacidadML, marca, Botella.Tipo.Vidrio, contenidoML)
        {
        }

        public Cerveza(int capacidadML, string marca, Botella.Tipo tipo, int contenidoML):base(marca, capacidadML, contenidoML)
        {
            this.tipo = tipo;
        }
        #endregion

        public override float ServirMedida()
        {
            float auxMedida = MEDIDA * 0.8f;
            if (auxMedida <= base.Contenido)
            {
                return base.Contenido -= auxMedida;
            }
            else
            {
                return base.Contenido -= base.Contenido;
            }
        }

        protected override string GenerarInforme()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine("Botella de Cerveza");
            sB.AppendLine(base.GenerarInforme());
            return sB.ToString();
        }

        public override string ToString()
        {
            return this.GenerarInforme();
        }

        public static implicit operator Botella.Tipo(Cerveza cerveza)
        {
            return cerveza.tipo;
        }
    }
}
