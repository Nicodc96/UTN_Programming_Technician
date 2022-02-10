using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Entidades;
using Entidades.Serializador;

namespace Formularios
{    
    public partial class FrmPrincipal : Form
    {
        private List<Presupuesto> listaPresupuestos;
        private List<Cliente> listaClientes;
        public FrmPrincipal()
        {
            InitializeComponent();
            this.listaPresupuestos = new List<Presupuesto>();
            this.listaClientes = new List<Cliente>();
        }

        private void pBtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pBtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            pBAcercaDe_Click(null, e);
            SerializadorXML<List<Cliente>> serClientes = new SerializadorXML<List<Cliente>>();
            try
            {
                this.listaClientes = serClientes.RecuperarDatos(Path.Combine(Environment.CurrentDirectory, @"Datos\ListaClientes.xml"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se ha producido un error al cargar los datos!\n\n" + ex.Message);
            }

        }

        #region Abrir formularios desde menú
        private void AbrirFormMenu(object formParam)
        {
            if (this.pContenidoMenu.Controls.Count > 0)
            {
                this.pContenidoMenu.Controls.RemoveAt(0);
            }
            Form newForm = formParam as Form;
            newForm.TopLevel = false;
            newForm.Dock = DockStyle.Fill;
            this.pContenidoMenu.Controls.Add(newForm);
            this.pContenidoMenu.Tag = newForm;
            newForm.Show();
        }
        #endregion

        #region Control para mover ventana
        /*
         * Esta sección tiene la única finalidad de incorporar a un control en su evento
         * MouseDown la capacidad de permitir mover el formulario.
         */
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Logo
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo pInfo = new ProcessStartInfo()
                {
                    FileName = "http://www.facebook.com/dcdiazcomputacion/",
                    UseShellExecute = true
                };
                Process.Start(pInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error! No se ha podido abrir el link solicitado.\n\nDetalles del error:\n{ex.Message}");
            }
        }
        #endregion

        private void pBAcercaDe_Click(object sender, EventArgs e)
        {
            this.AbrirFormMenu(new FrmInformacion());
        }
        /// <summary>
        /// Método para mostrar la hora y fecha en el formulario principal<br></br>
        /// AVISO: Este método puede resultar molesto a la hora de debuggear, se recomienda comentar.
        /// </summary>
        private void horaFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToShortTimeString();
            lblFecha.Text = DateTime.Now.ToString("d");
        }

        private void btnPresupuestos_Click(object sender, EventArgs e)
        {
            this.AbrirFormMenu(new frmPresupuestos());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            this.AbrirFormMenu(new frmProductos());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.AbrirFormMenu(new frmClientes());
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            this.AbrirFormMenu(new frmEstadisticas());
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?\n\nCualquier información que no se haya guardado se perderá.", "Atención!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
