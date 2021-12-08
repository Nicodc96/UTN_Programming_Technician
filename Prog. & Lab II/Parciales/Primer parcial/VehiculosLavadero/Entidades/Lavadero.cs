using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Lavadero
    {
        #region Atributos
        private List<Vehiculo> listaVehiculos;
        private float precioAuto;
        private float precioCamion;
        private float precioMoto;
        #endregion

        #region Propiedades
        /// <summary>
        /// Muestra la información completa del lavadero y su lista de vehiculos activos
        /// </summary>
        public string LavaderoInfo
        {
            get
            {
                StringBuilder sB = new StringBuilder();
                sB.AppendLine($"Precio de los autos: {this.precioAuto}");
                sB.AppendLine($"Precio de los camiones: {this.precioCamion}");
                sB.AppendLine($"Precio de las motos: {this.precioMoto}");
                sB.AppendLine("-Lista de vehiculos activos-");
                if (this.listaVehiculos.Count > 0)
                {
                    foreach (Vehiculo v in this.listaVehiculos)
                    {
                        sB.AppendLine(v.ToString());
                    }
                } else
                {
                    sB.AppendLine("No hay vehiculos activos actualmente!");
                }
                return sB.ToString();
            }
        }
        /// <summary>
        /// Devuelve la lista de vehiculos del lavadero
        /// </summary>
        public List<Vehiculo> Vehiculos
        {
            get { return this.listaVehiculos; }
        }
        #endregion

        #region Constructor
        private Lavadero()
        {
            this.listaVehiculos = new List<Vehiculo>();
        }
        public Lavadero(float precioAuto, float precioCamion, float precioMoto) : this()
        {
            this.precioAuto = precioAuto;
            this.precioCamion = precioCamion;
            this.precioMoto = precioMoto;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Muestra la suma total de los vehiculos ingresados al lavadero
        /// </summary>
        /// <returns></returns>
        public double MostrarTotalFacturado()
        {
            return MostrarTotalFacturado(EVehiculos.Todos);
        }
        /// <summary>
        /// Muestra el total recaudado del tipo de vehiculo indicado por parámetro
        /// </summary>
        /// <param name="vehiculos">Tipo de vehiculo</param>
        /// <returns></returns>
        public double MostrarTotalFacturado(EVehiculos vehiculos)
        {
            double total = 0;
            foreach (Vehiculo v in Vehiculos)
            {
                switch (vehiculos)
                {
                    case EVehiculos.Auto:
                        if (v is Auto)
                        {
                            total += this.precioAuto;
                        }
                        break;
                    case EVehiculos.Camion:
                        if (v is Camion)
                        {
                            total += this.precioCamion;
                        }
                        break;
                    case EVehiculos.Moto:
                        if (v is Moto)
                        {
                            total += this.precioMoto;
                        }
                        break;
                    case EVehiculos.Todos:
                        if (v is Auto)
                        {
                            total += this.precioAuto;
                        }
                        if (v is Camion)
                        {
                            total += this.precioCamion;
                        }
                        if (v is Moto)
                        {
                            total += this.precioMoto;
                        }
                        break;
                }
            }
            return total;
        }
        /// <summary>
        /// Método de ordenamiento de una lista de vehiculos según sus patentes
        /// </summary>
        /// <param name="v1">Objeto del tipo vehiculo a comparar</param>
        /// <param name="v2">Objeto del tipo vehiculo a comparar</param>
        /// <returns>0 si ambas patentes son iguales, 1 si la primera patente es mayor, -1 si la segunda es mayor</returns>
        public static int OrdenarVehiculosPorPatente(Vehiculo v1, Vehiculo v2)
        {
            return String.Compare(v1.Patente, v2.Patente);
        }
        /// <summary>
        /// Método de ordenamiento de una lista de vehiculos según sus marcas
        /// </summary>
        /// <param name="v1">Objeto del tipo vehiculo a comparar</param>
        /// <param name="v2">Objeto del tipo vehiculo a comparar</param>
        /// <returns>0 si ambas marcas son iguales, 1 si la primera marca es mayor, -1 si la segunda es mayor</returns>
        public static int OrdenarVehiculosPorMarca(Vehiculo v1, Vehiculo v2)
        {
            return String.Compare(v1.Marca.ToString(), v2.Marca.ToString());
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Comprueba si el vehiculo está dentro de la lista
        /// </summary>
        /// <param name="l">Mi lista de vehiculos</param>
        /// <param name="v">Objeto a comparar</param>
        /// <returns>True si se encuentra, en caso contrario devuelve false</returns>
        public static bool operator ==(Lavadero l, Vehiculo v)
        {
            return l.listaVehiculos.Contains(v);
        }
        public static bool operator !=(Lavadero l, Vehiculo v)
        {
            return !(l == v);
        }
        /// <summary>
        /// Ingresa un vehiculo a la lista si este no se encuentra actualmente
        /// </summary>
        /// <param name="l">Mi lista de vehiculos</param>
        /// <param name="v">Objeto a agregar</param>
        public static Lavadero operator +(Lavadero l, Vehiculo v)
        {
            if (l != v) l.listaVehiculos.Add(v);
            return l;
        }
        /// <summary>
        /// Remueve un vehiculo de la lista (si se encuentra en la lista)
        /// </summary>
        /// <param name="l">Mi lista de vehiculos</param>
        /// <param name="v">Objeto a quitar</param>
        public static Lavadero operator -(Lavadero l, Vehiculo v)
        {
            if (l == v) l.listaVehiculos.Remove(v);
            return l;
        }
        /// <summary>
        /// Verifica si el objeto es del tipo Vehiculo y si está contenido en la lista
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>True si cumple las condiciones, en otro caso false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Vehiculo ? this == (Vehiculo)obj : false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
