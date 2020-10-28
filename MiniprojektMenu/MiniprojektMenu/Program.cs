using System.IO;

namespace MiniprojektMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu("FancyMenu");
            menu.Add(new MenuItem("Punkt1", "content"));
            menu.Add(new MenuItem("Punkt2", "content"));
            Menu underMenu = new Menu("undermenu");
            underMenu.Add(new MenuItem("testpunkt"));
            underMenu.Add(new MenuItem("testpunkt2"));
            menu.Add(new InfiniteMenu("Uendelig menu"));
            menu.Add(underMenu);
            menu.Add(new FileSystemMenu(new DirectoryInfo("C:\\")));
            menu.Add(new DRMenu());
            menu.Add(new RSSMenu("http://blog.dota2.com/feed/"));
            menu.Add(new RSSMenu("Https://news.ycombinator.com/rss"));
            menu.Start();
        }
    }
}
