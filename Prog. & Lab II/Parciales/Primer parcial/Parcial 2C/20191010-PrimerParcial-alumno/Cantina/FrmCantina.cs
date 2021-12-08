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
using ControlCantina;

namespace CantinaNico
{
    public partial class FrmCantina : Form
    {
        public FrmCantina()
        {
            InitializeComponent();
        }

        private void FrmCantina_Load(object sender, EventArgs e)
        {
            this.barra.SetCantina = Cantina.GetCantina(10);
            this.cmbBotellaTipo.DataSource = Enum.GetValues(typeof(Botella.Tipo));
            this.rBtnAgua.Checked = true;
        }

        private void cmbBotellaTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Botella.Tipo tipo;
            Enum.TryParse<Botella.Tipo>(cmbBotellaTipo.SelectedValue.ToString(), out tipo);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.rBtnAgua.Checked == true)
            {
                this.barra.AgregarBotella(new Agua(this.txtBMarca.Text, (int)this.numUpDownCapacidad.Value, (int)this.numUpDownContenido.Value));
            } else
            {
                this.barra.AgregarBotella(new Cerveza((int)this.numUpDownCapacidad.Value, this.txtBMarca.Text, (int)this.numUpDownContenido.Value));
            }
        }
    }
}
