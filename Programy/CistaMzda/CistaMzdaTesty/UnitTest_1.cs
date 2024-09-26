using CistaMzdaProgram;
using Xunit;
public class UnitTest_1
{
    [Fact]
    public void TestCistaMzda()
    {
        int res1 = Program.VypocitejMzdu(40000, 2);
        Assert.Equal(35297, res1);
    }
}