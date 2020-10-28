using System;
using System.Collections.Generic;
using System.IO;

namespace MiniprojektMenu
{
    class FileSystemMenu : Menu, IMenuPoints
    {
        public FileSystemMenu(DirectoryInfo directory) : base(directory.Name)
        {
            Directory = directory;
            Files = new List<FileSystemInfo>(Directory.GetFileSystemInfos());
        }
        private List<FileSystemInfo> Files { get; set; }
        private DirectoryInfo Directory { get; set; }

        protected override int ActiveElement
        {
            get => _ActiveElement;
            set
            {
                if (value < 0) _ActiveElement = Files.Count - 1;
                else if (value >= Files.Count) _ActiveElement = 0;
                else _ActiveElement = value;
            }
        }
        protected override void PrintMenu()
        {

            PrintLine($"[[[{Title}]]]", ConsoleColor.Blue);
            for (int i = 0; i < Files.Count; i++)
            {
                PrintLine(Files[i].Name, i == ActiveElement ? ConsoleColor.DarkGray : Console.BackgroundColor);
            }
        }
        protected override void OpenSubmenu()
        {
            FileSystemInfo CurrentFile = Files[ActiveElement];
            if (CurrentFile is DirectoryInfo Info)
            {
                new FileSystemMenu(Info).Select();
            }
            else
            {

                try
                {
                    string[] AllLines = File.ReadAllLines(CurrentFile.FullName);
                    string LinesTogether = "";
                    foreach (string item in AllLines)
                    {
                        LinesTogether += $"{item}\n";
                    }
                    new MenuItem(CurrentFile.Name, LinesTogether).Select();
                }
                catch (Exception)
                {
                    Files.RemoveAt(ActiveElement);
                    ActiveElement--;
                }
            }
        }
    }
}
