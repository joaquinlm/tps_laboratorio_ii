using System;
using Entidades;
using System.Text;
using System.Windows.Forms;


namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }       

        
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Método para limpiar los campos del form. También sirve para que el primer ítem del cmbOperador sea un " ", 
        /// de otra forma podría ser null cuando lo paso como parámetro.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Items[0] = " ";
            this.cmbOperador.SelectedIndex = 0;
            this.lblResultado.Text = "0";
        }
        /// <summary>
        /// Método para operar dos números pasados como string. Usa una instancia de Calculadora para llamar
        /// al método homónimo de la antedicha clase.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando primerOperando = new Operando(numero1);
            Operando segundoOperando = new Operando(numero2);
            Calculadora instanciaCalculadora = new Calculadora();
            double resultado = instanciaCalculadora.Operar(primerOperando, segundoOperando, Char.Parse(operador));
            return resultado;
        }

        //Botones

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            double auxCheckNumero; //Variable auxiliar para chequear que los inputs sean números válidos
            string numero1 = txtNumero1.Text;
            string numero2 = txtNumero2.Text;
            string operador = cmbOperador.SelectedItem.ToString();//tira advertencia pero no puede ser null nunca
            if (cmbOperador.SelectedIndex == 0)
            {
                operador = "+";//la operacion es suma igualmente, pero cambio el operador para que se renderice ok el resultado en el list
            }
            if (
                string.IsNullOrWhiteSpace(numero1)
                || string.IsNullOrWhiteSpace(numero2)
                || !double.TryParse(numero1, out auxCheckNumero)
                || !double.TryParse(numero2, out auxCheckNumero)
                )
            {
                string mensaje = "Debe ingresar dos números válidos";
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                double.TryParse(numero2, out auxCheckNumero);//aprovecho el auxiliar para chequear que num dos es 0
                if (cmbOperador.SelectedIndex == 4 && auxCheckNumero == 0 )
                {
                    string mensaje = "Error: no se admite la división por cero";
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {             
                        resultado = Operar(numero1, numero2, operador);//tira advertencia pero no puede ser null nunca
                        this.lblResultado.Text = resultado.ToString();
                        this.lstOperaciones.Items.Add($"{numero1}{operador}{numero2} = {resultado}");
                }
            }
        }

        

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando aux = new Operando();
            string stringBinario = aux.BinarioDecimal(this.lblResultado.Text);
            this.lblResultado.Text = stringBinario;        
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {            
            Operando aux = new Operando();
            if (
                string.IsNullOrWhiteSpace(txtNumero1.Text) ||
                lblResultado.Text == "0"||
                lblResultado.Text == ""
               )
            {
                string mensaje = "Valor inválido";
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
            this.lblResultado.Text = aux.DecimalBinario(this.lblResultado.Text);                
            }     
        }
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "¿Está seguro de querer salir?";
            string title = "Salir del programa";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
