using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Entidades;
using Entidades.Serializador;

namespace Formularios
{
    public partial class frmAgregarPresupuesto : Form
    {
        private List<ComponenteElectronico> listaProductosInterna;
        private List<Presupuesto> listaPresupuestos;
        private SerializadorXML<List<ComponenteElectronico>> serializadorComponentes;
        private SerializadorXML<List<Presupuesto>> serializadorPresupuestos;
        private DateTime fechaPorDefecto;
        public List<Presupuesto> ListaPresupuesto
        {
            set
            {
                this.listaPresupuestos = value;
            }
        }
        public frmAgregarPresupuesto()
        {
            InitializeComponent();
            this.listaProductosInterna = new List<ComponenteElectronico>();
            this.serializadorPresupuestos = new SerializadorXML<List<Presupuesto>>();
            this.serializadorComponentes = new SerializadorXML<List<ComponenteElectronico>>();
            fechaPorDefecto = new DateTime(2000, 1, 1);
        }

        private void frmAgregarPresupuesto_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.dTFecha.Value = fechaPorDefecto;
            CargarListaProductos();
        }

        #region Método para DataGridView de Productos
        private void CargarListaProductos()
        {
            DataSet dataSet = new DataSet();
            if (!File.Exists(serializadorComponentes.RutaBase + @"\Datos\ResumenComponentes.xml"))
            {
                try
                {
                    this.listaProductosInterna = serializadorComponentes.RecuperarDatos(Path.Combine(Environment.CurrentDirectory, @"Datos\ListaComponentes.xml"));
                } catch (Exception ex)
                {
                    MessageBox.Show($"No se ha podido recuperar la información de los productos!\n\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    this.listaProductosInterna = serializadorComponentes.RecuperarDatos(Path.Combine(serializadorComponentes.RutaBase, @"Datos\ResumenComponentes.xml"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se ha podido recuperar la información de los productos!\n\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.dGVProductos.DataSource = this.listaProductosInterna;
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
        private void txBNuevoValor_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.txBNuevoValor.Text, "  ^ [0-9]"))
            {
                this.txBNuevoValor.Text = "";
            }
        }
        #endregion
        private void GuardarPresupuesto()
        {
            try
            {
                serializadorPresupuestos.GuardarDatos(this.listaPresupuestos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se ha podido guardar la información.\n\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Presupuesto nuevoPresupuesto;
            int cantidadAux = this.dGVProductos.SelectedRows.Count;
            if (string.IsNullOrEmpty(this.txBNuevoValor.Text) || this.dTFecha.Value == fechaPorDefecto)
            {
                nuevoPresupuesto = new Presupuesto(cantidadAux, DateTime.Now);
            } else
            {
                nuevoPresupuesto = new Presupuesto(cantidadAux, this.dTFecha.Value);
                nuevoPresupuesto.PrecioFinal = float.Parse(this.txBNuevoValor.Text);
            }
            for (int i = 0; i < cantidadAux; i++)
            {
                for (int j = 0; j < this.listaProductosInterna.Count; j++)
                {
                    if ((float)this.dGVProductos.SelectedRows[i].Cells[6].Value == this.listaProductosInterna[j].Potencia)
                    {
                        nuevoPresupuesto.ListaDeComponentes.Add(listaProductosInterna[j]);
                    }
                }
            }
            if (MessageBox.Show($"¿Confima agregar el nuevo presupuesto?\n\n{nuevoPresupuesto.InformarPresupuesto()}", "Ingresar nuevo presupuesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.listaPresupuestos.Add(nuevoPresupuesto);
                this.GuardarPresupuesto();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
