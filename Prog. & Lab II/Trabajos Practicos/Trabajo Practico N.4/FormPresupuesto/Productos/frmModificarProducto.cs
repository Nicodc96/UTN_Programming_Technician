using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Entidades;
using Entidades.Enumerado;
using Entidades.Componentes;
using Entidades.BaseDeDatos;

namespace Formularios
{
    public partial class frmModificarProducto : Form
    {
        private ComponenteElectronico compElectrAModificar;
        private List<ComponenteElectronico> listaDeComponentes;

        public ComponenteElectronico Componente
        {
            get => this.compElectrAModificar;
            set => this.compElectrAModificar = value;
        }
        public List<ComponenteElectronico> ListaInterna
        {
            get => listaDeComponentes;
            set => this.listaDeComponentes = value;
        }
        public frmModificarProducto()
        {
            InitializeComponent();
            this.listaDeComponentes = new List<ComponenteElectronico>();
        }

        private void frmModificarProducto_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.ApagarControles();
            this.CargarDatosEnComboBoxes();
            this.ChequearTipoYCargarDatos();
        }

        #region Métodos para ComboBoxes
        private void ApagarControles()
        {
            // Combobox de producto a modificar pero no habilitado para el usuario
            this.cmbTipoProducto.Enabled = false;
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
        private void txtTamanioDisco_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.txtTamanioDisco.Text, "  ^ [0-9]"))
            {
                this.txtTamanioDisco.Text = "";
            }
        }
        #endregion

        #region Métodos de carga de información

        private bool BuscarComponenteEnLista()
        {
            return this.ListaInterna == this.Componente;
        }
        private void CargarDatosPrincipales()
        {
            this.cmbMarcas.SelectedItem = this.compElectrAModificar.Marca;
            this.txBModelo.Text = this.compElectrAModificar.Modelo;
            this.txBConsumo.Text = this.compElectrAModificar.Consumo.ToString();
            this.txBPotencia.Text = this.compElectrAModificar.Potencia.ToString();
            this.txBPrecio.Text = this.compElectrAModificar.Precio.ToString();
        }
        private void ChequearTipoYCargarDatos()
        {
            if (!this.BuscarComponenteEnLista())
            {
                MessageBox.Show("ERROR! No se ha encontrado el elemento solicitado en la lista!", "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            } else
            {
                this.cmbMarcas.Enabled = true;
                this.txBModelo.Enabled = true;
                this.txBConsumo.Enabled = true;
                this.txBPotencia.Enabled = true;
                this.txBPrecio.Enabled = true;
                this.CargarDatosPrincipales();
                if (this.compElectrAModificar is not null)
                {
                    switch (this.compElectrAModificar)
                    {
                        case Disco:
                            this.cmbTipoProducto.SelectedItem = "Disco";
                            this.cmbTipoDisco.Enabled = true;
                            this.cmbTipoDisco.SelectedItem = ((Disco)this.compElectrAModificar).Tipo;
                            this.txtTamanioDisco.Enabled = true;
                            this.txtTamanioDisco.Text = ((Disco)this.compElectrAModificar).EspacioTotal.ToString();
                            break;
                        case FuenteDePoder:
                            this.cmbTipoProducto.SelectedItem = "FuenteDePoder";
                            this.cmbTipoFuente.Enabled = true;
                            this.cmbTipoFuente.SelectedItem = ((FuenteDePoder)this.compElectrAModificar).TipoDeFuente;
                            break;
                        case Memoria:
                            this.cmbTipoProducto.SelectedItem = "Memoria";
                            this.cmbTipoMemoria.Enabled = true;
                            this.cmbTipoMemoria.SelectedItem = ((Memoria)this.compElectrAModificar).TipoMemoria;
                            this.cmbGeneracion.Enabled = true;
                            this.cmbGeneracion.SelectedItem = ((Memoria)this.compElectrAModificar).Tecnologia;
                            break;
                        case PlacaDeVideo:
                            this.cmbTipoProducto.SelectedItem = "PlacaDeVideo";
                            this.cmbTipoPlaca.Enabled = true;
                            this.cmbTipoPlaca.SelectedItem = ((PlacaDeVideo)this.compElectrAModificar).Tipo;
                            this.txBMemoriaGrafica.Enabled = true;
                            this.txBMemoriaGrafica.Text = ((PlacaDeVideo)this.compElectrAModificar).MemoriaGrafica.ToString();
                            break;
                        case PlacaMadre:
                            this.cmbTipoProducto.SelectedItem = "PlacaMadre";
                            this.cmbTipoMother.Enabled = true;
                            this.cmbTipoMother.SelectedItem = ((PlacaMadre)this.compElectrAModificar).TipoDeMother;
                            this.cmbSocket.Enabled = true;
                            this.cmbSocket.SelectedItem = ((PlacaMadre)this.compElectrAModificar).Socket;
                            break;
                        case Procesador:
                            this.cmbTipoProducto.SelectedItem = "Procesador";
                            this.cmbFabricanteCPU.Enabled = true;
                            this.cmbFabricanteCPU.SelectedItem = ((Procesador)this.compElectrAModificar).Fabricante;
                            this.cmbCantNucleos.Enabled = true;
                            this.cmbCantNucleos.SelectedItem = ((Procesador)this.compElectrAModificar).Nucleos;
                            break;
                    }
                }
            }            
        }
        #endregion
        private void btnModificar_Click(object sender, EventArgs e)
        {  
            switch(this.compElectrAModificar)
            {
                case Disco:
                    if (!string.IsNullOrWhiteSpace(this.txBModelo.Text) && !string.IsNullOrWhiteSpace(this.txBPotencia.Text) && !string.IsNullOrWhiteSpace(this.txBConsumo.Text) && !string.IsNullOrWhiteSpace(this.txBPrecio.Text) && !string.IsNullOrWhiteSpace(this.txtTamanioDisco.Text))
                    {
                        if (MessageBox.Show($"¿Confirma modificar los datos del producto actual?\n\n", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ((Disco)this.compElectrAModificar).Marca = (EMarcas)this.cmbMarcas.SelectedItem;
                            ((Disco)this.compElectrAModificar).Modelo = this.txBModelo.Text;
                            ((Disco)this.compElectrAModificar).Potencia = float.Parse(this.txBPotencia.Text);
                            ((Disco)this.compElectrAModificar).Consumo = float.Parse(this.txBConsumo.Text);
                            ((Disco)this.compElectrAModificar).Precio = float.Parse(this.txBPrecio.Text);
                            ((Disco)this.compElectrAModificar).Tipo = (ETipoDisco)this.cmbTipoDisco.SelectedItem;
                            ((Disco)this.compElectrAModificar).EspacioTotal = short.Parse(this.txtTamanioDisco.Text);
                        }
                    } else
                    {
                        MessageBox.Show("Se deben completar los campos correctamente para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                    
                    break;
                case FuenteDePoder:
                    if (!string.IsNullOrWhiteSpace(this.txBModelo.Text) && !string.IsNullOrWhiteSpace(this.txBPotencia.Text) && !string.IsNullOrWhiteSpace(this.txBConsumo.Text) && !string.IsNullOrWhiteSpace(this.txBPrecio.Text))
                    {
                        if (MessageBox.Show($"¿Confirma modificar los datos del producto actual?\n\n", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ((FuenteDePoder)this.compElectrAModificar).Marca = (EMarcas)this.cmbMarcas.SelectedItem;
                            ((FuenteDePoder)this.compElectrAModificar).Modelo = this.txBModelo.Text;
                            ((FuenteDePoder)this.compElectrAModificar).Potencia = float.Parse(this.txBPotencia.Text);
                            ((FuenteDePoder)this.compElectrAModificar).Consumo = float.Parse(this.txBConsumo.Text);
                            ((FuenteDePoder)this.compElectrAModificar).Precio = float.Parse(this.txBPrecio.Text);
                            ((FuenteDePoder)this.compElectrAModificar).TipoDeFuente = (ETipoFuente)this.cmbTipoFuente.SelectedItem;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se deben completar los campos correctamente para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                    
                    break;
                case Memoria:
                    if (!string.IsNullOrWhiteSpace(this.txBModelo.Text) && !string.IsNullOrWhiteSpace(this.txBPotencia.Text) && !string.IsNullOrWhiteSpace(this.txBConsumo.Text) && !string.IsNullOrWhiteSpace(this.txBPrecio.Text))
                    {
                        if (MessageBox.Show($"¿Confirma modificar los datos del producto actual?\n\n", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ((Memoria)this.compElectrAModificar).Marca = (EMarcas)this.cmbMarcas.SelectedItem;
                            ((Memoria)this.compElectrAModificar).Modelo = this.txBModelo.Text;
                            ((Memoria)this.compElectrAModificar).Potencia = float.Parse(this.txBPotencia.Text);
                            ((Memoria)this.compElectrAModificar).Consumo = float.Parse(this.txBConsumo.Text);
                            ((Memoria)this.compElectrAModificar).Precio = float.Parse(this.txBPrecio.Text);
                            ((Memoria)this.compElectrAModificar).TipoMemoria = (ETipoMemoria)this.cmbTipoMemoria.SelectedItem;
                            ((Memoria)this.compElectrAModificar).Tecnologia = (ETecnologiaMemoria)this.cmbGeneracion.SelectedItem;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se deben completar los campos correctamente para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                    
                    break;
                case PlacaDeVideo:
                    if (!string.IsNullOrWhiteSpace(this.txBModelo.Text) && !string.IsNullOrWhiteSpace(this.txBPotencia.Text) && !string.IsNullOrWhiteSpace(this.txBConsumo.Text) && !string.IsNullOrWhiteSpace(this.txBPrecio.Text) && !string.IsNullOrWhiteSpace(this.txBMemoriaGrafica.Text))
                    {
                        if (MessageBox.Show($"¿Confirma modificar los datos del producto actual?\n\n", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ((PlacaDeVideo)this.compElectrAModificar).Marca = (EMarcas)this.cmbMarcas.SelectedItem;
                            ((PlacaDeVideo)this.compElectrAModificar).Modelo = this.txBModelo.Text;
                            ((PlacaDeVideo)this.compElectrAModificar).Potencia = float.Parse(this.txBPotencia.Text);
                            ((PlacaDeVideo)this.compElectrAModificar).Consumo = float.Parse(this.txBConsumo.Text);
                            ((PlacaDeVideo)this.compElectrAModificar).Precio = float.Parse(this.txBPrecio.Text);
                            ((PlacaDeVideo)this.compElectrAModificar).Tipo = (ETipoPlaca)this.cmbTipoPlaca.SelectedItem;
                            ((PlacaDeVideo)this.compElectrAModificar).MemoriaGrafica = float.Parse(this.txBMemoriaGrafica.Text);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se deben completar los campos correctamente para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                    
                    break;
                case PlacaMadre:
                    if (!string.IsNullOrWhiteSpace(this.txBModelo.Text) && !string.IsNullOrWhiteSpace(this.txBPotencia.Text) && !string.IsNullOrWhiteSpace(this.txBConsumo.Text) && !string.IsNullOrWhiteSpace(this.txBPrecio.Text))
                    {
                        if (MessageBox.Show($"¿Confirma modificar los datos del producto actual?\n\n", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ((PlacaMadre)this.compElectrAModificar).Marca = (EMarcas)this.cmbMarcas.SelectedItem;
                            ((PlacaMadre)this.compElectrAModificar).Modelo = this.txBModelo.Text;
                            ((PlacaMadre)this.compElectrAModificar).Potencia = float.Parse(this.txBPotencia.Text);
                            ((PlacaMadre)this.compElectrAModificar).Consumo = float.Parse(this.txBConsumo.Text);
                            ((PlacaMadre)this.compElectrAModificar).Precio = float.Parse(this.txBPrecio.Text);
                            ((PlacaMadre)this.compElectrAModificar).TipoDeMother = (ETipoMother)this.cmbTipoMother.SelectedItem;
                            ((PlacaMadre)this.compElectrAModificar).Socket = (ESocket)this.cmbSocket.SelectedItem;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se deben completar los campos correctamente para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                    
                    break;
                case Procesador:
                    if (!string.IsNullOrWhiteSpace(this.txBModelo.Text) && !string.IsNullOrWhiteSpace(this.txBPotencia.Text) && !string.IsNullOrWhiteSpace(this.txBConsumo.Text) && !string.IsNullOrWhiteSpace(this.txBPrecio.Text))
                    {
                        if (MessageBox.Show($"¿Confirma modificar los datos del producto actual?\n\n", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ((Procesador)this.compElectrAModificar).Marca = (EMarcas)this.cmbMarcas.SelectedItem;
                            ((Procesador)this.compElectrAModificar).Modelo = this.txBModelo.Text;
                            ((Procesador)this.compElectrAModificar).Potencia = float.Parse(this.txBPotencia.Text);
                            ((Procesador)this.compElectrAModificar).Consumo = float.Parse(this.txBConsumo.Text);
                            ((Procesador)this.compElectrAModificar).Precio = float.Parse(this.txBPrecio.Text);
                            ((Procesador)this.compElectrAModificar).Fabricante = (EFabricanteCPU)this.cmbFabricanteCPU.SelectedItem;
                            ((Procesador)this.compElectrAModificar).Nucleos = (ECantidadNucleos)this.cmbCantNucleos.SelectedItem;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se deben completar los campos correctamente para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                    
                    break;
            }
            this.DialogResult = DialogResult.OK;
            try
            {
                DAO.ActualizarComponente(compElectrAModificar);
            } catch(System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("No se pudo aplicar los cambios a la base de datos!\n\nRazón: No existe la base de datos DC_DB.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } finally
            {
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
