using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormCalculadora());

            //Operando uno = new Operando(15);
            //Operando dos = new Operando("a");

            //Operando resultado = new Operando();
            //Calculadora calc = new Calculadora();
            //double mensaje = calc.Operar(uno, dos, '-');
            //MessageBox.Show(mensaje.ToString());
            
        }
    }
}
