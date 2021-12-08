using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Entidades.BaseDeDatos;

namespace Entidades.Extension
{
    public static class ExtenderComponente
    {
        public static void GuardarComponenteEnBD(this ComponenteElectronico componente)
        {
            DAO.GuardarComponente(componente);
        }
    }
}
