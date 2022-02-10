using System.Text;
using Entidades.Enumerado;
using Entidades.Interfaces;

namespace Entidades.Componentes
{
    /// <summary>
    /// Hace referencia a un componente electrónico vital en una computadora, interconectando
    /// los demás componentes y comunicándolos entre ellos. <br></br>
    /// Componente vital.
    /// </summary>
    public class PlacaMadre : ComponenteElectronico, IComponente<PlacaMadre>, IBenchmark
    {
        #region Atributos
        private ETipoMother tipoDePlacaMadre;
        private ESocket tipoDeSocket;
        #endregion

        #region Propiedades
        /// <summary>
        /// Lectura: Retorna el tipo de Placa Madre<br></br>
        /// Escritura: Asigna un nuevo tipo de ETipoMother
        /// </summary>
        public ETipoMother TipoDeMother
        {
            get => this.tipoDePlacaMadre;
            set => this.tipoDePlacaMadre = value;
        }
        /// <summary>
        /// Lectura: Retorna el tipo de Socket que posee la Placa Madre<br></br>
        /// Escritura: Asigna un nuevo tipo de ESocket a la instancia
        /// </summary>
        public ESocket Socket
        {
            get => this.tipoDeSocket;
            set => this.tipoDeSocket = value;
        }
        /// <summary>
        /// Lectura: Retorna si una placa madre es potenciable
        /// </summary>
        public override bool Potenciable
        {
            get => EsOvercockleable(this);
        }
        #endregion

        #region Métodos

        #region Constructores
        public PlacaMadre() : base()
        { }
        public PlacaMadre(EMarcas marca, string modelo, float potencia, float consumo, float precio, ETipoMother tipoMother, ESocket tipoSocket, int id)
            : base(marca, modelo, potencia, consumo, precio, id)
        {
            this.tipoDePlacaMadre = tipoMother;
            this.tipoDeSocket = tipoSocket;
        }
        public PlacaMadre(EMarcas marca, string modelo, float potencia, float consumo, float precio, int id)
            : this(marca, modelo, potencia, consumo, precio, ETipoMother.Normal, ESocket.AM4, id)
        {
        }
        #endregion

        /// <summary>
        /// Muestra la información técnica y detallada de la Placa Madre
        /// </summary>
        public string DetallesTecnicos()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine($"Tipo de Placa Madre: {this.TipoDeMother}");
            sB.AppendLine($"Tipo de Socket: {this.Socket}");
            sB.AppendLine($"Consumo: {this.Consumo} Watts");
            if (this.TipoDeMother == ETipoMother.Gaming || this.TipoDeMother == ETipoMother.GamingRGB)
            {
                sB.AppendLine($"Esta placa madre permite SLI");
            } else
            {
                sB.AppendLine($"Esta placa madre NO permite SLI");
            }
            sB.AppendLine($"Este componente NO es potenciable"); // Por defecto esto se establece siempre
            sB.AppendLine($"Rendimiento Técnico: {this.RendimientoTecnico()} Watts de eficiencia");
            sB.AppendLine(base.ToString());
            return sB.ToString();
        }
        /// <summary>
        /// Verifica si una placa madre es potenciable, por defecto esto es False.
        /// </summary>
        /// <param name="obj">Instancia actual</param>
        public bool EsOvercockleable(PlacaMadre obj)
        {
            return false;
        }
        /// <summary>
        /// Realiza un testeo a la placa madre en base a su tipo
        /// </summary>
        /// <returns>El valor en Watts de eficiencia</returns>
        public float RendimientoTecnico()
        {
            float resultadoEnConsumo = this.Potencia / 3;
            if (this.TipoDeMother == ETipoMother.Gaming)
            {
                resultadoEnConsumo = this.Potencia / 1.5f;
            } else if (this.TipoDeMother == ETipoMother.GamingRGB)
            {
                resultadoEnConsumo = this.Potencia / 1.2f;
            }
            return resultadoEnConsumo;
        }
        /// <summary>
        /// Retorna la información completa de la Placa Madre
        /// </summary>
        public override string ToString()
        {
            return this.DetallesTecnicos();
        }
        #endregion
    }
}
