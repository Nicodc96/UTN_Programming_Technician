using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace LavaderoForm
{
    public partial class frmIngresoVehiculo : Form
    {
        #region Atributos Auxiliares
        private Vehiculo vehiculoAux;
        #endregion
        public frmIngresoVehiculo()
        {
            InitializeComponent();
        }

        #region Propiedades Auxiliares
        public Vehiculo GetVehiculo
        {
            get { return this.vehiculoAux; }
        }
        #endregion

        private void frmIngresoVehiculo_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.cmbCantAsientos.Enabled = false;
            this.txtBTara.Enabled = false;
            this.cmbCilindrada.Enabled = false;
            this.rBAuto.Checked = true;
            this.txtBPatente.MaxLength = 6;
            this.txtBCantRuedas.MaxLength = 2;
            foreach (EMarcas item in Enum.GetValues(typeof(EMarcas)))
            {
                this.cmbMarcas.Items.Add(item);
            }
            this.cmbCilindrada.Items.Add("125");
            this.cmbCilindrada.Items.Add("250");
            this.cmbCilindrada.Items.Add("500");
            this.cmbCilindrada.Items.Add("650");
            this.cmbCilindrada.Items.Add("900");
            this.cmbCilindrada.Items.Add("1000");
            this.cmbCilindrada.Items.Add("1200");
            this.cmbCantAsientos.Items.Add("2");
            this.cmbCantAsientos.Items.Add("4");
        }

        #region Métodos Auxiliares
        private void txtOnlyNumerics_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }
        private void txtOnlyTextNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void txtBCantRuedas_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.txtBCantRuedas.Text, "  ^ [0-9]"))
            {
                this.txtBCantRuedas.Text = "";
            }
        }
        private void txtBTara_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.txtBTara.Text, "  ^ [0-9]"))
            {
                this.txtBTara.Text = "";
            }
        }
        private void txtBPatente_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.txtBPatente.Text, "  ^ [0-9]") && Regex.IsMatch(this.txtBPatente.Text, " ^ [a-zA-Z]"))
            {
                this.txtBPatente.Text = "";
            }
        }
        #endregion

        private void rBAuto_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbCantAsientos.Enabled = true;
            this.txtBTara.Enabled = false;
            this.cmbCilindrada.Enabled = false;
        }

        private void rBCamion_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbCantAsientos.Enabled = false;
            this.txtBTara.Enabled = true;
            this.cmbCilindrada.Enabled = false;
            this.txtBTara.MaxLength = 7;
        }

        private void rBMoto_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbCantAsientos.Enabled = false;
            this.txtBTara.Enabled = false;
            this.cmbCilindrada.Enabled = true;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (this.txtBPatente.Text == "" || this.txtBCantRuedas.Text == "")
            {
                MessageBox.Show("Debe ingresar todos los datos solicitados antes de continuar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                if (this.rBAuto.Checked is true && this.cmbCantAsientos.SelectedItem is null)
                {
                    MessageBox.Show("Debe ingresar todos los datos solicitados antes de continuar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (this.rBCamion.Checked is true && this.txtBTara.Text == "")
                {
                    MessageBox.Show("Debe ingresar todos los datos solicitados antes de continuar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (this.rBMoto.Checked is true && this.cmbCilindrada.SelectedItem is null)
                {
                    MessageBox.Show("Debe ingresar todos los datos solicitados antes de continuar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DialogResult result;
                if (this.rBAuto.Checked is true && this.txtBPatente.Text != "" && this.txtBCantRuedas.Text != "" && !(this.cmbCantAsientos.SelectedItem is null))
                {
                    result = MessageBox.Show($"¿Confirma los siguientes datos?\n\nVehiculo: Auto\nPatente: {this.txtBPatente.Text}\nCant. de Ruedas: {this.txtBCantRuedas.Text}\nCant. de Asientos: {this.cmbCantAsientos.SelectedItem}", "Ingresar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        this.vehiculoAux = new Auto(int.Parse(this.cmbCantAsientos.SelectedItem.ToString()), this.txtBPatente.Text, byte.Parse(this.txtBCantRuedas.Text), (EMarcas)this.cmbMarcas.SelectedItem);
                        this.Close();
                    }
                }else if (this.rBCamion.Checked is true && this.txtBPatente.Text != "" && this.txtBCantRuedas.Text != "" && this.txtBTara.Text != "")
                {
                    result = MessageBox.Show($"¿Confirma los siguientes datos?\n\nVehiculo: Camión\nPatente: {this.txtBPatente.Text}\nCant. de Ruedas: {this.txtBCantRuedas.Text}\nTara: {this.txtBTara.Text} Kg", "Ingresar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        this.vehiculoAux = new Camion(float.Parse(this.txtBTara.Text), this.txtBPatente.Text, byte.Parse(this.txtBCantRuedas.Text), (EMarcas)this.cmbMarcas.SelectedItem);
                        this.Close();
                    }
                }else if (this.rBMoto.Checked is true && this.txtBPatente.Text != "" && this.txtBCantRuedas.Text != "" && !(this.cmbCilindrada.SelectedItem is null))
                {
                    result = MessageBox.Show($"¿Confirma los siguientes datos?\n\nVehiculo: Moto\nPatente: {this.txtBPatente.Text}\nCant. de Ruedas: {this.txtBCantRuedas.Text}\nCilindrada: {this.cmbCilindrada.SelectedItem} cc", "Ingresar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        this.vehiculoAux = new Moto(float.Parse(this.cmbCilindrada.SelectedItem.ToString()), this.txtBPatente.Text, byte.Parse(this.txtBCantRuedas.Text), (EMarcas)this.cmbMarcas.SelectedItem);
                        this.Close();
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
