using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars_Test
{
    public class DirReduction
    {
        public static string[] dirReduc(String[] arr)
        {
            List<string> List = new List<string>(arr);
            int i = 0;
            while (i < List.Count() - 1)
            {
                switch (List[i])
                {
                    case "NORTH":
                        i = List[i + 1] == "SOUTH" ? ListRemover(List, i) : i + 1;
                        break;
                    case "SOUTH":
                        i = List[i + 1] == "NORTH" ? ListRemover(List, i) : i + 1;
                        break;
                    case "WEST":
                        i = List[i + 1] == "EAST" ? ListRemover(List, i) : i + 1;
                        break;
                    case "EAST":
                        i = List[i + 1] == "WEST" ? ListRemover(List, i) : i + 1;
                        break;
                }
            }
            return List.ToArray();
        }

        private static int ListRemover(List<string> List, int i)
        {
            List.RemoveAt(i + 1);
            List.RemoveAt(i);
            return 0;
        }
    }
}
