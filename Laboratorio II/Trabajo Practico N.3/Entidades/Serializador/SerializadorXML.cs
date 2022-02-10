using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades.Serializador
{
    public class SerializadorXML<T> where T : class
    {
        #region Atributos
        private string rutaBase;
        private string extensionArchivo;
        #endregion
        /// <summary>
        /// Dirección de la ruta base de almacenamiento de archivos
        /// </summary>
        public string RutaBase
        {
            get
            {
                return this.rutaBase;
            }
        }
        public SerializadorXML()
        {
            rutaBase = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\DCApplication\";
            extensionArchivo = ".xml";
        }
        /// <summary>
        /// Serializa un objeto o lista de objetos y guarda un archivo XML en la carpeta Datos en la ruta base
        /// </summary>
        /// <typeparam name="T">Tipo de la instancia</typeparam>
        /// <returns>Datos serializados en XML</returns>
        public void GuardarDatos(T datos)
        {
            try
            {
                string rutaArchivo = this.rutaBase + @"\Datos\";
                if (Directory.Exists(rutaArchivo) == false)
                {
                    Directory.CreateDirectory(rutaArchivo);
                }
                if (datos is List<Presupuesto>)
                {
                    rutaArchivo += $@"ResumenPresupuestos{this.extensionArchivo}";
                }
                else if (datos is List<Cliente>)
                {
                    rutaArchivo += $@"ResumenClientes{this.extensionArchivo}";
                } else if (datos is List<ComponenteElectronico>)
                {
                    rutaArchivo += $@"ResumenComponentes{this.extensionArchivo}";
                } else
                {
                    rutaArchivo += $@"Resumen{typeof(T).Name}{this.extensionArchivo}";
                }
                using (StreamWriter streamWritter = new StreamWriter(rutaArchivo))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    serializador.Serialize(streamWritter, datos);
                }
            } catch(Exception e)
            {
                throw new Exception($"Occurió un error al Serealizar/Guardar los datos.\nUltima dirección: {rutaBase}", e);
            }
        }
        /// <summary>
        /// Deserealiza un objeto o lista de objetos de un archivo XML desde la ruta por parámetro
        /// </summary>
        /// <typeparam name="T">Tipo de la instancia</typeparam>
        /// <param name="path">Ruta donde deserealizar</param>
        /// <returns>Objeto/Lista de objetos deserealizado(s)</returns>
        public T RecuperarDatos(string path)
        {
            try
            {
                T archivoDeserealizado = default;
                using (StreamReader streamReader = new StreamReader(path))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    archivoDeserealizado = serializador.Deserialize(streamReader) as T;
                }
                return archivoDeserealizado;
            } catch(Exception e)
            {
                throw new Exception($"Occurió un error al Deserealizar los datos\nRuta ingresada: {path}", e);
            }
        }

    }
}
