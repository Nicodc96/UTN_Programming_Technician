using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Vehiculo
    {
        #region Atributos
        private DateTime horaEgreso;
        private DateTime horaIngreso;
        private string patente;
        #endregion

        #region Propiedades
        public abstract double CostoEstadia { get; }
        public abstract string Descripcion { get; }
        public DateTime HoraEgreso
        {
            get
            {
                return this.horaEgreso;
            }
            set
            {
                if (value >= this.horaIngreso)
                {
                    this.horaEgreso = value;
                }
            }
        }

        public DateTime HoraIngreso
        {
            get
            {
                return this.horaIngreso;
            }
        }

        public string Patente
        {
            get
            {
                return this.patente;
            }
            set
            {
                if (ValidarPatente(value) == true)
                {
                    this.patente = value;
                } else
                {
                    this.patente = "Patente Incorrecta";
                }
            }
        }
        #endregion

        #region Constructores
        public Vehiculo(string patente, DateTime horaIngreso)
        {
            this.Patente = patente;
            this.horaIngreso = horaIngreso;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Horas de estadia en estacionamiento
        /// </summary>
        /// <returns></returns>
        protected virtual double CargoDeEstacionamiento()
        {
            TimeSpan tiempoEstadia = this.HoraEgreso - this.HoraIngreso;
            return (double)tiempoEstadia.Hours;
        }
        /// <summary>
        /// Información del vehiculo: Patente y Hora de ingreso
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine($"Patente: {this.Patente}");
            sB.AppendLine($"Hora de Ingreso: {this.HoraIngreso}");
            return sB.ToString();
        }
        /// <summary>
        /// Valido si la patente tiene 6 carácteres como mínimo y 7 como máximo
        /// </summary>
        /// <param name="patente"></param>
        /// <returns></returns>
        private bool ValidarPatente(string patente)
        {
            if (patente.Length >= 6 && patente.Length <= 7)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Sobrecarga de Operadores
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return v1.Patente == v2.Patente;
        }
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        #endregion

        #region Enumerado
        public enum EVehiculos
        {
            Automovil,
            Moto
        }
        #endregion
    }
}
