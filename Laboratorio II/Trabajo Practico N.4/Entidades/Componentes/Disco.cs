using System.Text;
using Entidades.Enumerado;
using Entidades.Interfaces;

namespace Entidades.Componentes
{
    /// <summary>
    /// Hace referencia a un componente electrónico que almacena información a largo plazo donde alojará a un sistema operativo
    /// y donde el microprocesador recurrirá a la hora de iniciar. <br></br>
    /// Compontente vital.
    /// </summary>
    public class Disco : ComponenteElectronico, IComponente<Disco>, IBenchmark
    {
        #region Atributos
        private short cantidadDeEspacio;
        private ETipoDisco tipoDeDisco;
        #endregion

        #region Propiedades
        /// <summary>
        /// Lectura: Retorna la cantidad de espacio del Disco en GBs<br></br>
        /// Escritura: Asigna un nuevo espacio en GBs al Disco
        /// </summary>
        public short EspacioTotal
        {
            get => this.cantidadDeEspacio;
            set => this.cantidadDeEspacio = value;
        }
        /// <summary>
        /// Lectura: Retorna el tipo de Disco<br></br>
        /// Escritura: Asigna un nuevo tipo a la instancia actual
        /// </summary>
        public ETipoDisco Tipo
        {
            get => this.tipoDeDisco;
            set => this.tipoDeDisco = value;
        }
        /// <summary>
        /// Lectura: Indica si el Disco es Potenciable
        /// </summary>
        public override bool Potenciable
        {
            get => EsOvercockleable(this);
        }
        #endregion

        #region Métodos

        #region Constructores
        public Disco():base()
        {}
        public Disco(EMarcas marca, string modelo, float potencia, float consumo, float precio, short cantidadEspacio, ETipoDisco tipo, int id)
            : base(marca, modelo, potencia, consumo, precio, id)
        {
            this.cantidadDeEspacio = cantidadEspacio;
            this.tipoDeDisco = tipo;
        }
        public Disco(EMarcas marca, string modelo, float potencia, float consumo, float precio, int id)
            : this(marca, modelo, potencia, consumo, precio, 256, ETipoDisco.HDD, id)
        {
        }
        #endregion

        /// <summary>
        /// Muestra los detalles técnicos del Disco
        /// </summary>
        public string DetallesTecnicos()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine($"Tipo de Disco: {this.Tipo}");
            sB.AppendLine($"Tamaño de Disco: {this.EspacioTotal} GBs");
            sB.AppendLine($"Consumo: {this.Consumo} Watts");
            sB.AppendLine($"Tiempo de Lectura/Escritura: {this.RendimientoTecnico()} MB/s");
            sB.AppendLine($"Este componente NO es potenciable");
            sB.AppendLine(base.ToString());
            return sB.ToString();
        }

        /// <summary>
        /// Método interno que indica si la instancia actual es Potenciable. Por defecto es False.
        /// </summary>
        /// <param name="obj">Instancia actual</param>
        public bool EsOvercockleable(Disco obj)
        {
            return false;
        }
        /// <summary>
        /// Realiza una prueba técnica al Disco en base a su cantidad de espacio, su tipo y su consumo
        /// </summary>
        /// <returns>El valor de Lectura y Escritura en MB/s</returns>
        public float RendimientoTecnico()
        {
            float valorEnMB = (this.EspacioTotal * this.consumo) / 20;
            if (this.Tipo == ETipoDisco.SSD)
            {
                valorEnMB = (this.EspacioTotal * this.consumo) / 10;
            } else if (this.Tipo == ETipoDisco.SSHD)
            {
                valorEnMB = (this.EspacioTotal * this.consumo) / 15;
            }
            return valorEnMB;
        }
        #endregion

        #region Sobrecarga
        /// <summary>
        /// Verifica si dos Discos son iguales
        /// </summary>
        /// <param name="d1">Primer Disco a comparar</param>
        /// <param name="d2">Segundo Disco a comparar</param>
        /// <returns>True si ambos Discos son del mismo tipo y tienen la misma cantidad de espacio<br></br>
        /// De lo contrario, retorna False</returns>
        public static bool operator ==(Disco d1, Disco d2)
        {
            return d1.EspacioTotal == d2.EspacioTotal && d1.Tipo == d2.Tipo;
        }
        /// <summary>
        /// Verifica si dos Discos son distintos
        /// </summary>
        /// <param name="d1">Primer Disco a comparar</param>
        /// <param name="d2">Segundo Disco a comparar</param>
        /// <returns>True si ambos Discos tienen distinto tipo y/o distinta cantidad de espacio<br></br>
        /// De lo contrario, retorna False</returns>
        public static bool operator !=(Disco d1, Disco d2)
        {
            return !(d1 == d2);
        }
        #endregion

        #region Sobreescritura
        /// <summary>
        /// Verifica si el objeto por parámetro es igual a la instancia actual
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>True si el objeto es un Disco, y si posee mismo tipo y cantidad de espacio<br></br>
        /// De lo contrario False</returns>
        public override bool Equals(object obj)
        {
            return obj is Disco ? (Disco)obj == this : false;
        }
        /// <summary>
        /// Muestra la información completa del Disco
        /// </summary>
        public override string ToString()
        {
            return this.DetallesTecnicos();
        }
        #endregion
    }
}
