using System;
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
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Limpiar();
        }

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
            
            if (this.cmbOperador.Text == "")
            {
                this.cmbOperador.Text = "+";
            }
            double checkOperar = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);
            if (checkOperar == double.MinValue)
            {
                this.lblResultado.Text = "Error";
                MessageBox.Show("No es posible dividir por 0!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                this.lblResultado.Text = checkOperar.ToString();
            }
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

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando n1 = new Operando();
            string lstItemAux = this.lblResultado.Text;
            this.lblResultado.Text = n1.DecimalBinario(this.lblResultado.Text);
            if (this.lblResultado.Text != "Valor inválido")
            {
                this.lstOperaciones.Items.Add($"{lstItemAux} a binario -> {this.lblResultado.Text}");
                this.btnConvertirABinario.Enabled = false;
                this.btnConvertirADecimal.Enabled = true;
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
                this.btnConvertirADecimal.Enabled = false;
                this.btnConvertirABinario.Enabled = true;
            }
        }
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
            return Calculadora.Operar(n1, n2, Convert.ToChar(operador));
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
            this.btnConvertirABinario.Enabled = true;
            this.btnConvertirADecimal.Enabled = true;
        }
        #endregion
    }
}
