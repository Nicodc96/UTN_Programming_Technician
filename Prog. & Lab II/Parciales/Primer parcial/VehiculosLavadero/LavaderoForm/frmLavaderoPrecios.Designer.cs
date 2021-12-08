
namespace LavaderoForm
{
    partial class frmLavaderoPrecios
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreLavadero = new System.Windows.Forms.TextBox();
            this.grpPreciosTodos = new System.Windows.Forms.GroupBox();
            this.txtPrecioAuto = new System.Windows.Forms.TextBox();
            this.lblPrecioAuto = new System.Windows.Forms.Label();
            this.lblPrecioCamion = new System.Windows.Forms.Label();
            this.lblPrecioMoto = new System.Windows.Forms.Label();
            this.txtPrecioCamion = new System.Windows.Forms.TextBox();
            this.txtPrecioMoto = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpPreciosTodos.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del lavadero:";
            // 
            // txtNombreLavadero
            // 
            this.txtNombreLavadero.Location = new System.Drawing.Point(17, 34);
            this.txtNombreLavadero.Name = "txtNombreLavadero";
            this.txtNombreLavadero.Size = new System.Drawing.Size(330, 23);
            this.txtNombreLavadero.TabIndex = 1;
            // 
            // grpPreciosTodos
            // 
            this.grpPreciosTodos.Controls.Add(this.txtPrecioMoto);
            this.grpPreciosTodos.Controls.Add(this.txtPrecioCamion);
            this.grpPreciosTodos.Controls.Add(this.lblPrecioMoto);
            this.grpPreciosTodos.Controls.Add(this.lblPrecioCamion);
            this.grpPreciosTodos.Controls.Add(this.lblPrecioAuto);
            this.grpPreciosTodos.Controls.Add(this.txtPrecioAuto);
            this.grpPreciosTodos.Location = new System.Drawing.Point(67, 63);
            this.grpPreciosTodos.Name = "grpPreciosTodos";
            this.grpPreciosTodos.Size = new System.Drawing.Size(230, 151);
            this.grpPreciosTodos.TabIndex = 2;
            this.grpPreciosTodos.TabStop = false;
            this.grpPreciosTodos.Text = "Definir precios:";
            // 
            // txtPrecioAuto
            // 
            this.txtPrecioAuto.Location = new System.Drawing.Point(93, 27);
            this.txtPrecioAuto.Name = "txtPrecioAuto";
            this.txtPrecioAuto.Size = new System.Drawing.Size(90, 23);
            this.txtPrecioAuto.TabIndex = 0;
            this.txtPrecioAuto.TextChanged += new System.EventHandler(this.txtPrecioAuto_TextChanged);
            this.txtPrecioAuto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyNumerics_KeyPress);
            // 
            // lblPrecioAuto
            // 
            this.lblPrecioAuto.AutoSize = true;
            this.lblPrecioAuto.Location = new System.Drawing.Point(17, 30);
            this.lblPrecioAuto.Name = "lblPrecioAuto";
            this.lblPrecioAuto.Size = new System.Drawing.Size(41, 15);
            this.lblPrecioAuto.TabIndex = 1;
            this.lblPrecioAuto.Text = "Autos:";
            // 
            // lblPrecioCamion
            // 
            this.lblPrecioCamion.AutoSize = true;
            this.lblPrecioCamion.Location = new System.Drawing.Point(17, 72);
            this.lblPrecioCamion.Name = "lblPrecioCamion";
            this.lblPrecioCamion.Size = new System.Drawing.Size(63, 15);
            this.lblPrecioCamion.TabIndex = 2;
            this.lblPrecioCamion.Text = "Camiones:";
            // 
            // lblPrecioMoto
            // 
            this.lblPrecioMoto.AutoSize = true;
            this.lblPrecioMoto.Location = new System.Drawing.Point(17, 113);
            this.lblPrecioMoto.Name = "lblPrecioMoto";
            this.lblPrecioMoto.Size = new System.Drawing.Size(44, 15);
            this.lblPrecioMoto.TabIndex = 3;
            this.lblPrecioMoto.Text = "Motos:";
            // 
            // txtPrecioCamion
            // 
            this.txtPrecioCamion.Location = new System.Drawing.Point(93, 69);
            this.txtPrecioCamion.Name = "txtPrecioCamion";
            this.txtPrecioCamion.Size = new System.Drawing.Size(90, 23);
            this.txtPrecioCamion.TabIndex = 4;
            this.txtPrecioCamion.TextChanged += new System.EventHandler(this.txtPrecioCamion_TextChanged);
            this.txtPrecioCamion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyNumerics_KeyPress);
            // 
            // txtPrecioMoto
            // 
            this.txtPrecioMoto.Location = new System.Drawing.Point(93, 110);
            this.txtPrecioMoto.Name = "txtPrecioMoto";
            this.txtPrecioMoto.Size = new System.Drawing.Size(89, 23);
            this.txtPrecioMoto.TabIndex = 5;
            this.txtPrecioMoto.TextChanged += new System.EventHandler(this.txtPrecioMoto_TextChanged);
            this.txtPrecioMoto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyNumerics_KeyPress);
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(17, 220);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(130, 38);
            this.btnIngresar.TabIndex = 3;
            this.btnIngresar.Text = "Establecer datos";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(217, 220);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 38);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmLavaderoPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 276);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.grpPreciosTodos);
            this.Controls.Add(this.txtNombreLavadero);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLavaderoPrecios";
            this.Text = "Lavadero - Ingreso de Datos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLavaderoPrecios_FormClosing);
            this.Load += new System.EventHandler(this.frmLavaderoPrecios_Load);
            this.grpPreciosTodos.ResumeLayout(false);
            this.grpPreciosTodos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreLavadero;
        private System.Windows.Forms.GroupBox grpPreciosTodos;
        private System.Windows.Forms.TextBox txtPrecioMoto;
        private System.Windows.Forms.TextBox txtPrecioCamion;
        private System.Windows.Forms.Label lblPrecioMoto;
        private System.Windows.Forms.Label lblPrecioCamion;
        private System.Windows.Forms.Label lblPrecioAuto;
        private System.Windows.Forms.TextBox txtPrecioAuto;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnCancelar;
    }
}