using MyMathLibrary;
namespace UnitTestProgram;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Demo App for Unit tests");
        Console.WriteLine("Adding two numbers");
        Console.WriteLine("{0} + {1} = {2}", 1, 202, MathLibrary.Add(1, 202));
        Console.WriteLine("Subtracting two numbers");
        Console.WriteLine("{0} - {1} = {2}", 1, 202, MathLibrary.Subtract(1, 202));
    }
}
