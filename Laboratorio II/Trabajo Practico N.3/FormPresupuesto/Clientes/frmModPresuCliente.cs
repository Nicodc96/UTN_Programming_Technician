using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Entidades;
using Entidades.Serializador;

namespace Formularios
{
    public partial class frmModPresuCliente : Form
    {
        private Cliente clienteACambiarPresupuesto;
        private List<Presupuesto> listaPresupuestos;
        private SerializadorXML<List<Presupuesto>> serializadorPresupuestos;
        public Cliente Cliente
        {
            get
            {
                return this.clienteACambiarPresupuesto;
            }
            set
            {
                this.clienteACambiarPresupuesto = value;
            }
        }
        public frmModPresuCliente()
        {
            InitializeComponent();
            serializadorPresupuestos = new SerializadorXML<List<Presupuesto>>();
            this.listaPresupuestos = new List<Presupuesto>();
        }

        private void frmModPresuCliente_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.CargarPresupuestosEnDGV();
        }

        #region Métodos para DGV
        private void CargarPresupuestosEnDGV()
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
            }
            else
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.dGVPresupuestos.SelectedRows.Count > 1)
            {
                MessageBox.Show("Solo un prepuesto a la vez puede seleccionarse!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                Presupuesto pAux = this.ObtenerPresupuestoDeDGV();
                if (pAux is not null)
                {
                    if (MessageBox.Show("¿Confirmar selección?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.clienteACambiarPresupuesto.PresupuestoCliente = pAux;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }
    }
}
