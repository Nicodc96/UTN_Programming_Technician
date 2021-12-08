using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using static Entidades.Personaje;

namespace TestConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "PP LAB-II | Díaz, Lautaro | Test Consola (1C - 2021)";
            // Vengadores
            Marvel.Personaje = new Avenger("Anthony Stark", new List<EHabilidades>() { EHabilidades.InteligenciaSuperior }, EEquipamiento.Armadura);
            Marvel.Personaje = new Avenger("Anthony Stark", new List<EHabilidades>() { EHabilidades.InteligenciaSuperior }, EEquipamiento.Armadura);
            Marvel.Personaje = new Avenger("Dr Banner", new List<EHabilidades>() { EHabilidades.InteligenciaSuperior }, EEquipamiento.Transformacion);
            Marvel.Personaje = new Avenger("Dr Banner", new List<EHabilidades>() { EHabilidades.InteligenciaSuperior }, EEquipamiento.Transformacion);
            Marvel.Personaje = new Avenger("Natasha Romanoff ", new List<EHabilidades>() { EHabilidades.Sigilo, EHabilidades.Astucia }, EEquipamiento.ArtesMarciales);
            Marvel.Personaje = new Avenger("Thor", new List<EHabilidades>() { EHabilidades.Rayos, EHabilidades.Volar }, EEquipamiento.Martillo);
            Marvel.Personaje = new Avenger("Thor", new List<EHabilidades>() { EHabilidades.Rayos, EHabilidades.Volar }, EEquipamiento.Martillo);

            // Enemigos
            Marvel.Personaje = new Enemigo("Thanos", new List<EHabilidades>() { EHabilidades.SuperFuerza, EHabilidades.Astucia, EHabilidades.Resistencia }, "Obtener las infinity stones y un te de vainilla");
            Marvel.Personaje = new Enemigo("Ultron", new List<EHabilidades>() { EHabilidades.SuperFuerza, EHabilidades.Astucia, EHabilidades.Volar }, "Exterminar a los humanos");
            Marvel.Personaje = new Enemigo("Loki", new List<EHabilidades>() { EHabilidades.Astucia }, "Dominar los 9 reinos");

            Console.WriteLine(Marvel.MostrarInformacion());

            Console.ReadKey();
        }
    }
}
