using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Personaje
    {
        #region Atributos
        private List<EHabilidades> listaHabilidades;
        protected string nombre;
        #endregion

        #region Propiedades
        private string ListaHabilidades
        {
            get
            {
                StringBuilder sB = new StringBuilder();
                sB.AppendLine("- Habilidades -");
                foreach (EHabilidades item in this.listaHabilidades)
                {
                    sB.AppendLine(item.ToString());
                }
                return sB.ToString();
            }
        }
        protected abstract string Nombre
        {
            get;
        }
        #endregion

        #region Constructores
        private Personaje()
        {
            this.listaHabilidades = new List<EHabilidades>();
        }
        public Personaje(string nombre, List<EHabilidades> habilidades) : this()
        {
            this.nombre = nombre;
            this.listaHabilidades = habilidades;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Muestra la información completa del Personaje
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine(this.Nombre);
            sB.AppendLine(ListaHabilidades);
            return sB.ToString();
        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Verifica si el objeto Personaje está contenido en la lista pasada por parámetro
        /// </summary>
        /// <param name="listaPersonajes"></param>
        /// <param name="personaje"></param>
        /// <returns></returns>
        public static bool operator ==(List<Personaje> listaPersonajes, Personaje personaje)
        {
            bool returnAux = false;
            foreach (Personaje item in listaPersonajes)
            {
                if (item.GetType() == personaje.GetType() && item.Nombre == personaje.Nombre)
                {
                    returnAux = true;
                    break;
                }
             }
            return returnAux;
        }
        /// <summary>
        /// Verifica si el objeto Personaje NO está contenido en la lista pasada por parámetro
        /// </summary>
        /// <param name="listaPersonajes"></param>
        /// <param name="personaje"></param>
        /// <returns></returns>
        public static bool operator !=(List<Personaje> listaPersonajes, Personaje personaje)
        {
            return !(listaPersonajes == personaje);
        }
        /// <summary>
        /// Agrega un objeto Personaje a la lista pasada por parámetro
        /// </summary>
        /// <param name="listaPersonajes"></param>
        /// <param name="personaje"></param>
        /// <returns></returns>
        public static List<Personaje> operator +(List<Personaje> listaPersonajes, Personaje personaje)
        {
            if (!(personaje is null) && listaPersonajes != personaje)
            {
                listaPersonajes.Add(personaje);
            }
            return listaPersonajes;
        }
        #endregion

        #region Enumeraciones
        public enum EHabilidades
        {
            Volar,
            SuperFuerza,
            Resistencia,
            Rayos,
            Energia,
            InteligenciaSuperior,
            Sigilo,
            Astucia
        }
        public enum EEquipamiento
        {
            Armadura,
            Escudo,
            Martillo,
            Arco,
            Transformacion,
            ArtesMarciales
        }
        #endregion
    }
}
