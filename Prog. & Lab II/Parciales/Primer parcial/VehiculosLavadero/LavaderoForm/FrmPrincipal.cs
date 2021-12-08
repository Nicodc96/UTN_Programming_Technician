using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace LavaderoForm
{
    public partial class frmPrincipal : Form
    {
        #region Atributos
        private Lavadero MiLavadero;
        #endregion
        public frmPrincipal()
        {
            InitializeComponent();
        }

        #region Métodos de Formularios
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.btnAgregarVehiculo.Enabled = false;
            this.btnInformarListaOrdenada.Enabled = false;
            this.btnInformarTipo.Enabled = false;
            this.btnQuitarVehiculo.Enabled = false;
            this.btnInformeGananciasTotal.Enabled = false;
            this.rBAuto.Checked = true;
            this.rBSinOrden.Checked = true;
            this.grpBOrdenamientos.Enabled = false;
            this.grpGananciasTipo.Enabled = false;
        }

        private void btnDefinirLavadero_Click(object sender, EventArgs e)
        {
            frmLavaderoPrecios frmLavadero = new frmLavaderoPrecios();
            frmLavadero.ShowDialog();
            if (!(frmLavadero.Nombre is null) || frmLavadero.PrecioAuto != 0 || frmLavadero.PrecioMoto != 0 || frmLavadero.PrecioCamion != 0)
            {
                this.lblNombreLavadero.Text = $"Lavadero: '{frmLavadero.Nombre}'";
                this.rTxtBPrecios.Text = $"Autos: ${frmLavadero.PrecioAuto}\nCamiones: ${frmLavadero.PrecioCamion}\nMotos: ${frmLavadero.PrecioMoto}";
                this.MiLavadero = new Lavadero(frmLavadero.PrecioAuto, frmLavadero.PrecioCamion, frmLavadero.PrecioMoto);
                this.btnAgregarVehiculo.Enabled = true;
                this.btnInformarListaOrdenada.Enabled = true;
                this.btnInformarTipo.Enabled = true;
                this.btnQuitarVehiculo.Enabled = true;
                this.btnInformeGananciasTotal.Enabled = true;
                this.btnDefinirLavadero.Enabled = false;
                this.grpBOrdenamientos.Enabled = true;
                this.grpGananciasTipo.Enabled = true;

                // ¿Agregar Datos pre-definidos?
                this.IngresoDeDatosForzados();
            }
        }

        private void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            frmIngresoVehiculo frmIngreso = new frmIngresoVehiculo();
            frmIngreso.ShowDialog();
            if (!(frmIngreso.GetVehiculo is null))
            {
                this.MiLavadero += frmIngreso.GetVehiculo;
                this.rTxtBActividad.Text += "-------------------------\n";
                this.rTxtBActividad.Text += "-- INGRESO DE VEHICULO --\n";
                this.rTxtBActividad.Text += $"{frmIngreso.GetVehiculo.ToString()}";
                this.rTxtBActividad.Text += "-------------------------\n";
            }
        }

        private void btnQuitarVehiculo_Click(object sender, EventArgs e)
        {
            frmSalidaVehiculo frmSalida = new frmSalidaVehiculo();
            frmSalida.LavaderoSalida = this.MiLavadero;
            frmSalida.ShowDialog();
            if (frmSalida.VehiculoRemovido != "")
            {
                this.rTxtBActividad.Text += "------------------------\n";
                this.rTxtBActividad.Text += "-- SALIDA DE VEHICULO --\n";
                this.rTxtBActividad.Text += frmSalida.VehiculoRemovido;
                this.rTxtBActividad.Text += "------------------------\n";
                this.MiLavadero = frmSalida.LavaderoSalida;
            }
        }

        private void btnInformarTipo_Click(object sender, EventArgs e)
        {
            if (this.rBAuto.Checked is true || this.rBCamion.Checked is true || this.rBMoto.Checked is true)
            {
                this.rTxtBActividad.Text += "------------------------\n";
                if (this.rBAuto.Checked is true)
                {
                    this.rTxtBActividad.Text += $"Ganancias por Autos: ${this.MiLavadero.MostrarTotalFacturado(EVehiculos.Auto)}\n";
                } else if (this.rBCamion.Checked is true)
                {
                    this.rTxtBActividad.Text += $"Ganancias por Camiones: ${this.MiLavadero.MostrarTotalFacturado(EVehiculos.Camion)}\n";
                } else
                {
                    this.rTxtBActividad.Text += $"Ganancias por Motos: ${this.MiLavadero.MostrarTotalFacturado(EVehiculos.Moto)}\n";
                }
                this.rTxtBActividad.Text += "------------------------\n";
            } else
            {
                MessageBox.Show("Se debe seleccionar al menos una opción para informar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnInformeGananciasTotal_Click(object sender, EventArgs e)
        {
            this.rTxtBActividad.Text += "------------------------\n";
            this.rTxtBActividad.Text += $"Ganancias totales: ${this.MiLavadero.MostrarTotalFacturado()}\n";
            this.rTxtBActividad.Text += "------------------------\n";
        }

        private void btnInformarListaOrdenada_Click(object sender, EventArgs e)
        {
            if (this.rBSinOrden.Checked is true)
            {
                this.rTxtBActividad.Text += "--------------------------\n";
                this.rTxtBActividad.Text += "- Vehiculos desordenados -\n";
                this.rTxtBActividad.Text += this.MiLavadero.LavaderoInfo;
                this.rTxtBActividad.Text += "--------------------------\n";
            } else if (this.rBPatente.Checked is true)
            {
                this.MiLavadero.Vehiculos.Sort(Lavadero.OrdenarVehiculosPorPatente);
                this.rTxtBActividad.Text += "---------------------------\n";
                this.rTxtBActividad.Text += "- Vehiculos según Patente -\n";
                this.rTxtBActividad.Text += this.MiLavadero.LavaderoInfo;
                this.rTxtBActividad.Text += "---------------------------\n";
                
            } else
            {
                this.MiLavadero.Vehiculos.Sort(Lavadero.OrdenarVehiculosPorMarca);
                this.rTxtBActividad.Text += "-------------------------\n";
                this.rTxtBActividad.Text += "- Vehiculos según Marca -\n";
                this.rTxtBActividad.Text += this.MiLavadero.LavaderoInfo;
                this.rTxtBActividad.Text += "-------------------------\n";
            }
        }
        #endregion

        #region Harcodeo de Datos
        private void IngresoDeDatosForzados()
        {
            this.MiLavadero.Vehiculos.Add(new Auto(4, "FA0003", 4, EMarcas.Ford));
            this.MiLavadero.Vehiculos.Add(new Auto(2, "CG231A", 4, EMarcas.Fiat));
            this.MiLavadero.Vehiculos.Add(new Auto(5, "LL351A", 4, EMarcas.Ford));
            this.MiLavadero.Vehiculos.Add(new Auto(2, "LX511A", 4, EMarcas.Honda));
            this.MiLavadero.Vehiculos.Add(new Camion(2345.13f, "LX013B", 10, EMarcas.Iveco));
            this.MiLavadero.Vehiculos.Add(new Camion(3177.58f, "UY331K", 8, EMarcas.Scania));
            this.MiLavadero.Vehiculos.Add(new Camion(3157, "KG583A", 10, EMarcas.Iveco));
            this.MiLavadero.Vehiculos.Add(new Camion(2945.79f, "PL2331", 6, EMarcas.Scania));
            this.MiLavadero.Vehiculos.Add(new Moto(125, "LA512A", 2, EMarcas.Honda));
            this.MiLavadero.Vehiculos.Add(new Moto(1000, "KL888L", 2, EMarcas.Zanella));
            this.MiLavadero.Vehiculos.Add(new Moto(250, "JJ531G", 2, EMarcas.Honda));
            this.MiLavadero.Vehiculos.Add(new Moto(500, "ZZ534L", 2, EMarcas.Zanella));
        }
        #endregion
    }
}
