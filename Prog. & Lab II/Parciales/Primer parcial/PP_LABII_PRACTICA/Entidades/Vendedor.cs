using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vendedor
    {
        #region Atributos
        private string nombre;
        private List<Publicacion> ventas;
        #endregion

        #region Constructores
        private Vendedor()
        {
            this.ventas = new List<Publicacion>();
        }
        public Vendedor(string nombre):this()
        {
            this.nombre = nombre;
        }
        #endregion

        #region Métodos
        public static string InformeDeVentas(Vendedor v)
        {
            StringBuilder sB = new StringBuilder();
            float auxAcu = 0;
            sB.AppendLine($"{v.nombre.ToUpper()}");
            sB.AppendLine("---------------------------");
            foreach (Publicacion item in v.ventas)
            {
                if (item is Comic)
                {
                    sB.AppendLine($"PUBLICACION: {((Comic)item).Informacion()}");
                }
                else
                {
                    sB.AppendLine($"PUBLICACION: {((Biografia)item).Informacion()}");
                }
                sB.AppendLine("---------------------------");
            }
            for (int i = 0; i < v.ventas.Count; i++)
            {
                auxAcu += v.ventas[i].Importe;
            }
            sB.AppendLine($"GANANCIA TOTAL: {auxAcu}");
            return sB.ToString();
        }
        #endregion

        #region Sobrecarga de Operadores
        public static bool operator +(Vendedor v, Publicacion p)
        {
            bool auxReturn = false;
            if (!(v is null) && !(p is null) && p.HayStock == true)
            {
                v.ventas.Add(p);
                auxReturn = true;
                p.Stock--;
            }
            return auxReturn;
        }
        #endregion

    }
}
