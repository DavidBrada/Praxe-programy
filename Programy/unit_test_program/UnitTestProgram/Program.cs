using MyMathLibrary;
namespace unit_test_program;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Adding two numbers");
        Console.WriteLine("{0} + {1} = {2}", 1, 202, MyMath.Add(1, 202));
        Console.WriteLine("Subtracting two numbers");
        Console.WriteLine("{0} - {1} = {2}", 1, 202, MyMath.Subtract(1, 202));
    }
}