using System;


namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Método para hacer operaciones entre dos números
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public double Operar(Operando num1, Operando num2, char operador)
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
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }


        /// <summary>
        /// Método para validar que los operadores sean solo de suma, resta, multiplicación y división. 
        /// Defaultea a '+'
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static char ValidarOperador(char operador)
        {
            char[] arrOperandos = new char[] { '-', '*', '/' };
            char operadorRetornado = '+';
            for (int i = 0; i < arrOperandos.Length; i++)
            {
                if (arrOperandos[i] == operador)
                {
                    operadorRetornado = arrOperandos[i];
                    break;
                }
            }
            return operadorRetornado;
        }
    }
}
