using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Entidades;
using Entidades.BaseDeDatos;
using Entidades.Serializador;

namespace Formularios
{
    public partial class frmClientes : Form
    {
        private List<Cliente> listaClientes;
        private SerializadorXML<List<Cliente>> serializadorClientes;
        public frmClientes()
        {
            InitializeComponent();
            this.listaClientes = new List<Cliente>();
            this.serializadorClientes = new SerializadorXML<List<Cliente>>();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            if (!File.Exists(serializadorClientes.RutaBase + @"\Datos\ResumenClientes.xml"))
            {
                this.RecuperarPrimeraVez();
            }
            else
            {
                this.RecuperarDatos();
            }
            this.ActualizarLista();
        }

        #region Métodos para DGV y Serializacion
        private void GuardarDatos()
        {
            try
            {
                serializadorClientes.GuardarDatos(this.listaClientes, "ResumenClientes");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se ha podido guardar la información.\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RecuperarPrimeraVez()
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
        private void RecuperarDatos()
        {
            try
            {
                this.listaClientes = serializadorClientes.RecuperarDatos(Path.Combine(serializadorClientes.RutaBase, @"Datos\ResumenClientes.xml"));
            }catch (Exception ex)
            {
                MessageBox.Show($"No se ha podido recuperar los datos.\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarLista()
        {
            this.dGVClientes.DataSource = null;
            this.dGVClientes.DataSource = this.listaClientes;
        }
        #endregion

        #region Métodos Auxiliares
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarCliente formAgregar = new frmAgregarCliente();
            formAgregar.ListaDeClientes = this.listaClientes;
            if (formAgregar.ShowDialog() == DialogResult.OK)
            {
                this.listaClientes.Add(formAgregar.Cliente);
                this.GuardarDatos();
                this.ActualizarLista();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.dGVClientes.SelectedRows.Count > 1)
            {
                MessageBox.Show("Sólo es posible modificar un cliente a la vez.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                frmModificarCliente formModificar = new frmModificarCliente();
                Cliente clienteAModificar = this.BuscarClienteEnDGV();
                formModificar.Cliente = clienteAModificar;
                if (formModificar.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < this.listaClientes.Count; i++)
                    {
                        if (listaClientes[i] == clienteAModificar)
                        {
                            listaClientes[i] = formModificar.Cliente;
                            this.GuardarDatos();
                            this.ActualizarLista();
                        }
                    }
                }
            }            
        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (this.dGVClientes.SelectedRows.Count == 1)
            {
                Cliente auxCliente = this.BuscarClienteEnDGV();
                if (auxCliente is not null && this.listaClientes == auxCliente)
                {
                    if (MessageBox.Show("¿Está seguro de eliminar este elemento?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.listaClientes.Remove(auxCliente);                            
                        this.GuardarDatos();
                        this.ActualizarLista();
                        try
                        {
                            DAO.RemoverCliente(auxCliente.ID);
                        } catch (System.Data.SqlClient.SqlException)
                        {
                            MessageBox.Show("No se pudo aplicar los cambios a la base de datos!\n\nRazón: No existe la base de datos DC_DB.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }                        
                    }
                }
            } else
            {
                MessageBox.Show("Sólo es posible eliminar un cliente a la vez!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
