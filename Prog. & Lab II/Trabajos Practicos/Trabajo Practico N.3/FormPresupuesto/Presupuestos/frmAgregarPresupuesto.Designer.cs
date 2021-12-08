
namespace Formularios
{
    partial class frmAgregarPresupuesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarPresupuesto));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dGVProductos = new System.Windows.Forms.DataGridView();
            this.cEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDetalles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFechaEmision = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpOpcionales = new System.Windows.Forms.GroupBox();
            this.dTFecha = new System.Windows.Forms.DateTimePicker();
            this.txBNuevoValor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProductos)).BeginInit();
            this.grpOpcionales.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.Image = global::Formularios.Properties.Resources.remover;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(729, 90);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(158, 35);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAgregar.Image = global::Formularios.Properties.Resources.presupuesto1;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(729, 34);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(158, 35);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Ingresar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dGVProductos
            // 
            this.dGVProductos.AllowUserToAddRows = false;
            this.dGVProductos.AllowUserToDeleteRows = false;
            this.dGVProductos.AllowUserToResizeColumns = false;
            this.dGVProductos.AllowUserToResizeRows = false;
            this.dGVProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVProductos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.dGVProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGVProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dGVProductos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGVProductos.EnableHeadersVisualStyles = false;
            this.dGVProductos.GridColor = System.Drawing.Color.SteelBlue;
            this.dGVProductos.Location = new System.Drawing.Point(12, 143);
            this.dGVProductos.Name = "dGVProductos";
            this.dGVProductos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dGVProductos.RowHeadersVisible = false;
            this.dGVProductos.RowHeadersWidth = 35;
            this.dGVProductos.RowTemplate.Height = 25;
            this.dGVProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVProductos.Size = new System.Drawing.Size(884, 293);
            this.dGVProductos.TabIndex = 8;
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
            // lblFechaEmision
            // 
            this.lblFechaEmision.AutoSize = true;
            this.lblFechaEmision.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFechaEmision.Location = new System.Drawing.Point(28, 33);
            this.lblFechaEmision.Name = "lblFechaEmision";
            this.lblFechaEmision.Size = new System.Drawing.Size(141, 18);
            this.lblFechaEmision.TabIndex = 15;
            this.lblFechaEmision.Text = "Fecha de Emisión:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(117, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Valor:";
            // 
            // grpOpcionales
            // 
            this.grpOpcionales.Controls.Add(this.dTFecha);
            this.grpOpcionales.Controls.Add(this.txBNuevoValor);
            this.grpOpcionales.Controls.Add(this.label1);
            this.grpOpcionales.Controls.Add(this.lblFechaEmision);
            this.grpOpcionales.Location = new System.Drawing.Point(17, 28);
            this.grpOpcionales.Name = "grpOpcionales";
            this.grpOpcionales.Size = new System.Drawing.Size(365, 109);
            this.grpOpcionales.TabIndex = 17;
            this.grpOpcionales.TabStop = false;
            this.grpOpcionales.Text = "Valores opcionales:";
            // 
            // dTFecha
            // 
            this.dTFecha.Location = new System.Drawing.Point(175, 30);
            this.dTFecha.Name = "dTFecha";
            this.dTFecha.Size = new System.Drawing.Size(171, 23);
            this.dTFecha.TabIndex = 18;
            // 
            // txBNuevoValor
            // 
            this.txBNuevoValor.Location = new System.Drawing.Point(175, 68);
            this.txBNuevoValor.Name = "txBNuevoValor";
            this.txBNuevoValor.Size = new System.Drawing.Size(171, 23);
            this.txBNuevoValor.TabIndex = 39;
            this.txBNuevoValor.TextChanged += new System.EventHandler(this.txBNuevoValor_TextChanged);
            this.txBNuevoValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyNumerics_KeyPress);
            // 
            // frmAgregarPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.ClientSize = new System.Drawing.Size(904, 447);
            this.Controls.Add(this.grpOpcionales);
            this.Controls.Add(this.dGVProductos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAgregarPresupuesto";
            this.Text = "Agregar un nuevo presupuesto";
            this.Load += new System.EventHandler(this.frmAgregarPresupuesto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVProductos)).EndInit();
            this.grpOpcionales.ResumeLayout(false);
            this.grpOpcionales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dGVProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDetalles;
        private System.Windows.Forms.Label lblFechaEmision;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpOpcionales;
        private System.Windows.Forms.TextBox txBNuevoValor;
        private System.Windows.Forms.DateTimePicker dTFecha;
    }
}