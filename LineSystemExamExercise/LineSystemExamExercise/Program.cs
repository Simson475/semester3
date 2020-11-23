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
            CLI.Start();
        }
    }
}
