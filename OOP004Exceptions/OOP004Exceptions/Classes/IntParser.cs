using System;

namespace OOP004Exceptions
{
    class IntParser
    {
        public static int ReadInteger()
        {
            int? Value = null;
            do
            {
                try
                {
                    Value = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
            } while (Value == null);
            return (int)Value;
        }

    }
}
