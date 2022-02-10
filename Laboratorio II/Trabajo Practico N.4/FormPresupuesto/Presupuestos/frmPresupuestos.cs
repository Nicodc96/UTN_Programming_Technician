using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Entidades;
using Entidades.BaseDeDatos;
using Entidades.Serializador;

namespace Formularios
{
    public partial class frmPresupuestos : Form
    {
        private List<Presupuesto> listaPresupuestos;
        private SerializadorXML<List<Presupuesto>> serializadorPresupuestos;

        public List<Presupuesto> ListaInterna
        {
            get
            {
                return this.listaPresupuestos;
            }
            set
            {
                this.listaPresupuestos = value;
            }
        }

        public frmPresupuestos()
        {
            InitializeComponent();
            serializadorPresupuestos = new SerializadorXML<List<Presupuesto>>();
            this.listaPresupuestos = new List<Presupuesto>();
        }

        private void frmPresupuestos_Load(object sender, EventArgs e)
        {
            if (!File.Exists(serializadorPresupuestos.RutaBase + @"Datos\ResumenPresupuestos.xml"))
            {
                this.RecuperarPrimeraVez();
            } else
            {
                this.Recuperar();
            }
            this.ActualizarLista();
        }

        #region Métodos para el DataGridView
        /// <summary>
        /// Guarda la información en la ruta especificada
        /// </summary>
        private void Guardar()
        {
            try
            {
                serializadorPresupuestos.GuardarDatos(this.listaPresupuestos, "ResumenPresupuestos");
            } catch (Exception ex)
            {
                MessageBox.Show($"No se ha podido guardar la información.\n\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Recupera la información almacenada internamente si no existe el archivo en la ruta generada
        /// </summary>
        private void RecuperarPrimeraVez()
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
        /// <summary>
        /// Lee la información almacenada en la ruta generada si se han agregado/modificado/quitado presupuestos.
        /// </summary>
        private void Recuperar()
        {
            try
            {
                this.listaPresupuestos = serializadorPresupuestos.RecuperarDatos(Path.Combine(serializadorPresupuestos.RutaBase, @"Datos\ResumenPresupuestos.xml"));
            } catch (Exception ex)
            {
                MessageBox.Show($"No se ha podido recuperar los archivos.\n\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Actualiza la lista de presupuestos para mostrar en tiempo real el estado de los presupuestos
        /// </summary>
        private void ActualizarLista()
        {
            this.dGVPresupuestos.DataSource = null;
            this.dGVPresupuestos.DataSource = this.listaPresupuestos;
        }
        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarPresupuesto formAgregarPresupuesto = new frmAgregarPresupuesto();
            formAgregarPresupuesto.ListaPresupuesto = this.listaPresupuestos;
            formAgregarPresupuesto.ShowDialog();
            this.ActualizarLista();
            this.Guardar();
        }
        /// <summary>
        /// Método interno para identificar si el dato único a comparar en el DataGridView coincide con
        /// algún elemento en la lista. En el caso de que exista retorna el objeto en cuestión, de lo contrario
        /// devolverá un null.
        /// </summary>
        private Presupuesto ObtenerPresupuestoDeDGV()
        {
            Presupuesto pAux = null;
            if (this.dGVPresupuestos.SelectedRows.Count == 1)
            {
                try
                {
                    for (int i = 0; i < this.dGVPresupuestos.SelectedRows.Count; i++)
                    {
                        for (int j = 0; j < this.listaPresupuestos.Count; j++)
                        {
                            if ((float)this.dGVPresupuestos.SelectedRows[i].Cells[8].Value == this.listaPresupuestos[j].PrecioFinal)
                            {
                                pAux = this.listaPresupuestos[j];
                                break;
                            }
                        }
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show($"No se ha podido obtener el elemento.\nDetalles:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return pAux;
        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (this.dGVPresupuestos.SelectedRows.Count > 1)
            {
                MessageBox.Show("Solo un prepuesto a la vez puede eliminarse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                Presupuesto pAux = this.ObtenerPresupuestoDeDGV();
                if (pAux is not null)
                {
                    if (MessageBox.Show("¿Está seguro de eliminar este elemento?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        this.listaPresupuestos.Remove(pAux);
                        this.Guardar();
                        this.ActualizarLista();
                        try
                        {
                            DAO.RemoverDespensasPorPresupuesto(pAux.ID_Presupuesto);
                            DAO.RemoverPresupuesto(pAux.ID_Presupuesto);
                        } catch(System.Data.SqlClient.SqlException)
                        {
                            MessageBox.Show("No se pudo aplicar los cambios a la base de datos!\n\nRazón: No existe la base de datos DC_DB.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }            
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.dGVPresupuestos.SelectedRows.Count > 1)
            {
                MessageBox.Show("Sólo puede modificar un presupuesto a la vez.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                frmModificarPresupuesto formModificador = new frmModificarPresupuesto();
                Presupuesto presupuestoAModificar = this.ObtenerPresupuestoDeDGV();
                formModificador.Presupuesto = presupuestoAModificar;
                if (formModificador.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < this.listaPresupuestos.Count; i++)
                    {
                        if (listaPresupuestos[i] == presupuestoAModificar)
                        {
                            listaPresupuestos[i] = formModificador.Presupuesto;
                            this.DialogResult = DialogResult.OK;
                            this.Guardar();
                            this.ActualizarLista();
                        }
                    }
                }
            }            
        }
    }
}
