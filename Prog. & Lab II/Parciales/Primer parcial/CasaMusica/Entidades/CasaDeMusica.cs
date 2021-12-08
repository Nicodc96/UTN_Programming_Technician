using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CasaDeMusica
    {
        #region Atributos
        private List<Instrumento> listaDeInstrumentos;
        private int cantidadMaxima;
        #endregion

        #region Constructores
        public CasaDeMusica()
        {
            this.listaDeInstrumentos = new List<Instrumento>();
            this.cantidadMaxima = 5;
        }
        public CasaDeMusica(int cantidadMaxima):this()
        {
            this.cantidadMaxima = cantidadMaxima;
        }
        #endregion

        #region Métodos
        private string Mostrar()
        {
            StringBuilder sB = new StringBuilder();
            sB.AppendLine($"Capacidad máxima: {this.cantidadMaxima}");
            foreach (Instrumento i in this.listaDeInstrumentos)
            {
                sB.AppendLine(i.ToString());
            }
            return sB.ToString();
        }        
        #endregion

        #region Sobrecarga de Operadores
        public static bool operator ==(CasaDeMusica cM, Instrumento i)
        {
            bool check = false;
            foreach (Instrumento ins in cM.listaDeInstrumentos)
            {
                if (ins == i)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        public static bool operator !=(CasaDeMusica cM, Instrumento i)
        {
            return !(cM == i);
        }
        public static CasaDeMusica operator +(CasaDeMusica cM, Instrumento i)
        {
            if (cM != i && cM.listaDeInstrumentos.Count < cM.cantidadMaxima)
            {
                cM.listaDeInstrumentos.Add(i);
            }
            return cM;
        }
        public static CasaDeMusica operator -(CasaDeMusica cM, Instrumento i)
        {
            if (cM == i)
            {
                cM.listaDeInstrumentos.RemoveAt(cM.listaDeInstrumentos.IndexOf(i));
            }
            return cM;
        }
        public override string ToString()
        {
            return this.Mostrar();
        }

        public override bool Equals(object obj)
        {
            bool check = false;
            if (obj is Instrumento)
            {
                check = this == (Instrumento)obj;
            }
            return check;
        }
        #endregion
    }
}
