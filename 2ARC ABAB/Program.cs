using System;
using System.Windows.Forms;

namespace _2ARC_ABAB
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            DllImports.AllocConsole();

            Console.BufferWidth = 100;
            Console.WindowWidth = Console.BufferWidth;
            Console.Title = "PHPTP";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Louis Desplanche");
            Console.ForegroundColor = ConsoleColor.White;

            Application.EnableVisualStyles();
            
            Application.SetCompatibleTextRenderingDefault(false);
            
            Form1 launchPage = new Form1();
            Application.Run(launchPage);
        }
    }
}
