using System.Text;
using Entidades.Enumerado;
using Entidades.Interfaces;

namespace Entidades.Componentes
{
    /// <summary>
    /// Hace referencia a un componente electrónico que será el encargado de operar, establecer y determinar todas las
    /// tareas que realice una computadora, dependiente e independientemente del usuario. <br></br>
    /// Componente vital.
    /// </summary>
    public class Procesador : ComponenteElectronico, IComponente<Procesador>, IBenchmark
    {
        #region Atributos
        private EFabricanteCPU nombreFabricante;
        private ECantidadNucleos cantidadDeNucleos;
        #endregion

        #region Propiedades
        /// <summary>
        /// Lectura: Retorna el nombre del Fabricante<br></br>
        /// Escritura: Asigna un fabricante a la instancia actual
        /// </summary>
        public EFabricanteCPU Fabricante
        {
            get => this.nombreFabricante;
            set => this.nombreFabricante = value;
        }
        /// <summary>
        /// Lectura: Retorna el tipo de Nucleos que posee el Procesador<br></br>
        /// Escritura: Asigna una nueva cantidad de Nucleos a la instancia actual
        /// </summary>
        public ECantidadNucleos Nucleos
        {
            get => this.cantidadDeNucleos;
            set => this.cantidadDeNucleos = value;
        }
        /// <summary>
        /// Verifica si el Procesador es potenciable
        /// </summary>
        public override bool Potenciable
        {
            get => this.EsOvercockleable(this);
        }
        #endregion

        #region Métodos

        #region Constructores
        public Procesador() : base()
        { }
        public Procesador(EMarcas marca, string modelo, float potencia, float consumo, float precio, EFabricanteCPU fabricante, ECantidadNucleos cantNucleos, int id)
            : base(marca, modelo, potencia, consumo, precio, id)
        {
            this.nombreFabricante = fabricante;
            this.cantidadDeNucleos = cantNucleos;
        }
        public Procesador(EMarcas marca, string modelo, float potencia, float consumo, float precio, int id) 
            : this(marca, modelo, potencia, consumo, precio, EFabricanteCPU.AMD, ECantidadNucleos.Quad_Core, id)
        {
        }
        #endregion

        /// <summary>
        /// Muestra la información técnica y detallada del procesador
        /// </summary>
        public string DetallesTecnicos()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine($"Fabricante CPU: {this.Fabricante}");
            sB.AppendLine($"Cantidad de núcleos: {this.Nucleos}");
            sB.AppendLine($"Potencia: {this.Potencia} Mhz");
            sB.AppendLine($"Consumo: {this.Consumo} Watts");
            sB.AppendLine($"{this.RendimientoTecnico()} Operaciones p/ segundo");
            if (EsOvercockleable(this))
            {
                sB.AppendLine($"Este componente es potenciable");
            } else
            {
                sB.AppendLine($"Este componente NO es potenciable");
            }
            sB.AppendLine(base.ToString());
            return sB.ToString();
        }
        /// <summary>
        /// Método interno que indica si un precesador puede ser potenciable
        /// </summary>
        /// <param name="obj">Instancia actual</param>
        /// <returns>True si el procesador posee una potencia mayor a 3000 Mhz, caso contrario False</returns>
        public bool EsOvercockleable(Procesador obj)
        {
            return obj.Potencia > 3000;
        }
        /// <summary>
        /// Realiza una prueba técnica al Procesador a partir de su potencia, consumo y cantidad de núcleos
        /// </summary>
        /// <returns>La cantidad de operaciones por segundo</returns>
        public float RendimientoTecnico()
        {
            return this.Potencia * (int)this.Nucleos / this.Consumo;
        }
        #endregion

        #region Sobrecarga
        /// <summary>
        /// Compara dos procesadores
        /// </summary>
        /// <param name="p1">Primer Procesador a comparar</param>
        /// <param name="p2">Segundo Procesador a comparar</param>
        /// <returns>True si ambos poseen mismo rendimiento y fabricante, caso contrario False</returns>
        public static bool operator ==(Procesador p1, Procesador p2)
        {
            return p1.RendimientoTecnico() == p2.RendimientoTecnico() && p1.Fabricante == p1.Fabricante;
        }
        /// <summary>
        /// Compara dos procesadores
        /// </summary>
        /// <param name="p1">Primer Procesador a comparar</param>
        /// <param name="p2">Segundo Procesador a comparar</param>
        /// <returns>True si poseen distinto rendimiento y/o fabricante, caso contrario False</returns>
        public static bool operator !=(Procesador p1, Procesador p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #region Sobreescritura
        /// <summary>
        /// Verifica si el objeto por parámetro es igual a la instancia actual
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>True si el objeto es un Procesador, posee mismo rendimiento y mismo fabricante<br></br>
        /// Caso contrario, retorna False</returns>
        public override bool Equals(object obj)
        {
            return obj is Procesador ? (Procesador)obj == this : false;
        }
        /// <summary>
        /// Muestra la información completa del Procesador
        /// </summary>
        public override string ToString()
        {
            return this.DetallesTecnicos();
        }
        #endregion              
    }
}
