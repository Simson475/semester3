using System;
using System.Collections.Generic;

namespace MiniprojektMenu
{
    class Menu : PrintableMenu, IMenuPoints
    {
        public Menu(string title) => Title = title;
        public Menu() { }
        protected List<IMenuPoints> Content { get; set; } = new List<IMenuPoints>();

        protected int _ActiveElement;
        protected virtual int ActiveElement
        {
            get => _ActiveElement;
            set
            {
                if (value < 0) _ActiveElement = Content.Count - 1;
                else if (value >= Content.Count) _ActiveElement = 0;
                else _ActiveElement = value;
            }
        }
        public void Add(IMenuPoints item) => Content.Add(item);
        public void Start() => Select();
        public virtual void Select()
        {
            ConsoleKey Keypressed;
            do
            {
                Console.Clear();
                PrintMenu();
                Keypressed = Console.ReadKey().Key;
                if (Keypressed == ConsoleKey.UpArrow) ActiveElement--;
                else if (Keypressed == ConsoleKey.DownArrow) ActiveElement++;

                else if (Keypressed == ConsoleKey.Enter) OpenSubmenu();
            } while (Keypressed != ConsoleKey.Escape);
        }
        protected virtual void OpenSubmenu() => Content[ActiveElement].Select();
        protected virtual void PrintMenu()
        {
            PrintLine($"[[[{Title}]]]", ConsoleColor.Blue);
            for (int i = 0; i < Content.Count; i++)
            {
                PrintLine(Content[i].Title, i == ActiveElement ? ConsoleColor.DarkGray : Console.BackgroundColor);
            }
        }

    }
}
