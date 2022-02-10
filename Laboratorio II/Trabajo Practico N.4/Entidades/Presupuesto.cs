using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Presupuesto
    {
        #region Atributos
        private List<ComponenteElectronico> listaDeComponentes;
        private int id;
        private int idCliente;
        private int tamanioLista;
        private DateTime fechaDeEmision;
        private float precioFinal;        
        #endregion

        #region Propiedades
        /// <summary>
        /// Hace referencia al ID del Cliente al que pertenece el presupuesto
        /// </summary>
        public int ID_Cliente
        {
            get => this.idCliente;
            set => this.idCliente = value;
        }
        /// <summary>
        /// Hace referencia al ID del presupuesto
        /// </summary>
        public int ID_Presupuesto
        {
            get => this.id;
            set => this.id = value;
        }
        /// <summary>
        /// Retorna (si existe) la lista de componentes, si no devuelve una nueva lista vacía
        /// </summary>
        public List<ComponenteElectronico> ListaDeComponentes
        {
            get => this.listaDeComponentes;
            set => this.listaDeComponentes = value;
        }
        /// <summary>
        /// Cantidad de componentes contenido en el presupuesto
        /// </summary>
        public int CantidadComponentes
        {
            get
            {
                if (this.tamanioLista == 0)
                {
                    this.tamanioLista = this.ListaDeComponentes.Count;
                }
                return this.tamanioLista;
            }
            set => this.tamanioLista = value;
        }
        /// <summary>
        /// Retorna la fecha en la que se emitió el presupuesto
        /// </summary>
        public DateTime FechaEmision
        {
            get => this.fechaDeEmision;
            set => this.fechaDeEmision = value;
        }
        /// <summary>
        /// Retorna el precio total de los componentes en Dólares
        /// </summary>
        public float PrecioFinal
        {
            get
            {
                if (this.precioFinal == 0)
                {
                    if (ListaDeComponentes is not null)
                    {
                        foreach (ComponenteElectronico cE in ListaDeComponentes)
                        {
                            this.precioFinal += cE.Precio;
                        }
                    }
                }
                return this.precioFinal;
            }
            set => this.precioFinal = value;
        }
        /// <summary>
        /// Informa resumidamente las marcas y modelos de los componentes contenidos en el Presupuesto
        /// </summary>
        public string ResumenPresupuesto
        {
            get
            {
                StringBuilder sB = new StringBuilder();
                foreach (ComponenteElectronico item in this.ListaDeComponentes)
                {
                    sB.AppendLine($"Marca: {item.Marca} - Modelo: {item.Modelo}");
                }
                return sB.ToString();
            }
        }
        #endregion

        #region Métodos
        public Presupuesto()
        { }

        public Presupuesto(int tamanioLista, DateTime fechaEmision, int id, int idCliente):this()
        {
            listaDeComponentes = new List<ComponenteElectronico>(tamanioLista);
            this.id = id;
            this.idCliente = idCliente;
            this.tamanioLista = tamanioLista;
            this.fechaDeEmision = fechaEmision;
        }
        /// <summary>
        /// Método interno utilizado para obtener el índice de un componente dentro de la lista
        /// </summary>
        /// <param name="componente">Componente a buscar</param>
        /// <returns>El índice donde se encuentra el componente, de lo contrario devuelve -1</returns>
        private int GetIndice(ComponenteElectronico componente)
        {
            int indice = -1;
            for (int i = 0; i < this.ListaDeComponentes.Count(); i++)
            {
                if (this.listaDeComponentes[i].Equals(componente))
                {
                    indice = i;
                    break;
                }
            }
            return indice;
        }
        /// <summary>
        /// Información completa del presupuesto
        /// </summary>
        public string InformarPresupuesto()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine($"Cantidad de componentes: {this.ListaDeComponentes.Count()}");
            sB.AppendLine("Lista de componentes:");
            sB.AppendLine(this.InfoComponentes());
            sB.AppendLine($"Precio total: uSD${this.PrecioFinal}");
            return sB.ToString();
        }
        /// <summary>
        /// Ordena la lista según el precio de cada componente
        /// </summary>
        public void OrdenarPresupuesto()
        {
            this.ListaDeComponentes.Sort(ComponenteElectronico.OrdenamientoPorPrecio);
        }
        /// <summary>
        /// Informa resumidamente sobre los componentes que posee el Presupuesto
        /// </summary>
        public string InfoComponentes()
        {
            StringBuilder sB = new StringBuilder();
            foreach (ComponenteElectronico item in this.ListaDeComponentes)
            {
                sB.AppendLine(item.InfoResumida());
            }
            return sB.ToString();
        }
        #endregion

        #region Sobrecarga
        /// <summary>
        /// Verifica si un componente electrónico ya existe en el presupuesto
        /// </summary>
        /// <param name="lista">Lista de componentes</param>
        /// <param name="componente">Componente a buscar</param>
        /// <returns>True si ya existe en la lista, de lo contrario False</returns>
        public static bool operator ==(Presupuesto lista, ComponenteElectronico componente)
        {
            bool existeEnLista = false;
            if (lista is not null && lista.GetIndice(componente) != -1)
            {
                existeEnLista = true;
            }
            return existeEnLista;
        }
        /// <summary>
        /// Verifica si un componente no está incluído en el Presupuesto
        /// </summary>
        /// <param name="lista">Lista de componentes</param>
        /// <param name="componente">Componente a buscar</param>
        /// <returns>True si no está incluído, de lo contrario False</returns>
        public static bool operator !=(Presupuesto lista, ComponenteElectronico componente)
        {
            return !(lista == componente);
        }
        /// <summary>
        /// Verifica si dos presupuestos son iguales si poseen los mismos componentes electrónicos
        /// </summary>
        /// <param name="p1">Primer presupuesto a comparar</param>
        /// <param name="p2">Segundo presupuesto a comparar</param>
        /// <returns>True si ambos presupuestos poseen mismos componentes, de lo contrario False</returns>
        public static bool operator ==(Presupuesto p1, Presupuesto p2)
        {
            bool sonIguales = true;
            if (p1 is null || p2 is null)
            {
                sonIguales = false;
            } else
            {
                foreach (ComponenteElectronico cE in p1.listaDeComponentes)
                {
                    if (p2 != cE)
                    {
                        sonIguales = false;
                        break;
                    }
                }
            }
            return sonIguales;
        }
        /// <summary>
        /// Verifica si dos presupuestos poseen distintos componentes electrónicos
        /// </summary>
        /// <param name="p1">Primer presupuesto a comparar</param>
        /// <param name="p2">Segundo presupuesto a comparar</param>
        /// <returns>True si al menos poseen 1 componente distinto, de lo contrario False</returns>
        public static bool operator !=(Presupuesto p1, Presupuesto p2)
        {
            return !(p1 == p2);
        }
        /// <summary>
        /// Agrega un componente electrónico al presupuesto
        /// </summary>
        /// <param name="lista">Lista de componentes</param>
        /// <param name="componente">Componente a buscar</param>
        /// <returns>La lista con el componente agregado si no existe actualmente y si hay espacio en la lista de componentes<br></br>
        /// De lo contrario retorna la lista sin modificaciones</returns>
        public static Presupuesto operator +(Presupuesto lista, ComponenteElectronico componente)
        {
            if (lista != componente && lista.ListaDeComponentes.Count() < lista.tamanioLista)
            {
                lista.ListaDeComponentes.Add(componente);
            }
            return lista;
        }
        /// <summary>
        /// Quita un componente electrónico del presupuesto
        /// </summary>
        /// <param name="lista">Lista de componentes</param>
        /// <param name="componente">Componente a buscar</param>
        /// <returns>La lista con el componente removido si se encontraba en la lista, de lo contrario retorna la lista<br></br>
        /// sin modificaciones</returns>
        public static Presupuesto operator -(Presupuesto lista, ComponenteElectronico componente)
        {
            if (lista == componente)
            {
                lista.ListaDeComponentes.RemoveAt(lista.GetIndice(componente));
            }
            return lista;
        }
        #endregion

        #region Sobreescritura
        /// <summary>
        /// Verifica si el objeto por parámetro pertenece al presupuesto
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>True si el objeto es un presupuesto y tiene los mismos componentes<br></br>
        /// De lo contrario, devuelve False</returns>
        public override bool Equals(object obj)
        {
            return obj is Presupuesto ? this == (Presupuesto)obj : false;
        }
        /// <summary>
        /// Muestra la información completa del Presupuesto y de sus componentes
        /// </summary>
        public override string ToString()
        {
            return this.ResumenPresupuesto;
        }
        #endregion
    }
}
