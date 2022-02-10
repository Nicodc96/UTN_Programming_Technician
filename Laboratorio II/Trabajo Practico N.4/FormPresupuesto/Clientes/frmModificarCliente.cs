using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Entidades;
using Entidades.BaseDeDatos;

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
            this.clienteAModificar = new Cliente();
        }

        private void frmModificarCliente_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.txtBNombre.MaxLength = 40;
            this.txtBApellido.MaxLength = 40;
            this.txtBDNI.MaxLength = 8;
            this.txtBEdad.MaxLength = 3;
            this.txtBSexo.MaxLength = 1;
            if (pAux is not null)
            {
                pAux = this.clienteAModificar.PresupuestoCliente;
            }
            this.CargarDatosDeClienteAModificar();
        }

        private void CargarDatosDeClienteAModificar()
        {
            this.txtBNombre.Text = this.clienteAModificar.Nombre;
            this.txtBApellido.Text = this.clienteAModificar.Apellido;
            this.txtBDNI.Text = this.clienteAModificar.CUIL_CUIT;
            this.txtBEdad.Text = this.clienteAModificar.Edad.ToString();
            this.txtBSexo.Text = this.clienteAModificar.Sexo.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (pAux == this.clienteAModificar.PresupuestoCliente && (string.IsNullOrWhiteSpace(this.txtBNombre.Text) || string.IsNullOrWhiteSpace(this.txtBApellido.Text) || string.IsNullOrWhiteSpace(this.txtBDNI.Text) || string.IsNullOrWhiteSpace(this.txtBEdad.Text) || this.chBQuitarPresupuesto.Checked == false || string.IsNullOrWhiteSpace(this.txtBSexo.Text)))
            {
                MessageBox.Show("Debe realizar al menos una modificación para realizar esta acción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtBDNI.Text.Length == 8 && (!string.IsNullOrWhiteSpace(this.txtBNombre.Text) || !string.IsNullOrWhiteSpace(this.txtBApellido.Text) || !string.IsNullOrWhiteSpace(this.txtBDNI.Text) || !string.IsNullOrWhiteSpace(this.txtBEdad.Text) || pAux != this.clienteAModificar.PresupuestoCliente))
                {
                    string auxNombre = this.clienteAModificar.Nombre;
                    string auxApellido = this.clienteAModificar.Apellido;
                    string auxCUIT = this.clienteAModificar.CUIL_CUIT;
                    byte auxEdad = this.clienteAModificar.Edad;
                    char auxSexo = this.clienteAModificar.Sexo;
                    if (this.chBQuitarPresupuesto.Checked == true)
                    {
                        this.clienteAModificar.PresupuestoCliente = null;
                        this.clienteAModificar.ID_Presupuesto = -1;
                    }
                    if (!string.IsNullOrWhiteSpace(this.txtBNombre.Text))
                    {
                        auxNombre = this.txtBNombre.Text;
                    }
                    if (!string.IsNullOrWhiteSpace(this.txtBApellido.Text))
                    {
                        auxApellido = this.txtBApellido.Text;
                    }
                    if (!string.IsNullOrWhiteSpace(this.txtBDNI.Text))
                    {
                        auxCUIT = Cliente.CuilVerificado(this.txtBDNI.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(this.txtBEdad.Text))
                    {
                        auxEdad = byte.Parse(this.txtBEdad.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(this.txtBSexo.Text))
                    {
                        auxSexo = char.Parse(this.txtBSexo.Text);
                    }
                    if (MessageBox.Show("¿Confirma modificar los datos del cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.clienteAModificar.Nombre = auxNombre;
                        this.clienteAModificar.Apellido = auxApellido;
                        this.clienteAModificar.CUIL_CUIT = auxCUIT;
                        this.clienteAModificar.Edad = auxEdad;
                        this.clienteAModificar.Sexo = auxSexo;
                        this.DialogResult = DialogResult.OK;
                        try
                        {
                            DAO.ActualizarCliente(clienteAModificar);
                        } catch(System.Data.SqlClient.SqlException)
                        {
                            MessageBox.Show("No se pudo aplicar los cambios a la base de datos!\n\nRazón: No existe la base de datos DC_DB.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        } finally
                        {
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El campo DNI debe ser un valor numérico de 8 dígitos.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        #region Métodos Auxiliares para Eventos
        private void txtOnlyNumerics_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }
        private void txtOnlyText_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"[^a-zA-Z\s]");
            if (regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void txtOnlyOneDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 'm' && e.KeyChar != 'f' && e.KeyChar != 'x' && e.KeyChar != (char)Keys.Back)
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
        private void txtBSexo_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.txtBSexo.Text, " ^ [a-zA-Z]"))
            {
                this.txtBSexo.Text = "";
            }
        }
        #endregion
    }
}
