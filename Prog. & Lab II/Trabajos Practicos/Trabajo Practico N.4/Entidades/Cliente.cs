using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Cliente
    {
        #region Atributos
        private string nombre;
        private string apellido;
        private string CUIL;
        private byte edad;
        private char sexo;
        private bool esComprador;
        private Presupuesto presupuestoPedido;
        private int idPresupuesto;
        private int id;
        #endregion

        #region Propiedades
        /// <summary>
        /// Nombre del Cliente
        /// </summary>
        public string Nombre
        {
            get => this.nombre;
            set => this.nombre = value;
        }
        /// <summary>
        /// Apellido del Cliente
        /// </summary>
        public string Apellido
        {
            get => this.apellido;
            set => this.apellido = value;
        }
        /// <summary>
        /// CUIT o CUIL del Cliente
        /// </summary>
        public char Sexo
        {
            get => this.sexo;
            set => this.sexo = value;
        }
        public string CUIL_CUIT
        {
            get => this.CUIL;
            set => this.CUIL = value;
        }
        /// <summary>
        /// Edad del Cliente
        /// </summary>
        public byte Edad
        {
            get => this.edad;
            set => this.edad = value;
        }
        /// <summary>
        /// ID único del cliente
        /// </summary>
        public int ID
        {
            get => this.id;
            set => this.id = value;
        }
        /// <summary>
        /// ID del presupuesto que ha solicitado el Cliente
        /// </summary>
        public int ID_Presupuesto
        {
            get => this.idPresupuesto;
            set => this.idPresupuesto = value;
        }
        /// <summary>
        /// El presupuesto que ha solicitado el Cliente
        /// </summary>
        public Presupuesto PresupuestoCliente
        {
            get => this.presupuestoPedido;
            set => this.presupuestoPedido = value;
        }
        /// <summary>
        /// Verifica si el Cliente ha realizado una compra si por lo menos ha solicitado 1 componente
        /// </summary>
        public bool EsComprador
        {
            get
            {
                this.esComprador = RealizarCompra();
                return this.esComprador;
            }
            set => this.esComprador = value;
        }
        #endregion

        #region Métodos

        #region Constructores
        public Cliente()
        { }
        public Cliente(string nombre, string apellido, string documento, byte edad, Presupuesto presupuesto, char sexo, int id, int idPresupuesto):this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.CUIL = CuilVerificado(documento);
            this.sexo = sexo;
            this.edad = edad;
            this.id = id;
            this.idPresupuesto = idPresupuesto;
            this.presupuestoPedido = presupuesto;
        }
        public Cliente(string nombre, string apellido, string CUIL, byte edad, char sexo, int id, int idPresupuesto)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.CUIL = CUIL;
            this.edad = edad;
            this.presupuestoPedido = null;
            this.sexo = sexo;
            this.id = id;
            this.idPresupuesto = idPresupuesto;
        }
        #endregion

        /// <summary>
        /// Método privado que servirá para indicar la información completa del cliente y del presupuesto.<br></br>
        /// Además indicará si el cliente es o no un comprador.
        /// </summary>
        private string Informacion()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine($"Nombre completo: {this.apellido}, {this.nombre}");
            sB.AppendLine($"CUIL/CUIT: {this.CUIL}");
            sB.AppendLine($"Edad: {this.edad} años");
            switch (this.Sexo)
            {
                case 'm':
                    sB.AppendLine("Sexo: Masculino");
                    break;
                case 'f':
                    sB.AppendLine("Sexo: Femenino");
                    break;
                case 'x':
                    sB.AppendLine("Sexo: No binario");
                    break;
                default:
                    sB.AppendLine("Sexo: Sin definir");
                    break;
            }
            if (this.presupuestoPedido is not null)
            {
                sB.AppendLine(this.presupuestoPedido.ResumenPresupuesto);
                if (RealizarCompra())
                {
                    sB.AppendLine($"El cliente ha comprado {this.presupuestoPedido.ListaDeComponentes.Count()} componente(s)");
                }
                else
                {
                    sB.AppendLine("El cliente no ha realizado una compra.");
                }
            }
            return sB.ToString();
        }
        /// <summary>
        /// Método privado que verificará si el cliente es comprador según el presupuesto solicitado
        /// </summary>
        private bool RealizarCompra()
        {
            bool compraRealizada = false;
            if (!(this.presupuestoPedido is null) && this.presupuestoPedido.ListaDeComponentes.Count() >= 1)
            {
                compraRealizada = true;
            }
            return compraRealizada;
        }
        /// <summary>
        /// Método que recibe un DNI y lo convierte en un CUIL aleatorio
        /// </summary>
        /// <param name="documento">Documento del cliente</param>
        /// <returns>Un CUIL/CUIT armado</returns>
        public static string CuilVerificado(string documento)
        {
            Random numerosIniciales = new Random();
            Random numeroFinal = new Random();
            return $"{numerosIniciales.Next(20, 30)}-{documento}-{numeroFinal.Next(0, 9)}";
        }
        /// <summary>
        /// Muestra toda la información del Cliente
        /// </summary>
        public override string ToString()
        {
            return this.Informacion();
        }
        /// <summary>
        /// Verifica si el objeto por parámetro es igual a la instancia actual
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>True si el objeto es un Cliente y tienen mismo CUIL/CUIT, de lo contrario False</returns>
        public override bool Equals(object obj)
        {
            return obj is Cliente ? (Cliente)obj == this : false;
        }
        #endregion

        #region Sobrecarga
        /// <summary>
        /// Compara dos instancias del tipo Cliente
        /// </summary>
        /// <param name="c1">Primer cliente a comparar</param>
        /// <param name="c2">Segundo cliente a comparar</param>
        /// <returns>True si ambos poseen el mismo CUIL/CUIT, de lo contrario False</returns>
        public static bool operator ==(Cliente c1, Cliente c2)
        {
            return c1.CUIL_CUIT == c2.CUIL_CUIT;
        }
        /// <summary>
        /// Compara dos instancias del tipo Cliente
        /// </summary>
        /// <param name="c1">Primer cliente a comparar</param>
        /// <param name="c2">Segundo cliente a comparar</param>
        /// <returns>True si poseen distinto CUIL/CUIT, de lo contrario False</returns>
        public static bool operator !=(Cliente c1, Cliente c2)
        {
            return !(c1 == c2);
        }
        /// <summary>
        /// Comparar una lista de clientes con una instancia
        /// </summary>
        /// <param name="lista">Lista a comparar</param>
        /// <param name="c">Cliente a comparar</param>
        /// <returns>True si el cliente existe en la lista, de lo contrario False</returns>
        public static bool operator ==(List<Cliente> lista, Cliente c)
        {
            return lista.Contains(c);
        }
        /// <summary>
        /// Comparar una lista de clientes con una instancia
        /// </summary>
        /// <param name="lista">Lista a comparar</param>
        /// <param name="c">Cliente a comparar</param>
        /// <returns>True si el cliente no está en la lista, de lo contrario False</returns>
        public static bool operator !=(List<Cliente> lista, Cliente c)
        {
            return !(lista == c);
        }
        /// <summary>
        /// Agrega un cliente a una lista de clientes
        /// </summary>
        /// <param name="lista">Lista de clientes</param>
        /// <param name="c">Cliente a agregar</param>
        /// <returns>Devuelve la lista con el cliente agregado si este no existe previamente en la lista, de lo contrario
        /// devuelve la lista sin modificaciones</returns>
        public static List<Cliente> operator +(List<Cliente> lista, Cliente c)
        {
            if (lista != c)
            {
                lista.Add(c);
            }
            return lista;
        }
        #endregion
    }
}
