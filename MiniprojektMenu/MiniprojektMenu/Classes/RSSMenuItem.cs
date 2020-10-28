using System;
using System.ServiceModel.Syndication;

namespace MiniprojektMenu
{
    class RSSMenuItem : PrintableMenu, IMenuPoints
    {
        public RSSMenuItem(SyndicationItem item)
        {
            Item = item;
            Title = item.Title.Text;
        }
        public SyndicationItem Item { get; set; }
        public void Select()
        {
            ConsoleKey Keypressed;
            Console.Clear();
            PrintLine(Title, ConsoleColor.Blue);
            PrintLine("Summary:", Console.BackgroundColor);
            PrintLine(Item.Summary.Text, Console.BackgroundColor);
            PrintLine("Link:", Console.BackgroundColor);
            PrintLine(Item.Links[0].Uri.ToString(), Console.BackgroundColor);
            PrintLine("Press ESC to go back", Console.BackgroundColor);
            do Keypressed = Console.ReadKey().Key;
            while (Keypressed != ConsoleKey.Escape);
        }
    }
}
