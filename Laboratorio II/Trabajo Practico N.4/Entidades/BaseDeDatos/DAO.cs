using Entidades.Componentes;
using Entidades.Enumerado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Entidades.BaseDeDatos
{
    /// <summary>
    /// DAO = Database Access Object. Clase encargada de acceder a la base de datos y realizar las operaciones solicitadas.
    /// </summary>
    public static class DAO
    {
        private static SqlConnection conexion;
        private static SqlCommand comando;
        private static string connectionString;

        static DAO()
        {
            connectionString = "Data Source=.;Initial Catalog=DC_DB;Integrated Security=True";
            conexion = new SqlConnection(connectionString);
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;
        }
        /// <summary>
        /// Obtiene todos los componentes electrónicos que se encuentran en la base de datos, filtrando por tipo.
        /// </summary>
        /// <returns>La lista con los componentes.</returns>
        public static List<ComponenteElectronico> ObtenerComponentes()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                comando.Parameters.Clear();
                conexion.Open();
                List<ComponenteElectronico> listaDBComponentes = new List<ComponenteElectronico>();
                comando.CommandText = "SELECT * FROM ComponenteElectronico";
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {
                    switch (dataReader["discriminator"].ToString())
                    {
                        case "Disco":
                            listaDBComponentes += new Disco((EMarcas)Enum.Parse(typeof(EMarcas), dataReader["marca"].ToString()),
                                dataReader["modelo"].ToString(),
                                float.Parse(dataReader["potencia"].ToString()),
                                float.Parse(dataReader["consumo"].ToString()),
                                float.Parse(dataReader["precio"].ToString()),
                                short.Parse(dataReader["espacioDisco"].ToString()),
                                (ETipoDisco)Enum.Parse(typeof(ETipoDisco), dataReader["tipoDisco"].ToString()),
                                int.Parse(dataReader["id"].ToString()));
                            break;
                        case "FuenteDePoder":
                            listaDBComponentes += new FuenteDePoder((EMarcas)Enum.Parse(typeof(EMarcas), dataReader["marca"].ToString()),
                                dataReader["modelo"].ToString(),
                                float.Parse(dataReader["potencia"].ToString()),
                                float.Parse(dataReader["consumo"].ToString()),
                                float.Parse(dataReader["precio"].ToString()),
                                (ETipoFuente)Enum.Parse(typeof(ETipoFuente), dataReader["tipoFuente"].ToString()),
                                int.Parse(dataReader["id"].ToString()));
                            break;
                        case "Memoria":
                            listaDBComponentes += new Memoria((EMarcas)Enum.Parse(typeof(EMarcas), dataReader["marca"].ToString()),
                                dataReader["modelo"].ToString(),
                                float.Parse(dataReader["potencia"].ToString()),
                                float.Parse(dataReader["consumo"].ToString()),
                                float.Parse(dataReader["precio"].ToString()),
                                (ETipoMemoria)Enum.Parse(typeof(ETipoMemoria), dataReader["tipoMemoria"].ToString()),
                                (ETecnologiaMemoria)Enum.Parse(typeof(ETecnologiaMemoria), dataReader["tecnologiaMemoria"].ToString()),
                                int.Parse(dataReader["id"].ToString()));
                            break;
                        case "PlacaDeVideo":
                            listaDBComponentes += new PlacaDeVideo((EMarcas)Enum.Parse(typeof(EMarcas), dataReader["marca"].ToString()),
                                dataReader["modelo"].ToString(),
                                float.Parse(dataReader["potencia"].ToString()),
                                float.Parse(dataReader["consumo"].ToString()),
                                float.Parse(dataReader["precio"].ToString()),
                                float.Parse(dataReader["memoriaGrafica"].ToString()),
                                (ETipoPlaca)Enum.Parse(typeof(ETipoPlaca), dataReader["tipoPlacaVideo"].ToString()),
                                int.Parse(dataReader["id"].ToString()));
                            break;
                        case "PlacaMadre":
                            listaDBComponentes += new PlacaMadre((EMarcas)Enum.Parse(typeof(EMarcas), dataReader["marca"].ToString()),
                                dataReader["modelo"].ToString(),
                                float.Parse(dataReader["potencia"].ToString()),
                                float.Parse(dataReader["consumo"].ToString()),
                                float.Parse(dataReader["precio"].ToString()),
                                (ETipoMother)Enum.Parse(typeof(ETipoMother),dataReader["tipoPlacamadre"].ToString()),
                                (ESocket)Enum.Parse(typeof(ESocket), dataReader["tipoSocket"].ToString()),
                                int.Parse(dataReader["id"].ToString()));
                            break;
                        case "Procesador":
                            listaDBComponentes += new Procesador((EMarcas)Enum.Parse(typeof(EMarcas), dataReader["marca"].ToString()),
                                dataReader["modelo"].ToString(),
                                float.Parse(dataReader["potencia"].ToString()),
                                float.Parse(dataReader["consumo"].ToString()),
                                float.Parse(dataReader["precio"].ToString()),
                                (EFabricanteCPU)Enum.Parse(typeof(EFabricanteCPU), dataReader["nombreFabricante"].ToString()),
                                (ECantidadNucleos)Enum.Parse(typeof(ECantidadNucleos), dataReader["cantidadNucleos"].ToString()),
                                int.Parse(dataReader["id"].ToString()));
                            break;
                    }
                }
                return listaDBComponentes;
            }catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Obtiene todos los clientes que se encuentren actualmente en la base de datos.
        /// </summary>
        /// <returns>La lista con los clientes.</returns>
        public static List<Cliente> ObtenerClientes()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                comando.Parameters.Clear();
                conexion.Open();
                List<Cliente> listaDBClientes = new List<Cliente>();
                comando.CommandText = "SELECT * FROM Cliente";
                SqlDataReader dataReader = comando.ExecuteReader();
                while(dataReader.Read())
                {
                    listaDBClientes += new Cliente(dataReader["nombre"].ToString(),
                        dataReader["apellido"].ToString(),
                        dataReader["CUIL"].ToString(),
                        byte.Parse(dataReader["edad"].ToString()),
                        char.Parse(dataReader["sexo"].ToString()),
                        int.Parse(dataReader["id"].ToString()),
                        int.Parse(dataReader["idPresupuesto"].ToString()));
                }
                return listaDBClientes;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Obtiene todos los presupuestos que se encuentren actualmente en la base de datos.
        /// </summary>
        /// <returns>La lista con los presupuestos.</returns>
        public static List<Presupuesto> ObtenerPresupuestos()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                comando.Parameters.Clear();
                conexion.Open();
                List<Presupuesto> listaDBPresupuestos = new List<Presupuesto>();
                comando.CommandText = "SELECT * FROM Presupuesto";
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {
                    listaDBPresupuestos.Add(new Presupuesto(0,
                        (DateTime)dataReader["fechaEmision"],
                        int.Parse(dataReader["id"].ToString()),
                        int.Parse(dataReader["idCliente"].ToString())));
                }
                return listaDBPresupuestos;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Recupera de la base de datos todos los componentes electrónicos que corresponden al presupuesto por parámetro.
        /// </summary>
        /// <param name="presupuesto">El presupuesto a completar</param>
        public static void LlenarListaComponentesDePresupuesto(Presupuesto presupuesto)
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "SELECT cE.* FROM ComponenteElectronico cE INNER JOIN Despensas d ON cE.id = d.idProducto WHERE d.idPresupuesto = @idPresu";
                comando.Parameters.AddWithValue("@idPresu", presupuesto.ID_Presupuesto);
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {
                    switch (dataReader["discriminator"].ToString())
                    {
                        case "Disco":
                            presupuesto.ListaDeComponentes += new Disco((EMarcas)Enum.Parse(typeof(EMarcas), dataReader["marca"].ToString()),
                                dataReader["modelo"].ToString(),
                                float.Parse(dataReader["potencia"].ToString()),
                                float.Parse(dataReader["consumo"].ToString()),
                                float.Parse(dataReader["precio"].ToString()),
                                short.Parse(dataReader["espacioDisco"].ToString()),
                                (ETipoDisco)Enum.Parse(typeof(ETipoDisco), dataReader["tipoDisco"].ToString()),
                                int.Parse(dataReader["id"].ToString()));
                            break;
                        case "FuenteDePoder":
                            presupuesto.ListaDeComponentes += new FuenteDePoder((EMarcas)Enum.Parse(typeof(EMarcas), dataReader["marca"].ToString()),
                                dataReader["modelo"].ToString(),
                                float.Parse(dataReader["potencia"].ToString()),
                                float.Parse(dataReader["consumo"].ToString()),
                                float.Parse(dataReader["precio"].ToString()),
                                (ETipoFuente)Enum.Parse(typeof(ETipoFuente), dataReader["tipoFuente"].ToString()),
                                int.Parse(dataReader["id"].ToString()));
                            break;
                        case "Memoria":
                            presupuesto.ListaDeComponentes += new Memoria((EMarcas)Enum.Parse(typeof(EMarcas), dataReader["marca"].ToString()),
                                dataReader["modelo"].ToString(),
                                float.Parse(dataReader["potencia"].ToString()),
                                float.Parse(dataReader["consumo"].ToString()),
                                float.Parse(dataReader["precio"].ToString()),
                                (ETipoMemoria)Enum.Parse(typeof(ETipoMemoria), dataReader["tipoMemoria"].ToString()),
                                (ETecnologiaMemoria)Enum.Parse(typeof(ETecnologiaMemoria), dataReader["tecnologiaMemoria"].ToString()),
                                int.Parse(dataReader["id"].ToString()));
                            break;
                        case "PlacaDeVideo":
                            presupuesto.ListaDeComponentes += new PlacaDeVideo((EMarcas)Enum.Parse(typeof(EMarcas), dataReader["marca"].ToString()),
                                dataReader["modelo"].ToString(),
                                float.Parse(dataReader["potencia"].ToString()),
                                float.Parse(dataReader["consumo"].ToString()),
                                float.Parse(dataReader["precio"].ToString()),
                                float.Parse(dataReader["memoriaGrafica"].ToString()),
                                (ETipoPlaca)Enum.Parse(typeof(ETipoPlaca), dataReader["tipoPlacaVideo"].ToString()),
                                int.Parse(dataReader["id"].ToString()));
                            break;
                        case "PlacaMadre":
                            presupuesto.ListaDeComponentes += new PlacaMadre((EMarcas)Enum.Parse(typeof(EMarcas), dataReader["marca"].ToString()),
                                dataReader["modelo"].ToString(),
                                float.Parse(dataReader["potencia"].ToString()),
                                float.Parse(dataReader["consumo"].ToString()),
                                float.Parse(dataReader["precio"].ToString()),
                                (ETipoMother)Enum.Parse(typeof(ETipoMother), dataReader["tipoPlacamadre"].ToString()),
                                (ESocket)Enum.Parse(typeof(ESocket), dataReader["tipoSocket"].ToString()),
                                int.Parse(dataReader["id"].ToString()));
                            break;
                        case "Procesador":
                            presupuesto.ListaDeComponentes += new Procesador((EMarcas)Enum.Parse(typeof(EMarcas), dataReader["marca"].ToString()),
                                dataReader["modelo"].ToString(),
                                float.Parse(dataReader["potencia"].ToString()),
                                float.Parse(dataReader["consumo"].ToString()),
                                float.Parse(dataReader["precio"].ToString()),
                                (EFabricanteCPU)Enum.Parse(typeof(EFabricanteCPU), dataReader["nombreFabricante"].ToString()),
                                (ECantidadNucleos)Enum.Parse(typeof(ECantidadNucleos), dataReader["cantidadNucleos"].ToString()),
                                int.Parse(dataReader["id"].ToString()));
                            break;
                    }
                }
                presupuesto.CantidadComponentes = 0;
            }catch(SqlException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("No se ha podido guardar los componentes en la lista.", ex);
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Agrego una nueva despensa a partir de un ID de un presupuesto y un ID de un producto
        /// </summary>
        /// <param name="idPresupuesto">ID del presupuesto</param>
        /// <param name="idProducto">ID del producto</param>
        public static void AgregarDespensa(int idPresupuesto, int idProducto)
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "INSERT INTO Despensas (idProducto, idPresupuesto) VALUES (@idComp, @idPresu)";                
                comando.Parameters.AddWithValue("@idPresu", idPresupuesto);
                comando.Parameters.AddWithValue("@idComp", idProducto);
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Agrego una o más despensas a la base de datos al crear un nuevo presupuesto
        /// </summary>
        /// <param name="presupuesto">Presupuesto con una lista de componentes</param>
        public static void AgregarDespensas(Presupuesto presupuesto)
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "INSERT INTO Despensas (idProducto, idPresupuesto) VALUES (@idComp, @idPresu)";
                for (int i = 0; i < presupuesto.ListaDeComponentes.Count; i++)
                {
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@idPresu", presupuesto.ID_Presupuesto);
                    comando.Parameters.AddWithValue("@idComp", presupuesto.ListaDeComponentes[i].ID);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Método para uso interno. Guarda en la tabla 'Despensas' de la base de datos una despensa que posee tres ID:
        /// un ID propio, un ID que hace referencia a un producto y un ID que hace referencia a un presupuesto. Esta tabla
        /// hará de unión entre un Presupuesto y los componentes electrónicos.
        /// </summary>
        /// <param name="listaPresupuestos">Presupuestos que DEBEN tener componentes cargados</param>
        public static void GenerarDespensas(List<Presupuesto> listaPresupuestos)
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "INSERT INTO Despensas (idProducto, idPresupuesto) VALUES (@idComp, @idPresu)";
                foreach (Presupuesto p in listaPresupuestos)
                {
                    for (int i = 0; i < p.ListaDeComponentes.Count; i++)
                    {
                        comando.Parameters.Clear();
                        comando.Parameters.AddWithValue("@idPresu", p.ID_Presupuesto);
                        comando.Parameters.AddWithValue("@idComp", p.ListaDeComponentes[i].ID);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Remueve la/s despensa/s que contengan una id de un producto que se ha removido de la base de datos
        /// </summary>
        /// <param name="idProducto">ID del producto que se ha removido</param>
        /// <returns>True si se ha removido al menos una despensa, de lo contrario false.</returns>
        public static bool RemoverDespensasPorProducto(int idProducto)
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                bool haRemovido = false;
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "DELETE FROM Despensas WHERE idProducto = @idDelProducto";
                comando.Parameters.AddWithValue("@idDelProducto", idProducto);
                if (comando.ExecuteNonQuery() >= 1)
                {
                    haRemovido = true;
                }
                return haRemovido;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Remueve la/s despensa/s que contengan una id de un presupuesto que se ha removido de la base de datos
        /// </summary>
        /// <param name="idPresupuesto">ID del presupuesto que se ha removido</param>
        /// <returns>True si se ha removido al menos una despensa, de lo contrario false.</returns>
        public static bool RemoverDespensasPorPresupuesto(int idPresupuesto)
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                bool haRemovido = false;
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "DELETE FROM Despensas WHERE idPresupuesto = @idDelPresupuesto";
                comando.Parameters.AddWithValue("@idDelPresupuesto", idPresupuesto);
                if (comando.ExecuteNonQuery() >= 1)
                {
                    haRemovido = true;
                }
                return haRemovido;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Guarda una lista de Componentes en la base de datos
        /// </summary>
        /// <param name="listaComponentes">Lista a guardar</param>
        /// <returns>True si se ha guardado correctamente la lista, de lo contrario False.</returns>
        public static bool GuardarComponente(List<ComponenteElectronico> listaComponentes)
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                bool guardadoCompletado = false;
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "DELETE FROM ComponenteElectronico";
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                foreach (ComponenteElectronico cE in listaComponentes)
                {
                    guardadoCompletado = GuardarComponente(cE);
                }
                return guardadoCompletado;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Guarda un Componente en la base de datos
        /// </summary>
        /// <param name="componente">Componente a guardar</param>
        /// <returns>True si se ha guardado correctamente el componente, de lo contrario False.</returns>
        public static bool GuardarComponente(ComponenteElectronico componente)
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                bool guardadoCompletado = false;
                comando.Parameters.Clear();
                conexion.Open();
                switch (componente)
                {
                    case Disco:
                        comando.CommandText = "INSERT INTO ComponenteElectronico (id, marca, modelo, potencia, consumo, precio, espacioDisco, tipoDisco, discriminator) VALUES (@id, @marca, @modelo, @potencia, @consumo, @precio, @espacioDisco, @tipoDisco, 'Disco')";
                        comando.Parameters.AddWithValue("@espacioDisco", ((Disco)componente).EspacioTotal);
                        comando.Parameters.AddWithValue("@tipoDisco", ((Disco)componente).Tipo);
                        break;
                    case FuenteDePoder:
                        comando.CommandText = "INSERT INTO ComponenteElectronico (id, marca, modelo, potencia, consumo, precio, tipoFuente, discriminator) VALUES(@id, @marca, @modelo, @potencia, @consumo, @precio, @tipoFuente, 'FuenteDePoder')";
                        comando.Parameters.AddWithValue("@tipoFuente", ((FuenteDePoder)componente).TipoDeFuente);
                        break;
                    case Memoria:
                        comando.CommandText = "INSERT INTO ComponenteElectronico (id, marca, modelo, potencia, consumo, precio, tipoMemoria, tecnologiaMemoria, discriminator) values (@id, @marca, @modelo, @potencia, @consumo, @precio, @tipoMemoria, @tecnologia, 'Memoria')";
                        comando.Parameters.AddWithValue("@tipoMemoria", ((Memoria)componente).TipoMemoria);
                        comando.Parameters.AddWithValue("@tecnologia", ((Memoria)componente).Tecnologia);
                        break;
                    case PlacaDeVideo:
                        comando.CommandText = "INSERT INTO ComponenteElectronico (id, marca, modelo, potencia, consumo, precio, tipoPlacaVideo, memoriaGrafica, discriminator) values (@id, @marca, @modelo, @potencia, @consumo, @precio, @tipoPlaca, @cantMemoria, 'PlacaDeVideo')";
                        comando.Parameters.AddWithValue("@tipoPlaca", ((PlacaDeVideo)componente).Tipo);
                        comando.Parameters.AddWithValue("@cantMemoria", ((PlacaDeVideo)componente).MemoriaGrafica);
                        break;
                    case PlacaMadre:
                        comando.CommandText = "INSERT INTO ComponenteElectronico (id, marca, modelo, potencia, consumo, precio, tipoPlacamadre, tipoSocket, discriminator) VALUES(@id, @marca, @modelo, @potencia, @consumo, @precio, @tipoPlaca, @tipoSocket, 'PlacaMadre')";
                        comando.Parameters.AddWithValue("@tipoPlaca", ((PlacaMadre)componente).TipoDeMother);
                        comando.Parameters.AddWithValue("@tipoSocket", ((PlacaMadre)componente).Socket);
                        break;
                    case Procesador:
                        comando.CommandText = "INSERT INTO ComponenteElectronico (id, marca, modelo, potencia, consumo, precio, nombreFabricante, cantidadNucleos, discriminator) VALUES(@id, @marca, @modelo, @potencia, @consumo, @precio, @fabricante, @cantNucleos, 'Procesador')";
                        comando.Parameters.AddWithValue("@fabricante", ((Procesador)componente).Fabricante);
                        comando.Parameters.AddWithValue("@cantNucleos", ((Procesador)componente).Nucleos);
                        break;
                }
                comando.Parameters.AddWithValue("@id", componente.ID);
                comando.Parameters.AddWithValue("@marca", componente.Marca);
                comando.Parameters.AddWithValue("@modelo", componente.Modelo);
                comando.Parameters.AddWithValue("@potencia", componente.Potencia);
                comando.Parameters.AddWithValue("@consumo", componente.Consumo);
                comando.Parameters.AddWithValue("@precio", componente.Precio);
                if (comando.ExecuteNonQuery() > 0)
                {
                    guardadoCompletado = true;
                }
                return guardadoCompletado;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Guarda una lista de Clientes en la base de datos
        /// </summary>
        /// <param name="listaClientes">Lista a guardar</param>
        /// <returns>True si ha guardado correctamente la lista, de lo contrario false.</returns>
        public static bool GuardarCliente(List<Cliente> listaClientes)
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                bool guardadoCompletado = false;
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "DELETE FROM Cliente";
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                foreach (Cliente c in listaClientes)
                {
                    guardadoCompletado = GuardarCliente(c);
                }
                return guardadoCompletado;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Guarda un Cliente en la base de datos
        /// </summary>
        /// <param name="cliente">Cliente a guardar</param>
        /// <returns>True si ha guardado correctamente el cliente, de lo contrario false.</returns>
        public static bool GuardarCliente(Cliente cliente)
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                bool guardadoCompletado = false;
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "INSERT INTO Cliente (id, nombre, apellido, CUIL, edad, sexo, idPresupuesto) VALUES (@id, @nombre, @apellido, @CUIL, @edad, @sexo, @idPresu)";
                comando.Parameters.AddWithValue("@id", cliente.ID);
                comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@apellido", cliente.Apellido);
                comando.Parameters.AddWithValue("@CUIL", cliente.CUIL_CUIT);
                comando.Parameters.AddWithValue("@edad", cliente.Edad);
                comando.Parameters.AddWithValue("@sexo", cliente.Sexo);
                comando.Parameters.AddWithValue("@idPresu", cliente.ID_Presupuesto);
                if (comando.ExecuteNonQuery() > 0)
                {
                    guardadoCompletado = true;
                }
                return guardadoCompletado;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Guarda una lista de Presupuestos en la base de datos
        /// </summary>
        /// <param name="listaPresupuestos">Lista a guardar</param>
        /// <returns>True si se ha guardado correctamente la lista, de lo contrario False.</returns>
        public static bool GuardarPresupuesto(List<Presupuesto> listaPresupuestos)
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                bool guardadoCompletado = false;
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "DELETE FROM Presupuesto";
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                foreach (Presupuesto p in listaPresupuestos)
                {
                    guardadoCompletado = GuardarPresupuesto(p);
                }
                return guardadoCompletado;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Guarda un Presupuesto en la base de datos
        /// </summary>
        /// <param name="presupuesto">Presupuesto a guardar</param>
        /// <returns>True si se ha guardado correctamente el presupuesto, de lo contrario False.</returns>
        public static bool GuardarPresupuesto(Presupuesto presupuesto)
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                bool guardadoCompletado = false;
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "INSERT INTO Presupuesto (id, fechaEmision, precioFinal, idCliente) VALUES (@id, @fecha, @precio, @idCliente)";
                comando.Parameters.AddWithValue("@id", presupuesto.ID_Presupuesto);
                comando.Parameters.AddWithValue("@fecha", presupuesto.FechaEmision);
                comando.Parameters.AddWithValue("@precio", presupuesto.PrecioFinal);
                comando.Parameters.AddWithValue("@idCliente", presupuesto.ID_Cliente);
                if (comando.ExecuteNonQuery() > 0)
                {
                    guardadoCompletado = true;
                }
                return guardadoCompletado;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Modifica un componente de la base de datos según el ID del componente por parámetro
        /// </summary>
        /// <param name="componente">Componente con los valores nuevos</param>
        /// <returns>True si se ha modificado correctamente, de lo contrario false.</returns>
        public static bool ActualizarComponente(ComponenteElectronico componente)
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                bool actualizadoCompleto = false;
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "UPDATE ComponenteElectronico SET marca = @marca, modelo = @modelo, potencia = @potencia, consumo = @consumo, precio = @precio, ";
                switch(componente)
                {
                    case Disco:
                        comando.CommandText += "tipoDisco = @tipoDisco, espacioDisco = @espacioDisco ";
                        comando.Parameters.AddWithValue("@espacioDisco", ((Disco)componente).EspacioTotal);
                        comando.Parameters.AddWithValue("@tipoDisco", ((Disco)componente).Tipo);
                        break;
                    case FuenteDePoder:
                        comando.CommandText += "tipoFuente = @tipoFuente ";
                        comando.Parameters.AddWithValue("@tipoFuente", ((FuenteDePoder)componente).TipoDeFuente);
                        break;
                    case Memoria:
                        comando.CommandText += "tipoMemoria = @tipoMemoria, tecnologiaMemoria = @tecnologia ";
                        comando.Parameters.AddWithValue("@tipoMemoria", ((Memoria)componente).TipoMemoria);
                        comando.Parameters.AddWithValue("@tecnologia", ((Memoria)componente).Tecnologia);
                        break;
                    case PlacaDeVideo:
                        comando.CommandText += "tipoPlacaVideo = @tipoPlaca, memoriaGrafica = @cantMemoria ";
                        comando.Parameters.AddWithValue("@tipoPlaca", ((PlacaDeVideo)componente).Tipo);
                        comando.Parameters.AddWithValue("@cantMemoria", ((PlacaDeVideo)componente).MemoriaGrafica);
                        break;
                    case PlacaMadre:
                        comando.CommandText += "tipoPlacamadre = @tipoPlaca, tipoSocket = @tipoSocket ";
                        comando.Parameters.AddWithValue("@tipoPlaca", ((PlacaMadre)componente).TipoDeMother);
                        comando.Parameters.AddWithValue("@tipoSocket", ((PlacaMadre)componente).Socket);
                        break;
                    case Procesador:
                        comando.CommandText += "nombreFabricante = @fabricante, cantidadNucleos = @cantNucleos ";
                        comando.Parameters.AddWithValue("@fabricante", ((Procesador)componente).Fabricante);
                        comando.Parameters.AddWithValue("@cantNucleos", ((Procesador)componente).Nucleos);
                        break;
                }
                comando.CommandText += "WHERE id = @id";
                comando.Parameters.AddWithValue("@id", componente.ID);
                comando.Parameters.AddWithValue("@marca", componente.Marca);
                comando.Parameters.AddWithValue("@modelo", componente.Modelo);
                comando.Parameters.AddWithValue("@potencia", componente.Potencia);
                comando.Parameters.AddWithValue("@consumo", componente.Consumo);
                comando.Parameters.AddWithValue("@precio", componente.Precio);
                if (comando.ExecuteNonQuery() == 1)
                {
                    actualizadoCompleto = true;
                }
                return actualizadoCompleto;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Modifica un cliente de la base de datos según el ID del componente por parámetro
        /// </summary>
        /// <param name="cliente">Cliente con los valores nuevos</param>
        /// <returns>True si se ha modificado correctamente, de lo contrario false.</returns>
        public static bool ActualizarCliente(Cliente cliente)
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                bool actualizadoCompleto = false;
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "UPDATE Cliente SET nombre = @nombre, apellido = @apellido, CUIL = @cuil, edad = @edad, sexo = @sexo, idPresupuesto = @idPresu WHERE id = @idCliente";
                comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@apellido", cliente.Apellido);
                comando.Parameters.AddWithValue("@cuil", cliente.CUIL_CUIT);
                comando.Parameters.AddWithValue("@edad", cliente.Edad);
                comando.Parameters.AddWithValue("@sexo", cliente.Sexo);
                comando.Parameters.AddWithValue("@idCliente", cliente.ID);
                if (cliente.ID_Presupuesto == -1)
                {
                    comando.Parameters.AddWithValue("@idPresu", 0);
                } else
                {
                    comando.Parameters.AddWithValue("@idPresu", cliente.ID_Presupuesto);
                }                
                if (comando.ExecuteNonQuery() == 1)
                {
                    actualizadoCompleto = true;
                }
                return actualizadoCompleto;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Modifica un presupuesto de la base de datos según el ID del componente por parámetro
        /// </summary>
        /// <param name="presupuesto">Presupuesto con los valores nuevos</param>
        /// <returns>True si se ha modificado correctamente, de lo contrario false.</returns>
        public static bool ActualizarPresupuesto(Presupuesto presupuesto)
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                bool actualizadoCompleto = false;
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "UPDATE Presupuesto SET fechaEmision = @fecha, precioFinal = @precio, idCliente = @idCliente WHERE id = @idPresu";
                comando.Parameters.AddWithValue("@fecha", presupuesto.FechaEmision);
                comando.Parameters.AddWithValue("@precio", presupuesto.PrecioFinal);
                comando.Parameters.AddWithValue("@idPresu", presupuesto.ID_Presupuesto);
                comando.Parameters.AddWithValue("@idCliente", presupuesto.ID_Cliente);
                if (comando.ExecuteNonQuery() == 1)
                {
                    actualizadoCompleto = true;
                }
                return actualizadoCompleto;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Elimina un componente de la base de datos según el ID indicado
        /// </summary>
        /// <param name="idComponente">ID a buscar en la base de datos</param>
        /// <returns>True si se ha eliminado correctamente, de lo contrario false.</returns>
        public static bool RemoverComponente(int idComponente)
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                bool haRemovido = false;
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "DELETE FROM ComponenteElectronico WHERE id = @idComp";
                comando.Parameters.AddWithValue("@idComp", idComponente);
                if (comando.ExecuteNonQuery() == 1)
                {
                    haRemovido = true;
                }
                return haRemovido;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Elimina un cliente de la base de datos según el ID indicado
        /// </summary>
        /// <param name="idCliente">ID a buscar en la base de datos</param>
        /// <returns>True si se ha eliminado correctamente, de lo contrario false.</returns>
        public static bool RemoverCliente(int idCliente)
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                bool haRemovido = false;
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "DELETE FROM Cliente WHERE id = @idCliente";
                comando.Parameters.AddWithValue("@idCliente", idCliente);
                if (comando.ExecuteNonQuery() == 1)
                {
                    haRemovido = true;
                }
                return haRemovido;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Elimina un presupuesto de la base de datos según el ID indicado
        /// </summary>
        /// <param name="idPresupuesto">ID a buscar en la base de datos</param>
        /// <returns>True si se ha eliminado correctamente, de lo contrario false.</returns>
        public static bool RemoverPresupuesto(int idPresupuesto)
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                bool haRemovido = false;
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "DELETE FROM Presupuesto WHERE id = @idPresupuesto";
                comando.Parameters.AddWithValue("@idPresupuesto", idPresupuesto);
                if (comando.ExecuteNonQuery() == 1)
                {
                    haRemovido = true;
                }
                return haRemovido;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
