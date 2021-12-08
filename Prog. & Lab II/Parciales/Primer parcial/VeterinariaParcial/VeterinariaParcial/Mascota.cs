using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaParcial
{    
    public abstract class Mascota
    {
        public enum ETipoMascota
        {
            Canario,
            Perro,
            Gato,
            Otro
        }

        protected List<Mascota> listaMascotas;
        protected string dueñoDNI;
        protected int numeroMascota;
        protected string nombreMascota;
        protected int edadMascota;
        protected ETipoMascota tipo;

        public List<Mascota> ListaMascota
        {
            get
            {
                return this.listaMascotas;
            }
            set
            {
                listaMascotas = value;
            }
        }
        public abstract string DueñoDNI
        {
            get;
            set;
        }
        public abstract int NumeroMascota
        {
            get;
        }

        public abstract string NombreMascota
        {
            get;
            set;
        }
        
        public abstract int EdadMascota
        {
            get;
            set;
        }

        public ETipoMascota Tipo
        {
            get
            {
                return this.tipo;
            }
        }
        protected Mascota()
        {
            this.listaMascotas = new List<Mascota>();
        }

        protected Mascota(string nombreMascota, string dueñoDNI, int edadMascota, int numeroMascota):this()
        {
            this.nombreMascota = nombreMascota;
            this.numeroMascota = numeroMascota;
            this.dueñoDNI = dueñoDNI;
            this.edadMascota = edadMascota;
        }
        //public abstract Mascota CrearMascota();

        public virtual string Mostrar()
        {
            StringBuilder sB = new StringBuilder();

            sB.AppendLine($"Nombre de la mascota: {this.NombreMascota}");
            sB.AppendLine($"DNI del dueño: {this.DueñoDNI}");
            sB.AppendLine($"Edad de la mascota: {this.EdadMascota}");
            sB.AppendLine($"Numero: {this.NumeroMascota}");

            return sB.ToString();
        }

        public static bool operator ==(Mascota m1, Mascota m2)
        {
            if (m1.numeroMascota == m2.numeroMascota)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Mascota m1, Mascota m2)
        {
            return !(m1 == m2);
        }
    }
}
