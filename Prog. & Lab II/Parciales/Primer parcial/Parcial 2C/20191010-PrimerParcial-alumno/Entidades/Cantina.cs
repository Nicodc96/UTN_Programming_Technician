using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cantina
    {
        #region Atributos
        private List<Botella> botellas;
        private int espacioTotales;
        private static Cantina singleton;
        #endregion

        #region Propiedades
        public List<Botella> Botellas
        {
            get
            {
                return this.botellas;
            }
        }
        #endregion

        #region Constructor        
        private Cantina(int espacios)
        {
            this.botellas = new List<Botella>();
            this.espacioTotales = espacios;
        }
        #endregion

        #region Métodos
        public static Cantina GetCantina(int espacios)
        {
            if (singleton is null)
            {
                singleton = new Cantina(espacios);
            }
            else
            {
                singleton.espacioTotales += espacios;                
            }
            return singleton;
        }
        #endregion

        #region Sobrecarga de operadores
        public static bool operator +(Cantina c, Botella b)
        {
            bool check = false;
            if (c.botellas.Count() < c.espacioTotales)
            {
                c.botellas.Add(b);
                check = true;
            }
            return check;
        }
        #endregion
    }
}
