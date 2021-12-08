
namespace FrmTest1
{
    partial class FrmTest
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
            this.rtbInforme = new System.Windows.Forms.RichTextBox();
            this.btnVender = new System.Windows.Forms.Button();
            this.btnVerInforme = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lstStock = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // rtbInforme
            // 
            this.rtbInforme.Location = new System.Drawing.Point(394, 12);
            this.rtbInforme.Name = "rtbInforme";
            this.rtbInforme.Size = new System.Drawing.Size(346, 490);
            this.rtbInforme.TabIndex = 0;
            this.rtbInforme.Text = "";
            // 
            // btnVender
            // 
            this.btnVender.Location = new System.Drawing.Point(17, 371);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(367, 38);
            this.btnVender.TabIndex = 1;
            this.btnVender.Text = "Vender";
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // btnVerInforme
            // 
            this.btnVerInforme.Location = new System.Drawing.Point(16, 415);
            this.btnVerInforme.Name = "btnVerInforme";
            this.btnVerInforme.Size = new System.Drawing.Size(367, 39);
            this.btnVerInforme.TabIndex = 2;
            this.btnVerInforme.Text = "Ver informe";
            this.btnVerInforme.UseVisualStyleBackColor = true;
            this.btnVerInforme.Click += new System.EventHandler(this.btnVerInforme_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(18, 460);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(364, 43);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lstStock
            // 
            this.lstStock.FormattingEnabled = true;
            this.lstStock.Location = new System.Drawing.Point(16, 15);
            this.lstStock.Name = "lstStock";
            this.lstStock.Size = new System.Drawing.Size(365, 342);
            this.lstStock.TabIndex = 4;
            this.lstStock.SelectedIndexChanged += new System.EventHandler(this.lstStock_SelectedIndexChanged);
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 514);
            this.Controls.Add(this.lstStock);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnVerInforme);
            this.Controls.Add(this.btnVender);
            this.Controls.Add(this.rtbInforme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTest";
            this.Text = "Testear App de Lautaro N. Díaz (2°C)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbInforme;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.Button btnVerInforme;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ListBox lstStock;
    }
}

