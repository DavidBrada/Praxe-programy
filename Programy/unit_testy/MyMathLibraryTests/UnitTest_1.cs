using MyMathLibrary;
namespace MyMathLibraryTests;

public class UnitTest_1
{
    [Fact]
    public void TestAddMethod01()
    {
        int res1 = MathLibrary.Add(1, 202);
        Assert.Equal(203, res1);
    }

    [Theory]
    [InlineData(99, 202, -103)]
    [InlineData(-52, 22, -74)]
    [InlineData(303, 23302, -22999)]   
    public void TestSubstractMethod(int a, int b, int expected) 
    {
        Assert.Equal(expected, MathLibrary.Subtract(a, b));
    }
}