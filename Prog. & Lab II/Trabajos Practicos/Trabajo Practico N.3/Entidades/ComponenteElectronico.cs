using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Entidades.Componentes;
using Entidades.Enumerado;

namespace Entidades
{
    /// <summary>
    /// Clase base. Se refiere a un tipo de componente electrónico, específicamente un componente de PC.<br></br><br></br>
    /// No será posible instanciar un objeto de este tipo.
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(Disco))]
    [XmlInclude(typeof(FuenteDePoder))]
    [XmlInclude(typeof(Memoria))]
    [XmlInclude(typeof(PlacaDeVideo))]
    [XmlInclude(typeof(PlacaMadre))]
    [XmlInclude(typeof(Procesador))]
    public abstract class ComponenteElectronico
    {
        #region Atributos
        protected EMarcas marca;
        protected string modelo;
        protected float potencia;
        protected float consumo;
        protected float precio;
        protected bool esPotenciable;
        #endregion

        #region Propiedades
        /// <summary>
        /// Lectura: Retorna la marca del Componente<br></br>
        /// Escritura: Asigna una marca si pertenece a <enum>EMarcas</enum>
        /// </summary>
        public virtual EMarcas Marca
        {
            get
            {
                return this.marca;
            }
            set
            {
                this.marca = value;
            }
        }
        /// <summary>
        /// Lectura: Retorna el modelo del Componente<br></br>
        /// Escritura: Asigna el modelo del Componente
        /// </summary>
        public virtual string Modelo
        {
            get
            {
                return this.modelo;
            }
            set
            {
                this.modelo = value;
            }
        }
        /// <summary>
        /// Lectura: Retorna la potencia del Componente<br></br>
        /// Escritura: Asigna la potencia del Componente
        /// </summary>
        public virtual float Potencia
        {
            get
            {
                return this.potencia;
            }
            set
            {
                this.potencia = value;
            }
        }
        /// <summary>
        /// Lectura: Retorna el consumo del Componente<br></br>
        /// Escritura: Asigna el consumo del Componente
        /// </summary>
        public virtual float Consumo
        {
            get
            {
                return this.consumo;
            }
            set
            {
                this.consumo = value;
            }
        }
        /// <summary>
        /// Lectura: Retorna el precio del Componente<br></br>
        /// Escritura: Asigna el precio del Componente
        /// </summary>
        public virtual float Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }
        /// <summary>
        /// Lectura: Retorna true si es posible realizar mejora al Componente, de lo contrario false<br></br>
        /// Escritura: Asigna una condición que hará que el componente sea o no mejorable
        /// </summary>
        public virtual bool Potenciable
        {
            get
            {
                return this.esPotenciable;
            }
            set
            {
                this.esPotenciable = value;
            }
        }
        #endregion

        #region Métodos
        public ComponenteElectronico()
        { }
        public ComponenteElectronico(EMarcas marca, string modelo, float potencia, float consumo, float precio) : this()
        {
            this.marca = marca;
            this.modelo = modelo;
            this.potencia = potencia;
            this.consumo = consumo;
            this.precio = precio;
            this.esPotenciable = false;
        }
        /// <summary>
        /// Aplica una potencia extra al componente si esta no supera el 15% de la potencia total actual
        /// </summary>
        /// <param name="nuevaPotencia">Nueva potencia a aplicar</param>
        /// <returns>True si la potencia se ha podido aplicar, de lo contrario false</returns>
        public virtual bool Overclocking(float nuevaPotencia)
        {
            bool potenciaAplicada = false;
            if (nuevaPotencia <= this.Potencia * 0.15)
            {
                this.Potencia = nuevaPotencia;
                potenciaAplicada = true;
            }
            return potenciaAplicada;
        }
        /// <summary>
        /// Método de ordenamiento con criterio basado en el precio del componente
        /// </summary>
        /// <param name="cE1">Primer componente a comparar</param>
        /// <param name="cE2">Segundo componente a comparar</param>
        /// <returns>0: si los componentes tienen el mismo precio<br></br>
        /// 1: si el primer componente es más caro que el segundo<br></br> 
        /// -1: si el segundo componente es más caro que el primero</returns>
        public static int OrdenamientoPorPrecio(ComponenteElectronico cE1, ComponenteElectronico cE2)
        {
            int valorRetorno = 0;
            if (cE1.Precio > cE2.Precio)
            {
                valorRetorno = 1;
            } else if (cE1.Precio < cE2.Precio)
            {
                valorRetorno = -1;
            }
            return valorRetorno;
        }
        #endregion

        #region Sobrecarga
        /// <summary>
        /// Verifica si dos componentes comparten Marca y Modelo
        /// </summary>
        /// <param name="cE1">Primer Componente</param>
        /// <param name="cE2">Segundo Componente</param>
        /// <returns>True si tienen misma Marca y Modelo, de lo contrario False</returns>
        public static bool operator ==(ComponenteElectronico cE1, ComponenteElectronico cE2)
        {
            return (cE1.Marca == cE2.Marca) && (cE1.Modelo == cE2.Modelo);
        }
        public static bool operator !=(ComponenteElectronico cE1, ComponenteElectronico cE2)
        {
            return !(cE1 == cE2);
        }
        /// <summary>
        /// Verifica si existe un componente en una lista
        /// </summary>
        /// <param name="lista">Lista de componentes</param>
        /// <param name="cE">Componente a buscar</param>
        /// <returns>True si el componente existe en la lista, de lo contrario False</returns>
        public static bool operator ==(List<ComponenteElectronico> lista, ComponenteElectronico cE)
        {
            return lista.Contains(cE);
        }
        /// <summary>
        /// Verifica si el componente no está incluído en la lista
        /// </summary>
        /// <param name="lista">Lista de componentes</param>
        /// <param name="cE">Componente a buscar</param>
        /// <returns>True si el componente está incluído en la lista, de lo contrario False</returns>
        public static bool operator !=(List<ComponenteElectronico> lista, ComponenteElectronico cE)
        {
            return !(lista == cE);
        }
        public static explicit operator string(ComponenteElectronico cE)
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine($"Marca: {cE.Marca}");
            sB.AppendLine($"Modelo: {cE.Modelo}");            
            sB.AppendLine($"Precio: uSd${cE.Precio}");
            return sB.ToString();
        }
        /// <summary>
        /// Método que informa únicamente Marca y Modelo de un componente
        /// </summary>
        public string InfoResumida()
        {
            return $"{this.Marca} - {this.Modelo} ";
        }
        #endregion

        #region Sobreescritura
        /// <summary>
        /// Retorna la información contenida de un componente electrónico
        /// </summary>
        public override string ToString()
        {
            return (string)this;
        }
        /// <summary>
        /// Verifica si el objeto por parámetro es igual a la instancia actual
        /// </summary>
        /// <param name="obj">Objeto a verificar</param>
        /// <returns>True si el objeto es un componente, y comparten Marca y Modelo<br></br>
        /// De lo contrario, devuelve False</returns>
        public override bool Equals(object obj)
        {
            return obj is ComponenteElectronico ? (ComponenteElectronico)obj == this : false;
        }
        #endregion
    }
}
