using System;

namespace Entidades
{
    /// <summary>
    /// Clase estática realizadora de las 4 operaciones básicas de una calculadora.
    /// </summary>
    public static class Calculadora
    {
        #region Métodos
        /// <summary>
        /// Realiza una operación de calculadora básica utilizando la clase Operando.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>El resultado de la operación solicitada por parámetro.</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;

            switch (ValidarOperador(operador))
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
            }
            return resultado;
        }
        /// <summary>
        /// Valida que el operador en parámetro sea uno de los cuatro operadores básicos de una calculadora.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Un char indicando el tipo de operación. 
        /// En caso de que no corresponda a uno de los cuatro operadores básicos devuelve '+'.</returns>
        private static char ValidarOperador(char operador)
        {
            if (operador != '+' && operador != '-' && operador != '*' && operador != '/')
            {
                operador = '+';
            }
            return operador;
        }
        #endregion
    }
}
