using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Moto : Vehiculo
    {
        #region Atributos
        private ETipo tipo;
        private static double valorHora;
        #endregion

        #region Propiedades
        public override double CostoEstadia
        {
            get
            {
                return CargoDeEstacionamiento();
            }
        }
        public override string Descripcion
        {
            get
            {
                return this.tipo.ToString();
            }
        }
        public static double ValorHora
        {
            set
            {
                if (value > 0)
                {
                    Moto.valorHora = value;
                }
            }
        }
        #endregion

        #region Constructores
        static Moto()
        {
            Moto.valorHora = 100;
        }
        public Moto(string patente, DateTime horaIngreso, ETipo tipo):base(patente, horaIngreso)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Se obtiene el valor por hora de estadía
        /// </summary>
        /// <returns></returns>
        protected override double CargoDeEstacionamiento()
        {
            TimeSpan tiempoEstadia = base.HoraEgreso - base.HoraIngreso;
            return (double)(tiempoEstadia.Hours * Moto.valorHora);
        }
        protected override string MostrarDatos()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine("****MOTO*****");
            sB.AppendLine($"Descripcion: {this.Descripcion}");
            return sB.ToString();
        }
        /// <summary>
        /// Muestra la descripción del objeto Moto
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Enumerado
        public enum ETipo
        {
            Ciclomotor,
            Scooter,
            Sport
        }
        #endregion
    }
}
