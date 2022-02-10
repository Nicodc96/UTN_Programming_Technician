
namespace Formularios
{
    partial class frmModificarPresupuesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificarPresupuesto));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvPresupuesto = new System.Windows.Forms.DataGridView();
            this.cEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDetalles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAplicarCambios = new System.Windows.Forms.Button();
            this.grpAtributos = new System.Windows.Forms.GroupBox();
            this.dTFecha = new System.Windows.Forms.DateTimePicker();
            this.txBNuevoValor = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblFechaEmision = new System.Windows.Forms.Label();
            this.grpListaComponentes = new System.Windows.Forms.GroupBox();
            this.btnQuitarComponente = new System.Windows.Forms.Button();
            this.btnAgregarComponente = new System.Windows.Forms.Button();
            this.chBLimpiarLista = new System.Windows.Forms.CheckBox();
            this.btnModificarCliente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuesto)).BeginInit();
            this.grpAtributos.SuspendLayout();
            this.grpListaComponentes.SuspendLayout();
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
            this.btnCancelar.Location = new System.Drawing.Point(658, 269);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(190, 35);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dgvPresupuesto
            // 
            this.dgvPresupuesto.AllowUserToAddRows = false;
            this.dgvPresupuesto.AllowUserToDeleteRows = false;
            this.dgvPresupuesto.AllowUserToResizeColumns = false;
            this.dgvPresupuesto.AllowUserToResizeRows = false;
            this.dgvPresupuesto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPresupuesto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPresupuesto.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.dgvPresupuesto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPresupuesto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPresupuesto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPresupuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPresupuesto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dgvPresupuesto.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPresupuesto.EnableHeadersVisualStyles = false;
            this.dgvPresupuesto.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvPresupuesto.Location = new System.Drawing.Point(12, 40);
            this.dgvPresupuesto.Name = "dgvPresupuesto";
            this.dgvPresupuesto.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPresupuesto.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPresupuesto.RowHeadersVisible = false;
            this.dgvPresupuesto.RowHeadersWidth = 35;
            this.dgvPresupuesto.RowTemplate.Height = 25;
            this.dgvPresupuesto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPresupuesto.Size = new System.Drawing.Size(842, 110);
            this.dgvPresupuesto.TabIndex = 9;
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
            this.lblTitulo.Location = new System.Drawing.Point(12, 17);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(367, 20);
            this.lblTitulo.TabIndex = 10;
            this.lblTitulo.Text = "Usted está modificando el siguiente presupuesto:";
            // 
            // btnAplicarCambios
            // 
            this.btnAplicarCambios.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAplicarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarCambios.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAplicarCambios.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAplicarCambios.Image = global::Formularios.Properties.Resources.modificar;
            this.btnAplicarCambios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAplicarCambios.Location = new System.Drawing.Point(462, 269);
            this.btnAplicarCambios.Name = "btnAplicarCambios";
            this.btnAplicarCambios.Size = new System.Drawing.Size(190, 35);
            this.btnAplicarCambios.TabIndex = 11;
            this.btnAplicarCambios.Text = "Aplicar cambios";
            this.btnAplicarCambios.UseVisualStyleBackColor = false;
            this.btnAplicarCambios.Click += new System.EventHandler(this.btnAplicarCambios_Click);
            // 
            // grpAtributos
            // 
            this.grpAtributos.Controls.Add(this.dTFecha);
            this.grpAtributos.Controls.Add(this.txBNuevoValor);
            this.grpAtributos.Controls.Add(this.lblValor);
            this.grpAtributos.Controls.Add(this.lblFechaEmision);
            this.grpAtributos.Location = new System.Drawing.Point(12, 154);
            this.grpAtributos.Name = "grpAtributos";
            this.grpAtributos.Size = new System.Drawing.Size(365, 109);
            this.grpAtributos.TabIndex = 18;
            this.grpAtributos.TabStop = false;
            this.grpAtributos.Text = "Atributos:";
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
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblValor.Location = new System.Drawing.Point(117, 69);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(52, 18);
            this.lblValor.TabIndex = 16;
            this.lblValor.Text = "Valor:";
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
            // grpListaComponentes
            // 
            this.grpListaComponentes.Controls.Add(this.btnQuitarComponente);
            this.grpListaComponentes.Controls.Add(this.btnAgregarComponente);
            this.grpListaComponentes.Controls.Add(this.chBLimpiarLista);
            this.grpListaComponentes.Location = new System.Drawing.Point(515, 154);
            this.grpListaComponentes.Name = "grpListaComponentes";
            this.grpListaComponentes.Size = new System.Drawing.Size(339, 109);
            this.grpListaComponentes.TabIndex = 19;
            this.grpListaComponentes.TabStop = false;
            this.grpListaComponentes.Text = "Lista de componentes:";
            // 
            // btnQuitarComponente
            // 
            this.btnQuitarComponente.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnQuitarComponente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarComponente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnQuitarComponente.ForeColor = System.Drawing.SystemColors.Control;
            this.btnQuitarComponente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitarComponente.Location = new System.Drawing.Point(141, 66);
            this.btnQuitarComponente.Name = "btnQuitarComponente";
            this.btnQuitarComponente.Size = new System.Drawing.Size(192, 27);
            this.btnQuitarComponente.TabIndex = 21;
            this.btnQuitarComponente.Text = "Quitar componentes";
            this.btnQuitarComponente.UseVisualStyleBackColor = false;
            this.btnQuitarComponente.Click += new System.EventHandler(this.btnQuitarComponente_Click);
            // 
            // btnAgregarComponente
            // 
            this.btnAgregarComponente.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAgregarComponente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarComponente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAgregarComponente.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAgregarComponente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarComponente.Location = new System.Drawing.Point(141, 30);
            this.btnAgregarComponente.Name = "btnAgregarComponente";
            this.btnAgregarComponente.Size = new System.Drawing.Size(192, 27);
            this.btnAgregarComponente.TabIndex = 20;
            this.btnAgregarComponente.Text = "Agregar componentes";
            this.btnAgregarComponente.UseVisualStyleBackColor = false;
            this.btnAgregarComponente.Click += new System.EventHandler(this.btnAgregarComponente_Click);
            // 
            // chBLimpiarLista
            // 
            this.chBLimpiarLista.AutoSize = true;
            this.chBLimpiarLista.Location = new System.Drawing.Point(15, 48);
            this.chBLimpiarLista.Name = "chBLimpiarLista";
            this.chBLimpiarLista.Size = new System.Drawing.Size(103, 21);
            this.chBLimpiarLista.TabIndex = 0;
            this.chBLimpiarLista.Text = "Limpiar lista";
            this.chBLimpiarLista.UseVisualStyleBackColor = true;
            // 
            // btnModificarCliente
            // 
            this.btnModificarCliente.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnModificarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarCliente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnModificarCliente.ForeColor = System.Drawing.SystemColors.Control;
            this.btnModificarCliente.Image = global::Formularios.Properties.Resources.clientes;
            this.btnModificarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarCliente.Location = new System.Drawing.Point(12, 269);
            this.btnModificarCliente.Name = "btnModificarCliente";
            this.btnModificarCliente.Size = new System.Drawing.Size(218, 35);
            this.btnModificarCliente.TabIndex = 20;
            this.btnModificarCliente.Text = "Modificar Cliente";
            this.btnModificarCliente.UseVisualStyleBackColor = false;
            this.btnModificarCliente.Click += new System.EventHandler(this.btnModificarCliente_Click);
            // 
            // frmModificarPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.ClientSize = new System.Drawing.Size(866, 315);
            this.Controls.Add(this.btnModificarCliente);
            this.Controls.Add(this.grpListaComponentes);
            this.Controls.Add(this.grpAtributos);
            this.Controls.Add(this.btnAplicarCambios);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvPresupuesto);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModificarPresupuesto";
            this.Text = "Modificar un presupuesto";
            this.Load += new System.EventHandler(this.frmModificarPresupuesto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuesto)).EndInit();
            this.grpAtributos.ResumeLayout(false);
            this.grpAtributos.PerformLayout();
            this.grpListaComponentes.ResumeLayout(false);
            this.grpListaComponentes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvPresupuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDetalles;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAplicarCambios;
        private System.Windows.Forms.GroupBox grpAtributos;
        private System.Windows.Forms.DateTimePicker dTFecha;
        private System.Windows.Forms.TextBox txBNuevoValor;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblFechaEmision;
        private System.Windows.Forms.GroupBox grpListaComponentes;
        private System.Windows.Forms.Button btnQuitarComponente;
        private System.Windows.Forms.Button btnAgregarComponente;
        private System.Windows.Forms.CheckBox chBLimpiarLista;
        private System.Windows.Forms.Button btnModificarCliente;
    }
}