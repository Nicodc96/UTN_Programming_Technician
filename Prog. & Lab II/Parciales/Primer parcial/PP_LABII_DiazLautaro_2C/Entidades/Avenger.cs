using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Avenger : Personaje
    {
        #region Atributos
        private EEquipamiento equipamiento;
        #endregion

        #region Propiedades
        protected override string Nombre
        {
            get
            {
                return $"Mi nombre es {base.nombre} y si no puedo proteger la tierra, la vengaré!";
            }
        }
        #endregion

        #region Constructores
        public Avenger(string nombre, List<EHabilidades> hab, EEquipamiento equipo):base(nombre, hab)
        {
            this.equipamiento = equipo;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Muestra la información completa de un Vengador
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine(base.ToString());
            sB.AppendLine("-- Equipamiento --");
            sB.AppendLine(this.equipamiento.ToString());
            return sB.ToString();
        }
        #endregion
    }
}
