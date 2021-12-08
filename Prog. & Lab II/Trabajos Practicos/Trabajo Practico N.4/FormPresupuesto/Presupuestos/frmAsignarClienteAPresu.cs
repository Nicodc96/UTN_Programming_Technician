using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Entidades;
using Entidades.Serializador;

namespace Formularios
{
    public partial class frmAsignarClienteAPresu : Form
    {
        private List<Cliente> listaClientes;
        private SerializadorXML<List<Cliente>> serializadorClientes;
        private Presupuesto presupuestoAsignarCliente;
        private Cliente clienteModificado;

        public Cliente ClienteConIDPresupuestoModificado
        {
            get => this.clienteModificado;
        }
        public Presupuesto Presupuesto
        {
            set => this.presupuestoAsignarCliente = value;
        }

        public frmAsignarClienteAPresu()
        {
            InitializeComponent();
            this.listaClientes = new List<Cliente>();
            this.serializadorClientes = new SerializadorXML<List<Cliente>>();
        }

        private void frmAsignarClienteAPresu_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.CargarDatosEnDGV();
        }

        #region Métodos para DGV
        private void CargarDatosEnDGV()
        {
            if (!File.Exists(serializadorClientes.RutaBase + @"\Datos\ResumenClientes.xml"))
            {
                try
                {
                    this.listaClientes = serializadorClientes.RecuperarDatos(Path.Combine(Environment.CurrentDirectory, @"Datos\ListaClientes.xml"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se ha podido recuperar los archivos.\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    this.listaClientes = serializadorClientes.RecuperarDatos(Path.Combine(serializadorClientes.RutaBase, @"Datos\ResumenClientes.xml"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se ha podido recuperar los datos.\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.dGVClientes.DataSource = this.listaClientes;
        }
        private Cliente BuscarClienteEnDGV()
        {
            Cliente auxCliente = null;
            if (this.dGVClientes.SelectedRows.Count == 1)
            {
                try
                {
                    for (int i = 0; i < this.listaClientes.Count; i++)
                    {

                        if (listaClientes[i].CUIL_CUIT == this.dGVClientes.CurrentRow.Cells[7].Value.ToString())
                        {
                            auxCliente = listaClientes[i];
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ha ocurrido un error al buscar al cliente.\n\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return auxCliente;
        }
        #endregion

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (this.presupuestoAsignarCliente is not null)
            {
                if (this.dGVClientes.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Sólo se puede seleccionar un cliente a la vez!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else
                {
                    clienteModificado = this.BuscarClienteEnDGV();
                    if (MessageBox.Show("¿Confirmar asignar este cliente al presupuesto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (clienteModificado is not null)
                        {
                            this.presupuestoAsignarCliente.ID_Cliente = clienteModificado.ID;
                            this.clienteModificado.ID_Presupuesto = this.presupuestoAsignarCliente.ID_Presupuesto;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        } else
                        {
                            MessageBox.Show("Error, el cliente a asignar está vacío o no existe!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            } else
            {
                MessageBox.Show("Error, el presupuesto a editar está vacío o no existe!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
