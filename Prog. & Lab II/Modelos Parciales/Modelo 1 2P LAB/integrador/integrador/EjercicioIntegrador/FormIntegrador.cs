using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioIntegrador
{
    public partial class FormIntegrador : Form
    {
        public FormIntegrador()
        {
            InitializeComponent();


      


            this.StartPosition = FormStartPosition.CenterScreen;
        }



         /* 
           1- Crear un objeto de tipo Planeta.
           2- Serializarlo y mostrar en un MessageBox lo sucedido.
		   3- Si serializo, deserializarlo y mostrarlo en el RichTextBox.
         */
        private void btn1_Click(object sender, EventArgs e)
        {


        }



        /*
        1- Crear tres objetos de tipo Planeta.
		2- Crear objeto de tipo SistemaSolar.
		3- Agregarlos planetas al sistema solar.
        4- Mostrarlos en el RichTextBox.
        */
        private void btn2_Click(object sender, EventArgs e)
        {

        }




        /*
         1- Crear tres objetos de tipo Planeta.
		 2- Crear objeto de tipo SistemaSolar con capacidad=2.
		 3- Atrapar la Excepción "NoHayLugarException" en un bloque try-catch 
         4- Mostrar el mensaje de error en un MessageBox.
         */
        private void btn3_Click(object sender, EventArgs e)
        {

        }


        /*
         * 1-Creo un objeto planeta
         * 2-Asociar evento al manejador "PlanetaConMuchaGravedad"
         * 3-Hago saltar el evento
         * 4-Atrapo y muestro la gravedad del planeta en el RichTextBox
         
         */

        private void btn4_Click(object sender, EventArgs e)
        {

        }




        /*
         1-Crea un Task, creo el método TraerPlanetas():void
         2-En el subproceso invoco al método TraerPlanetas()
         2-Traigo los planetas de la base de datos a través del hilo secundario.
         3-Modifico el ReachTextBox a través del hilo principal.
         */
        private void btnTraer_Click(object sender, EventArgs e)
        {

        }


        /*
         1- Invoca al formulario de alta.
		 2- Si se acepta, se actualiza BD, se agrega a la lista.
         3- Retorna la lista y muestra en el RichTextBox.
         * */
        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        /*
         1 Invoca el formulario de alta a modificar pasandole los datos para mostrar.
		 2- Si se acepta el modificado, se actualiza BD 
         3-retorna la lista y muestra en el RichTextBox.
         * */
        private void btnModificar_Click(object sender, EventArgs e)
        {

        }



        /*
         1- Invoca el formulario de alta a eliminar pasandole los datos para mostrar.
		 2- Si se acepta el eliminado, se actualiza BD
         3-retorna la lista y muestra.
         */
        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }


       
    }
}
