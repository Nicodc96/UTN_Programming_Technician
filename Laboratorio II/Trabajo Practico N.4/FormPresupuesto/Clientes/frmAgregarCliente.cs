using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;
using Entidades.Serializador;
using System.Text.RegularExpressions;
using Entidades.BaseDeDatos;

namespace Formularios
{
    public partial class frmAgregarCliente : Form
    {
        Cliente clienteGenerado;
        private List<Presupuesto> listaPresupuestos;
        private List<Cliente> listaClientes;
        private SerializadorXML<List<Presupuesto>> serializadorPresupuestos;
        public Cliente Cliente
        {
            get => this.clienteGenerado;
        }
        public List<Cliente> ListaDeClientes
        {
            set => this.listaClientes = value;
        }
        public frmAgregarCliente()
        {
            InitializeComponent();
            this.listaPresupuestos = new List<Presupuesto>();
            this.serializadorPresupuestos = new SerializadorXML<List<Presupuesto>>();
        }
        private void frmAgregarCliente_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.txtBDNI.MaxLength = 8;
            this.txtBEdad.MaxLength = 3;
            this.txtBSexo.MaxLength = 1;
            this.CargarDatosDePresupuestos();
        }

        #region Métodos para DGV
        private void CargarDatosDePresupuestos()
        {
            if (!File.Exists(serializadorPresupuestos.RutaBase + @"Datos\ResumenPresupuestos.xml"))
            {
                try
                {
                    this.listaPresupuestos = serializadorPresupuestos.RecuperarDatos(Path.Combine(Environment.CurrentDirectory, @"Datos\ListaPresupuestos.xml"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se ha podido recuperar los archivos, archivo modificado.\n\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                try
                {
                    this.listaPresupuestos = serializadorPresupuestos.RecuperarDatos(Path.Combine(serializadorPresupuestos.RutaBase, @"Datos\ResumenPresupuestos.xml"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se ha podido recuperar los archivos.\n\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.dGVPresupuestos.DataSource = this.listaPresupuestos;
        }

        private Presupuesto ObtenerPresupuestoDeDGV()
        {
            Presupuesto pAux = null;
            if (this.dGVPresupuestos.SelectedRows.Count == 1)
            {
                try
                {
                    for (int i = 0; i < this.dGVPresupuestos.SelectedRows.Count; i++)
                    {
                        for (int j = 0; j < this.listaPresupuestos.Count; j++)
                        {
                            if ((float)this.dGVPresupuestos.SelectedRows[i].Cells[8].Value == this.listaPresupuestos[j].PrecioFinal)
                            {
                                pAux = this.listaPresupuestos[j];
                                break;
                            }
                        }
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show($"No se ha podido obtener el elemento.\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return pAux;
        }
        #endregion

        #region Métodos Auxiliares
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
        private void txtBDNI_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.txtBDNI.Text, "  ^ [0-9]"))
            {
                this.txtBDNI.Text = "";
            }
        }
        private void txtBID_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.txtBID.Text, "  ^ [0-9]"))
            {
                this.txtBID.Text = "";
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool verificadorID = true;
            if (string.IsNullOrWhiteSpace(this.txtBNombre.Text) || string.IsNullOrWhiteSpace(this.txtBApellido.Text) || string.IsNullOrWhiteSpace(this.txtBDNI.Text) || string.IsNullOrWhiteSpace(this.txtBEdad.Text) || string.IsNullOrWhiteSpace(this.txtBSexo.Text) || string.IsNullOrWhiteSpace(this.txtBID.Text))
            {
                MessageBox.Show("Se deben completar todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                if (this.dGVPresupuestos.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Solo se puede agregar un presupuesto por cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    if (this.chBNoSolicita.Checked == true)
                    {
                        clienteGenerado = new Cliente(this.txtBNombre.Text, this.txtBApellido.Text, this.txtBDNI.Text, byte.Parse(this.txtBEdad.Text), null, char.Parse(this.txtBSexo.Text), int.Parse(this.txtBID.Text), 0);
                    }
                    else
                    {
                        Presupuesto pAux = this.ObtenerPresupuestoDeDGV();
                        if (pAux is not null)
                        {
                            clienteGenerado = new Cliente(this.txtBNombre.Text, this.txtBApellido.Text, this.txtBDNI.Text, byte.Parse(this.txtBEdad.Text), pAux, char.Parse(this.txtBSexo.Text), int.Parse(this.txtBID.Text), pAux.ID_Presupuesto);
                            pAux.ID_Cliente = this.clienteGenerado.ID;
                        }
                    }
                    
                    if (this.listaClientes is not null)
                    {
                        for (int i = 0; i < this.listaClientes.Count; i++)
                        {
                            if (this.listaClientes[i].ID == this.clienteGenerado.ID)
                            {
                                verificadorID = false;
                                break;
                            }
                        }
                    }
                    if (verificadorID)
                    {
                        if (MessageBox.Show("¿Confirma agregar el siguiente cliente?\n" +
                        $"Nombre: {this.txtBNombre.Text}\n" +
                        $"Apellido: {this.txtBApellido.Text}\n" +
                        $"CUIL/CUIT: {clienteGenerado.CUIL_CUIT}\n" +
                        $"Edad: {this.txtBEdad.Text}\n" +
                        $"ID: {this.txtBID.Text}\n" +
                        $"¿Es comprador?: {clienteGenerado.EsComprador}", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.DialogResult = DialogResult.OK;
                            try
                            {
                                DAO.GuardarCliente(clienteGenerado);
                            } catch (System.Data.SqlClient.SqlException)
                            {
                                MessageBox.Show("No se pudo aplicar los cambios a la base de datos!\n\nRazón: No existe la base de datos DC_DB.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            finally
                            {
                                this.Close();
                            }
                        }
                    } else
                    {
                        MessageBox.Show("Ya existe un cliente con el ID ingresado!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
