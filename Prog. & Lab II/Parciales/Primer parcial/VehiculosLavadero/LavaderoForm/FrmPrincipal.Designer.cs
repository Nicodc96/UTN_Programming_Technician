
namespace LavaderoForm
{
    partial class frmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAgregarVehiculo = new System.Windows.Forms.Button();
            this.btnQuitarVehiculo = new System.Windows.Forms.Button();
            this.btnInformarListaOrdenada = new System.Windows.Forms.Button();
            this.grpBOrdenamientos = new System.Windows.Forms.GroupBox();
            this.rBMarca = new System.Windows.Forms.RadioButton();
            this.rBPatente = new System.Windows.Forms.RadioButton();
            this.lblEySVehiculos = new System.Windows.Forms.Label();
            this.lblGanancias = new System.Windows.Forms.Label();
            this.btnInformeGananciasTotal = new System.Windows.Forms.Button();
            this.grpGananciasTipo = new System.Windows.Forms.GroupBox();
            this.rBMoto = new System.Windows.Forms.RadioButton();
            this.rBCamion = new System.Windows.Forms.RadioButton();
            this.rBAuto = new System.Windows.Forms.RadioButton();
            this.btnInformarTipo = new System.Windows.Forms.Button();
            this.lblListaVehiculos = new System.Windows.Forms.Label();
            this.lblNombreLavadero = new System.Windows.Forms.Label();
            this.btnDefinirLavadero = new System.Windows.Forms.Button();
            this.lblPrecios = new System.Windows.Forms.Label();
            this.rTxtBPrecios = new System.Windows.Forms.RichTextBox();
            this.rTxtBActividad = new System.Windows.Forms.RichTextBox();
            this.rBSinOrden = new System.Windows.Forms.RadioButton();
            this.grpBOrdenamientos.SuspendLayout();
            this.grpGananciasTipo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgregarVehiculo
            // 
            this.btnAgregarVehiculo.Location = new System.Drawing.Point(12, 142);
            this.btnAgregarVehiculo.Name = "btnAgregarVehiculo";
            this.btnAgregarVehiculo.Size = new System.Drawing.Size(133, 31);
            this.btnAgregarVehiculo.TabIndex = 0;
            this.btnAgregarVehiculo.Text = "Agregar Vehiculo";
            this.btnAgregarVehiculo.UseVisualStyleBackColor = true;
            this.btnAgregarVehiculo.Click += new System.EventHandler(this.btnAgregarVehiculo_Click);
            // 
            // btnQuitarVehiculo
            // 
            this.btnQuitarVehiculo.Location = new System.Drawing.Point(151, 142);
            this.btnQuitarVehiculo.Name = "btnQuitarVehiculo";
            this.btnQuitarVehiculo.Size = new System.Drawing.Size(133, 31);
            this.btnQuitarVehiculo.TabIndex = 1;
            this.btnQuitarVehiculo.Text = "Quitar Vehiculo";
            this.btnQuitarVehiculo.UseVisualStyleBackColor = true;
            this.btnQuitarVehiculo.Click += new System.EventHandler(this.btnQuitarVehiculo_Click);
            // 
            // btnInformarListaOrdenada
            // 
            this.btnInformarListaOrdenada.Location = new System.Drawing.Point(584, 125);
            this.btnInformarListaOrdenada.Name = "btnInformarListaOrdenada";
            this.btnInformarListaOrdenada.Size = new System.Drawing.Size(143, 34);
            this.btnInformarListaOrdenada.TabIndex = 3;
            this.btnInformarListaOrdenada.Text = "Informar";
            this.btnInformarListaOrdenada.UseVisualStyleBackColor = true;
            this.btnInformarListaOrdenada.Click += new System.EventHandler(this.btnInformarListaOrdenada_Click);
            // 
            // grpBOrdenamientos
            // 
            this.grpBOrdenamientos.Controls.Add(this.rBSinOrden);
            this.grpBOrdenamientos.Controls.Add(this.rBMarca);
            this.grpBOrdenamientos.Controls.Add(this.rBPatente);
            this.grpBOrdenamientos.Location = new System.Drawing.Point(534, 23);
            this.grpBOrdenamientos.Name = "grpBOrdenamientos";
            this.grpBOrdenamientos.Size = new System.Drawing.Size(193, 96);
            this.grpBOrdenamientos.TabIndex = 4;
            this.grpBOrdenamientos.TabStop = false;
            this.grpBOrdenamientos.Text = "Ordenamiento por:";
            // 
            // rBMarca
            // 
            this.rBMarca.AutoSize = true;
            this.rBMarca.Location = new System.Drawing.Point(18, 64);
            this.rBMarca.Name = "rBMarca";
            this.rBMarca.Size = new System.Drawing.Size(58, 19);
            this.rBMarca.TabIndex = 1;
            this.rBMarca.TabStop = true;
            this.rBMarca.Text = "Marca";
            this.rBMarca.UseVisualStyleBackColor = true;
            // 
            // rBPatente
            // 
            this.rBPatente.AutoSize = true;
            this.rBPatente.Location = new System.Drawing.Point(18, 26);
            this.rBPatente.Name = "rBPatente";
            this.rBPatente.Size = new System.Drawing.Size(65, 19);
            this.rBPatente.TabIndex = 0;
            this.rBPatente.TabStop = true;
            this.rBPatente.Text = "Patente";
            this.rBPatente.UseVisualStyleBackColor = true;
            // 
            // lblEySVehiculos
            // 
            this.lblEySVehiculos.AutoSize = true;
            this.lblEySVehiculos.Location = new System.Drawing.Point(12, 124);
            this.lblEySVehiculos.Name = "lblEySVehiculos";
            this.lblEySVehiculos.Size = new System.Drawing.Size(161, 15);
            this.lblEySVehiculos.TabIndex = 5;
            this.lblEySVehiculos.Text = "Entrada y salida de vehiculos:";
            // 
            // lblGanancias
            // 
            this.lblGanancias.AutoSize = true;
            this.lblGanancias.Location = new System.Drawing.Point(12, 189);
            this.lblGanancias.Name = "lblGanancias";
            this.lblGanancias.Size = new System.Drawing.Size(124, 15);
            this.lblGanancias.TabIndex = 6;
            this.lblGanancias.Text = "Informe de ganancias:";
            // 
            // btnInformeGananciasTotal
            // 
            this.btnInformeGananciasTotal.Location = new System.Drawing.Point(151, 314);
            this.btnInformeGananciasTotal.Name = "btnInformeGananciasTotal";
            this.btnInformeGananciasTotal.Size = new System.Drawing.Size(133, 31);
            this.btnInformeGananciasTotal.TabIndex = 7;
            this.btnInformeGananciasTotal.Text = "Informar totalidad";
            this.btnInformeGananciasTotal.UseVisualStyleBackColor = true;
            this.btnInformeGananciasTotal.Click += new System.EventHandler(this.btnInformeGananciasTotal_Click);
            // 
            // grpGananciasTipo
            // 
            this.grpGananciasTipo.Controls.Add(this.rBMoto);
            this.grpGananciasTipo.Controls.Add(this.rBCamion);
            this.grpGananciasTipo.Controls.Add(this.rBAuto);
            this.grpGananciasTipo.Location = new System.Drawing.Point(18, 207);
            this.grpGananciasTipo.Name = "grpGananciasTipo";
            this.grpGananciasTipo.Size = new System.Drawing.Size(272, 101);
            this.grpGananciasTipo.TabIndex = 8;
            this.grpGananciasTipo.TabStop = false;
            this.grpGananciasTipo.Text = "Tipo de vehiculo:";
            // 
            // rBMoto
            // 
            this.rBMoto.AutoSize = true;
            this.rBMoto.Location = new System.Drawing.Point(6, 72);
            this.rBMoto.Name = "rBMoto";
            this.rBMoto.Size = new System.Drawing.Size(59, 19);
            this.rBMoto.TabIndex = 2;
            this.rBMoto.TabStop = true;
            this.rBMoto.Text = "Motos";
            this.rBMoto.UseVisualStyleBackColor = true;
            // 
            // rBCamion
            // 
            this.rBCamion.AutoSize = true;
            this.rBCamion.Location = new System.Drawing.Point(6, 47);
            this.rBCamion.Name = "rBCamion";
            this.rBCamion.Size = new System.Drawing.Size(78, 19);
            this.rBCamion.TabIndex = 1;
            this.rBCamion.TabStop = true;
            this.rBCamion.Text = "Camiones";
            this.rBCamion.UseVisualStyleBackColor = true;
            // 
            // rBAuto
            // 
            this.rBAuto.AutoSize = true;
            this.rBAuto.Location = new System.Drawing.Point(6, 22);
            this.rBAuto.Name = "rBAuto";
            this.rBAuto.Size = new System.Drawing.Size(56, 19);
            this.rBAuto.TabIndex = 0;
            this.rBAuto.TabStop = true;
            this.rBAuto.Text = "Autos";
            this.rBAuto.UseVisualStyleBackColor = true;
            // 
            // btnInformarTipo
            // 
            this.btnInformarTipo.Location = new System.Drawing.Point(18, 314);
            this.btnInformarTipo.Name = "btnInformarTipo";
            this.btnInformarTipo.Size = new System.Drawing.Size(133, 31);
            this.btnInformarTipo.TabIndex = 9;
            this.btnInformarTipo.Text = "Informar";
            this.btnInformarTipo.UseVisualStyleBackColor = true;
            this.btnInformarTipo.Click += new System.EventHandler(this.btnInformarTipo_Click);
            // 
            // lblListaVehiculos
            // 
            this.lblListaVehiculos.AutoSize = true;
            this.lblListaVehiculos.Location = new System.Drawing.Point(291, 7);
            this.lblListaVehiculos.Name = "lblListaVehiculos";
            this.lblListaVehiculos.Size = new System.Drawing.Size(153, 15);
            this.lblListaVehiculos.TabIndex = 10;
            this.lblListaVehiculos.Text = "Información de actividades:";
            // 
            // lblNombreLavadero
            // 
            this.lblNombreLavadero.AutoSize = true;
            this.lblNombreLavadero.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblNombreLavadero.Location = new System.Drawing.Point(46, 2);
            this.lblNombreLavadero.Name = "lblNombreLavadero";
            this.lblNombreLavadero.Size = new System.Drawing.Size(127, 20);
            this.lblNombreLavadero.TabIndex = 11;
            this.lblNombreLavadero.Text = "Lavadero: \"N/A\"";
            // 
            // btnDefinirLavadero
            // 
            this.btnDefinirLavadero.Location = new System.Drawing.Point(12, 90);
            this.btnDefinirLavadero.Name = "btnDefinirLavadero";
            this.btnDefinirLavadero.Size = new System.Drawing.Size(133, 31);
            this.btnDefinirLavadero.TabIndex = 12;
            this.btnDefinirLavadero.Text = "Definir lavadero";
            this.btnDefinirLavadero.UseVisualStyleBackColor = true;
            this.btnDefinirLavadero.Click += new System.EventHandler(this.btnDefinirLavadero_Click);
            // 
            // lblPrecios
            // 
            this.lblPrecios.AutoSize = true;
            this.lblPrecios.Location = new System.Drawing.Point(12, 23);
            this.lblPrecios.Name = "lblPrecios";
            this.lblPrecios.Size = new System.Drawing.Size(48, 15);
            this.lblPrecios.TabIndex = 13;
            this.lblPrecios.Text = "Precios:";
            // 
            // rTxtBPrecios
            // 
            this.rTxtBPrecios.Location = new System.Drawing.Point(14, 39);
            this.rTxtBPrecios.Name = "rTxtBPrecios";
            this.rTxtBPrecios.Size = new System.Drawing.Size(257, 50);
            this.rTxtBPrecios.TabIndex = 14;
            this.rTxtBPrecios.Text = "";
            // 
            // rTxtBActividad
            // 
            this.rTxtBActividad.Location = new System.Drawing.Point(290, 23);
            this.rTxtBActividad.Name = "rTxtBActividad";
            this.rTxtBActividad.Size = new System.Drawing.Size(238, 332);
            this.rTxtBActividad.TabIndex = 15;
            this.rTxtBActividad.Text = "";
            // 
            // rBSinOrden
            // 
            this.rBSinOrden.AutoSize = true;
            this.rBSinOrden.Location = new System.Drawing.Point(96, 26);
            this.rBSinOrden.Name = "rBSinOrden";
            this.rBSinOrden.Size = new System.Drawing.Size(77, 19);
            this.rBSinOrden.TabIndex = 2;
            this.rBSinOrden.TabStop = true;
            this.rBSinOrden.Text = "Sin Orden";
            this.rBSinOrden.UseVisualStyleBackColor = true;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 367);
            this.Controls.Add(this.rTxtBActividad);
            this.Controls.Add(this.rTxtBPrecios);
            this.Controls.Add(this.lblPrecios);
            this.Controls.Add(this.btnDefinirLavadero);
            this.Controls.Add(this.lblNombreLavadero);
            this.Controls.Add(this.lblListaVehiculos);
            this.Controls.Add(this.btnInformarTipo);
            this.Controls.Add(this.grpGananciasTipo);
            this.Controls.Add(this.btnInformeGananciasTotal);
            this.Controls.Add(this.lblGanancias);
            this.Controls.Add(this.lblEySVehiculos);
            this.Controls.Add(this.grpBOrdenamientos);
            this.Controls.Add(this.btnInformarListaOrdenada);
            this.Controls.Add(this.btnQuitarVehiculo);
            this.Controls.Add(this.btnAgregarVehiculo);
            this.Name = "frmPrincipal";
            this.Text = "Lavadero de Vehiculos";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.grpBOrdenamientos.ResumeLayout(false);
            this.grpBOrdenamientos.PerformLayout();
            this.grpGananciasTipo.ResumeLayout(false);
            this.grpGananciasTipo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAgregarVehiculo;
        private System.Windows.Forms.Button btnQuitarVehiculo;
        private System.Windows.Forms.Button btnInformarListaOrdenada;
        private System.Windows.Forms.GroupBox grpBOrdenamientos;
        private System.Windows.Forms.RadioButton rBMarca;
        private System.Windows.Forms.RadioButton rBPatente;
        private System.Windows.Forms.Label lblEySVehiculos;
        private System.Windows.Forms.Label lblGanancias;
        private System.Windows.Forms.Button btnInformeGananciasTotal;
        private System.Windows.Forms.GroupBox grpGananciasTipo;
        private System.Windows.Forms.RadioButton rBMoto;
        private System.Windows.Forms.RadioButton rBCamion;
        private System.Windows.Forms.RadioButton rBAuto;
        private System.Windows.Forms.Button btnInformarTipo;
        private System.Windows.Forms.Label lblListaVehiculos;
        private System.Windows.Forms.Label lblNombreLavadero;
        private System.Windows.Forms.Button btnDefinirLavadero;
        private System.Windows.Forms.Label lblPrecios;
        private System.Windows.Forms.RichTextBox rTxtBPrecios;
        private System.Windows.Forms.RichTextBox rTxtBActividad;
        private System.Windows.Forms.RadioButton rBSinOrden;
    }
}

