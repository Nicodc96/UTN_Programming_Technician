
namespace Formularios
{
    partial class frmModPresuCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModPresuCliente));
            this.dGVPresupuestos = new System.Windows.Forms.DataGridView();
            this.cEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDetalles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVPresupuestos)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVPresupuestos
            // 
            this.dGVPresupuestos.AllowUserToAddRows = false;
            this.dGVPresupuestos.AllowUserToDeleteRows = false;
            this.dGVPresupuestos.AllowUserToResizeColumns = false;
            this.dGVPresupuestos.AllowUserToResizeRows = false;
            this.dGVPresupuestos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVPresupuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVPresupuestos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.dGVPresupuestos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGVPresupuestos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVPresupuestos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVPresupuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVPresupuestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cEmision,
            this.cCantidad,
            this.cPrecio,
            this.cDetalles});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVPresupuestos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGVPresupuestos.EnableHeadersVisualStyles = false;
            this.dGVPresupuestos.GridColor = System.Drawing.Color.SteelBlue;
            this.dGVPresupuestos.Location = new System.Drawing.Point(12, 32);
            this.dGVPresupuestos.Name = "dGVPresupuestos";
            this.dGVPresupuestos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVPresupuestos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dGVPresupuestos.RowHeadersVisible = false;
            this.dGVPresupuestos.RowHeadersWidth = 35;
            this.dGVPresupuestos.RowTemplate.Height = 25;
            this.dGVPresupuestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVPresupuestos.Size = new System.Drawing.Size(890, 271);
            this.dGVPresupuestos.TabIndex = 11;
            // 
            // cEmision
            // 
            this.cEmision.FillWeight = 50F;
            this.cEmision.HeaderText = "Emitido el:";
            this.cEmision.Name = "cEmision";
            this.cEmision.ReadOnly = true;
            this.cEmision.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cEmision.Visible = false;
            // 
            // cCantidad
            // 
            this.cCantidad.FillWeight = 75F;
            this.cCantidad.HeaderText = "Cant. Componentes";
            this.cCantidad.Name = "cCantidad";
            this.cCantidad.ReadOnly = true;
            this.cCantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cCantidad.Visible = false;
            // 
            // cPrecio
            // 
            this.cPrecio.FillWeight = 50F;
            this.cPrecio.HeaderText = "Precio total";
            this.cPrecio.Name = "cPrecio";
            this.cPrecio.ReadOnly = true;
            this.cPrecio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cPrecio.Visible = false;
            // 
            // cDetalles
            // 
            this.cDetalles.FillWeight = 125F;
            this.cDetalles.HeaderText = "Detalles";
            this.cDetalles.Name = "cDetalles";
            this.cDetalles.ReadOnly = true;
            this.cDetalles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cDetalles.Visible = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(405, 20);
            this.lblTitulo.TabIndex = 12;
            this.lblTitulo.Text = "Seleccione un presupuesto por el que desea cambiar:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAgregar.Image = global::Formularios.Properties.Resources.presupuesto1;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(373, 323);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(158, 35);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Ingresar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // frmModPresuCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.ClientSize = new System.Drawing.Size(914, 370);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dGVPresupuestos);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModPresuCliente";
            this.Text = "Modificar presupuesto de un cliente";
            this.Load += new System.EventHandler(this.frmModPresuCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVPresupuestos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVPresupuestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDetalles;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAgregar;
    }
}