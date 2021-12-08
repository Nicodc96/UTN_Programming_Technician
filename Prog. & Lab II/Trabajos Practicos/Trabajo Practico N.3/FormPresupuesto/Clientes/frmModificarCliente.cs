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

namespace Formularios
{
    public partial class frmModificarCliente : Form
    {
        private Cliente clienteAModificar;
        Presupuesto pAux;
        public Cliente Cliente
        {
            get
            {
                return this.clienteAModificar;
            }
            set
            {
                this.clienteAModificar = value;
            }
        }
        public frmModificarCliente()
        {
            InitializeComponent();
        }

        private void frmModificarCliente_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.txtBDNI.MaxLength = 8;
            this.txtBEdad.MaxLength = 3;
            pAux = this.clienteAModificar.PresupuestoCliente;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (pAux == this.clienteAModificar.PresupuestoCliente && (string.IsNullOrEmpty(this.txtBNombre.Text) || string.IsNullOrEmpty(this.txtBApellido.Text) || string.IsNullOrEmpty(this.txtBDNI.Text) || string.IsNullOrEmpty(this.txtBEdad.Text) || this.chBQuitarPresupuesto.Checked == false))
            {
                MessageBox.Show("Debe realizar al menos una modificación para realizar esta acción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!string.IsNullOrEmpty(this.txtBNombre.Text) || !string.IsNullOrEmpty(this.txtBApellido.Text) || !string.IsNullOrEmpty(this.txtBDNI.Text) || !string.IsNullOrEmpty(this.txtBEdad.Text) || pAux != this.clienteAModificar.PresupuestoCliente)
                {
                    string auxNombre = this.clienteAModificar.Nombre;
                    string auxApellido = this.clienteAModificar.Apellido;
                    string auxCUIT = this.clienteAModificar.CUIL_CUIT;
                    byte auxEdad = this.clienteAModificar.Edad;
                    if (this.chBQuitarPresupuesto.Checked == true)
                    {
                        this.clienteAModificar.PresupuestoCliente = null;
                    }
                    if (!string.IsNullOrEmpty(this.txtBNombre.Text))
                    {
                        auxNombre = this.txtBNombre.Text;
                    }
                    if (!string.IsNullOrEmpty(this.txtBApellido.Text))
                    {
                        auxApellido = this.txtBApellido.Text;
                    }
                    if (!string.IsNullOrEmpty(this.txtBDNI.Text))
                    {
                        auxCUIT = Cliente.CuilVerificado(this.txtBDNI.Text);
                    }
                    if (!string.IsNullOrEmpty(this.txtBEdad.Text))
                    {
                        auxEdad = byte.Parse(this.txtBEdad.Text);
                    }
                    if (MessageBox.Show("¿Confirma modificar los datos del cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.clienteAModificar.Nombre = auxNombre;
                        this.clienteAModificar.Apellido = auxApellido;
                        this.clienteAModificar.CUIL_CUIT = auxCUIT;
                        this.clienteAModificar.Edad = auxEdad;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }
        private void btnCambiarPresupuesto_Click(object sender, EventArgs e)
        {
            frmModPresuCliente formCambiarPresupuesto = new frmModPresuCliente();
            formCambiarPresupuesto.Cliente = this.clienteAModificar;
            if (formCambiarPresupuesto.ShowDialog() == DialogResult.OK)
            {
                this.clienteAModificar = formCambiarPresupuesto.Cliente;
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
        private void txtBEdad_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.txtBEdad.Text, "  ^ [0-9]"))
            {
                this.txtBEdad.Text = "";
            }
        }
        #endregion
    }
}
