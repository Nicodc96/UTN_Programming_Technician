using System.Text;
using Entidades.Enumerado;
using Entidades.Interfaces;

namespace Entidades.Componentes
{
    /// <summary>
    /// Hace referencia a un componente que alimenta a los demás componentes de una computadora. <br></br>
    /// Componente vital.
    /// </summary>
    public class FuenteDePoder : ComponenteElectronico, IComponente<FuenteDePoder>, IBenchmark
    {
        #region Atributos
        private ETipoFuente tipoDeFuente;
        #endregion

        #region Propiedades
        /// <summary>
        /// Lectura: Retorna si una fuente de poder es potenciable en base al tipo que sea
        /// </summary>
        public override bool Potenciable
        {
            get
            {
                return EsOvercockleable(this);
            }
        }

        /// <summary>
        /// Lectura: Retorna el tipo de fuente<br></br>
        /// Escritura: Asigna un nuevo tipo de ETipoFuente a la instancia actual
        /// </summary>
        public ETipoFuente TipoDeFuente
        {
            get
            {
                return this.tipoDeFuente;
            }
            set
            {
                this.tipoDeFuente = value;
            }
        }
        #endregion

        #region Métodos

        #region Constructor
        public FuenteDePoder() : base()
        { }
        public FuenteDePoder(EMarcas marca, string modelo, float potencia, float consumo, float precio, ETipoFuente tipo)
            : base(marca, modelo, potencia, consumo, precio)
        {
            this.tipoDeFuente = tipo;
        }
        public FuenteDePoder(EMarcas marca, string modelo, float potencia, float consumo, float precio)
            : this(marca, modelo, potencia, consumo, precio, ETipoFuente.ATX)
        {
        }
        #endregion

        /// <summary>
        /// Muestra la información técnica de la fuente de poder
        /// </summary>
        public string DetallesTecnicos()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine($"Fuente de poder de tipo: {this.tipoDeFuente}");
            sB.AppendLine($"Potencia: {this.Potencia} Watts");
            if (EsOvercockleable(this))
            {
                sB.AppendLine($"Este componente es potenciable");
            } else
            {
                sB.AppendLine($"Este componente NO es potenciable");
            }
            sB.AppendLine($"Rendimiento Técnico: Genera {this.RendimientoTecnico()} Watts Reales");
            sB.AppendLine(base.ToString());
            return sB.ToString();
        }
        /// <summary>
        /// Método interno utilizado para indicar si el componente es potenciable
        /// </summary>
        /// <param name="obj">La instancia actual</param>
        /// <returns>True si el objeto es del tipo ETipoFuente.ATX, de lo contrario false</returns>
        public bool EsOvercockleable(FuenteDePoder obj)
        {
            return obj.tipoDeFuente == ETipoFuente.ATX;
        }
        /// <summary>
        /// Realiza una prueba técnica a la potencia y el consumo de la fuente de poder en base a su tipo
        /// </summary>
        /// <returns>La cantidad de Watts reales que la fuente puede generar</returns>
        public float RendimientoTecnico()
        {
            float valorEnWatts = this.Potencia - (this.Consumo * 7.5f);
            if (this.TipoDeFuente == ETipoFuente.SFX)
            {
                valorEnWatts = this.Potencia - (this.Consumo * 10);
            } else if (this.TipoDeFuente == ETipoFuente.TFX)
            {
                valorEnWatts = this.Potencia - (this.Consumo / 8.5f);
            }
            return valorEnWatts;
        }
        /// <summary>
        /// Muestra la información de la Fuente de Poder actual
        /// </summary>
        public override string ToString()
        {
            return this.DetallesTecnicos();
        }
        #endregion
    }
}
