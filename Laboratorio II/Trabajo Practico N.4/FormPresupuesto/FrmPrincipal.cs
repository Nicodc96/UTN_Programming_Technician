using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Entidades;
using Entidades.Serializador;
using System.Threading.Tasks;
using Entidades.Extension;
using Entidades.BaseDeDatos;

namespace Formularios
{    
    public partial class FrmPrincipal : Form
    {
        #region Atributos internos
        private List<Cliente> listaClientes;
        private List<Presupuesto> listaPresupuestos;
        private List<ComponenteElectronico> listaComponentes;
        private SerializadorXML<List<Cliente>> serializadorClientes;
        private SerializadorXML<List<Presupuesto>> serializadorPresupuestos;
        private SerializadorXML<List<ComponenteElectronico>> serializadorComponentes;
        public Task actualizadorHoraFecha;
        #endregion
        public FrmPrincipal()
        {
            InitializeComponent();
            this.listaClientes = new List<Cliente>();
            this.listaPresupuestos = new List<Presupuesto>();
            this.listaComponentes = new List<ComponenteElectronico>();
            this.serializadorClientes = new SerializadorXML<List<Cliente>>();
            this.serializadorPresupuestos = new SerializadorXML<List<Presupuesto>>();
            this.serializadorComponentes = new SerializadorXML<List<ComponenteElectronico>>();
            this.actualizadorHoraFecha = new Task(new Action(ActualizarFechaHora));
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
            try
            {
                this.CargarPrimeraVezDatosEnBD();
            } catch (System.Data.SqlClient.SqlException)
            {
                /* 
                 * Se captura excepción si no se pudo cargar datos, pero no se notifica al usuario, para evitar un mensaje
                 * repetitivo y molesto a la hora de abrir la aplicación. De igual manera se notificará cuando se utilice
                 * las demás funciones de la misma.
                 * */
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

        private void ActualizarFechaHora()
        {
            while(true)
            {
                this.actualizadorHoraFecha.Wait(1000);
                if (this.lblFecha.InvokeRequired && this.lblHora.InvokeRequired)
                {
                    this.lblFecha.BeginInvoke((EventHandler)horaFecha_Tick);
                    this.lblHora.BeginInvoke((EventHandler)horaFecha_Tick);
                } else
                {
                    this.lblFecha.BeginInvoke((EventHandler)horaFecha_Tick);
                    this.lblHora.BeginInvoke((EventHandler)horaFecha_Tick);
                }
            }
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
            frmEstadisticas formEstadisticas = new frmEstadisticas();
            this.AbrirFormMenu(formEstadisticas);
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Confirma salir de la aplicación?", "Confirmación de salida", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                if (this.actualizadorHoraFecha.Status == TaskStatus.Running)
                {
                    this.actualizadorHoraFecha.Dispose();
                }
                e.Cancel = true;
            }
        }

        #region Cargar datos de archivos locales
        private void CargarDatosEnListas()
        {
            try
            {
                if (!File.Exists(serializadorClientes.RutaBase + @"Datos\ResumenClientes.xml"))
                {
                    this.listaClientes = serializadorClientes.RecuperarDatos(Path.Combine(Environment.CurrentDirectory, @"Datos\ListaClientes.xml"));
                }
                else
                {
                    this.listaClientes = serializadorClientes.RecuperarDatos(Path.Combine(serializadorClientes.RutaBase, @"Datos\ResumenClientes.xml"));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se han podido cargar los datos de los clientes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (!File.Exists(serializadorPresupuestos.RutaBase + @"Datos\ResumenPresupuestos.xml"))
                {
                    this.listaPresupuestos = serializadorPresupuestos.RecuperarDatos(Path.Combine(Environment.CurrentDirectory, @"Datos\ListaPresupuestos.xml"));
                }
                else
                {
                    this.listaPresupuestos = serializadorPresupuestos.RecuperarDatos(Path.Combine(serializadorPresupuestos.RutaBase, @"Datos\ResumenPresupuestos.xml"));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se han podido cargar los datos de los presupuestos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (!File.Exists(serializadorComponentes.RutaBase + @"Datos\ResumenComponentes.xml"))
                {
                    this.listaComponentes = serializadorComponentes.RecuperarDatos(Path.Combine(Environment.CurrentDirectory, @"Datos\ListaComponentes.xml"));
                }
                else
                {
                    this.listaComponentes = serializadorComponentes.RecuperarDatos(Path.Combine(serializadorComponentes.RutaBase, @"Datos\ResumenComponentes.xml"));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se han podido cargar los datos de los componentes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Cargar datos en BD
        private void CargarPrimeraVezDatosEnBD()
        {
            this.CargarDatosEnListas();
            foreach (Cliente c in this.listaClientes)
            {
                c.GuardarClienteEnBD();
            }
            foreach (Presupuesto p in this.listaPresupuestos)
            {
                p.GuardarPresupuestoEnBD();
            }
            foreach (ComponenteElectronico cE in this.listaComponentes)
            {
                cE.GuardarComponenteEnBD();
            }
            DAO.GenerarDespensas(this.listaPresupuestos);
        }
        #endregion
    }
}
