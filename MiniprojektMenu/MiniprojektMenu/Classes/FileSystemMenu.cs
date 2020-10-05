using System;
using System.IO;

namespace MiniprojektMenu
{
    class FileSystemMenu : Menu, IMenuPoints
    {
        public FileSystemMenu(DirectoryInfo directory) : base(directory.Name)
        {
            Directory = directory;
            Files = Directory.GetFileSystemInfos();
        }
        private FileSystemInfo[] Files { get; set; }
        private DirectoryInfo Directory { get; set; }

        protected override int ActiveElement
        {
            get => _ActiveElement;
            set
            {
                if (value < 0) _ActiveElement = Content.Count - 1;
                else if (value >= Files.Length) _ActiveElement = 0;
                else _ActiveElement = value;
            }
        }
        protected override void PrintMenu()
        {

            PrintLine($"[[[{Title}]]]", ConsoleColor.Blue);
            for (int i = 0; i < Files.Length; i++)
            {
                PrintLine(Files[i].Name, i == ActiveElement ? ConsoleColor.DarkGray : Console.BackgroundColor);
            }
        }
        protected override void OpenSubmenu()
        {
            FileSystemInfo CurrentFile = Files[ActiveElement];
            if (CurrentFile is DirectoryInfo Info)
            {
                new FileSystemMenu(Info).PrintContent();
            }
            else
            {
                new MenuItem(CurrentFile.Name, "You opened a file").PrintContent();
            }
        }
    }
}
