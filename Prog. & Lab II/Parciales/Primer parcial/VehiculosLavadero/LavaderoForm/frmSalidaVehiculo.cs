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
    public partial class frmSalidaVehiculo : Form
    {
        #region Atributos Auxiliares
        private Lavadero lavaderoAux;
        private string vehiculoRemovido;
        #endregion

        #region Propiedades Auxiliares
        public Lavadero LavaderoSalida
        {
            set { this.lavaderoAux = value; }
            get { return this.lavaderoAux; }
        }
        public string VehiculoRemovido
        {
            set { this.vehiculoRemovido = value; }
            get { return this.vehiculoRemovido; }
        }
        #endregion

        public frmSalidaVehiculo()
        {
            InitializeComponent();
            this.VehiculoRemovido = "";
        }

        private void frmSalidaVehiculo_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            foreach (Vehiculo v in LavaderoSalida.Vehiculos)
            {
                this.lstVehiculos.Items.Add(v.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (this.lstVehiculos.SelectedItem is null)
            {
                MessageBox.Show("Debe seleccionar un vehiculo antes de continuar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                if (MessageBox.Show($"Confirmar salida:\n\n{this.lstVehiculos.SelectedItem}", "Salida vehiculo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.VehiculoRemovido = this.lstVehiculos.SelectedItem.ToString();
                    for (int i = 0; i < LavaderoSalida.Vehiculos.Count; i++)
                    {
                        if (LavaderoSalida.Vehiculos[i] is Auto && LavaderoSalida.Vehiculos[i].ToString() == this.lstVehiculos.SelectedItem.ToString())
                        {
                            this.LavaderoSalida -= LavaderoSalida.Vehiculos[i];
                            break;
                        }
                        if (LavaderoSalida.Vehiculos[i] is Camion && LavaderoSalida.Vehiculos[i].ToString() == this.lstVehiculos.SelectedItem.ToString())
                        {
                            this.LavaderoSalida -= LavaderoSalida.Vehiculos[i];
                            break;
                        }
                        if (LavaderoSalida.Vehiculos[i] is Moto && LavaderoSalida.Vehiculos[i].ToString() == this.lstVehiculos.SelectedItem.ToString())
                        {
                            this.LavaderoSalida -= LavaderoSalida.Vehiculos[i];
                            break;
                        }
                    }
                    this.Close();
                }                
            }
        }
    }
}
