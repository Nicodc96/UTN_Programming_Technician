using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using Entidades;
using Entidades.BaseDeDatos;
using Entidades.Extension;
using Entidades.Serializador;
using System.Collections;
using System.Data;

namespace Formularios
{
    public partial class frmEstadisticas : Form
    {
        #region Atributos internos
        private List<Cliente> listaClientes;
        private List<Presupuesto> listaPresupuestos;
        private List<ComponenteElectronico> listaComponentes;
        private SerializadorXML<List<Cliente>> serializadorClientes;
        private SerializadorXML<List<Presupuesto>> serializadorPresupuestos;
        private SerializadorXML<List<ComponenteElectronico>> serializadorComponentes;
        private SqlConnection conexionEstadistica;
        private SqlCommand comandoEstadistica;
        private SqlDataReader dataReader;
        private string rutaConexion = "Data Source =.; Initial Catalog = DC_DB; Integrated Security = True";
        private ArrayList top5Productos;
        private ArrayList top5Cantidad;
        #endregion

        private delegate void ManejadorDeDatos();
        private event ManejadorDeDatos actualizadorDeDatos;
        public frmEstadisticas()
        {
            InitializeComponent();
            this.listaClientes = new List<Cliente>();
            this.listaPresupuestos = new List<Presupuesto>();
            this.listaComponentes = new List<ComponenteElectronico>();
            this.serializadorClientes = new SerializadorXML<List<Cliente>>();
            this.serializadorPresupuestos = new SerializadorXML<List<Presupuesto>>();
            this.serializadorComponentes = new SerializadorXML<List<ComponenteElectronico>>();
            this.conexionEstadistica = new SqlConnection(rutaConexion);
            this.top5Productos = new ArrayList();
            this.top5Cantidad = new ArrayList();
        }

        private void frmEstadisticas_Load(object sender, EventArgs e)
        {
            try
            {
                actualizadorDeDatos += this.CargarDatosEnListas;
                actualizadorDeDatos += this.TipoCantidadProductos;
                actualizadorDeDatos += this.Top5ProductosElegidos;
                actualizadorDeDatos += this.InformacionGeneral;
                actualizadorDeDatos += this.PresupuestoMasCaro;
                actualizadorDeDatos.Invoke();
            } catch (Exception)
            {
                MessageBox.Show("Se deben cargar datos en la base de datos para visualizar esta sección.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        #region Métodos para mostrar estadísticas
        private void PresupuestoMasCaro()
        {
            try
            {
                List<Presupuesto> listaConPresupuestoMasCaro = new List<Presupuesto>();
                this.comandoEstadistica = new SqlCommand("PresupuestoMasCaro", conexionEstadistica);
                this.comandoEstadistica.CommandType = CommandType.StoredProcedure;
                
                SqlParameter presupuestoMasCaro = new SqlParameter("@PresuMasCaro", 0);
                presupuestoMasCaro.Direction = ParameterDirection.Output;

                this.comandoEstadistica.Parameters.Add(presupuestoMasCaro);

                this.conexionEstadistica.Open();
                this.comandoEstadistica.ExecuteNonQuery();

                foreach (Presupuesto p in this.listaPresupuestos)
                {
                    if (p.PrecioFinal == float.Parse(this.comandoEstadistica.Parameters["@PresuMasCaro"].Value.ToString()))
                    {
                        listaConPresupuestoMasCaro.Add(p);
                        break;
                    }
                }
                this.dGVPresupuestoCaro.DataSource = listaConPresupuestoMasCaro;
            } catch(Exception)
            {
                throw;
            } finally
            {
                conexionEstadistica.Close();
            }
        }

        private void InformacionGeneral()
        {
            try
            {
                this.comandoEstadistica = new SqlCommand("CantidadDatos", conexionEstadistica);
                this.comandoEstadistica.CommandType = CommandType.StoredProcedure;

                SqlParameter totalVentas = new SqlParameter("@totalVentas", 0);
                totalVentas.Direction = ParameterDirection.Output;
                SqlParameter cantClientes = new SqlParameter("@cantidadClientes", 0);
                cantClientes.Direction = ParameterDirection.Output;
                SqlParameter cantPresupuestos = new SqlParameter("@cantidadPresupuestos", 0);
                cantPresupuestos.Direction = ParameterDirection.Output;
                SqlParameter cantComponentes = new SqlParameter("@cantidadComponentes", 0);
                cantComponentes.Direction = ParameterDirection.Output;

                this.comandoEstadistica.Parameters.Add(totalVentas);
                this.comandoEstadistica.Parameters.Add(cantClientes);
                this.comandoEstadistica.Parameters.Add(cantPresupuestos);
                this.comandoEstadistica.Parameters.Add(cantComponentes);

                this.conexionEstadistica.Open();
                this.comandoEstadistica.ExecuteNonQuery();

                this.lblTotalVentas.Text = $"${comandoEstadistica.Parameters["@totalVentas"].Value.ToString()}";
                this.lblCantClientes.Text = comandoEstadistica.Parameters["@cantidadClientes"].Value.ToString();
                this.lblCantPresupuestos.Text = comandoEstadistica.Parameters["@cantidadPresupuestos"].Value.ToString();
                this.lblCantComponentes.Text = comandoEstadistica.Parameters["@cantidadComponentes"].Value.ToString();
            } catch (Exception)
            {
                throw;
            }finally
            {
                this.conexionEstadistica.Close();
            }            
        }
        private void Top5ProductosElegidos()
        {
            try
            {
                comandoEstadistica = new SqlCommand("ProductosPreferidos", conexionEstadistica);
                comandoEstadistica.CommandType = CommandType.StoredProcedure;
                conexionEstadistica.Open();
                dataReader = comandoEstadistica.ExecuteReader();
                while (dataReader.Read())
                {
                    this.top5Productos.Add(dataReader["ProductoPreferido"].ToString());
                    this.top5Cantidad.Add(dataReader["Cantidad"].ToString());
                }
                this.dGVTop5.Rows.Add(5);
                for (int i = 0; i < this.top5Productos.Count; i++)
                {
                    this.dGVTop5.Rows[i].Cells[0].Value = this.top5Productos[i];
                }
                for (int i = 0; i < this.top5Cantidad.Count; i++)
                {
                    this.dGVTop5.Rows[i].Cells[1].Value = this.top5Cantidad[i];
                }
            } catch (Exception)
            {
                throw;
            }finally
            {
                if (dataReader is not null)
                {
                    this.dataReader.Close();
                }                
                this.conexionEstadistica.Close();
            }            
        }
        private void TipoCantidadProductos()
        {
            try
            {
                comandoEstadistica = new SqlCommand("TipoCantidadProductos", conexionEstadistica);
                comandoEstadistica.CommandType = CommandType.StoredProcedure;
                conexionEstadistica.Open();
                dataReader = comandoEstadistica.ExecuteReader();
                while (dataReader.Read())
                {
                    switch (dataReader["TipoProducto"].ToString())
                    {
                        case "Disco":
                            this.lblCantDisco.Text = dataReader["Cantidad"].ToString();
                            break;
                        case "Memoria":
                            this.lblCantMemorias.Text = dataReader["Cantidad"].ToString();
                            break;
                        case "Procesador":
                            this.lblCantProcesador.Text = dataReader["Cantidad"].ToString();
                            break;
                        case "PlacaDeVideo":
                            this.lblCantPlacaVideo.Text = dataReader["Cantidad"].ToString();
                            break;
                        case "FuenteDePoder":
                            this.lblCantFuentes.Text = dataReader["Cantidad"].ToString();
                            break;
                        case "PlacaMadre":
                            this.lblCantPlacaMadre.Text = dataReader["Cantidad"].ToString();
                            break;
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }finally
            {
                if (dataReader is not null)
                {
                    this.dataReader.Close();
                }
                this.conexionEstadistica.Close();
            }
        }
        #endregion

        private void btnCargarDatosBD_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarPrimeraVezDatosEnBD();                
                MessageBox.Show("Se han cargado los datos correctamente en la base de datos.", "Datos cargados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmEstadisticas_Load(sender, e);
            }
            catch (SqlException)
            {
                MessageBox.Show("Error! Base de datos inexistente o ya se han cargado los datos previamente!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region Cargar de archivos locales
        private void CargarDatosEnListas()
        {
            try
            {
                if (!File.Exists(serializadorClientes.RutaBase + @"\Datos\ResumenClientes.xml"))
                {
                    this.listaClientes = serializadorClientes.RecuperarDatos(Path.Combine(Environment.CurrentDirectory, @"Datos\ListaClientes.xml"));
                }
                else
                {
                    this.listaClientes = serializadorClientes.RecuperarDatos(Path.Combine(serializadorClientes.RutaBase, @"Datos\ResumenClientes.xml"));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se han podido cargar los datos de los clientes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (!File.Exists(serializadorPresupuestos.RutaBase + @"\Datos\ResumenPresupuestos.xml"))
                {
                    this.listaPresupuestos = serializadorPresupuestos.RecuperarDatos(Path.Combine(Environment.CurrentDirectory, @"Datos\ListaPresupuestos.xml"));
                }
                else
                {
                    this.listaPresupuestos = serializadorPresupuestos.RecuperarDatos(Path.Combine(serializadorPresupuestos.RutaBase, @"Datos\ResumenPresupuestos.xml"));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se han podido cargar los datos de los presupuestos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (!File.Exists(serializadorComponentes.RutaBase + @"\Datos\ResumenComponentes.xml"))
                {
                    this.listaComponentes = serializadorComponentes.RecuperarDatos(Path.Combine(Environment.CurrentDirectory, @"Datos\ListaComponentes.xml"));
                }
                else
                {
                    this.listaComponentes = serializadorComponentes.RecuperarDatos(Path.Combine(serializadorComponentes.RutaBase, @"Datos\ResumenComponentes.xml"));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se han podido cargar los datos de los componentes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void CargarPrimeraVezDatosEnBD()
        {
            this.CargarDatosEnListas();
            foreach (Cliente c in this.listaClientes)
            {
                c.GuardarClienteEnBD();
            }
            foreach (Presupuesto p in this.listaPresupuestos)
            {
                p.GuardarPresupuestoEnBD();
            }
            foreach (ComponenteElectronico cE in this.listaComponentes)
            {
                cE.GuardarComponenteEnBD();
            }
            DAO.GenerarDespensas(this.listaPresupuestos);
        }
    }
}
