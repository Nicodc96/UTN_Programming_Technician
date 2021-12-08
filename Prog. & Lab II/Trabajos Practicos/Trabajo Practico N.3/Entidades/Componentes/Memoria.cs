using System.Text;
using Entidades.Enumerado;
using Entidades.Interfaces;

namespace Entidades.Componentes
{
    /// <summary>
    /// Hace referencia a un componente electrónico que almacena información temporal y volátil que será utilizado
    /// por un microprocesador para su correcto funcionamiento. <br></br>
    /// Componente vital.
    /// </summary>
    public class Memoria : ComponenteElectronico, IComponente<Memoria>, IBenchmark
    {
        #region Atributos
        private ETipoMemoria tipoDeMemoria;
        private ETecnologiaMemoria tipoDeTecnologiaMemoria;
        #endregion

        #region Propiedades
        /// <summary>
        /// Lectura: Retorna el tipo de Memoria<br></br>
        /// Escritura: Asigna un nuevo tipo de ETipoMemoria a la instancia actual
        /// </summary>
        public ETipoMemoria TipoMemoria
        {
            get
            {
                return this.tipoDeMemoria;
            }
            set
            {
                this.tipoDeMemoria = value;
            }
        }
        /// <summary>
        /// Lectura: Retorna la tecnologia actual de la Memoria<br></br>
        /// Escritura: Asigna un nuevo tipo de ETecnologiaMemoria a la instancia actual
        /// </summary>
        public ETecnologiaMemoria Tecnologia
        {
            get
            {
                return this.tipoDeTecnologiaMemoria;
            }
            set
            {
                this.tipoDeTecnologiaMemoria = value;
            }
        }
        /// <summary>
        /// Lectura: Verifica si una Memoria es Potenciable
        /// </summary>
        public override bool Potenciable
        {
            get
            {
                return EsOvercockleable(this);
            }
        }
        #endregion
        #region Métodos

        #region Constructor
        public Memoria() : base()
        { }
        public Memoria(EMarcas marca, string modelo, float potencia, float consumo, float precio, ETipoMemoria tipoMemoria, ETecnologiaMemoria tipoTecnologia)
            : base(marca, modelo, potencia, consumo, precio)
        {
            this.tipoDeMemoria = tipoMemoria;
            this.tipoDeTecnologiaMemoria = tipoTecnologia;
        }
        public Memoria(EMarcas marca, string modelo, float potencia, float consumo, float precio)
            : this(marca, modelo, potencia, consumo, precio, ETipoMemoria.DIMM, ETecnologiaMemoria.DDR4)
        {
        }
        #endregion

        /// <summary>
        /// Realiza una prueba técnica a la memoria basado en su tipo, su potencia y su consumo
        /// </summary>
        /// <returns>La velocidad de Lectura y Escritura en MB/s</returns>
        public float RendimientoTecnico()
        {
            float valorEnMB = this.Potencia * (this.Consumo / 3);
            if (this.TipoMemoria == ETipoMemoria.SODIMM)
            {
                valorEnMB = this.Potencia * (this.Consumo / 4.5f);
            }
            return valorEnMB;
        }
        /// <summary>
        /// Método interno que verifica si una memoria es potenciable a partir de su Potencia (Frecuencia)
        /// </summary>
        /// <param name="obj">Instancia actual</param>
        /// <returns>True si la frecuencia de la memoria es igual o mayor a 2333 Mhz, de lo contrario False</returns>
        public bool EsOvercockleable(Memoria obj)
        {
            return obj.Potencia >= 2333;
        }
        /// <summary>
        /// Muestra la información técnica detallada de una Memoria RAM
        /// </summary>
        public string DetallesTecnicos()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine($"Tipo de Memoria: {this.TipoMemoria}");
            sB.AppendLine($"Generacion: {this.Tecnologia}");
            sB.AppendLine($"Potencia: {this.Potencia} Mhz");
            sB.AppendLine($"Consumo: {this.Consumo} Watts");
            sB.AppendLine($"Velocidad de Escritura/Lectura: {this.RendimientoTecnico()} MB/s");
            if (this.Potenciable)
            {
                sB.AppendLine($"Este componente es potenciable");
            }
            else
            {
                sB.AppendLine($"Este componente NO es potenciable");
            }
            sB.AppendLine(base.ToString());
            return sB.ToString();
        }
        /// <summary>
        /// Compara dos tipos de Memoria
        /// </summary>
        /// <param name="m1">Primera memoria a comparar</param>
        /// <param name="m2">Segunda memoria a comparar</param>
        /// <returns>True si ambos comparten Potencia y Tecnologia, de lo contrario False</returns>
        public static bool operator ==(Memoria m1, Memoria m2)
        {
            return m1.Potencia == m2.Potencia && m1.TipoMemoria == m2.TipoMemoria;
        }
        /// <summary>
        /// Compara dos tipos de Memoria
        /// </summary>
        /// <param name="m1">Primera memoria a comparar</param>
        /// <param name="m2">Segunda memoria a comparar</param>
        /// <returns>True si ambos tienen distinto Potencia y/o Tecnologia, de lo contrario False</returns>
        public static bool operator !=(Memoria m1, Memoria m2)
        {
            return !(m1 == m2);
        }
        #endregion

        #region Sobreescritura
        /// <summary>
        /// Verifica si el objeto por parámetro es igual a la instancia actual
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>True si el objeto es de tipo Memoria, comparten Tipo y Tecnologia<br></br>
        /// Caso contrario, retorna false</returns>
        public override bool Equals(object obj)
        {
            return obj is Memoria ? (Memoria)obj == this : false;
        }
        /// <summary>
        /// Muestra la información completa de la Memoria
        /// </summary>
        public override string ToString()
        {
            return this.DetallesTecnicos();
        }
        #endregion
    }
}
