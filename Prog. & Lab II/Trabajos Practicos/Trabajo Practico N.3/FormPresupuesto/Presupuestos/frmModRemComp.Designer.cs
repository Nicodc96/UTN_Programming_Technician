
namespace Formularios
{
    partial class frmModRemComp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModRemComp));
            this.btnRemover = new System.Windows.Forms.Button();
            this.dGVProductos = new System.Windows.Forms.DataGridView();
            this.cEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDetalles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRemover
            // 
            this.btnRemover.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemover.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemover.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRemover.Image = global::Formularios.Properties.Resources.remover;
            this.btnRemover.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemover.Location = new System.Drawing.Point(351, 329);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(158, 35);
            this.btnRemover.TabIndex = 8;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = false;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
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
            this.dGVProductos.Location = new System.Drawing.Point(12, 12);
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
            this.dGVProductos.Size = new System.Drawing.Size(847, 304);
            this.dGVProductos.TabIndex = 7;
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
            // frmModRemComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.ClientSize = new System.Drawing.Size(871, 376);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.dGVProductos);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModRemComp";
            this.Text = "Remover un componente";
            this.Load += new System.EventHandler(this.frmModRemComp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.DataGridView dGVProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDetalles;
    }
}