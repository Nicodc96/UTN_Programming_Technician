using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Entidades;
using Entidades.Serializador;

namespace Formularios
{
    public partial class frmModAddComp : Form
    {
        private List<ComponenteElectronico> listaCompleta;
        private List<ComponenteElectronico> listaDelPresupuesto;
        private SerializadorXML<List<ComponenteElectronico>> serializadorLista;

        public List<ComponenteElectronico> ComponentesDelPresupuesto
        {
            get
            {
                return this.listaDelPresupuesto;
            }
            set
            {
                this.listaDelPresupuesto = value;
            }
        }
        public frmModAddComp()
        {
            InitializeComponent();
            this.listaCompleta = new List<ComponenteElectronico>();
            this.listaDelPresupuesto = new List<ComponenteElectronico>();
            this.serializadorLista = new SerializadorXML<List<ComponenteElectronico>>();
        }       

        private void frmModAddComp_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.CargarDatosDeProductos();
        }

        #region Carga de datos en DGV
        private void CargarDatosDeProductos()
        {
            if (!File.Exists(serializadorLista.RutaBase + @"\Datos\ResumenComponentes.xml"))
            {
                try
                {
                    this.listaCompleta = serializadorLista.RecuperarDatos(Path.Combine(Environment.CurrentDirectory, @"Datos\ListaComponentes.xml"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se ha podido recuperar los archivos.\n\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                try
                {
                    this.listaCompleta = serializadorLista.RecuperarDatos(Path.Combine(serializadorLista.RutaBase, @"Datos\ResumenComponentes.xml"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se ha podido recuperar los archivos.\n\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.dGVProductos.DataSource = this.listaCompleta;
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
                        for (int j = 0; j < this.listaCompleta.Count; j++)
                        {
                            if (this.dGVProductos.SelectedRows[i].Cells[8].Value.ToString() == listaCompleta[j].Precio.ToString())
                            {
                                cEAux = this.listaCompleta[j];
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se ha podido eliminar el elemento.\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return cEAux;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.dGVProductos.SelectedRows.Count > 1)
            {
                MessageBox.Show("Solo es posible agregar un producto a la vez!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                ComponenteElectronico cEAux = BuscarProductoEnDGV();
                if (cEAux is not null && this.listaDelPresupuesto != cEAux)
                {
                    if (MessageBox.Show($"¿Confirma agregar el siguiente elemento?\n\n{cEAux.InfoResumida()}", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.listaDelPresupuesto.Add(cEAux);
                        this.Close();
                    }                    
                }
            }
        }
    }
}
