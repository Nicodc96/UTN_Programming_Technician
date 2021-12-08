
namespace FrmPrincipal
{
    partial class frmEstacionamiento
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblVehiculo = new System.Windows.Forms.Label();
            this.lblPatente = new System.Windows.Forms.Label();
            this.btnAgregarVehiculo = new System.Windows.Forms.Button();
            this.cmbTipoVehiculo = new System.Windows.Forms.ComboBox();
            this.cmbTipoMoto = new System.Windows.Forms.ComboBox();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.lstVehiculos = new System.Windows.Forms.ListBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtEstacionamiento = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblVehiculo
            // 
            this.lblVehiculo.AutoSize = true;
            this.lblVehiculo.Location = new System.Drawing.Point(20, 48);
            this.lblVehiculo.Name = "lblVehiculo";
            this.lblVehiculo.Size = new System.Drawing.Size(72, 13);
            this.lblVehiculo.TabIndex = 0;
            this.lblVehiculo.Text = "Tipo Vehiculo";
            // 
            // lblPatente
            // 
            this.lblPatente.AutoSize = true;
            this.lblPatente.Location = new System.Drawing.Point(43, 81);
            this.lblPatente.Name = "lblPatente";
            this.lblPatente.Size = new System.Drawing.Size(47, 13);
            this.lblPatente.TabIndex = 1;
            this.lblPatente.Text = "Patente:";
            // 
            // btnAgregarVehiculo
            // 
            this.btnAgregarVehiculo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAgregarVehiculo.Location = new System.Drawing.Point(23, 378);
            this.btnAgregarVehiculo.Name = "btnAgregarVehiculo";
            this.btnAgregarVehiculo.Size = new System.Drawing.Size(171, 48);
            this.btnAgregarVehiculo.TabIndex = 3;
            this.btnAgregarVehiculo.Text = "Agregar Vehiculo";
            this.btnAgregarVehiculo.UseVisualStyleBackColor = false;
            this.btnAgregarVehiculo.Click += new System.EventHandler(this.btnAgregarVehiculo_Click);
            // 
            // cmbTipoVehiculo
            // 
            this.cmbTipoVehiculo.FormattingEnabled = true;
            this.cmbTipoVehiculo.Location = new System.Drawing.Point(97, 45);
            this.cmbTipoVehiculo.Name = "cmbTipoVehiculo";
            this.cmbTipoVehiculo.Size = new System.Drawing.Size(119, 21);
            this.cmbTipoVehiculo.TabIndex = 4;
            this.cmbTipoVehiculo.SelectedIndexChanged += new System.EventHandler(this.cmbTipoVehiculo_SelectedIndexChanged);
            // 
            // cmbTipoMoto
            // 
            this.cmbTipoMoto.FormattingEnabled = true;
            this.cmbTipoMoto.Location = new System.Drawing.Point(96, 108);
            this.cmbTipoMoto.Name = "cmbTipoMoto";
            this.cmbTipoMoto.Size = new System.Drawing.Size(120, 21);
            this.cmbTipoMoto.TabIndex = 5;
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(96, 78);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(120, 20);
            this.txtPatente.TabIndex = 6;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(234, 91);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(123, 20);
            this.txtMarca.TabIndex = 7;
            // 
            // lstVehiculos
            // 
            this.lstVehiculos.BackColor = System.Drawing.Color.LightGreen;
            this.lstVehiculos.FormattingEnabled = true;
            this.lstVehiculos.Location = new System.Drawing.Point(387, 110);
            this.lstVehiculos.Name = "lstVehiculos";
            this.lstVehiculos.Size = new System.Drawing.Size(401, 316);
            this.lstVehiculos.TabIndex = 9;
            this.lstVehiculos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstVehiculos_MouseDoubleClick);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(33, 111);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(0, 13);
            this.lblTipo.TabIndex = 10;
            // 
            // txtEstacionamiento
            // 
            this.txtEstacionamiento.BackColor = System.Drawing.Color.LightGreen;
            this.txtEstacionamiento.Location = new System.Drawing.Point(385, 17);
            this.txtEstacionamiento.Name = "txtEstacionamiento";
            this.txtEstacionamiento.Size = new System.Drawing.Size(402, 73);
            this.txtEstacionamiento.TabIndex = 11;
            this.txtEstacionamiento.Text = "";
            // 
            // frmEstacionamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtEstacionamiento);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lstVehiculos);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.txtPatente);
            this.Controls.Add(this.cmbTipoMoto);
            this.Controls.Add(this.cmbTipoVehiculo);
            this.Controls.Add(this.btnAgregarVehiculo);
            this.Controls.Add(this.lblPatente);
            this.Controls.Add(this.lblVehiculo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEstacionamiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RPP.Diaz.Lautaro.2C";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVehiculo;
        private System.Windows.Forms.Label lblPatente;
        private System.Windows.Forms.Button btnAgregarVehiculo;
        private System.Windows.Forms.ComboBox cmbTipoVehiculo;
        private System.Windows.Forms.ComboBox cmbTipoMoto;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.ListBox lstVehiculos;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.RichTextBox txtEstacionamiento;
    }
}

