using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        #region Metodos del Formulario
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            bool checkTxtNum1 = double.TryParse(this.txtNumero1.Text, out double txtNum1Aux);
            bool checkTxtNum2 = double.TryParse(this.txtNumero2.Text, out double txtNum2Aux);
            
            if (!(this.cmbOperador.Text == "")) // Si el operador no está vacío procede a operar
            {
                /*
                 * Verifico en el caso de división si el divisor es = 0 devolverá double.MinValue y en tal caso
                 * indico en el lblResultado un mensaje más apropiado.
                 */
                double checkOperar = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);
                if (checkOperar == double.MinValue)
                {
                    this.lblResultado.Text = "Error: divisor = 0";
                } else
                {
                    this.lblResultado.Text = checkOperar.ToString();
                }
                /*
                 * Valido si en alguno de los TextBox hay algo que no sea un número, en tal caso mostrará 
                 * en el ComboBox un '0' como operación. Esto es únicamente para mostrar en el ComboBox
                 * los resultados que el código trabaja internamente.
                 */
                if (!checkTxtNum1 || !checkTxtNum2)
                {
                    if (!checkTxtNum1 && checkTxtNum2)
                    {
                        this.lstOperaciones.Items.Add($"{txtNum1Aux} {this.cmbOperador.Text[0]} {this.txtNumero2.Text} = {this.lblResultado.Text}");
                    } else if (checkTxtNum1 && !checkTxtNum2)
                    {
                        this.lstOperaciones.Items.Add($"{this.txtNumero1.Text} {this.cmbOperador.Text[0]} {txtNum2Aux} = {this.lblResultado.Text}");
                    }
                    else
                    {
                        this.lstOperaciones.Items.Add($"{txtNum1Aux} {this.cmbOperador.Text[0]} {txtNum2Aux} = {this.lblResultado.Text}");
                    }
                } else
                {
                    this.lstOperaciones.Items.Add($"{this.txtNumero1.Text} {this.cmbOperador.Text[0]} {this.txtNumero2.Text} = {this.lblResultado.Text}");
                }
            }
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando n1 = new Operando();
            string lstItemAux = this.lblResultado.Text;
            this.lblResultado.Text = n1.DecimalBinario(this.lblResultado.Text);
            if (this.lblResultado.Text != "Valor inválido")
            {
                this.lstOperaciones.Items.Add($"{lstItemAux} a binario -> {this.lblResultado.Text}");
            }            
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando n1 = new Operando();
            string lstItemAux = this.lblResultado.Text;
            this.lblResultado.Text = n1.BinarioDecimal(this.lblResultado.Text);
            if (this.lblResultado.Text != "Valor inválido")
            {
                this.lstOperaciones.Items.Add($"{lstItemAux} a decimal -> {this.lblResultado.Text}");
            }
        }
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Limpiar();
        }
        #endregion

        #region Metodos Auxiliares
        /// <summary>
        /// Recibe dos numeros y un operador y retorna la operación solicitada
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>El retorno llama a la clase Calculadora.Operar()</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando n1 = new Operando(numero1);
            Operando n2 = new Operando(numero2);
            return Calculadora.Operar(n1, n2, operador[0]);
        }
        /// <summary>
        /// Limpia los datos de los textBox, ComboBox, Label resultado y los elementos del ListBox.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "Resultado";
            this.cmbOperador.SelectedIndex = 0;
        }
        #endregion
    }
}
