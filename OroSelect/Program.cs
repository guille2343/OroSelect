using BLL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OroSelect
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.menuPrincipal();
            Console.ReadKey();

            //Console.WriteLine("Colores de texto:");
            //Console.ForegroundColor = ConsoleColor.Black;
            //Console.WriteLine("Negro");
            //Console.ForegroundColor = ConsoleColor.DarkBlue;
            //Console.WriteLine("Azul oscuro");
            //Console.ForegroundColor = ConsoleColor.DarkGreen;
            //Console.WriteLine("Verde oscuro");
            //Console.ForegroundColor = ConsoleColor.DarkCyan;
            //Console.WriteLine("Cian oscuro");
            //Console.ForegroundColor = ConsoleColor.DarkRed;
            //Console.WriteLine("Rojo oscuro");
            //Console.ForegroundColor = ConsoleColor.DarkMagenta;
            //Console.WriteLine("Magenta oscuro");
            //Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Console.WriteLine("Amarillo oscuro");
            //Console.ForegroundColor = ConsoleColor.Gray;
            //Console.WriteLine("Gris");
            //Console.ForegroundColor = ConsoleColor.DarkGray;
            //Console.WriteLine("Gris oscuro");
            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine("Azul");
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("Verde");
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine("Cian");
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("Rojo");
            //Console.ForegroundColor = ConsoleColor.Magenta;
            //Console.WriteLine("Magenta");
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("Amarillo");
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine("Blanco");

            //Console.WriteLine("\nColores de fondo:");
            //Console.BackgroundColor = ConsoleColor.Black;
            //Console.WriteLine("Negro");
            //Console.BackgroundColor = ConsoleColor.DarkBlue;
            //Console.WriteLine("Azul oscuro");
            //Console.BackgroundColor = ConsoleColor.DarkGreen;
            //Console.WriteLine("Verde oscuro");
            //Console.BackgroundColor = ConsoleColor.DarkCyan;
            //Console.WriteLine("Cian oscuro");
            //Console.BackgroundColor = ConsoleColor.DarkRed;
            //Console.WriteLine("Rojo oscuro");
            //Console.BackgroundColor = ConsoleColor.DarkMagenta;
            //Console.WriteLine("Magenta oscuro");
            //Console.BackgroundColor = ConsoleColor.DarkYellow;
            //Console.WriteLine("Amarillo oscuro");
            //Console.BackgroundColor = ConsoleColor.Gray;
            //Console.WriteLine("Gris");
            //Console.BackgroundColor = ConsoleColor.DarkGray;
            //Console.WriteLine("Gris oscuro");
            //Console.BackgroundColor = ConsoleColor.Blue;
            //Console.WriteLine("Azul");
            //Console.BackgroundColor = ConsoleColor.Green;
            //Console.WriteLine("Verde");
            //Console.BackgroundColor = ConsoleColor.Cyan;
            //Console.WriteLine("Cian");
            //Console.BackgroundColor = ConsoleColor.Red;
            //Console.WriteLine("Rojo");
            //Console.BackgroundColor = ConsoleColor.Magenta;
            //Console.WriteLine("Magenta");
            //Console.BackgroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("Amarillo");
            //Console.BackgroundColor = ConsoleColor.White;
            //Console.WriteLine("Blanco");
            //Console.ReadKey();

            //// Restaurar los colores originales
            //Console.ResetColor();
        }
    }
}
