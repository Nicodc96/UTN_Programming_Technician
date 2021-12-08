using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;
using Entidades.Serializador;
using System.Text.RegularExpressions;

namespace Formularios
{
    public partial class frmAgregarCliente : Form
    {
        Cliente clienteGenerado;
        private List<Presupuesto> listaPresupuestos;
        private SerializadorXML<List<Presupuesto>> serializadorPresupuestos;
        public Cliente Cliente
        {
            get
            {
                return this.clienteGenerado;
            }
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
                for (int i = 0; i < this.dGVPresupuestos.SelectedRows.Count; i++)
                {
                    for (int j = 0; j < this.listaPresupuestos.Count; j++)
                    {
                        if ((float)this.dGVPresupuestos.SelectedRows[i].Cells[5].Value == this.listaPresupuestos[j].PrecioFinal)
                        {
                            pAux = this.listaPresupuestos[j];
                            break;
                        }
                    }
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
        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtBNombre.Text) || string.IsNullOrEmpty(this.txtBApellido.Text) || string.IsNullOrEmpty(this.txtBDNI.Text) || string.IsNullOrEmpty(this.txtBEdad.Text))
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
                        clienteGenerado = new Cliente(this.txtBNombre.Text, this.txtBApellido.Text, this.txtBDNI.Text, byte.Parse(this.txtBEdad.Text), null);
                    }
                    else
                    {
                        Presupuesto pAux = this.ObtenerPresupuestoDeDGV();
                        if (pAux is not null)
                        {
                            clienteGenerado = new Cliente(this.txtBNombre.Text, this.txtBApellido.Text, this.txtBDNI.Text, byte.Parse(this.txtBEdad.Text), pAux);
                        }
                    }
                    if (MessageBox.Show("¿Confirma agregar el siguiente cliente?\n" +
                        $"Nombre: {this.txtBNombre.Text}\n" +
                        $"Apellido: {this.txtBApellido.Text}\n" +
                        $"CUIL/CUIT: {clienteGenerado.CUIL_CUIT}\n" +
                        $"Edad: {this.txtBEdad.Text}\n" +
                        $"¿Es comprador?: {clienteGenerado.EsComprador}", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.OK;
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
