using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Automovil: Vehiculo
    {
        #region Atributos
        private string marca;
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
                return this.marca;
            }
        }
        /// <summary>
        /// Valor de la hora (positivo)
        /// </summary>
        public static double ValorHora
        {
            set
            {
                if (value > 0)
                {
                    Automovil.valorHora = value;
                }                
            }
        }
        #endregion

        #region Constructores
        static Automovil()
        {
            Automovil.valorHora = 120;
        }

        public Automovil(string patente, DateTime horaIngreso, string marca): base(patente, horaIngreso)
        {
            this.marca = marca;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Se obtiene el valor por hora de estadía
        /// </summary>
        /// <returns></returns>
        protected override double CargoDeEstacionamiento()
        {
            //TimeSpan tiempoEstadia = base.HoraEgreso - base.HoraIngreso;
            return (double)(base.CargoDeEstacionamiento() * Automovil.valorHora);
        }
        protected override string MostrarDatos()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine("****AUTOMOVIL*****");
            sB.AppendLine($"Descripcion: {this.Descripcion}");
            return sB.ToString();
        }
        /// <summary>
        /// Muestra la descripción del objeto Moto
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }
        #endregion
    }
}
