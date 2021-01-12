using CommandParser;
using Core;
using UserInterface;

namespace LineSystemExamExercise
{
    class Program
    {
        static void Main()
        {
            LineSystemBuilder builder = new LineSystemBuilder();

            LineSystem lineSystem = builder.Build();
            LineSystemCLI CLI = new LineSystemCLI(lineSystem);
            LineSystemCommandParser commandParser = new LineSystemCommandParser(CLI, lineSystem);
            CLI.Start();
        }
    }
}
