
namespace Formularios
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.pBarraTitulo = new System.Windows.Forms.Panel();
            this.lblTituloFormulario = new System.Windows.Forms.Label();
            this.pBtnMinimizar = new System.Windows.Forms.PictureBox();
            this.pBtnCerrar = new System.Windows.Forms.PictureBox();
            this.pMenu = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.pBAcercaDe = new System.Windows.Forms.PictureBox();
            this.btnEstadisticas = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClientes = new System.Windows.Forms.Button();
            this.pBLogoMenu = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPresupuestos = new System.Windows.Forms.Button();
            this.pContenidoMenu = new System.Windows.Forms.Panel();
            this.horaFecha = new System.Windows.Forms.Timer(this.components);
            this.pBarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBtnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBtnCerrar)).BeginInit();
            this.pMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBAcercaDe)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBLogoMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // pBarraTitulo
            // 
            this.pBarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(140)))));
            this.pBarraTitulo.Controls.Add(this.lblTituloFormulario);
            this.pBarraTitulo.Controls.Add(this.pBtnMinimizar);
            this.pBarraTitulo.Controls.Add(this.pBtnCerrar);
            this.pBarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pBarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.pBarraTitulo.Name = "pBarraTitulo";
            this.pBarraTitulo.Size = new System.Drawing.Size(1113, 30);
            this.pBarraTitulo.TabIndex = 0;
            this.pBarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBarraTitulo_MouseDown);
            // 
            // lblTituloFormulario
            // 
            this.lblTituloFormulario.AutoSize = true;
            this.lblTituloFormulario.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloFormulario.Location = new System.Drawing.Point(388, 7);
            this.lblTituloFormulario.Name = "lblTituloFormulario";
            this.lblTituloFormulario.Size = new System.Drawing.Size(320, 18);
            this.lblTituloFormulario.TabIndex = 2;
            this.lblTituloFormulario.Text = "Presupuestos - Clientes | DC Computación";
            // 
            // pBtnMinimizar
            // 
            this.pBtnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBtnMinimizar.Image = global::Formularios.Properties.Resources.minimizar;
            this.pBtnMinimizar.Location = new System.Drawing.Point(1053, 7);
            this.pBtnMinimizar.Name = "pBtnMinimizar";
            this.pBtnMinimizar.Size = new System.Drawing.Size(26, 21);
            this.pBtnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBtnMinimizar.TabIndex = 1;
            this.pBtnMinimizar.TabStop = false;
            this.pBtnMinimizar.Click += new System.EventHandler(this.pBtnMinimizar_Click);
            // 
            // pBtnCerrar
            // 
            this.pBtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBtnCerrar.Image = global::Formularios.Properties.Resources.cerrar;
            this.pBtnCerrar.Location = new System.Drawing.Point(1085, 3);
            this.pBtnCerrar.Name = "pBtnCerrar";
            this.pBtnCerrar.Size = new System.Drawing.Size(25, 25);
            this.pBtnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBtnCerrar.TabIndex = 0;
            this.pBtnCerrar.TabStop = false;
            this.pBtnCerrar.Click += new System.EventHandler(this.pBtnCerrar_Click);
            // 
            // pMenu
            // 
            this.pMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.pMenu.Controls.Add(this.lblFecha);
            this.pMenu.Controls.Add(this.lblHora);
            this.pMenu.Controls.Add(this.pBAcercaDe);
            this.pMenu.Controls.Add(this.btnEstadisticas);
            this.pMenu.Controls.Add(this.btnProductos);
            this.pMenu.Controls.Add(this.panel5);
            this.pMenu.Controls.Add(this.panel3);
            this.pMenu.Controls.Add(this.panel2);
            this.pMenu.Controls.Add(this.btnClientes);
            this.pMenu.Controls.Add(this.pBLogoMenu);
            this.pMenu.Controls.Add(this.panel1);
            this.pMenu.Controls.Add(this.btnPresupuestos);
            this.pMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pMenu.Location = new System.Drawing.Point(0, 30);
            this.pMenu.Name = "pMenu";
            this.pMenu.Size = new System.Drawing.Size(211, 572);
            this.pMenu.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFecha.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFecha.Location = new System.Drawing.Point(55, 549);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 18);
            this.lblFecha.TabIndex = 10;
            this.lblFecha.Text = "fecha";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHora.Location = new System.Drawing.Point(55, 527);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(53, 22);
            this.lblHora.TabIndex = 9;
            this.lblHora.Text = "hora";
            // 
            // pBAcercaDe
            // 
            this.pBAcercaDe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBAcercaDe.Image = global::Formularios.Properties.Resources.acercade11;
            this.pBAcercaDe.Location = new System.Drawing.Point(9, 527);
            this.pBAcercaDe.Name = "pBAcercaDe";
            this.pBAcercaDe.Size = new System.Drawing.Size(40, 33);
            this.pBAcercaDe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBAcercaDe.TabIndex = 8;
            this.pBAcercaDe.TabStop = false;
            this.pBAcercaDe.Click += new System.EventHandler(this.pBAcercaDe_Click);
            // 
            // btnEstadisticas
            // 
            this.btnEstadisticas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstadisticas.FlatAppearance.BorderSize = 0;
            this.btnEstadisticas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(140)))));
            this.btnEstadisticas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadisticas.Image = global::Formularios.Properties.Resources.estadistica;
            this.btnEstadisticas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstadisticas.Location = new System.Drawing.Point(9, 368);
            this.btnEstadisticas.Name = "btnEstadisticas";
            this.btnEstadisticas.Size = new System.Drawing.Size(202, 34);
            this.btnEstadisticas.TabIndex = 7;
            this.btnEstadisticas.Text = "Estadísticas";
            this.btnEstadisticas.UseVisualStyleBackColor = true;
            this.btnEstadisticas.Click += new System.EventHandler(this.btnEstadisticas_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(140)))));
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Image = global::Formularios.Properties.Resources.producto;
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Location = new System.Drawing.Point(9, 310);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(202, 34);
            this.btnProductos.TabIndex = 6;
            this.btnProductos.Text = "Productos";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(140)))));
            this.panel5.Location = new System.Drawing.Point(0, 368);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 34);
            this.panel5.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(140)))));
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(0, 310);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 34);
            this.panel3.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(160)))));
            this.panel4.Location = new System.Drawing.Point(0, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 34);
            this.panel4.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(140)))));
            this.panel2.Location = new System.Drawing.Point(0, 251);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 34);
            this.panel2.TabIndex = 4;
            // 
            // btnClientes
            // 
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(140)))));
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Image = global::Formularios.Properties.Resources.clientes;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(9, 251);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(202, 34);
            this.btnClientes.TabIndex = 3;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // pBLogoMenu
            // 
            this.pBLogoMenu.Image = global::Formularios.Properties.Resources.LogoTP;
            this.pBLogoMenu.Location = new System.Drawing.Point(0, 15);
            this.pBLogoMenu.Name = "pBLogoMenu";
            this.pBLogoMenu.Size = new System.Drawing.Size(211, 157);
            this.pBLogoMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBLogoMenu.TabIndex = 2;
            this.pBLogoMenu.TabStop = false;
            this.pBLogoMenu.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(140)))));
            this.panel1.Location = new System.Drawing.Point(0, 199);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 34);
            this.panel1.TabIndex = 1;
            // 
            // btnPresupuestos
            // 
            this.btnPresupuestos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPresupuestos.FlatAppearance.BorderSize = 0;
            this.btnPresupuestos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(140)))));
            this.btnPresupuestos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPresupuestos.Image = global::Formularios.Properties.Resources.presupuesto1;
            this.btnPresupuestos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPresupuestos.Location = new System.Drawing.Point(9, 199);
            this.btnPresupuestos.Name = "btnPresupuestos";
            this.btnPresupuestos.Size = new System.Drawing.Size(202, 34);
            this.btnPresupuestos.TabIndex = 0;
            this.btnPresupuestos.Text = "Presupuestos";
            this.btnPresupuestos.UseVisualStyleBackColor = true;
            this.btnPresupuestos.Click += new System.EventHandler(this.btnPresupuestos_Click);
            // 
            // pContenidoMenu
            // 
            this.pContenidoMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.pContenidoMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pContenidoMenu.Location = new System.Drawing.Point(211, 30);
            this.pContenidoMenu.Name = "pContenidoMenu";
            this.pContenidoMenu.Size = new System.Drawing.Size(902, 572);
            this.pContenidoMenu.TabIndex = 2;
            // 
            // horaFecha
            // 
            this.horaFecha.Enabled = true;
            this.horaFecha.Tick += new System.EventHandler(this.horaFecha_Tick);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(1113, 602);
            this.Controls.Add(this.pContenidoMenu);
            this.Controls.Add(this.pMenu);
            this.Controls.Add(this.pBarraTitulo);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar presupuesto - DC Computación";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.pBarraTitulo.ResumeLayout(false);
            this.pBarraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBtnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBtnCerrar)).EndInit();
            this.pMenu.ResumeLayout(false);
            this.pMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBAcercaDe)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBLogoMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBarraTitulo;
        private System.Windows.Forms.PictureBox pBtnCerrar;
        private System.Windows.Forms.Panel pMenu;
        private System.Windows.Forms.Panel pContenidoMenu;
        private System.Windows.Forms.PictureBox pBtnMinimizar;
        private System.Windows.Forms.Button btnPresupuestos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTituloFormulario;
        private System.Windows.Forms.PictureBox pBLogoMenu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnEstadisticas;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.PictureBox pBAcercaDe;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Timer horaFecha;
    }
}

