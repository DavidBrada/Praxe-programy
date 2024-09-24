using MyMathLibrary;
namespace MyMathLibraryTests;

public class MathUnitTest{
    [Fact]
    public void TestAddMethod()
    {
        int res1 = MyMath.Add(1, 202);
        Assert.equal(203, res1);
    }
}