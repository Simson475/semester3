using System;

namespace MiniprojektMenu
{
    abstract class PrintableMenu
    {
        public string Title { get; set; }
        protected void PrintLine(string text, ConsoleColor color)
        {
            int Width = Console.WindowWidth / 2 - text.Length / 2;
            string Padding = "";
            for (int i = 0; i <= Width; i++)
            {
                Padding += " ";
            }
            Console.Write(Padding);

            Console.BackgroundColor = color;

            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
