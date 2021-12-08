using System.Text;
using Entidades.Interfaces;
using Entidades.Enumerado;

namespace Entidades.Componentes
{
    /// <summary>
    /// Hace referencia a un componente que genera gráficos e imagen en una computadora.
    /// </summary>
    public class PlacaDeVideo : ComponenteElectronico, IComponente<ComponenteElectronico>, IBenchmark
    {
        #region Atributos
        private float memoriaGrafica;
        private ETipoPlaca tipoDePlacaGrafica;
        #endregion

        #region Propiedades
        /// <summary>
        /// Lectura: Retorna el tipo de Placa de video<br></br>
        /// Escritura: Asigna un nuevo tipo ETipoPlaca a la Placa de video
        /// </summary>
        public ETipoPlaca Tipo
        {
            get => this.tipoDePlacaGrafica;
            set => this.tipoDePlacaGrafica = value;
        }
        /// <summary>
        /// Lectura: Retorna la cantidad de memoria gráfica que posee la Placa de video<br></br>
        /// Escritura: Asigna una cantidad de memoria gráfica a la Placa de video
        /// </summary>
        public float MemoriaGrafica
        {
            get => this.memoriaGrafica;
            set => this.memoriaGrafica = value;
        }
        /// <summary>
        /// Lectura: Retorna si una placa de video es potenciable en base a su cantidad de memoria gráfica<br></br>
        /// </summary>
        public override bool Potenciable
        { 
            get => EsOvercockleable(this);
        }
        #endregion

        #region Métodos

        #region Constructores
        public PlacaDeVideo() : base()
        { }
        public PlacaDeVideo(EMarcas marca, string modelo, float potencia, float consumo, float precio, float memoriaGrafica, ETipoPlaca tipo, int id)
            : base(marca, modelo, potencia, consumo, precio, id)
        {
            this.memoriaGrafica = memoriaGrafica;
            this.tipoDePlacaGrafica = tipo;
        }
        public PlacaDeVideo(EMarcas marca, string modelo, float potencia, float consumo, float precio, int id)
            : this(marca, modelo, potencia, consumo, precio, 1f, ETipoPlaca.IntegradaCPU, id)
        {
        }
        #endregion

        /// <summary>
        /// Método interno utilizado para indicar si el componente es potenciable
        /// </summary>
        /// <param name="obj">La instancia actual</param>
        /// <returns>True si el objeto es una placa de video y posee más de 1 GB de memoria grafica, de lo contrario false</returns>
        public bool EsOvercockleable(ComponenteElectronico obj)
        {
            return obj is PlacaDeVideo ? this.memoriaGrafica > 1 : false;
        }
        /// <summary>
        /// Muestra la información técnica de la placa de video
        /// </summary>
        public string DetallesTecnicos()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine($"Placa de video de tipo: {this.tipoDePlacaGrafica}");
            sB.AppendLine($"Potencia: {this.Potencia} Ghz");
            sB.AppendLine($"Consumo: {this.Consumo} Watts");
            sB.AppendLine(base.ToString());
            return sB.ToString();
        }
        /// <summary>
        /// Realiza un testeo de potencia, memoria gráfica y el consumo de una placa de video
        /// </summary>
        /// <returns>El valor obtenido en TFLOPS</returns>
        public float RendimientoTecnico()
        {
            return this.Potencia * this.MemoriaGrafica / (this.Consumo * 2);
        }
        /// <summary>
        /// Pone a prueba dos placas de video, obtiene sus valores en TFLOPS y retorna la placa con mayor rendimiento
        /// </summary>
        /// <param name="pV1">Primera placa de video puesta a prueba</param>
        /// <param name="pV2">Segunda placa de video puesta a prueba</param>
        public static PlacaDeVideo RendimientoTecnico(PlacaDeVideo pV1, PlacaDeVideo pV2)
        {            
            if (pV1.RendimientoTecnico() > pV2.RendimientoTecnico())
            {
                return pV1;
            } else
            {
                return pV2;
            }
        }
        #endregion

        #region Sobrecarga
        /// <summary>
        /// Compara dos placas de videos según su rendimiento técnico
        /// </summary>
        /// <param name="pV1">Primer placa de video a comparar</param>
        /// <param name="pV2">Segunda placa de video a comparar</param>
        /// <returns>True si ambos poseen mismo rendimiento técnico, de lo contrario False</returns>
        public static bool operator ==(PlacaDeVideo pV1, PlacaDeVideo pV2)
        {
            return pV1.RendimientoTecnico() == pV2.RendimientoTecnico();
        }
        /// <summary>
        /// Compara dos placas de videos según su rendimiento técnico
        /// </summary>
        /// <param name="pV1">Primer placa de video a comparar</param>
        /// <param name="pV2">Segunda placa de video a comparar</param>
        /// <returns>True si poseen distinto rendimiento técnico, de lo contrario False</returns>
        public static bool operator !=(PlacaDeVideo pV1, PlacaDeVideo pV2)
        {
            return !(pV1 == pV2);
        }
        #endregion

        #region Sobreescritura
        /// <summary>
        /// Retorna la información completa de la placa de video
        /// </summary>
        public override string ToString()
        {
            return this.DetallesTecnicos();
        }
        /// <summary>
        /// Verifica si el objeto en parámetro es igual a la instancia actual
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>True si el objeto es una placa de video y poseen mismo rendimiento, de lo contrario False</returns>
        public override bool Equals(object obj)
        {
            return obj is PlacaDeVideo ? (PlacaDeVideo)obj == this : false;
        }
        #endregion
    }
}
