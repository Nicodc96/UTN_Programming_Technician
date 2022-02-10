using System;
using System.Linq;

namespace Entidades
{
    /// <summary>
    /// Opera valores numéricos de base 2 (binarios) y de base 10 (decimales). Esta clase esta destinada a usarse con la clase estática Calculadora.
    /// </summary>
    public class Operando
    {
        private double numero;

        private string Numero
        {
            set => this.numero = this.ValidarOperando(value);
        }

        public Operando():this(0)
        {
        }
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }
        public Operando(double numero):this(numero.ToString())
        {
        }

        #region Metodos
        /// <summary>
        /// Valida que un numero recibido por string contenga números.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Retorna el valor double validado, en caso contrario retorna 0.</returns>
        private double ValidarOperando(string strNumero)
        {
            double.TryParse(strNumero, out double numVal);
            return numVal;
        }
        private bool EsBinario(string binario)
        {
            bool check = true;
            foreach (char item in binario)
            {
                if (!(item == '1' || item == '0'))
                {
                    check = false;
                    break;
                }
            }
            return check;
        }
        /// <summary>
        /// Convierte un String de numeros binarios en su valor decimal.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>String numérico. Si la conversion no fue posible retorna 'Valor inválido'.</returns>
        public string BinarioDecimal(string binario)
        {
            string resultado = "Valor inválido";
            if (EsBinario(binario) == true)
            {
                char[] cadenaAux = binario.ToArray();
                Array.Reverse(cadenaAux);
                int acumulador = 0;

                for (int i = 0; i < cadenaAux.Length; i++)
                {
                    if (cadenaAux[i] == '1')
                    {
                        acumulador += (int)Math.Pow(2, i);
                    }
                }
                resultado = acumulador.ToString();
            }
            return resultado;
        }
        /// <summary>
        /// Convierte un Double en un String de numeros binarios.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Un string de números binarios. Si no fue posible la conversion, retorna 'Valor inválido'.</returns>
        public string DecimalBinario(double numero)
        {
            string resultado = "Valor inválido";
            int numAux = (int)numero;
            int numBin;

            if (numAux < 0 && numAux > int.MinValue)
            {
                numAux = Math.Abs(numAux);
            }
            if (numAux >= 0)
            {
                resultado = "";
                if (numAux == 0)
                {
                    resultado = "0";
                }
                else
                {
                    while (numAux >= 1)
                    {
                        numBin = numAux % 2;
                        numAux /= 2;
                        resultado = (numBin.ToString() + resultado);
                    }
                }
            }
            return resultado;
        }
        /// <summary>
        /// Convierte un String de numeros a un String de numeros binarios
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Un string de números binarios. Si no fue posible la conversión, retorna 'Valor inválido'.</returns>
        public string DecimalBinario(string numero)
        {
            string resultado = "Valor inválido";
            if (double.TryParse(numero, out double numAux))
            {
                resultado = DecimalBinario(numAux);
            }
            return resultado;
        }
        #endregion

        #region Sobrecarga
        /// <summary>
        /// Resta los valores de dos objetos Operando.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>El resultado en Double.</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Suma los valores de dos objetos Operando.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>El resultado en Double.</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Divide los valores de dos objetos Operando.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>El resultado en Double si el divisor es distinto de 0. Caso contrario devuelve double.MinValue.</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            double rta;
            if (n2.numero == 0)
            {
                rta = double.MinValue;
            } else
            {
                rta = n1.numero / n2.numero;
            }
            return rta;
        }
        /// <summary>
        /// Multiplica los valores de dos objetos Operando.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>El resultado en Double.</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        #endregion
    }
}
