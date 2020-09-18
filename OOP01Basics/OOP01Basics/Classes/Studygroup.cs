using System;

namespace OOP01
{
    public class Studygroup
    {
        public Studygroup(string NewGroupName)
        {
            GroupName = NewGroupName;
        }
        public string[] MemberList { get; set; }
        private string GroupName { get; }
        public void SetMembers()
        {
            int MemberAmount = -1;
            Console.WriteLine("How many members does your group have?");
            while (MemberAmount < 0)
            {
                try
                {
                    MemberAmount = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("please write a number!");
                }
            }
            MemberList = new string[MemberAmount];

            for (int i = 0; i < MemberAmount; i++)
            {
                Console.WriteLine($"Name of member {i + 1}");
                MemberList[i] = Console.ReadLine();
            }

            return;
        }

        public void PrintMembers()
        {
            Console.WriteLine($"Members in group {GroupName}");
            foreach (string Elem in MemberList)
            {
                Console.WriteLine(Elem);
            }
        }
    }
}
