using System;

namespace CodeWars_Test
{
    /*UGLIEST CODE EVER WRITTEN.
     * Laver alleord til stort startbogstav
     */

    public static class JadenCase
    {
        public static string ToJadenCase(this string phrase)
        {
            bool capitalize = true;
            Console.WriteLine(phrase);
            string[] split = phrase.Split(" ");
            char[] jadenCased = new char[phrase.Length];
            char temp = ' ';
            for (int i = 0; i < phrase.Length; i++)
            {
                if (capitalize)
                {
                    temp = phrase[i];
                    jadenCased[i] = char.ToUpper(temp);
                    capitalize = false;
                }
                else if (phrase[i].Equals(' '))
                {
                    jadenCased[i] = phrase[i];
                    capitalize = true;
                }
                else jadenCased[i] = phrase[i];
            }
            return new string(jadenCased);
        }
    }

}
