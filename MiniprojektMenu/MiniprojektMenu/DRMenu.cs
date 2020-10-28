using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniprojektMenu
{
    class DRMenu : Menu
    {
        public DRMenu()
        {
            Menus.Add(new RSSMenu("https://www.dr.dk/nyheder/service/feeds/allenyheder"));
            Menus.Add(new RSSMenu("https://www.dr.dk/nyheder/service/feeds/indland"));
            Menus.Add(new RSSMenu("https://www.dr.dk/nyheder/service/feeds/udland"));
            Menus.Add(new RSSMenu("https://www.dr.dk/nyheder/service/feeds/penge"));
            Menus.Add(new RSSMenu("https://www.dr.dk/nyheder/service/feeds/politik"));
            Menus.Add(new RSSMenu("https://www.dr.dk/nyheder/service/feeds/kultur"));
            Menus.Add(new RSSMenu("https://www.dr.dk/nyheder/service/feeds/levnu"));
            Menus.Add(new RSSMenu("https://www.dr.dk/nyheder/service/feeds/viden"));
            Menus.Add(new RSSMenu("https://www.dr.dk/nyheder/service/feeds/sporten"));
            Menus.Add(new RSSMenu("https://www.dr.dk/nyheder/service/feeds/vejret"));
            Menus.Add(new RSSMenu("https://www.dr.dk/nyheder/service/feeds/ligetil"));
            Menus.Add(new RSSMenu("https://www.dr.dk/Nyheder/Service/feeds/regionale/kbh/"));
            Menus.Add(new RSSMenu("https://www.dr.dk/Nyheder/Service/feeds/regionale/bornholm/"));
            Menus.Add(new RSSMenu("https://www.dr.dk/Nyheder/Service/feeds/regionale/syd/"));
            Menus.Add(new RSSMenu("https://www.dr.dk/Nyheder/Service/feeds/regionale/fyn/"));
            Menus.Add(new RSSMenu("https://www.dr.dk/Nyheder/Service/feeds/regionale/vest/"));
            Menus.Add(new RSSMenu("https://www.dr.dk/Nyheder/Service/feeds/regionale/nord/"));
            Menus.Add(new RSSMenu("https://www.dr.dk/Nyheder/Service/feeds/regionale/trekanten/"));
            Menus.Add(new RSSMenu("https://www.dr.dk/Nyheder/Service/feeds/regionale/sjaelland/"));
            Menus.Add(new RSSMenu("https://www.dr.dk/Nyheder/Service/feeds/regionale/oestjylland/"));

            Title = "DR nyheder";
        }
        public List<RSSMenu> Menus { get; set; } = new List<RSSMenu>();
        protected override int ActiveElement
        {
            get => _ActiveElement;
            set
            {
                if (value < 0) _ActiveElement = Menus.Count() - 1;
                else if (value >= Menus.Count()) _ActiveElement = 0;
                else _ActiveElement = value;
            }
        }
        protected override void OpenSubmenu() => Menus[ActiveElement].Select();
        protected override void PrintMenu()
        {
            PrintLine($"[[[{Title}]]]", ConsoleColor.Blue);
            for (int i = 0; i < Menus.Count(); i++)
            {
                PrintLine(Menus.ElementAt(i).Title, i == ActiveElement ? ConsoleColor.DarkGray : Console.BackgroundColor);
            }
        }
    }
}
