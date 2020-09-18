namespace CodeWars_Test
{
    public class InitialsFormatter
    {
        public static string AbbrevName(string name)
        {
            string[] names = name.ToUpper().Split(" ");
            return $"{names[0][0]}.{names[1][0]}";
        }
    }
}
