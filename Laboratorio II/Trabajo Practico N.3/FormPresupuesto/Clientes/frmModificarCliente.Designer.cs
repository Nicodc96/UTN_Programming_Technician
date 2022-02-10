
namespace Formularios
{
    partial class frmModificarCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificarCliente));
            this.grpCamposOpcionales = new System.Windows.Forms.GroupBox();
            this.txtBEdad = new System.Windows.Forms.TextBox();
            this.lblEdad = new System.Windows.Forms.Label();
            this.txtBDNI = new System.Windows.Forms.TextBox();
            this.lblDNI = new System.Windows.Forms.Label();
            this.txtBApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtBNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.chBQuitarPresupuesto = new System.Windows.Forms.CheckBox();
            this.btnCambiarPresupuesto = new System.Windows.Forms.Button();
            this.grpCamposOpcionales.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCamposOpcionales
            // 
            this.grpCamposOpcionales.Controls.Add(this.txtBEdad);
            this.grpCamposOpcionales.Controls.Add(this.lblEdad);
            this.grpCamposOpcionales.Controls.Add(this.txtBDNI);
            this.grpCamposOpcionales.Controls.Add(this.lblDNI);
            this.grpCamposOpcionales.Controls.Add(this.txtBApellido);
            this.grpCamposOpcionales.Controls.Add(this.lblApellido);
            this.grpCamposOpcionales.Controls.Add(this.txtBNombre);
            this.grpCamposOpcionales.Controls.Add(this.lblNombre);
            this.grpCamposOpcionales.Location = new System.Drawing.Point(22, 22);
            this.grpCamposOpcionales.Name = "grpCamposOpcionales";
            this.grpCamposOpcionales.Size = new System.Drawing.Size(369, 145);
            this.grpCamposOpcionales.TabIndex = 22;
            this.grpCamposOpcionales.TabStop = false;
            this.grpCamposOpcionales.Text = "Campos opcionales:";
            // 
            // txtBEdad
            // 
            this.txtBEdad.Location = new System.Drawing.Point(122, 110);
            this.txtBEdad.Name = "txtBEdad";
            this.txtBEdad.Size = new System.Drawing.Size(195, 23);
            this.txtBEdad.TabIndex = 19;
            this.txtBEdad.TextChanged += new System.EventHandler(this.txtBEdad_TextChanged);
            this.txtBEdad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyNumerics_KeyPress);
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEdad.Location = new System.Drawing.Point(57, 111);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(50, 18);
            this.lblEdad.TabIndex = 18;
            this.lblEdad.Text = "Edad:";
            // 
            // txtBDNI
            // 
            this.txtBDNI.Location = new System.Drawing.Point(122, 81);
            this.txtBDNI.Name = "txtBDNI";
            this.txtBDNI.Size = new System.Drawing.Size(195, 23);
            this.txtBDNI.TabIndex = 17;
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDNI.Location = new System.Drawing.Point(66, 82);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(38, 18);
            this.lblDNI.TabIndex = 16;
            this.lblDNI.Text = "DNI:";
            // 
            // txtBApellido
            // 
            this.txtBApellido.Location = new System.Drawing.Point(122, 51);
            this.txtBApellido.Name = "txtBApellido";
            this.txtBApellido.Size = new System.Drawing.Size(195, 23);
            this.txtBApellido.TabIndex = 15;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblApellido.Location = new System.Drawing.Point(32, 52);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(75, 18);
            this.lblApellido.TabIndex = 14;
            this.lblApellido.Text = "Apellido:";
            // 
            // txtBNombre
            // 
            this.txtBNombre.Location = new System.Drawing.Point(122, 22);
            this.txtBNombre.Name = "txtBNombre";
            this.txtBNombre.Size = new System.Drawing.Size(195, 23);
            this.txtBNombre.TabIndex = 13;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.Location = new System.Drawing.Point(32, 23);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(72, 18);
            this.lblNombre.TabIndex = 12;
            this.lblNombre.Text = "Nombre:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.Image = global::Formularios.Properties.Resources.remover;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(677, 88);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(197, 35);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnModificar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnModificar.Image = global::Formularios.Properties.Resources.modificar;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(677, 36);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(197, 35);
            this.btnModificar.TabIndex = 23;
            this.btnModificar.Text = "Ingresar cambios";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // chBQuitarPresupuesto
            // 
            this.chBQuitarPresupuesto.AutoSize = true;
            this.chBQuitarPresupuesto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chBQuitarPresupuesto.Location = new System.Drawing.Point(419, 36);
            this.chBQuitarPresupuesto.Name = "chBQuitarPresupuesto";
            this.chBQuitarPresupuesto.Size = new System.Drawing.Size(165, 22);
            this.chBQuitarPresupuesto.TabIndex = 25;
            this.chBQuitarPresupuesto.Text = "Quitar presupuesto";
            this.chBQuitarPresupuesto.UseVisualStyleBackColor = true;
            // 
            // btnCambiarPresupuesto
            // 
            this.btnCambiarPresupuesto.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCambiarPresupuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarPresupuesto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCambiarPresupuesto.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCambiarPresupuesto.Image = global::Formularios.Properties.Resources.presupuesto1;
            this.btnCambiarPresupuesto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiarPresupuesto.Location = new System.Drawing.Point(419, 87);
            this.btnCambiarPresupuesto.Name = "btnCambiarPresupuesto";
            this.btnCambiarPresupuesto.Size = new System.Drawing.Size(220, 35);
            this.btnCambiarPresupuesto.TabIndex = 26;
            this.btnCambiarPresupuesto.Text = "Modificar Presupuesto";
            this.btnCambiarPresupuesto.UseVisualStyleBackColor = false;
            this.btnCambiarPresupuesto.Click += new System.EventHandler(this.btnCambiarPresupuesto_Click);
            // 
            // frmModificarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.ClientSize = new System.Drawing.Size(886, 195);
            this.Controls.Add(this.btnCambiarPresupuesto);
            this.Controls.Add(this.chBQuitarPresupuesto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.grpCamposOpcionales);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModificarCliente";
            this.Text = "Modificar un cliente";
            this.Load += new System.EventHandler(this.frmModificarCliente_Load);
            this.grpCamposOpcionales.ResumeLayout(false);
            this.grpCamposOpcionales.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCamposOpcionales;
        private System.Windows.Forms.TextBox txtBEdad;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.TextBox txtBDNI;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.TextBox txtBApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtBNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.CheckBox chBQuitarPresupuesto;
        private System.Windows.Forms.Button btnCambiarPresupuesto;
    }
}