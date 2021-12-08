using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Entidades;
using Entidades.BaseDeDatos;

namespace Formularios
{
    public partial class frmModificarPresupuesto : Form
    {
        public delegate void ManejadorDeLecturaArchivos();
        public event ManejadorDeLecturaArchivos cargarDatos;
        private Cliente clienteQueSeHaModificado;
        private Presupuesto presupuestoAModificar;
        private List<ComponenteElectronico> componentesRemovidos;
        private List<ComponenteElectronico> componentesAgregados;
        private List<Presupuesto> listaAuxiliar; // Lista únicamente con el propósito de mostrar en DGV
        private List<ComponenteElectronico> componentesIniciales;
        private DateTime fechaPorDefecto;
        private int cantidadComponentesInicial;
        public Presupuesto Presupuesto
        {
            get
            {
                return this.presupuestoAModificar;
            }
            set
            {
                this.presupuestoAModificar = value;
            }
        }
        public frmModificarPresupuesto()
        {
            InitializeComponent();
            this.listaAuxiliar = new List<Presupuesto>();
            this.fechaPorDefecto = new DateTime(2000, 1, 1);
            this.componentesAgregados = new List<ComponenteElectronico>();
            this.componentesRemovidos = new List<ComponenteElectronico>();            
        }

        private void frmModificarPresupuesto_Load(object sender, EventArgs e)
        {
            this.dTFecha.Value = fechaPorDefecto;           
            this.cargarDatos += this.CenterToParent;
            this.cargarDatos += this.CargarDatosEnDataGridView;
            this.cargarDatos += this.CargarDatosDelPresupuestoAModificar;
            this.cargarDatos.Invoke();
        }

        private void btnAplicarCambios_Click(object sender, EventArgs e)
        {
            if (dTFecha.Value == this.fechaPorDefecto && string.IsNullOrWhiteSpace(this.txBNuevoValor.Text) && !this.chBLimpiarLista.Checked && this.presupuestoAModificar.ListaDeComponentes == componentesIniciales)
            {
                MessageBox.Show("Debe aplicar alguna modificación para realizar esta acción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (this.presupuestoAModificar.ListaDeComponentes != this.componentesIniciales || dTFecha.Value != this.fechaPorDefecto || !string.IsNullOrWhiteSpace(this.txBNuevoValor.Text) || this.chBLimpiarLista.Checked == true)
                {
                    DateTime fechaAux = this.presupuestoAModificar.FechaEmision;
                    float nuevoValorAux = this.presupuestoAModificar.PrecioFinal;
                    List<ComponenteElectronico> listaAuxiliar = this.presupuestoAModificar.ListaDeComponentes;
                    if (this.chBLimpiarLista.Checked == true)
                    {
                        listaAuxiliar.Clear();
                    }
                    if (dTFecha.Value != this.fechaPorDefecto)
                    {
                        fechaAux = dTFecha.Value;
                    }
                    if (!string.IsNullOrWhiteSpace(this.txBNuevoValor.Text))
                    {
                        nuevoValorAux = float.Parse(this.txBNuevoValor.Text);
                    }
                    if (MessageBox.Show($"¿Confirma realizar los siguientes cambios?\n\n" +
                        $"Valor previo: ${this.presupuestoAModificar.PrecioFinal} -> Nuevo valor: ${this.txBNuevoValor.Text}\n" +
                        $"Fecha previa: {this.presupuestoAModificar.FechaEmision}\nNueva fecha: {fechaAux}\n" +
                        $"Lista Actualmente:\n{this.MostrarLista(listaAuxiliar)}",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.presupuestoAModificar.PrecioFinal = nuevoValorAux;
                        this.presupuestoAModificar.FechaEmision = fechaAux;
                        this.presupuestoAModificar.ListaDeComponentes = listaAuxiliar;
                        try
                        {
                            DAO.ActualizarPresupuesto(presupuestoAModificar);
                            if (this.clienteQueSeHaModificado is not null)
                            {
                                DAO.ActualizarCliente(this.clienteQueSeHaModificado);
                            }
                            if (this.presupuestoAModificar.ListaDeComponentes.Count > this.cantidadComponentesInicial)
                            {
                                for (int i = 0; i < this.componentesAgregados.Count; i++)
                                {
                                    DAO.AgregarDespensa(this.presupuestoAModificar.ID_Presupuesto, this.componentesAgregados[i].ID);
                                }
                            } else if (this.presupuestoAModificar.ListaDeComponentes.Count < this.cantidadComponentesInicial)
                            {
                                for (int i = 0; i < this.componentesRemovidos.Count; i++)
                                {
                                    DAO.RemoverDespensasPorProducto(this.componentesRemovidos[i].ID);
                                }                            
                            }
                        } catch (System.Data.SqlClient.SqlException)
                        {
                            MessageBox.Show("No se pudo aplicar los cambios a la base de datos!\n\nRazón: No existe la base de datos DC_DB.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }finally
                        {
                            this.Close();
                        }
                    }
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarComponente_Click(object sender, EventArgs e)
        {
            frmModAddComp formAgregarNuevoComponente = new frmModAddComp();
            formAgregarNuevoComponente.ComponentesDelPresupuesto = this.presupuestoAModificar.ListaDeComponentes;
            if (formAgregarNuevoComponente.ShowDialog() == DialogResult.OK)
            {
                this.presupuestoAModificar.ListaDeComponentes = formAgregarNuevoComponente.ComponentesDelPresupuesto;
                MessageBox.Show("Se ha agregado un nuevo componente al presupuesto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActualizarDGV();
                this.componentesAgregados.Add(formAgregarNuevoComponente.ComponenteAgregado);
            }
        }
        private void btnQuitarComponente_Click(object sender, EventArgs e)
        {
            frmModRemComp formRemoverComponente = new frmModRemComp();
            formRemoverComponente.ComponentesDelPresupuesto = this.presupuestoAModificar.ListaDeComponentes;
            if (formRemoverComponente.ShowDialog() == DialogResult.OK)
            {
                this.presupuestoAModificar.ListaDeComponentes = formRemoverComponente.ComponentesDelPresupuesto;
                MessageBox.Show("Se ha quitado un componente al presupuesto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActualizarDGV();
                this.componentesRemovidos.Add(formRemoverComponente.ComponenteRemovido);
            }
        }
        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            frmAsignarClienteAPresu formCambiarCliente = new frmAsignarClienteAPresu();
            formCambiarCliente.Presupuesto = presupuestoAModificar;
            formCambiarCliente.ShowDialog();
            this.clienteQueSeHaModificado = formCambiarCliente.ClienteConIDPresupuestoModificado;
        }

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
        private string MostrarLista(List<ComponenteElectronico> lista)
        {
            StringBuilder sB = new StringBuilder();
            foreach (ComponenteElectronico cE in lista)
            {
                sB.AppendLine(cE.InfoResumida());
            }
            return sB.ToString();
        }
        #endregion

        #region Métodos de manejo de lista de presupuestos
        private void CargarDatosDelPresupuestoAModificar()
        {
            this.txBNuevoValor.Text = this.presupuestoAModificar.PrecioFinal.ToString();
            this.dTFecha.Value = this.presupuestoAModificar.FechaEmision;
        }
        private void CargarDatosEnDataGridView()
        {
            if (this.presupuestoAModificar is not null)
            {
                componentesIniciales = this.presupuestoAModificar.ListaDeComponentes;
                this.cantidadComponentesInicial = this.componentesIniciales.Count;
                this.listaAuxiliar.Add(this.presupuestoAModificar);
                this.dgvPresupuesto.DataSource = listaAuxiliar;
            }
        }
        private void ActualizarDGV()
        {
            this.dgvPresupuesto.DataSource = null;
            this.dgvPresupuesto.DataSource = listaAuxiliar;
        }
        #endregion

    }
}
