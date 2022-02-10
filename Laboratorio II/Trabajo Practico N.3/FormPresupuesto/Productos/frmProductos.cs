using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Entidades.Serializador;
using Entidades;

namespace Formularios
{
    public partial class frmProductos : Form
    {
        private List<ComponenteElectronico> listaActual;
        private SerializadorXML<List<ComponenteElectronico>> serializadorLista;
        public frmProductos()
        {
            InitializeComponent();
            listaActual = new List<ComponenteElectronico>();
            serializadorLista = new SerializadorXML<List<ComponenteElectronico>>();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            if (!File.Exists(serializadorLista.RutaBase + @"\Datos\ResumenComponentes.xml"))
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
                serializadorLista.GuardarDatos(this.listaActual);
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
                this.listaActual = serializadorLista.RecuperarDatos(Path.Combine(Environment.CurrentDirectory, @"Datos\ListaComponentes.xml"));
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
                this.listaActual = serializadorLista.RecuperarDatos(Path.Combine(serializadorLista.RutaBase, @"Datos\ResumenComponentes.xml"));
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void ActualizarLista()
        {
            this.dGVProductos.DataSource = null;
            this.dGVProductos.DataSource = this.listaActual;
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
                        for (int j = 0; j < this.listaActual.Count; j++)
                        {
                            if (this.dGVProductos.SelectedRows[i].Cells[8].Value.ToString() == listaActual[j].Precio.ToString())
                            {
                                cEAux = this.listaActual[j];
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
                        this.listaActual.Remove(cEAux);
                        this.ActualizarLista();
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
            formAgregar.ListaInterna = this.listaActual;
            if(formAgregar.ShowDialog() == DialogResult.OK)
            {
                this.ActualizarLista();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificarProducto formModificar = new frmModificarProducto();
            formModificar.ListaInterna = this.listaActual;
            formModificar.Componente = this.BuscarProductoEnDGV();
            if (formModificar.ShowDialog() == DialogResult.OK)
            {
                this.ActualizarLista();
            }
        }

        private void pBGuardar_Click(object sender, EventArgs e)
        {
            this.Guardar();
            MessageBox.Show("Se ha guardado la información correctamente.", "Guardar información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
