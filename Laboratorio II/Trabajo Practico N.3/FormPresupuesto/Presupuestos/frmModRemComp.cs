using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Entidades.Serializador;

namespace Formularios
{
    public partial class frmModRemComp : Form
    {
        private List<ComponenteElectronico> listaDelPresupuesto;
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
        public frmModRemComp()
        {
            InitializeComponent();
            this.listaDelPresupuesto = new List<ComponenteElectronico>();
        }
        #region Carga de datos en DGV
        private void CargarDatosDeProductos()
        {
            this.dGVProductos.DataSource = listaDelPresupuesto;
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
                        for (int j = 0; j < this.listaDelPresupuesto.Count; j++)
                        {
                            if (this.dGVProductos.SelectedRows[i].Cells[8].Value.ToString() == listaDelPresupuesto[j].Precio.ToString())
                            {
                                cEAux = this.listaDelPresupuesto[j];
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

        private void frmModRemComp_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.CargarDatosDeProductos();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (this.dGVProductos.SelectedRows.Count > 1)
            {
                MessageBox.Show("Solo es posible eliminar un producto a la vez!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ComponenteElectronico cEAux = BuscarProductoEnDGV();
                if (cEAux is not null)
                {
                    if (MessageBox.Show($"¿Confirma eliminar el siguiente elemento?\n\n{cEAux.InfoResumida()}", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.listaDelPresupuesto.Remove(cEAux);
                        this.Close();
                    }
                }
            }
        }
    }
}
