using System;
using Entidades;

namespace TestConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Test de Casa de Musica e Instrumentos - Lautaro Díaz";
            
            int cantidadMaxima = 5;

            CasaDeMusica CasaDeMusicaUno = new Entidades.CasaDeMusica(cantidadMaxima);
            Instrumento GuitarraUno = new Guitarra("Les Paul", 7, 25523, EClasificacion.Cuerdas, ETipoGuitarra.Electrica);
            Instrumento GuitarraDos = new Guitarra("Gracia M2", 6, 34411, EClasificacion.Cuerdas, ETipoGuitarra.Criolla);
            Instrumento BateriaUno = new Bateria("Mapex Prodigy", 55133, EClasificacion.Percusion, 7);
            Instrumento BateriaDos = new Bateria("Mapex Prodigy", 55134, EClasificacion.Percusion, 7);
            Instrumento TrompetaUno = new Trompeta("Lincoln", 15233, EClasificacion.Vientos, "Clave de Sol");
            Instrumento TrompetaDos = new Trompeta("Yamaha", 15233, EClasificacion.Vientos, "Clave de Sol");

            // La Trompetados no deberia agregarse ya que tiene mismo código
            CasaDeMusicaUno += GuitarraUno;
            CasaDeMusicaUno += GuitarraDos;
            CasaDeMusicaUno += BateriaUno;
            CasaDeMusicaUno += BateriaDos;
            CasaDeMusicaUno += TrompetaUno;
            CasaDeMusicaUno += TrompetaDos;

            Console.WriteLine("Objetos agregados.");

            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine("--- Lista de Instrumentos ----");
            Console.WriteLine(CasaDeMusicaUno.ToString());

            if (BateriaUno.Equals(BateriaDos))
            {
                Console.WriteLine("Las baterias poseen el mismo código (son iguales).");
            } else
            {
                Console.WriteLine("Las baterias NO son iguales (distinta código).");
            }

            if (GuitarraUno.Equals(GuitarraDos))
            {
                Console.WriteLine("Las guitarras poseen el mismo código (son iguales).");
            }
            else
            {
                Console.WriteLine("Las guitarras NO son iguales (distinta código).");
            }
            if (TrompetaUno.Equals(TrompetaDos))
            {
                Console.WriteLine("Las trompetas poseen el mismo código (son iguales).");
            }
            else
            {
                Console.WriteLine("Las trompetas NO son iguales (distinta código).");
            }
            Console.ReadKey();
            CasaDeMusicaUno -= TrompetaDos;
            CasaDeMusicaUno -= TrompetaUno;
            // Quito las trompetas y muestro
            Console.WriteLine("\n-- Lista habiendo quitado las trompetas --");
            Console.WriteLine(CasaDeMusicaUno.ToString());

            if (CasaDeMusicaUno.Equals(TrompetaUno))
            {
                Console.WriteLine("El instrumento se encuentra en la lista.");
            }
            else
            {
                Console.WriteLine("El instrumento NO está en la lista.");
            }
            if (CasaDeMusicaUno.Equals(GuitarraDos))
            {
                Console.WriteLine("El instrumento se encuentra en la lista.");
            }
            else
            {
                Console.WriteLine("El instrumento NO está en la lista.");
            }
            Console.ReadKey();
        }
    }
}
