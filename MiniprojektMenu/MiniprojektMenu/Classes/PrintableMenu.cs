using System;

namespace MiniprojektMenu
{
    abstract class PrintableMenu
    {
        public string Title { get; set; }
        protected void PrintLine(string text, ConsoleColor color)
        {


            string[] AllLines = text.Split("\n");
            foreach (string item in AllLines)
            {
                int Width = Console.WindowWidth / 2 - item.Length / 2;
                string Padding = "";
                for (int i = 0; i <= Width; i++)
                {
                    Padding += " ";
                }
                Console.Write(Padding);
                Console.BackgroundColor = color;
                Console.WriteLine(item);
                Console.ResetColor();
            }
        }
    }
}
