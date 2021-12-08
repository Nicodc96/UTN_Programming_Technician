using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Agua : Botella
    {
        #region Atributos
        private const int MEDIDA = 400;
        #endregion

        #region Constructor
        public Agua(string marca, int capacidadML, int contenidoML)
            :base(marca, capacidadML, contenidoML)
        {
        }
        #endregion

        #region Métodos
        public override float ServirMedida()
        {
            return ServirMedida(MEDIDA);
        }

        public float ServirMedida(float medida)
        {
            float aux = base.Contenido;
            if (medida <= aux)
            {
                base.Contenido = aux - medida;
            } else if (medida > aux)
            {
                base.Contenido = 0;
                return aux;
            }
            return base.Contenido;
        }
        
        protected override string GenerarInforme()
        {
            StringBuilder sB = new StringBuilder();

            sB.AppendLine("-- Botella de Agua --");
            sB.AppendLine(base.GenerarInforme());

            return sB.ToString();
        }
        public override string ToString()
        {
            return this.GenerarInforme();
        }
        #endregion
    }
}
