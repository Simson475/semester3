using System;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace OOP01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DegreeConverter.ToRadians(180));
            Console.WriteLine(DegreeConverter.ToDegrees(Math.PI));
            StarPrinter.Stair(5);
            StarPrinter.ReverseStair(5);
            Lotto.PrintWinners();

            Studygroup Group = new Studygroup("2.2.5");
            Group.SetMembers();
            Group.PrintMembers();


            StudygroupLists GroupLists = new StudygroupLists("0.2.13");
            GroupLists.SetMembers();
            GroupLists.PrintMembers();
        }
    }
}
