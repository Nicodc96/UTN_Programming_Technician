﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaParcial
{
    public class Canario : Mascota
    {
        protected float precioConsulta;
        public Canario(string nombreMascota, string dueñoDNI, int edadMascota, int numeroMascota, float precioConsulta)
            : base(nombreMascota, dueñoDNI, edadMascota, numeroMascota)
        {
            this.precioConsulta = precioConsulta;
        }
        public override string Mostrar()
        {
            StringBuilder sB = new StringBuilder();

            sB.AppendLine(base.Mostrar());
            sB.AppendLine($"Precio de la consulta: {this.precioConsulta}");

            return sB.ToString();
        }
    }
}