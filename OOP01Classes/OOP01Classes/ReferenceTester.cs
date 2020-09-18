using System;

namespace OOP01Classes
{
    public class ReferenceTester
    {
        public ReferenceTester(int test) => TestValue = test;
        public int TestValue { get; set; }

        public override bool Equals(object obj) => obj is ReferenceTester tester &&
                   TestValue == tester.TestValue;

        public override int GetHashCode()
        {
            return HashCode.Combine(TestValue);
        }
    }
}
