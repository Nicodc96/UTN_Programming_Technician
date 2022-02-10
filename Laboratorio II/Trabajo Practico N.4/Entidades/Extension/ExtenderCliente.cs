using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Entidades.BaseDeDatos;

namespace Entidades.Extension
{
    public static class ExtenderCliente
    {
        public static void GuardarClienteEnBD(this Cliente cliente)
        {
            DAO.GuardarCliente(cliente);
        }
    }
}
