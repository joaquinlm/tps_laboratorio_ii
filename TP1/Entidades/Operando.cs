using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        public double numero;
        /// <summary>
        /// sobrecarga del constructor Operando(double numero)
        /// </summary>
        public Operando() : this(0)
        {
        }
        /// <summary>
        /// constructor principal
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// sobrecarga del constructor para recibir strings
        /// </summary>
        /// <param name="strNumero"></param>
        public Operando(string strNumero)
        {
            Numero = strNumero;
        }
        /// <summary>
        /// setter de la pr
        /// </summary>
        public string Numero
        {
            set { numero = ValidarOperando(value); }
        }

        //Sobrecargas de operadores
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return Double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
        /// <summary>
        /// Valida que el string que se le pasa como parametro se pueda parsear a double, caso contrario, retorna cero.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarOperando(string strNumero)
        {

            if (double.TryParse(strNumero, out double numeroValido))
            {
                return numeroValido;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Este método verifica que el string que se le pasa como parametro solo tenga unos o ceros mediante una expresión regular.
        /// Usa el método IsMatch de la clase Regex.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private bool EsBinario(string binario)
        {
            bool retorno = false;
            // Regex ceroUno = new Regex("^[01]+$");
            if (Regex.IsMatch(binario, "^[01]+$"))
            {
                retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Metodo para convertir de binario a decimal. Utiliza el metodo ToString de la clase Convert https://docs.microsoft.com/en-us/dotnet/api/system.convert.tostring?view=net-5.0 
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            string checkNegativo = binario.Substring(0, 1);            
            if (checkNegativo=="-")//Chequeo si tiene signo y se lo quito
            {
               binario =  binario.Remove(0,1);
            }
            string auxEntero = binario.Split(",")[0].Trim(); //chequeo si tiene coma y lo corto
            string auxBinario;
            int auxNum;
            int.TryParse(auxEntero, out auxNum);
            auxBinario = Convert.ToString(auxNum, 2);
            return auxBinario;
          
        }
        /// <summary>
        /// Metodo para convertir de decimal a binario. Utiliza el metodo ToInt32 de la clase Convert https://docs.microsoft.com/en-us/dotnet/api/system.convert.toint32?view=net-5.0
        /// Usa la función EsBinario de esta misma clase para verificar que el número a convertir solo contenga unos o ceros.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            string aux= "Operación no válida";
            if (EsBinario(numero))
            {
                aux = Convert.ToInt32(numero, 2).ToString();

            }
           
            return aux;
          
        }

    }
}
