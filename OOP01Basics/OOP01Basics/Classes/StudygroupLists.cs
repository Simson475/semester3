using System;
using System.Collections.Generic;

namespace OOP01
{
    public class StudygroupLists
    {
        public StudygroupLists(string NewGroupName)
        {
            GroupName = NewGroupName;
        }
        private List<string> MemberList = new List<string>();
        private string GroupName { get; }
        public void SetMembers()
        {
            int Counter = 1;
            string Name;
            do
            {
                Console.Write($"Member no {Counter++}: ");
                Name = Console.ReadLine();
                if (Name != "") MemberList.Add(Name);
            } while (Name != "");
            return;
        }

        public void PrintMembers()
        {
            Console.WriteLine($"Members in group {GroupName}");
            foreach (string Elem in this.MemberList)
            {
                Console.WriteLine(Elem);
            }
        }
    }
}
