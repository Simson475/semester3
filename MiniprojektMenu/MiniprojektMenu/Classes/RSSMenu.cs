using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

namespace MiniprojektMenu
{
    class RSSMenu : Menu, IMenuPoints
    {
        public RSSMenu(string url)
        {
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed Feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem item in Feed.Items)
            {
                MenuItems.Add(new RSSMenuItem(item));
            }
            Title = Feed.Title.Text;
        }
        public List<RSSMenuItem> MenuItems { get; set; } = new List<RSSMenuItem>();
        protected override int ActiveElement
        {
            get => _ActiveElement;
            set
            {
                if (value < 0) _ActiveElement = MenuItems.Count() - 1;
                else if (value >= MenuItems.Count()) _ActiveElement = 0;
                else _ActiveElement = value;
            }
        }
        protected override void OpenSubmenu() => MenuItems[ActiveElement].Select();


        protected override void PrintMenu()
        {
            PrintLine($"[[[{Title}]]]", ConsoleColor.Blue);
            for (int i = 0; i < MenuItems.Count(); i++)
            {
                PrintLine(MenuItems.ElementAt(i).Title, i == ActiveElement ? ConsoleColor.DarkGray : Console.BackgroundColor);
            }
        }
    }
}
