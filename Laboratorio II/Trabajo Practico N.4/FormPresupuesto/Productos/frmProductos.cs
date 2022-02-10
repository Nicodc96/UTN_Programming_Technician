using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Entidades.Serializador;
using Entidades;
using Entidades.BaseDeDatos;

namespace Formularios
{
    public partial class frmProductos : Form
    {
        private List<ComponenteElectronico> listaDeComponentes;
        private SerializadorXML<List<ComponenteElectronico>> serializadorLista;
        public frmProductos()
        {
            InitializeComponent();
            listaDeComponentes = new List<ComponenteElectronico>();
            serializadorLista = new SerializadorXML<List<ComponenteElectronico>>();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            if (!File.Exists(serializadorLista.RutaBase + @"Datos\ResumenComponentes.xml"))
            {
                this.RecuperarPrimeraVez();
            }
            else
            {
                try
                {
                    this.RecuperarDatos();
                } catch (Exception ex)
                {
                    MessageBox.Show($"No se ha podido recuperar los archivos.\n\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.ActualizarLista();
        }

        #region Métodos para el DGV
        private void Guardar()
        {
            try
            {
                serializadorLista.GuardarDatos(this.listaDeComponentes, "ResumenComponentes");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se ha podido guardar la información.\n\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RecuperarPrimeraVez()
        {
            try
            {
                this.listaDeComponentes = serializadorLista.RecuperarDatos(Path.Combine(Environment.CurrentDirectory, @"Datos\ListaComponentes.xml"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se ha podido recuperar los archivos.\n\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecuperarDatos()
        {
            try
            {
                this.listaDeComponentes = serializadorLista.RecuperarDatos(Path.Combine(serializadorLista.RutaBase, @"Datos\ResumenComponentes.xml"));
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void ActualizarLista()
        {
            this.dGVProductos.DataSource = null;
            this.dGVProductos.DataSource = this.listaDeComponentes;
        }
        #endregion

        private ComponenteElectronico BuscarProductoEnDGV()
        {
            ComponenteElectronico cEAux = null;
            if (this.dGVProductos.SelectedRows.Count == 1)
            {
                try
                {
                    for (int i = 0; i < this.dGVProductos.SelectedRows.Count; i++)
                    {
                        for (int j = 0; j < this.listaDeComponentes.Count; j++)
                        {
                            if (this.dGVProductos.SelectedRows[i].Cells[9].Value.ToString() == listaDeComponentes[j].Precio.ToString())
                            {
                                cEAux = this.listaDeComponentes[j];
                                break;
                            }
                        }
                    }
                }catch (Exception ex)
                {
                    MessageBox.Show($"No se ha podido eliminar el elemento.\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return cEAux;
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (this.dGVProductos.SelectedRows.Count == 1)
            {
                ComponenteElectronico cEAux = BuscarProductoEnDGV();
                if (cEAux is not null)
                {
                    if (MessageBox.Show("¿Está seguro de eliminar este elemento?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        this.listaDeComponentes.Remove(cEAux);
                        this.Guardar();
                        this.ActualizarLista();
                        try
                        {
                            DAO.RemoverDespensasPorProducto(cEAux.ID);
                            DAO.RemoverComponente(cEAux.ID);
                        } catch (System.Data.SqlClient.SqlException)
                        {
                            MessageBox.Show("No se pudo aplicar los cambios a la base de datos!\n\nRazón: No existe la base de datos DC_DB.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            } else
            {
                MessageBox.Show("Solo un producto a la vez puede eliminarse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarProducto formAgregar = new frmAgregarProducto();
            formAgregar.ListaInterna = this.listaDeComponentes;
            if(formAgregar.ShowDialog() == DialogResult.OK)
            {
                this.ActualizarLista();
            }
            this.Guardar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificarProducto formModificar = new frmModificarProducto();
            formModificar.ListaInterna = this.listaDeComponentes;
            formModificar.Componente = this.BuscarProductoEnDGV();
            if (formModificar.ShowDialog() == DialogResult.OK)
            {
                this.ActualizarLista();
                this.Guardar();
            }
        }
    }
}
