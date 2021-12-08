using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Entidades;
using Entidades.BaseDeDatos;
using Entidades.Serializador;

namespace Formularios
{
    public partial class frmAgregarPresupuesto : Form
    {
        private List<ComponenteElectronico> listaProductosInterna;
        private List<Presupuesto> listaPresupuestos;
        private Cliente clienteLinkeadoAlPresupuesto;
        private SerializadorXML<List<ComponenteElectronico>> serializadorComponentes;
        private SerializadorXML<List<Presupuesto>> serializadorPresupuestos;
        private Presupuesto nuevoPresupuesto;
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
            this.nuevoPresupuesto = new Presupuesto();
            this.nuevoPresupuesto.ListaDeComponentes = new List<ComponenteElectronico>();
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
        private void txBID_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.txBID.Text, "  ^ [0-9]"))
            {
                this.txBID.Text = "";
            }
        }
        #endregion

        private void GuardarPresupuesto()
        {
            try
            {
                serializadorPresupuestos.GuardarDatos(this.listaPresupuestos, "ResumenPresupuestos");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se ha podido guardar la información.\n\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int cantidadAux = this.dGVProductos.SelectedRows.Count;
            bool verificadorID = true;
            if (string.IsNullOrWhiteSpace(this.txBNuevoValor.Text) || this.dTFecha.Value == fechaPorDefecto)
            {
                this.nuevoPresupuesto.CantidadComponentes = cantidadAux;
                this.nuevoPresupuesto.FechaEmision = DateTime.Now;
                this.nuevoPresupuesto.ID_Presupuesto = random.Next(0, 10000);
            } else
            {
                nuevoPresupuesto.CantidadComponentes = this.dGVProductos.SelectedRows.Count;
                nuevoPresupuesto.FechaEmision = this.dTFecha.Value;
                nuevoPresupuesto.ID_Presupuesto = int.Parse(this.txBID.Text);
                nuevoPresupuesto.PrecioFinal = float.Parse(this.txBNuevoValor.Text);
            }
            if (nuevoPresupuesto.ID_Cliente == 0)
            {
                nuevoPresupuesto.ID_Cliente = -1;
            }            
            for (int i = 0; i < this.listaPresupuestos.Count; i++)
            {
                if (this.listaPresupuestos[i].ID_Presupuesto == nuevoPresupuesto.ID_Presupuesto)
                {
                    verificadorID = false;
                    break;
                }
            }
            if (verificadorID)
            {
                for (int i = 0; i < cantidadAux; i++)
                {
                    for (int j = 0; j < this.listaProductosInterna.Count; j++)
                    {
                        if ((float)this.dGVProductos.SelectedRows[i].Cells[7].Value == this.listaProductosInterna[j].Potencia)
                        {
                            this.nuevoPresupuesto.ListaDeComponentes.Add(listaProductosInterna[j]);
                        }
                    }
                }
                if (MessageBox.Show($"¿Confima agregar el nuevo presupuesto?\n\n{nuevoPresupuesto.InformarPresupuesto()}", "Ingresar nuevo presupuesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.listaPresupuestos.Add(this.nuevoPresupuesto);
                    this.GuardarPresupuesto();
                    try
                    {
                        DAO.GuardarPresupuesto(this.nuevoPresupuesto);
                        DAO.AgregarDespensas(this.nuevoPresupuesto);
                        DAO.ActualizarCliente(this.clienteLinkeadoAlPresupuesto);
                    } catch (System.Data.SqlClient.SqlException)
                    {
                        MessageBox.Show("No se pudo aplicar los cambios a la base de datos!\n\nRazón: No existe la base de datos DC_DB.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }finally
                    {
                        this.Close();
                    }
                } else
                {
                    this.nuevoPresupuesto.ListaDeComponentes.Clear();
                }
            } else
            {
                MessageBox.Show("El ID del presupuesto ingresado ya existe en la base de datos!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAsignarCliente_Click(object sender, EventArgs e)
        {
            frmAsignarClienteAPresu formAsignarCliente = new frmAsignarClienteAPresu();
            formAsignarCliente.Presupuesto = this.nuevoPresupuesto;
            formAsignarCliente.ShowDialog();
            this.clienteLinkeadoAlPresupuesto = formAsignarCliente.ClienteConIDPresupuestoModificado;
        }
    }
}
