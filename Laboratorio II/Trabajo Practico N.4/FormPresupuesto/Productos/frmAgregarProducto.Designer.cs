﻿
namespace Formularios
{
    partial class frmAgregarProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarProducto));
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbMarcas = new System.Windows.Forms.ComboBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.txBModelo = new System.Windows.Forms.TextBox();
            this.lblPotencia = new System.Windows.Forms.Label();
            this.lblConsumo = new System.Windows.Forms.Label();
            this.txBPotencia = new System.Windows.Forms.TextBox();
            this.txBConsumo = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipoProducto = new System.Windows.Forms.ComboBox();
            this.lblGeneración = new System.Windows.Forms.Label();
            this.lblTipoMemoria = new System.Windows.Forms.Label();
            this.lblTipoPlacaVideo = new System.Windows.Forms.Label();
            this.lblTipoMother = new System.Windows.Forms.Label();
            this.lblSocket = new System.Windows.Forms.Label();
            this.lblTipoFuente = new System.Windows.Forms.Label();
            this.lblTipoDisco = new System.Windows.Forms.Label();
            this.lblFabricanteCPU = new System.Windows.Forms.Label();
            this.lblCantNucleos = new System.Windows.Forms.Label();
            this.cmbTipoPlaca = new System.Windows.Forms.ComboBox();
            this.grpInfoVital = new System.Windows.Forms.GroupBox();
            this.txBPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.cmbTipoMother = new System.Windows.Forms.ComboBox();
            this.cmbSocket = new System.Windows.Forms.ComboBox();
            this.cmbTipoFuente = new System.Windows.Forms.ComboBox();
            this.cmbTipoMemoria = new System.Windows.Forms.ComboBox();
            this.cmbGeneracion = new System.Windows.Forms.ComboBox();
            this.cmbTipoDisco = new System.Windows.Forms.ComboBox();
            this.cmbFabricanteCPU = new System.Windows.Forms.ComboBox();
            this.cmbCantNucleos = new System.Windows.Forms.ComboBox();
            this.lblTamanioDisco = new System.Windows.Forms.Label();
            this.txtTamanioDisco = new System.Windows.Forms.TextBox();
            this.lblMemoriaGrafica = new System.Windows.Forms.Label();
            this.txBMemoriaGrafica = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.txBID = new System.Windows.Forms.TextBox();
            this.grpInfoVital.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAgregar.Image = global::Formularios.Properties.Resources.producto;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(12, 319);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(158, 35);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Ingresar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.Image = global::Formularios.Properties.Resources.remover;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(178, 319);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(158, 35);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbMarcas
            // 
            this.cmbMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarcas.FormattingEnabled = true;
            this.cmbMarcas.Location = new System.Drawing.Point(111, 28);
            this.cmbMarcas.Name = "cmbMarcas";
            this.cmbMarcas.Size = new System.Drawing.Size(170, 25);
            this.cmbMarcas.TabIndex = 6;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMarca.Location = new System.Drawing.Point(31, 29);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(61, 18);
            this.lblMarca.TabIndex = 7;
            this.lblMarca.Text = "Marca:";
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblModelo.Location = new System.Drawing.Point(22, 66);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(70, 18);
            this.lblModelo.TabIndex = 8;
            this.lblModelo.Text = "Modelo:";
            // 
            // txBModelo
            // 
            this.txBModelo.Location = new System.Drawing.Point(111, 66);
            this.txBModelo.Name = "txBModelo";
            this.txBModelo.Size = new System.Drawing.Size(170, 23);
            this.txBModelo.TabIndex = 9;
            // 
            // lblPotencia
            // 
            this.lblPotencia.AutoSize = true;
            this.lblPotencia.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPotencia.Location = new System.Drawing.Point(15, 104);
            this.lblPotencia.Name = "lblPotencia";
            this.lblPotencia.Size = new System.Drawing.Size(77, 18);
            this.lblPotencia.TabIndex = 10;
            this.lblPotencia.Text = "Potencia:";
            // 
            // lblConsumo
            // 
            this.lblConsumo.AutoSize = true;
            this.lblConsumo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblConsumo.Location = new System.Drawing.Point(10, 142);
            this.lblConsumo.Name = "lblConsumo";
            this.lblConsumo.Size = new System.Drawing.Size(82, 18);
            this.lblConsumo.TabIndex = 11;
            this.lblConsumo.Text = "Consumo:";
            // 
            // txBPotencia
            // 
            this.txBPotencia.Location = new System.Drawing.Point(111, 103);
            this.txBPotencia.Name = "txBPotencia";
            this.txBPotencia.Size = new System.Drawing.Size(170, 23);
            this.txBPotencia.TabIndex = 12;
            this.txBPotencia.TextChanged += new System.EventHandler(this.txBPotencia_TextChanged);
            this.txBPotencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyNumerics_KeyPress);
            // 
            // txBConsumo
            // 
            this.txBConsumo.Location = new System.Drawing.Point(111, 141);
            this.txBConsumo.Name = "txBConsumo";
            this.txBConsumo.Size = new System.Drawing.Size(170, 23);
            this.txBConsumo.TabIndex = 13;
            this.txBConsumo.TextChanged += new System.EventHandler(this.txBConsumo_TextChanged);
            this.txBConsumo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyNumerics_KeyPress);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTipo.Location = new System.Drawing.Point(12, 27);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(136, 18);
            this.lblTipo.TabIndex = 14;
            this.lblTipo.Text = "Tipo de Producto:";
            // 
            // cmbTipoProducto
            // 
            this.cmbTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoProducto.FormattingEnabled = true;
            this.cmbTipoProducto.Items.AddRange(new object[] {
            "Disco",
            "FuenteDePoder",
            "Memoria",
            "PlacaDeVideo",
            "PlacaMadre",
            "Procesador"});
            this.cmbTipoProducto.Location = new System.Drawing.Point(153, 26);
            this.cmbTipoProducto.Name = "cmbTipoProducto";
            this.cmbTipoProducto.Size = new System.Drawing.Size(170, 25);
            this.cmbTipoProducto.TabIndex = 15;
            this.cmbTipoProducto.SelectedIndexChanged += new System.EventHandler(this.cmbTipoProducto_SelectedIndexChanged);
            // 
            // lblGeneración
            // 
            this.lblGeneración.AutoSize = true;
            this.lblGeneración.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGeneración.Location = new System.Drawing.Point(376, 210);
            this.lblGeneración.Name = "lblGeneración";
            this.lblGeneración.Size = new System.Drawing.Size(102, 18);
            this.lblGeneración.TabIndex = 16;
            this.lblGeneración.Text = "Generación:";
            // 
            // lblTipoMemoria
            // 
            this.lblTipoMemoria.AutoSize = true;
            this.lblTipoMemoria.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTipoMemoria.Location = new System.Drawing.Point(366, 179);
            this.lblTipoMemoria.Name = "lblTipoMemoria";
            this.lblTipoMemoria.Size = new System.Drawing.Size(113, 18);
            this.lblTipoMemoria.TabIndex = 17;
            this.lblTipoMemoria.Text = "Tipo Memoria:";
            // 
            // lblTipoPlacaVideo
            // 
            this.lblTipoPlacaVideo.AutoSize = true;
            this.lblTipoPlacaVideo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTipoPlacaVideo.Location = new System.Drawing.Point(367, 25);
            this.lblTipoPlacaVideo.Name = "lblTipoPlacaVideo";
            this.lblTipoPlacaVideo.Size = new System.Drawing.Size(112, 18);
            this.lblTipoPlacaVideo.TabIndex = 18;
            this.lblTipoPlacaVideo.Text = "Tipo de Placa:";
            // 
            // lblTipoMother
            // 
            this.lblTipoMother.AutoSize = true;
            this.lblTipoMother.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTipoMother.Location = new System.Drawing.Point(357, 86);
            this.lblTipoMother.Name = "lblTipoMother";
            this.lblTipoMother.Size = new System.Drawing.Size(122, 18);
            this.lblTipoMother.TabIndex = 19;
            this.lblTipoMother.Text = "Tipo de Mother:";
            // 
            // lblSocket
            // 
            this.lblSocket.AutoSize = true;
            this.lblSocket.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSocket.Location = new System.Drawing.Point(415, 117);
            this.lblSocket.Name = "lblSocket";
            this.lblSocket.Size = new System.Drawing.Size(63, 18);
            this.lblSocket.TabIndex = 20;
            this.lblSocket.Text = "Socket:";
            // 
            // lblTipoFuente
            // 
            this.lblTipoFuente.AutoSize = true;
            this.lblTipoFuente.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTipoFuente.Location = new System.Drawing.Point(360, 148);
            this.lblTipoFuente.Name = "lblTipoFuente";
            this.lblTipoFuente.Size = new System.Drawing.Size(119, 18);
            this.lblTipoFuente.TabIndex = 21;
            this.lblTipoFuente.Text = "Tipo de Fuente:";
            // 
            // lblTipoDisco
            // 
            this.lblTipoDisco.AutoSize = true;
            this.lblTipoDisco.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTipoDisco.Location = new System.Drawing.Point(368, 241);
            this.lblTipoDisco.Name = "lblTipoDisco";
            this.lblTipoDisco.Size = new System.Drawing.Size(111, 18);
            this.lblTipoDisco.TabIndex = 22;
            this.lblTipoDisco.Text = "Tipo de Disco:";
            // 
            // lblFabricanteCPU
            // 
            this.lblFabricanteCPU.AutoSize = true;
            this.lblFabricanteCPU.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFabricanteCPU.Location = new System.Drawing.Point(354, 301);
            this.lblFabricanteCPU.Name = "lblFabricanteCPU";
            this.lblFabricanteCPU.Size = new System.Drawing.Size(125, 18);
            this.lblFabricanteCPU.TabIndex = 23;
            this.lblFabricanteCPU.Text = "Fabricante CPU:";
            // 
            // lblCantNucleos
            // 
            this.lblCantNucleos.AutoSize = true;
            this.lblCantNucleos.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCantNucleos.Location = new System.Drawing.Point(364, 332);
            this.lblCantNucleos.Name = "lblCantNucleos";
            this.lblCantNucleos.Size = new System.Drawing.Size(115, 18);
            this.lblCantNucleos.TabIndex = 24;
            this.lblCantNucleos.Text = "Cant. Nucleos:";
            // 
            // cmbTipoPlaca
            // 
            this.cmbTipoPlaca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPlaca.FormattingEnabled = true;
            this.cmbTipoPlaca.Location = new System.Drawing.Point(485, 24);
            this.cmbTipoPlaca.Name = "cmbTipoPlaca";
            this.cmbTipoPlaca.Size = new System.Drawing.Size(170, 25);
            this.cmbTipoPlaca.TabIndex = 25;
            // 
            // grpInfoVital
            // 
            this.grpInfoVital.Controls.Add(this.txBID);
            this.grpInfoVital.Controls.Add(this.lblID);
            this.grpInfoVital.Controls.Add(this.txBPrecio);
            this.grpInfoVital.Controls.Add(this.lblPrecio);
            this.grpInfoVital.Controls.Add(this.txBConsumo);
            this.grpInfoVital.Controls.Add(this.txBPotencia);
            this.grpInfoVital.Controls.Add(this.lblConsumo);
            this.grpInfoVital.Controls.Add(this.lblPotencia);
            this.grpInfoVital.Controls.Add(this.txBModelo);
            this.grpInfoVital.Controls.Add(this.lblModelo);
            this.grpInfoVital.Controls.Add(this.lblMarca);
            this.grpInfoVital.Controls.Add(this.cmbMarcas);
            this.grpInfoVital.Location = new System.Drawing.Point(27, 59);
            this.grpInfoVital.Name = "grpInfoVital";
            this.grpInfoVital.Size = new System.Drawing.Size(296, 245);
            this.grpInfoVital.TabIndex = 26;
            this.grpInfoVital.TabStop = false;
            this.grpInfoVital.Text = "Datos centrales:";
            // 
            // txBPrecio
            // 
            this.txBPrecio.Location = new System.Drawing.Point(111, 175);
            this.txBPrecio.Name = "txBPrecio";
            this.txBPrecio.Size = new System.Drawing.Size(170, 23);
            this.txBPrecio.TabIndex = 15;
            this.txBPrecio.TextChanged += new System.EventHandler(this.txBPrecio_TextChanged);
            this.txBPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyNumerics_KeyPress);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPrecio.Location = new System.Drawing.Point(33, 176);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(59, 18);
            this.lblPrecio.TabIndex = 14;
            this.lblPrecio.Text = "Precio:";
            // 
            // cmbTipoMother
            // 
            this.cmbTipoMother.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoMother.FormattingEnabled = true;
            this.cmbTipoMother.Location = new System.Drawing.Point(485, 85);
            this.cmbTipoMother.Name = "cmbTipoMother";
            this.cmbTipoMother.Size = new System.Drawing.Size(170, 25);
            this.cmbTipoMother.TabIndex = 27;
            // 
            // cmbSocket
            // 
            this.cmbSocket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSocket.FormattingEnabled = true;
            this.cmbSocket.Location = new System.Drawing.Point(485, 116);
            this.cmbSocket.Name = "cmbSocket";
            this.cmbSocket.Size = new System.Drawing.Size(170, 25);
            this.cmbSocket.TabIndex = 28;
            // 
            // cmbTipoFuente
            // 
            this.cmbTipoFuente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoFuente.FormattingEnabled = true;
            this.cmbTipoFuente.Location = new System.Drawing.Point(485, 147);
            this.cmbTipoFuente.Name = "cmbTipoFuente";
            this.cmbTipoFuente.Size = new System.Drawing.Size(170, 25);
            this.cmbTipoFuente.TabIndex = 29;
            // 
            // cmbTipoMemoria
            // 
            this.cmbTipoMemoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoMemoria.FormattingEnabled = true;
            this.cmbTipoMemoria.Location = new System.Drawing.Point(485, 178);
            this.cmbTipoMemoria.Name = "cmbTipoMemoria";
            this.cmbTipoMemoria.Size = new System.Drawing.Size(170, 25);
            this.cmbTipoMemoria.TabIndex = 30;
            // 
            // cmbGeneracion
            // 
            this.cmbGeneracion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGeneracion.FormattingEnabled = true;
            this.cmbGeneracion.Location = new System.Drawing.Point(485, 209);
            this.cmbGeneracion.Name = "cmbGeneracion";
            this.cmbGeneracion.Size = new System.Drawing.Size(170, 25);
            this.cmbGeneracion.TabIndex = 31;
            // 
            // cmbTipoDisco
            // 
            this.cmbTipoDisco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDisco.FormattingEnabled = true;
            this.cmbTipoDisco.Location = new System.Drawing.Point(485, 240);
            this.cmbTipoDisco.Name = "cmbTipoDisco";
            this.cmbTipoDisco.Size = new System.Drawing.Size(170, 25);
            this.cmbTipoDisco.TabIndex = 32;
            // 
            // cmbFabricanteCPU
            // 
            this.cmbFabricanteCPU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFabricanteCPU.FormattingEnabled = true;
            this.cmbFabricanteCPU.Location = new System.Drawing.Point(486, 300);
            this.cmbFabricanteCPU.Name = "cmbFabricanteCPU";
            this.cmbFabricanteCPU.Size = new System.Drawing.Size(170, 25);
            this.cmbFabricanteCPU.TabIndex = 33;
            // 
            // cmbCantNucleos
            // 
            this.cmbCantNucleos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCantNucleos.FormattingEnabled = true;
            this.cmbCantNucleos.Location = new System.Drawing.Point(486, 331);
            this.cmbCantNucleos.Name = "cmbCantNucleos";
            this.cmbCantNucleos.Size = new System.Drawing.Size(170, 25);
            this.cmbCantNucleos.TabIndex = 34;
            // 
            // lblTamanioDisco
            // 
            this.lblTamanioDisco.AutoSize = true;
            this.lblTamanioDisco.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTamanioDisco.Location = new System.Drawing.Point(365, 272);
            this.lblTamanioDisco.Name = "lblTamanioDisco";
            this.lblTamanioDisco.Size = new System.Drawing.Size(116, 18);
            this.lblTamanioDisco.TabIndex = 35;
            this.lblTamanioDisco.Text = "Tamaño Disco:";
            // 
            // txtTamanioDisco
            // 
            this.txtTamanioDisco.Location = new System.Drawing.Point(485, 271);
            this.txtTamanioDisco.Name = "txtTamanioDisco";
            this.txtTamanioDisco.Size = new System.Drawing.Size(171, 23);
            this.txtTamanioDisco.TabIndex = 14;
            this.txtTamanioDisco.TextChanged += new System.EventHandler(this.txtTamanioDisco_TextChanged);
            this.txtTamanioDisco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyNumerics_KeyPress);
            // 
            // lblMemoriaGrafica
            // 
            this.lblMemoriaGrafica.AutoSize = true;
            this.lblMemoriaGrafica.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMemoriaGrafica.Location = new System.Drawing.Point(340, 59);
            this.lblMemoriaGrafica.Name = "lblMemoriaGrafica";
            this.lblMemoriaGrafica.Size = new System.Drawing.Size(141, 16);
            this.lblMemoriaGrafica.TabIndex = 36;
            this.lblMemoriaGrafica.Text = "Cant. memoria gráfica:";
            // 
            // txBMemoriaGrafica
            // 
            this.txBMemoriaGrafica.Location = new System.Drawing.Point(485, 56);
            this.txBMemoriaGrafica.Name = "txBMemoriaGrafica";
            this.txBMemoriaGrafica.Size = new System.Drawing.Size(171, 23);
            this.txBMemoriaGrafica.TabIndex = 37;
            this.txBMemoriaGrafica.TextChanged += new System.EventHandler(this.txBMemoriaGrafica_TextChanged);
            this.txBMemoriaGrafica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyNumerics_KeyPress);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblID.Location = new System.Drawing.Point(65, 213);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(27, 18);
            this.lblID.TabIndex = 16;
            this.lblID.Text = "ID:";
            // 
            // txBID
            // 
            this.txBID.Location = new System.Drawing.Point(111, 211);
            this.txBID.Name = "txBID";
            this.txBID.Size = new System.Drawing.Size(170, 23);
            this.txBID.TabIndex = 17;
            this.txBID.TextChanged += new System.EventHandler(this.txBID_TextChanged);
            this.txBID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnlyNumerics_KeyPress);
            // 
            // frmAgregarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.ClientSize = new System.Drawing.Size(663, 373);
            this.Controls.Add(this.txBMemoriaGrafica);
            this.Controls.Add(this.lblMemoriaGrafica);
            this.Controls.Add(this.txtTamanioDisco);
            this.Controls.Add(this.lblTamanioDisco);
            this.Controls.Add(this.cmbCantNucleos);
            this.Controls.Add(this.cmbFabricanteCPU);
            this.Controls.Add(this.cmbTipoDisco);
            this.Controls.Add(this.cmbGeneracion);
            this.Controls.Add(this.cmbTipoMemoria);
            this.Controls.Add(this.cmbTipoFuente);
            this.Controls.Add(this.cmbSocket);
            this.Controls.Add(this.cmbTipoMother);
            this.Controls.Add(this.grpInfoVital);
            this.Controls.Add(this.cmbTipoPlaca);
            this.Controls.Add(this.lblCantNucleos);
            this.Controls.Add(this.lblFabricanteCPU);
            this.Controls.Add(this.lblTipoDisco);
            this.Controls.Add(this.lblTipoFuente);
            this.Controls.Add(this.lblSocket);
            this.Controls.Add(this.lblTipoMother);
            this.Controls.Add(this.lblTipoPlacaVideo);
            this.Controls.Add(this.lblTipoMemoria);
            this.Controls.Add(this.lblGeneración);
            this.Controls.Add(this.cmbTipoProducto);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAgregarProducto";
            this.Text = "Agregar un producto";
            this.Load += new System.EventHandler(this.frmAgregarProducto_Load);
            this.grpInfoVital.ResumeLayout(false);
            this.grpInfoVital.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbMarcas;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.TextBox txBModelo;
        private System.Windows.Forms.Label lblPotencia;
        private System.Windows.Forms.Label lblConsumo;
        private System.Windows.Forms.TextBox txBPotencia;
        private System.Windows.Forms.TextBox txBConsumo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipoProducto;
        private System.Windows.Forms.Label lblGeneración;
        private System.Windows.Forms.Label lblTipoMemoria;
        private System.Windows.Forms.Label lblTipoPlacaVideo;
        private System.Windows.Forms.Label lblTipoMother;
        private System.Windows.Forms.Label lblSocket;
        private System.Windows.Forms.Label lblTipoFuente;
        private System.Windows.Forms.Label lblTipoDisco;
        private System.Windows.Forms.Label lblFabricanteCPU;
        private System.Windows.Forms.Label lblCantNucleos;
        private System.Windows.Forms.ComboBox cmbTipoPlaca;
        private System.Windows.Forms.GroupBox grpInfoVital;
        private System.Windows.Forms.ComboBox cmbTipoMother;
        private System.Windows.Forms.ComboBox cmbSocket;
        private System.Windows.Forms.ComboBox cmbTipoFuente;
        private System.Windows.Forms.ComboBox cmbTipoMemoria;
        private System.Windows.Forms.ComboBox cmbGeneracion;
        private System.Windows.Forms.ComboBox cmbTipoDisco;
        private System.Windows.Forms.ComboBox cmbFabricanteCPU;
        private System.Windows.Forms.ComboBox cmbCantNucleos;
        private System.Windows.Forms.Label lblTamanioDisco;
        private System.Windows.Forms.TextBox txtTamanioDisco;
        private System.Windows.Forms.Label lblMemoriaGrafica;
        private System.Windows.Forms.TextBox txBMemoriaGrafica;
        private System.Windows.Forms.TextBox txBPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txBID;
        private System.Windows.Forms.Label lblID;
    }
}