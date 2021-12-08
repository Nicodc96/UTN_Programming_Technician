
namespace LavaderoForm
{
    partial class frmIngresoVehiculo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpBTipo = new System.Windows.Forms.GroupBox();
            this.rBMoto = new System.Windows.Forms.RadioButton();
            this.rBCamion = new System.Windows.Forms.RadioButton();
            this.rBAuto = new System.Windows.Forms.RadioButton();
            this.lblPatente = new System.Windows.Forms.Label();
            this.lblCantRuedas = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtBPatente = new System.Windows.Forms.TextBox();
            this.txtBCantRuedas = new System.Windows.Forms.TextBox();
            this.lblCantAsientos = new System.Windows.Forms.Label();
            this.grpBInfoExtra = new System.Windows.Forms.GroupBox();
            this.cmbCilindrada = new System.Windows.Forms.ComboBox();
            this.cmbCantAsientos = new System.Windows.Forms.ComboBox();
            this.txtBTara = new System.Windows.Forms.TextBox();
            this.lblCilindrada = new System.Windows.Forms.Label();
            this.lblTara = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.cmbMarcas = new System.Windows.Forms.ComboBox();
            this.grpBTipo.SuspendLayout();
            this.grpBInfoExtra.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBTipo
            // 
            this.grpBTipo.Controls.Add(this.rBMoto);
            this.grpBTipo.Controls.Add(this.rBCamion);
            this.grpBTipo.Controls.Add(this.rBAuto);
            this.grpBTipo.Location = new System.Drawing.Point(12, 12);
            this.grpBTipo.Name = "grpBTipo";
            this.grpBTipo.Size = new System.Drawing.Size(353, 54);
            this.grpBTipo.TabIndex = 0;
            this.grpBTipo.TabStop = false;
            this.grpBTipo.Text = "Tipo de vehiculo:";
            // 
            // rBMoto
            // 
            this.rBMoto.AutoSize = true;
            this.rBMoto.Location = new System.Drawing.Point(270, 22);
            this.rBMoto.Name = "rBMoto";
            this.rBMoto.Size = new System.Drawing.Size(54, 19);
            this.rBMoto.TabIndex = 2;
            this.rBMoto.Text = "Moto";
            this.rBMoto.UseVisualStyleBackColor = true;
            this.rBMoto.CheckedChanged += new System.EventHandler(this.rBMoto_CheckedChanged);
            // 
            // rBCamion
            // 
            this.rBCamion.AutoSize = true;
            this.rBCamion.Location = new System.Drawing.Point(123, 22);
            this.rBCamion.Name = "rBCamion";
            this.rBCamion.Size = new System.Drawing.Size(67, 19);
            this.rBCamion.TabIndex = 1;
            this.rBCamion.Text = "Camion";
            this.rBCamion.UseVisualStyleBackColor = true;
            this.rBCamion.CheckedChanged += new System.EventHandler(this.rBCamion_CheckedChanged);
            // 
            // rBAuto
            // 
            this.rBAuto.AutoSize = true;
            this.rBAuto.Location = new System.Drawing.Point(6, 22);
            this.rBAuto.Name = "rBAuto";
            this.rBAuto.Size = new System.Drawing.Size(51, 19);
            this.rBAuto.TabIndex = 0;
            this.rBAuto.Text = "Auto";
            this.rBAuto.UseVisualStyleBackColor = true;
            this.rBAuto.CheckedChanged += new System.EventHandler(this.rBAuto_CheckedChanged);
            // 
            // lblPatente
            // 
            this.lblPatente.AutoSize = true;
            this.lblPatente.Location = new System.Drawing.Point(77, 79);
            this.lblPatente.Name = "lblPatente";
            this.lblPatente.Size = new System.Drawing.Size(50, 15);
            this.lblPatente.TabIndex = 1;
            this.lblPatente.Text = "Patente:";
            // 
            // lblCantRuedas
            // 
            this.lblCantRuedas.AutoSize = true;
            this.lblCantRuedas.Location = new System.Drawing.Point(12, 113);
            this.lblCantRuedas.Name = "lblCantRuedas";
            this.lblCantRuedas.Size = new System.Drawing.Size(115, 15);
            this.lblCantRuedas.TabIndex = 2;
            this.lblCantRuedas.Text = "Cantidad de Ruedas:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(84, 146);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(43, 15);
            this.lblMarca.TabIndex = 3;
            this.lblMarca.Text = "Marca:";
            // 
            // txtBPatente
            // 
            this.txtBPatente.Location = new System.Drawing.Point(133, 76);
            this.txtBPatente.Name = "txtBPatente";
            this.txtBPatente.Size = new System.Drawing.Size(195, 23);
            this.txtBPatente.TabIndex = 4;
            this.txtBPatente.TextChanged += new System.EventHandler(this.txtBPatente_TextChanged);
            this.txtBPatente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyTextNumbers_KeyPress);
            // 
            // txtBCantRuedas
            // 
            this.txtBCantRuedas.Location = new System.Drawing.Point(133, 110);
            this.txtBCantRuedas.Name = "txtBCantRuedas";
            this.txtBCantRuedas.Size = new System.Drawing.Size(195, 23);
            this.txtBCantRuedas.TabIndex = 5;
            this.txtBCantRuedas.TextChanged += new System.EventHandler(this.txtBCantRuedas_TextChanged);
            this.txtBCantRuedas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyNumerics_KeyPress);
            // 
            // lblCantAsientos
            // 
            this.lblCantAsientos.AutoSize = true;
            this.lblCantAsientos.Location = new System.Drawing.Point(6, 28);
            this.lblCantAsientos.Name = "lblCantAsientos";
            this.lblCantAsientos.Size = new System.Drawing.Size(120, 15);
            this.lblCantAsientos.TabIndex = 8;
            this.lblCantAsientos.Text = "Cantidad de asientos:";
            // 
            // grpBInfoExtra
            // 
            this.grpBInfoExtra.Controls.Add(this.cmbCilindrada);
            this.grpBInfoExtra.Controls.Add(this.cmbCantAsientos);
            this.grpBInfoExtra.Controls.Add(this.txtBTara);
            this.grpBInfoExtra.Controls.Add(this.lblCilindrada);
            this.grpBInfoExtra.Controls.Add(this.lblTara);
            this.grpBInfoExtra.Controls.Add(this.lblCantAsientos);
            this.grpBInfoExtra.Location = new System.Drawing.Point(19, 181);
            this.grpBInfoExtra.Name = "grpBInfoExtra";
            this.grpBInfoExtra.Size = new System.Drawing.Size(345, 127);
            this.grpBInfoExtra.TabIndex = 9;
            this.grpBInfoExtra.TabStop = false;
            this.grpBInfoExtra.Text = "Información Adicional:";
            // 
            // cmbCilindrada
            // 
            this.cmbCilindrada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCilindrada.FormattingEnabled = true;
            this.cmbCilindrada.Location = new System.Drawing.Point(130, 87);
            this.cmbCilindrada.Name = "cmbCilindrada";
            this.cmbCilindrada.Size = new System.Drawing.Size(133, 23);
            this.cmbCilindrada.TabIndex = 15;
            // 
            // cmbCantAsientos
            // 
            this.cmbCantAsientos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCantAsientos.FormattingEnabled = true;
            this.cmbCantAsientos.Location = new System.Drawing.Point(130, 25);
            this.cmbCantAsientos.Name = "cmbCantAsientos";
            this.cmbCantAsientos.Size = new System.Drawing.Size(133, 23);
            this.cmbCantAsientos.TabIndex = 14;
            // 
            // txtBTara
            // 
            this.txtBTara.Location = new System.Drawing.Point(130, 57);
            this.txtBTara.Name = "txtBTara";
            this.txtBTara.Size = new System.Drawing.Size(133, 23);
            this.txtBTara.TabIndex = 12;
            this.txtBTara.TextChanged += new System.EventHandler(this.txtBTara_TextChanged);
            this.txtBTara.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyNumerics_KeyPress);
            // 
            // lblCilindrada
            // 
            this.lblCilindrada.AutoSize = true;
            this.lblCilindrada.Location = new System.Drawing.Point(62, 90);
            this.lblCilindrada.Name = "lblCilindrada";
            this.lblCilindrada.Size = new System.Drawing.Size(64, 15);
            this.lblCilindrada.TabIndex = 10;
            this.lblCilindrada.Text = "Cilindrada:";
            // 
            // lblTara
            // 
            this.lblTara.AutoSize = true;
            this.lblTara.Location = new System.Drawing.Point(95, 58);
            this.lblTara.Name = "lblTara";
            this.lblTara.Size = new System.Drawing.Size(31, 15);
            this.lblTara.TabIndex = 9;
            this.lblTara.Text = "Tara:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(241, 328);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(123, 38);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(18, 328);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(123, 38);
            this.btnIngresar.TabIndex = 11;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // cmbMarcas
            // 
            this.cmbMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarcas.Location = new System.Drawing.Point(131, 144);
            this.cmbMarcas.Name = "cmbMarcas";
            this.cmbMarcas.Size = new System.Drawing.Size(196, 23);
            this.cmbMarcas.TabIndex = 12;
            // 
            // frmIngresoVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 375);
            this.Controls.Add(this.cmbMarcas);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpBInfoExtra);
            this.Controls.Add(this.txtBCantRuedas);
            this.Controls.Add(this.txtBPatente);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblCantRuedas);
            this.Controls.Add(this.lblPatente);
            this.Controls.Add(this.grpBTipo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIngresoVehiculo";
            this.Text = "Agregar vehiculo al lavadero";
            this.Load += new System.EventHandler(this.frmIngresoVehiculo_Load);
            this.grpBTipo.ResumeLayout(false);
            this.grpBTipo.PerformLayout();
            this.grpBInfoExtra.ResumeLayout(false);
            this.grpBInfoExtra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBTipo;
        private System.Windows.Forms.RadioButton rBMoto;
        private System.Windows.Forms.RadioButton rBCamion;
        private System.Windows.Forms.RadioButton rBAuto;
        private System.Windows.Forms.Label lblPatente;
        private System.Windows.Forms.Label lblCantRuedas;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox txtBPatente;
        private System.Windows.Forms.TextBox txtBCantRuedas;
        private System.Windows.Forms.Label lblCantAsientos;
        private System.Windows.Forms.GroupBox grpBInfoExtra;
        private System.Windows.Forms.TextBox txtBTara;
        private System.Windows.Forms.Label lblCilindrada;
        private System.Windows.Forms.Label lblTara;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.ComboBox cmbCilindrada;
        private System.Windows.Forms.ComboBox cmbCantAsientos;
        private System.Windows.Forms.ComboBox cmbMarcas;
    }
}