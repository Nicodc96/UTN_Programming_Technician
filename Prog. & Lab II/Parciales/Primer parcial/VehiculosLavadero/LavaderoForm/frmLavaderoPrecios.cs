using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LavaderoForm
{
    public partial class frmLavaderoPrecios : Form
    {
        #region Atributos Auxiliares
        private string nombreLavadero;
        private float precioAuto;
        private float precioCamion;
        private float precioMoto;
        #endregion

        #region Propiedades Auxiliares
        public string Nombre
        {
            get { return this.nombreLavadero; }
        }
        public float PrecioAuto
        {
            get { return this.precioAuto; }
        }
        public float PrecioCamion
        {
            get { return this.precioCamion; }
        }
        public float PrecioMoto
        {
            get { return this.precioMoto ; }
        }
        #endregion
        public frmLavaderoPrecios()
        {
            InitializeComponent();
        }

        private void frmLavaderoPrecios_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLavaderoPrecios_FormClosing(object sender, FormClosingEventArgs e)
        {            
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (this.txtPrecioAuto.Text == "" || this.txtPrecioCamion.Text == "" || this.txtPrecioMoto.Text == "" || this.txtNombreLavadero.Text == "")
            {
                MessageBox.Show("Debe ingresar datos válidos antes de continuar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                DialogResult result = MessageBox.Show($"Confirmar los datos ingresados:\nNombre: {this.txtNombreLavadero.Text}\nPrecios:\nAutos: ${this.txtPrecioAuto.Text}\nCamiones: ${this.txtPrecioCamion.Text}\nMotos: ${this.txtPrecioMoto.Text}",
                "Ingreso",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    this.nombreLavadero = this.txtNombreLavadero.Text;
                    this.precioAuto = float.Parse(this.txtPrecioAuto.Text);
                    this.precioCamion = float.Parse(this.txtPrecioCamion.Text);
                    this.precioMoto = float.Parse(this.txtPrecioMoto.Text);
                    this.Close();
                }
            }            
        }
        #region Métodos Auxiliares
        private void txtOnlyNumerics_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void txtPrecioAuto_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(this.txtPrecioAuto.Text, "  ^ [0-9]"))
            {
                this.txtPrecioAuto.Text = "";
            }
        }
        private void txtPrecioCamion_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(this.txtPrecioCamion.Text, "  ^ [0-9]"))
            {
                this.txtPrecioCamion.Text = "";
            }
        }
        private void txtPrecioMoto_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(this.txtPrecioMoto.Text, "  ^ [0-9]"))
            {
                this.txtPrecioMoto.Text = "";
            }
        }
        #endregion
    }
}
