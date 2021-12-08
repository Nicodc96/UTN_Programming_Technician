using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Opera valores numéricos de base 2 (binarios) y de base 10 (decimales). Esta clase esta destinada a usarse con la clase estática Calculadora.
    /// </summary>
    public class Operando
    {
        #region Atributos
        private double numero;
        #endregion

        #region Propiedades
        private string SetNumero
        {
            set
            {
                this.numero = this.ValidarOperando(value);
            }
        }
        #endregion

        #region Constructores
        public Operando()
        {
            this.numero = 0;
        }
        public Operando(double numero)
        {
            this.numero = numero;
        }
        public Operando(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

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
                //  Si es negativo, lo convierto en positivo
                numAux = Math.Abs(numAux);
            }
            if (numAux >= 0)
            {
                //  Cuando llega positivo, limpio el string resultado (para evitar un concatenar)
                resultado = "";
                if (numAux == 0)
                {
                    //  Si el numero es exactamente cero, retorno tal valor
                    resultado = "0";
                }
                else
                {
                    /*
                     * Mientras sea mayor a 1, obtendre el modulo en cada iteración. Divide el numero
                     * auxiliar a la mitad (para luego volver a iterar), si me retorna 0-1 lo sumaré al array
                     * casteado, y luego concatenar el siguiente numero (para evitar que retorne el numero
                     * correcto pero invertido)
                     */
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
            /* En el caso que reciba una cadena de numeros binarios, tomará su valor
             * como número decimal y lo convertirá en el número binario correspondiente
             */
            if (double.TryParse(numero, out double numAux))
            {
                resultado = DecimalBinario(numAux);
            }
            return resultado;
        }
        #endregion

        #region Sobrecarga de Operadores
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
            if (n2.numero == 0)
            {
                return double.MinValue;
            } else
            {
                return n1.numero / n2.numero;
            }
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
