using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Entidades.Enumerado;
using Entidades;
using Entidades.Componentes;
using Entidades.BaseDeDatos;

namespace Formularios
{    
    public partial class frmAgregarProducto : Form
    {
        private List<ComponenteElectronico> listaComponentesActual;
        private ComponenteElectronico componenteNuevo;
        public ComponenteElectronico ComponenteNuevo
        {
            get => this.componenteNuevo;
        }
        public List<ComponenteElectronico> ListaInterna
        {
            set => this.listaComponentesActual = value;
        }
        public frmAgregarProducto()
        {
            InitializeComponent();
            this.listaComponentesActual = new List<ComponenteElectronico>();
        }

        private void frmAgregarProducto_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.CargarDatosEnComboBoxes();
            this.ApagarControles();            
        }

        #region Métodos para ComboBoxes
        private void ApagarControles()
        {
            // Datos centrales //
            this.cmbMarcas.Enabled = false;
            this.txBModelo.Enabled = false;
            this.txBConsumo.Enabled = false;
            this.txBPotencia.Enabled = false;
            this.txBPrecio.Enabled = false;
            // Datos específicos segun producto //
            this.ApagarControlesEspecificos();
        }

        private void ApagarControlesEspecificos()
        {
            this.cmbTipoPlaca.Enabled = false;
            this.txBMemoriaGrafica.Enabled = false;
            this.cmbTipoMother.Enabled = false;
            this.cmbSocket.Enabled = false;
            this.cmbTipoFuente.Enabled = false;
            this.cmbTipoMemoria.Enabled = false;
            this.cmbGeneracion.Enabled = false;
            this.cmbTipoDisco.Enabled = false;
            this.txtTamanioDisco.Enabled = false;
            this.cmbFabricanteCPU.Enabled = false;
            this.cmbCantNucleos.Enabled = false;
        }
        private void CargarDatosEnComboBoxes()
        {
            foreach (EMarcas marca in Enum.GetValues(typeof(EMarcas)))
            {
                this.cmbMarcas.Items.Add(marca);
            }
            foreach (ETipoPlaca placa in Enum.GetValues(typeof(ETipoPlaca)))
            {
                this.cmbTipoPlaca.Items.Add(placa);
            }
            foreach (ETipoMother mother in Enum.GetValues(typeof(ETipoMother)))
            {
                this.cmbTipoMother.Items.Add(mother);
            }
            foreach (ESocket socket in Enum.GetValues(typeof(ESocket)))
            {
                this.cmbSocket.Items.Add(socket);
            }
            foreach (ETipoFuente fuente in Enum.GetValues(typeof(ETipoFuente)))
            {
                this.cmbTipoFuente.Items.Add(fuente);
            }
            foreach (ETipoMemoria memoria in Enum.GetValues(typeof(ETipoMemoria)))
            {
                this.cmbTipoMemoria.Items.Add(memoria);
            }
            foreach (ETecnologiaMemoria generacion in Enum.GetValues(typeof(ETecnologiaMemoria)))
            {
                this.cmbGeneracion.Items.Add(generacion);
            }
            foreach (ETipoDisco disco in Enum.GetValues(typeof(ETipoDisco)))
            {
                this.cmbTipoDisco.Items.Add(disco);
            }
            foreach (EFabricanteCPU fabricante in Enum.GetValues(typeof(EFabricanteCPU)))
            {
                this.cmbFabricanteCPU.Items.Add(fabricante);
            }
            foreach (ECantidadNucleos cantNucleos in Enum.GetValues(typeof(ECantidadNucleos)))
            {
                this.cmbCantNucleos.Items.Add(cantNucleos);
            }
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
        private void txBPotencia_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.txBPotencia.Text, "  ^ [0-9]"))
            {
                this.txBPotencia.Text = "";
            }
        }
        private void txBConsumo_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.txBConsumo.Text, "  ^ [0-9]"))
            {
                this.txBConsumo.Text = "";
            }
        }
        private void txBPrecio_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.txBPrecio.Text, "  ^ [0-9]"))
            {
                this.txBPrecio.Text = "";
            }
        }
        private void txBMemoriaGrafica_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.txBMemoriaGrafica.Text, "  ^ [0-9]"))
            {
                this.txBMemoriaGrafica.Text = "";
            }
        }
        private void txBID_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.txBID.Text, "  ^ [0-9]"))
            {
                this.txBID.Text = "";
            }
        }
        private void txtTamanioDisco_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.txtTamanioDisco.Text, "  ^ [0-9]"))
            {
                this.txtTamanioDisco.Text = "";
            }
        }
        #endregion

        private void cmbTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbMarcas.Enabled = true;
            this.txBModelo.Enabled = true;
            this.txBConsumo.Enabled = true;
            this.txBPotencia.Enabled = true;
            this.txBPrecio.Enabled = true;
            switch (this.cmbTipoProducto.SelectedItem.ToString())
            {
                case "Disco":
                    this.ApagarControlesEspecificos();
                    this.cmbTipoDisco.Enabled = true;
                    this.txtTamanioDisco.Enabled = true;
                    break;
                case "FuenteDePoder":
                    this.ApagarControlesEspecificos();
                    this.cmbTipoFuente.Enabled = true;
                    break;
                case "Memoria":
                    this.ApagarControlesEspecificos();
                    this.cmbTipoMemoria.Enabled = true;
                    this.cmbGeneracion.Enabled = true;
                    break;
                case "PlacaDeVideo":
                    this.ApagarControlesEspecificos();
                    this.cmbTipoPlaca.Enabled = true;
                    this.txBMemoriaGrafica.Enabled = true;
                    break;
                case "PlacaMadre":
                    this.ApagarControlesEspecificos();
                    this.cmbTipoMother.Enabled = true;
                    this.cmbSocket.Enabled = true;
                    break;
                case "Procesador":
                    this.ApagarControlesEspecificos();
                    this.cmbFabricanteCPU.Enabled = true;
                    this.cmbCantNucleos.Enabled = true;
                    break;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbTipoProducto.SelectedItem is not null)
            {
                if (this.cmbMarcas.SelectedItem is null || string.IsNullOrWhiteSpace(this.txBModelo.Text) || string.IsNullOrWhiteSpace(this.txBPotencia.Text) || string.IsNullOrWhiteSpace(this.txBConsumo.Text) || string.IsNullOrWhiteSpace(this.txBPrecio.Text) || string.IsNullOrWhiteSpace(this.txBID.Text))
                {
                    MessageBox.Show("Todos los campos de los datos centrales deben completarse!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    switch (this.cmbTipoProducto.SelectedItem.ToString())
                    {
                        case "Disco":
                            if (this.cmbTipoDisco.SelectedItem is null || string.IsNullOrWhiteSpace(this.txtTamanioDisco.Text))
                            {
                                this.componenteNuevo = new Disco((EMarcas)this.cmbMarcas.SelectedItem, this.txBModelo.Text, float.Parse(this.txBPotencia.Text), float.Parse(this.txBConsumo.Text), float.Parse(this.txBPrecio.Text), int.Parse(this.txBID.Text));                                
                            } else
                            {
                                this.componenteNuevo = new Disco((EMarcas)this.cmbMarcas.SelectedItem, this.txBModelo.Text, float.Parse(this.txBPotencia.Text), float.Parse(this.txBConsumo.Text), float.Parse(this.txBPrecio.Text), short.Parse(this.txtTamanioDisco.Text), (ETipoDisco)this.cmbTipoDisco.SelectedItem, int.Parse(this.txBID.Text));
                            }
                            AgregandoComponente(this.componenteNuevo);
                            break;
                        case "FuenteDePoder":
                            if (this.cmbTipoFuente.SelectedItem is null)
                            {
                                this.componenteNuevo = new FuenteDePoder((EMarcas)this.cmbMarcas.SelectedItem, this.txBModelo.Text, float.Parse(this.txBPotencia.Text), float.Parse(this.txBConsumo.Text), float.Parse(this.txBPrecio.Text), int.Parse(this.txBID.Text));
                            } else
                            {
                                this.componenteNuevo = new FuenteDePoder((EMarcas)this.cmbMarcas.SelectedItem, this.txBModelo.Text, float.Parse(this.txBPotencia.Text), float.Parse(this.txBConsumo.Text), float.Parse(this.txBPrecio.Text), (ETipoFuente)this.cmbTipoFuente.SelectedItem, int.Parse(this.txBID.Text));
                            }
                            AgregandoComponente(this.componenteNuevo);
                            break;
                        case "Memoria":
                            if (this.cmbTipoMemoria.SelectedItem is null || this.cmbGeneracion.SelectedItem is null)
                            {
                                this.componenteNuevo = new Memoria((EMarcas)this.cmbMarcas.SelectedItem, this.txBModelo.Text, float.Parse(this.txBPotencia.Text), float.Parse(this.txBConsumo.Text), float.Parse(this.txBPrecio.Text), int.Parse(this.txBID.Text));
                            } else
                            {
                                this.componenteNuevo = new Memoria((EMarcas)this.cmbMarcas.SelectedItem, this.txBModelo.Text, float.Parse(this.txBPotencia.Text), float.Parse(this.txBConsumo.Text), float.Parse(this.txBPrecio.Text), (ETipoMemoria)this.cmbTipoMemoria.SelectedItem, (ETecnologiaMemoria)this.cmbGeneracion.SelectedItem, int.Parse(this.txBID.Text));
                            }
                            AgregandoComponente(this.componenteNuevo);
                            break;
                        case "PlacaDeVideo":
                            if (this.cmbTipoPlaca.SelectedItem is null || string.IsNullOrWhiteSpace(this.txBMemoriaGrafica.Text))
                            {
                                this.componenteNuevo = new PlacaDeVideo((EMarcas)this.cmbMarcas.SelectedItem, this.txBModelo.Text, float.Parse(this.txBPotencia.Text), float.Parse(this.txBConsumo.Text), float.Parse(this.txBPrecio.Text), int.Parse(this.txBID.Text));
                            } else
                            {
                                this.componenteNuevo = new PlacaDeVideo((EMarcas)this.cmbMarcas.SelectedItem, this.txBModelo.Text, float.Parse(this.txBPotencia.Text), float.Parse(this.txBConsumo.Text), float.Parse(this.txBPrecio.Text), float.Parse(this.txBMemoriaGrafica.Text), (ETipoPlaca)this.cmbTipoPlaca.SelectedItem, int.Parse(this.txBID.Text));
                            }
                            AgregandoComponente(this.componenteNuevo);
                            break;
                        case "PlacaMadre":
                            if (this.cmbTipoMother.SelectedItem is null || this.cmbSocket.SelectedItem is null)
                            {
                                this.componenteNuevo = new PlacaMadre((EMarcas)this.cmbMarcas.SelectedItem, this.txBModelo.Text, float.Parse(this.txBPotencia.Text), float.Parse(this.txBConsumo.Text), float.Parse(this.txBPrecio.Text), int.Parse(this.txBID.Text));
                            } else
                            {
                                this.componenteNuevo = new PlacaMadre((EMarcas)this.cmbMarcas.SelectedItem, this.txBModelo.Text, float.Parse(this.txBPotencia.Text), float.Parse(this.txBConsumo.Text), float.Parse(this.txBPrecio.Text), (ETipoMother)this.cmbTipoMother.SelectedItem, (ESocket)this.cmbSocket.SelectedItem, int.Parse(this.txBID.Text));
                            }
                            AgregandoComponente(this.componenteNuevo);
                            break;
                        case "Procesador":
                            if (this.cmbFabricanteCPU.SelectedItem is null || this.cmbCantNucleos.SelectedItem is null)
                            {
                                this.componenteNuevo = new Procesador((EMarcas)this.cmbMarcas.SelectedItem, this.txBModelo.Text, float.Parse(this.txBPotencia.Text), float.Parse(this.txBConsumo.Text), float.Parse(this.txBPrecio.Text), int.Parse(this.txBID.Text));
                            } else
                            {
                                this.componenteNuevo = new Procesador((EMarcas)this.cmbMarcas.SelectedItem, this.txBModelo.Text, float.Parse(this.txBPotencia.Text), float.Parse(this.txBConsumo.Text), float.Parse(this.txBPrecio.Text), (EFabricanteCPU)this.cmbFabricanteCPU.SelectedItem, (ECantidadNucleos)this.cmbCantNucleos.SelectedItem, int.Parse(this.txBID.Text));
                            }
                            AgregandoComponente(this.componenteNuevo);
                            break;
                    }
                }
            } else
            {
                MessageBox.Show("Se debe ingresar el tipo de producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AgregandoComponente(ComponenteElectronico comp)
        {
            bool verificador = true;
            for (int i = 0; i < this.listaComponentesActual.Count; i++)
            {
                if (this.listaComponentesActual[i].ID == comp.ID)
                {
                    verificador = false;
                    break;
                }
            }
            if (verificador)
            {
                this.listaComponentesActual.Add(comp);
                this.DialogResult = DialogResult.OK;
                try
                {
                    DAO.GuardarComponente(comp);
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("No se pudo aplicar los cambios a la base de datos!\n\nRazón: No existe la base de datos DC_DB.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    this.Close();
                }
            } else
            {
                MessageBox.Show("El ID del producto ya existe en la base de datos!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
