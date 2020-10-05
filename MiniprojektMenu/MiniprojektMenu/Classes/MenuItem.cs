using System;

namespace MiniprojektMenu
{
    class MenuItem : PrintableMenu, IMenuPoints
    {
        public MenuItem(string title)
        {
            Title = title;
        }
        public MenuItem(string title, string content)
        {
            Title = title;
            Content = content;
        }
        protected string Content { get; set; } = "";
        public void PrintContent()
        {
            ConsoleKey Keypressed;
            Console.Clear();
            PrintLine(Title, ConsoleColor.Blue);
            PrintLine(Content, Console.BackgroundColor);
            PrintLine("Press ESC to go back", Console.BackgroundColor);
            do Keypressed = Console.ReadKey().Key;
            while (Keypressed != ConsoleKey.Escape);
        }
    }
}
