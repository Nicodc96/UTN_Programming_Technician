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

namespace FrmTest1
{
    public partial class FrmTest : Form
    {
        Vendedor vendedor;
        public FrmTest()
        {
            InitializeComponent();
            this.vendedor = new Vendedor("Nicolas Díaz");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Biografia p1 = (Biografia)"Life (Keith Richards)";
            Biografia p2 = new Biografia("White line fever (Lemmy)", 5);
            Biografia p3 = new Biografia("Commando (Johnny Ramone)", 2, 5000);
            Comic p4 = new Comic("La Muerte de Superman (Superman)", true, 1, 1850);
            Comic p5 = new Comic("Año Uno (Batman)", false, 3, 1270);
            this.lstStock.Items.Add(p1);
            this.lstStock.Items.Add(p2);
            this.lstStock.Items.Add(p3);
            this.lstStock.Items.Add(p4);
            this.lstStock.Items.Add(p5);
            this.CenterToScreen();
        }

        private void lstStock_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (!(lstStock.SelectedItem is null))
            {
                if (this.vendedor + ((Publicacion)lstStock.SelectedItem) == true)
                {
                    MessageBox.Show("La venta se ha realizado correctamente!\n" + ((Publicacion)lstStock.SelectedItem).Informacion(), "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("La venta NO se ha podido realizar!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("No se ha realizado ninguna selección!","Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerInforme_Click(object sender, EventArgs e)
        {
            this.rtbInforme.Text = Vendedor.InformeDeVentas(this.vendedor);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("¿Confirmar Salida?", "Cerrar aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
