using FluentAssertions;
using MainProgram;

namespace Xunit;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestHasWinnerDiagonalLefttoRight()
    {
        char[] b = ['x', 'o', 'c', 
                    'd', 'x', 'o', 
                    'g', 'h', 'x'];
        bool answer = Program.HasWinner(b);
        answer.Should().BeTrue();
    }
    [TestMethod]
    public void TestHasWinnerDiagonalRighttoLeft()
    {
        char[] b = ['a', 'o', 'x', 
                    'd', 'x', 'o', 
                    'x', 'h', 'o'];
        bool answer = Program.HasWinner(b);
        answer.Should().BeTrue();
    }
    [TestMethod]
    public void TestHasWinnerRow1()
    {
        char[] b = ['x', 'x', 'x', 
                    'd', 'x', 'o', 
                    'g', 'h', 'i'];
        bool answer = Program.HasWinner(b);
        answer.Should().BeTrue();
    }
    [TestMethod]
    public void TestHasWinnerRow2()
    {
        char[] b = ['x', 'o', 'c', 
                    'o', 'o', 'o', 
                    'g', 'h', 'x'];
        bool answer = Program.HasWinner(b);
        answer.Should().BeTrue();
    }
    [TestMethod]
    public void TestHasWinnerRow3()
    {
        char[] b = ['a', 'o', 'c', 
                    'd', 'x', 'o', 
                    'x', 'x', 'x'];
        bool answer = Program.HasWinner(b);
        answer.Should().BeTrue();
    }
    [TestMethod]
    public void TestHasWinnerColumn1()
    {
        char[] b = ['x', 'o', 'c', 
                    'x', 'e', 'o', 
                    'x', 'h', 'x'];
        bool answer = Program.HasWinner(b);
        answer.Should().BeTrue();
    }
    
    [TestMethod]
    public void TestHasWinnerColumn2()
    {
        char[] b = ['a', 'x', 'c', 
                    'd', 'x', 'o', 
                    'g', 'x', 'i'];
        bool answer = Program.HasWinner(b);
        answer.Should().BeTrue();
    }
    
    [TestMethod]
    public void TestHasWinnerColumn3()
    {
        char[] b = ['x', 'o', 'o', 
                    'd', 'x', 'o', 
                    'g', 'h', 'o'];
        bool answer = Program.HasWinner(b);
        answer.Should().BeTrue();
    }
}