using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estacionamiento
    {
        #region Atributos
        private int capacidadEstacionamiento;
        private static Estacionamiento estacionamiento;
        private List<Vehiculo> listadoVehiculos;
        private string nombre;
        #endregion

        #region Propiedades
        public List<Vehiculo> ListadoVehiculos
        {
            get
            {
                return this.listadoVehiculos;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }
        #endregion

        #region Constructores
        private Estacionamiento(string nombre, int capacidad)
        {
            listadoVehiculos = new List<Vehiculo>();
            this.nombre = nombre;
            this.capacidadEstacionamiento = capacidad;
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Instancia de Estacionamiento
        /// Permite modificar la capacidad del Estacionamiento
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="capacidad"></param>
        /// <returns></returns>
        public static Estacionamiento GetEstacionamiento(string nombre, int capacidad)
        {
            if (Estacionamiento.estacionamiento is null)
            {
                Estacionamiento.estacionamiento = new Estacionamiento(nombre, capacidad);
            } else
            {
                Estacionamiento.estacionamiento.capacidadEstacionamiento = capacidad;
            }
            return Estacionamiento.estacionamiento;
        }
        /// <summary>
        /// Informa la salida del vehiculo del estacionamiento y sus datos
        /// </summary>
        /// <param name="vehiculo"></param>
        /// <returns></returns>
        public string InformarSalida(Vehiculo vehiculo)
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine($"Nombre del Estacionamiento: {this.Nombre}");
            if (vehiculo is Automovil)
            {
                sB.AppendLine($"Datos del Vehiculo:\n{vehiculo.ToString()}");
            } else
            {
                sB.AppendLine($"Datos del Vehiculo:\n{vehiculo.ToString()}");
            }
            sB.AppendLine($"Hora de Salida: {vehiculo.HoraEgreso.Hour}");
            sB.AppendLine($"Cargo del Estacionamiento: {vehiculo.CostoEstadia}");
            return sB.ToString();
        }
        #endregion

        #region Sobrecarga de Operadores
        public static bool operator ==(Estacionamiento estacionamiento, Vehiculo vehiculo)
        {
            if (!(vehiculo is null))
            {
                return estacionamiento.listadoVehiculos.Contains(vehiculo);
            }
            else return false;            
        }
        public static bool operator !=(Estacionamiento estacionamiento, Vehiculo vehiculo)
        {
            return !(estacionamiento == vehiculo);
        }

        public static bool operator +(Estacionamiento estacionamiento, Vehiculo vehiculo)
        {
            if (Estacionamiento.estacionamiento.listadoVehiculos.Count < Estacionamiento.estacionamiento.capacidadEstacionamiento
                && estacionamiento != vehiculo && !(vehiculo is null))
            {
                estacionamiento.listadoVehiculos.Add(vehiculo);
                return true;
            }
            else return false;
        }

        public static bool operator -(Estacionamiento estacionamiento, Vehiculo vehiculo)
        {
            if (!(vehiculo is null) && Estacionamiento.estacionamiento == vehiculo)
            {
                vehiculo.HoraEgreso = DateTime.Now;
                Estacionamiento.estacionamiento.listadoVehiculos.Remove(vehiculo);
                return true;
            }
            else return false;
        }
        #endregion
    }
}
