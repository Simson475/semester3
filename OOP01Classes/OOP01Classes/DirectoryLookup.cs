using System;
using System.IO;

namespace OOP01Classes
{
    public static class DirectoryLookup
    {
        public static void PrintFolders(DirectoryInfo Target)
        {
            Console.WriteLine("Folders:");
            DirectoryInfo[] folders = Target.GetDirectories();
            foreach (DirectoryInfo item in folders)
            {
                Console.WriteLine(item);
            }
        }

        public static void PrintFiles(DirectoryInfo Target)
        {
            FileInfo[] files = Target.GetFiles();
            Console.WriteLine("Files:");
            foreach (FileInfo item in files)
            {
                Console.WriteLine($"{item} Size: {item.Length}");
            }
        }

        public static void PrintAllSubfoldersAndFiles(DirectoryInfo Target)
        {
            DirectoryInfo[] folders = Target.GetDirectories();
            FileInfo[] files = Target.GetFiles();
            foreach (FileInfo Item in files)
            {
                Console.WriteLine($"FILE:             {Item} Size: {Item.Length}");
            }
            foreach (DirectoryInfo item in folders)
            {
                Console.WriteLine($"FOLDER:           {item}");
                PrintAllSubfoldersAndFiles(item);
            }

        }
        public static void Search(DirectoryInfo Folder, string Keyword)
        {
            DirectoryInfo[] Folders = Folder.GetDirectories();
            DirectoryInfo[] FoldersToPrint = Folder.GetDirectories("*" + Keyword + "*.*");
            FileInfo[] files = Folder.GetFiles("*" + Keyword + "*.*");

            foreach (FileInfo item in files) Console.WriteLine($"FILE:          {item}");

            foreach (DirectoryInfo item in FoldersToPrint) Console.WriteLine($"Folder:          {item}");

            foreach (DirectoryInfo item in Folders)
            {
                Search(item, Keyword);
            }
        }
    }
}
