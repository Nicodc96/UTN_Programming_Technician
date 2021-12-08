
namespace FormTest
{
    partial class FormularioPrincipal
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
            this.btnMostrarPersonajes = new System.Windows.Forms.Button();
            this.rTbPersonajes = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnMostrarPersonajes
            // 
            this.btnMostrarPersonajes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMostrarPersonajes.Location = new System.Drawing.Point(193, 12);
            this.btnMostrarPersonajes.Name = "btnMostrarPersonajes";
            this.btnMostrarPersonajes.Size = new System.Drawing.Size(384, 51);
            this.btnMostrarPersonajes.TabIndex = 0;
            this.btnMostrarPersonajes.Text = "Mostrar personajes";
            this.btnMostrarPersonajes.UseVisualStyleBackColor = true;
            this.btnMostrarPersonajes.Click += new System.EventHandler(this.btnMostrarPersonajes_Click);
            // 
            // rTbPersonajes
            // 
            this.rTbPersonajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTbPersonajes.Location = new System.Drawing.Point(29, 74);
            this.rTbPersonajes.Name = "rTbPersonajes";
            this.rTbPersonajes.Size = new System.Drawing.Size(739, 451);
            this.rTbPersonajes.TabIndex = 1;
            this.rTbPersonajes.Text = "";
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 537);
            this.Controls.Add(this.rTbPersonajes);
            this.Controls.Add(this.btnMostrarPersonajes);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormularioPrincipal";
            this.Text = "Diaz Lautaro 2°C - Primer Parcial 1C-2021";
            this.Load += new System.EventHandler(this.FormularioPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMostrarPersonajes;
        private System.Windows.Forms.RichTextBox rTbPersonajes;
    }
}

