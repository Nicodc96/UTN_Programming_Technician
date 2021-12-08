
namespace CantinaNico
{
    partial class FrmCantina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCantina));
            this.cmbBotellaTipo = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtBMarca = new System.Windows.Forms.TextBox();
            this.numUpDownCapacidad = new System.Windows.Forms.NumericUpDown();
            this.numUpDownContenido = new System.Windows.Forms.NumericUpDown();
            this.rBtnCerveza = new System.Windows.Forms.RadioButton();
            this.rBtnAgua = new System.Windows.Forms.RadioButton();
            this.grpCantina = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblContenido = new System.Windows.Forms.Label();
            this.lblCapacidad = new System.Windows.Forms.Label();
            this.barra = new ControlCantina.Barra();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCapacidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownContenido)).BeginInit();
            this.grpCantina.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbBotellaTipo
            // 
            this.cmbBotellaTipo.FormattingEnabled = true;
            this.cmbBotellaTipo.Location = new System.Drawing.Point(436, 38);
            this.cmbBotellaTipo.Name = "cmbBotellaTipo";
            this.cmbBotellaTipo.Size = new System.Drawing.Size(140, 21);
            this.cmbBotellaTipo.TabIndex = 0;
            this.cmbBotellaTipo.SelectedIndexChanged += new System.EventHandler(this.cmbBotellaTipo_SelectedIndexChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(436, 65);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(137, 45);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtBMarca
            // 
            this.txtBMarca.Location = new System.Drawing.Point(208, 39);
            this.txtBMarca.Name = "txtBMarca";
            this.txtBMarca.Size = new System.Drawing.Size(163, 20);
            this.txtBMarca.TabIndex = 2;
            // 
            // numUpDownCapacidad
            // 
            this.numUpDownCapacidad.Location = new System.Drawing.Point(208, 90);
            this.numUpDownCapacidad.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numUpDownCapacidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownCapacidad.Name = "numUpDownCapacidad";
            this.numUpDownCapacidad.Size = new System.Drawing.Size(63, 20);
            this.numUpDownCapacidad.TabIndex = 3;
            this.numUpDownCapacidad.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numUpDownContenido
            // 
            this.numUpDownContenido.Location = new System.Drawing.Point(311, 90);
            this.numUpDownContenido.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numUpDownContenido.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownContenido.Name = "numUpDownContenido";
            this.numUpDownContenido.Size = new System.Drawing.Size(60, 20);
            this.numUpDownContenido.TabIndex = 4;
            this.numUpDownContenido.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // rBtnCerveza
            // 
            this.rBtnCerveza.AutoSize = true;
            this.rBtnCerveza.Location = new System.Drawing.Point(52, 38);
            this.rBtnCerveza.Name = "rBtnCerveza";
            this.rBtnCerveza.Size = new System.Drawing.Size(64, 17);
            this.rBtnCerveza.TabIndex = 5;
            this.rBtnCerveza.TabStop = true;
            this.rBtnCerveza.Text = "Cerveza";
            this.rBtnCerveza.UseVisualStyleBackColor = true;
            // 
            // rBtnAgua
            // 
            this.rBtnAgua.AutoSize = true;
            this.rBtnAgua.Location = new System.Drawing.Point(52, 72);
            this.rBtnAgua.Name = "rBtnAgua";
            this.rBtnAgua.Size = new System.Drawing.Size(50, 17);
            this.rBtnAgua.TabIndex = 6;
            this.rBtnAgua.TabStop = true;
            this.rBtnAgua.Text = "Agua";
            this.rBtnAgua.UseVisualStyleBackColor = true;
            // 
            // grpCantina
            // 
            this.grpCantina.Controls.Add(this.label1);
            this.grpCantina.Controls.Add(this.lblMarca);
            this.grpCantina.Controls.Add(this.lblContenido);
            this.grpCantina.Controls.Add(this.lblCapacidad);
            this.grpCantina.Controls.Add(this.rBtnAgua);
            this.grpCantina.Controls.Add(this.rBtnCerveza);
            this.grpCantina.Controls.Add(this.numUpDownContenido);
            this.grpCantina.Controls.Add(this.numUpDownCapacidad);
            this.grpCantina.Controls.Add(this.txtBMarca);
            this.grpCantina.Controls.Add(this.btnAgregar);
            this.grpCantina.Controls.Add(this.cmbBotellaTipo);
            this.grpCantina.Location = new System.Drawing.Point(26, 383);
            this.grpCantina.Name = "grpCantina";
            this.grpCantina.Size = new System.Drawing.Size(650, 130);
            this.grpCantina.TabIndex = 7;
            this.grpCantina.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(433, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tipo de Botella";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(205, 22);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(37, 13);
            this.lblMarca.TabIndex = 9;
            this.lblMarca.Text = "Marca";
            // 
            // lblContenido
            // 
            this.lblContenido.AutoSize = true;
            this.lblContenido.Location = new System.Drawing.Point(308, 74);
            this.lblContenido.Name = "lblContenido";
            this.lblContenido.Size = new System.Drawing.Size(55, 13);
            this.lblContenido.TabIndex = 8;
            this.lblContenido.Text = "Contenido";
            // 
            // lblCapacidad
            // 
            this.lblCapacidad.AutoSize = true;
            this.lblCapacidad.Location = new System.Drawing.Point(205, 74);
            this.lblCapacidad.Name = "lblCapacidad";
            this.lblCapacidad.Size = new System.Drawing.Size(58, 13);
            this.lblCapacidad.TabIndex = 7;
            this.lblCapacidad.Text = "Capacidad";
            // 
            // barra
            // 
            this.barra.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("barra.BackgroundImage")));
            this.barra.Location = new System.Drawing.Point(28, 15);
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(647, 355);
            this.barra.TabIndex = 8;
            // 
            // FrmCantina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 525);
            this.Controls.Add(this.barra);
            this.Controls.Add(this.grpCantina);
            this.Name = "FrmCantina";
            this.Text = "Cantina - Diaz Lautaro Nicolás 2°C";
            this.Load += new System.EventHandler(this.FrmCantina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCapacidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownContenido)).EndInit();
            this.grpCantina.ResumeLayout(false);
            this.grpCantina.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBotellaTipo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtBMarca;
        private System.Windows.Forms.NumericUpDown numUpDownCapacidad;
        private System.Windows.Forms.NumericUpDown numUpDownContenido;
        private System.Windows.Forms.RadioButton rBtnCerveza;
        private System.Windows.Forms.RadioButton rBtnAgua;
        private System.Windows.Forms.GroupBox grpCantina;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblContenido;
        private System.Windows.Forms.Label lblCapacidad;
        private System.Windows.Forms.Label label1;
        private ControlCantina.Barra barra;
    }
}

