using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeaCucumber;

namespace SeaCucumberTests.Extensions;

public static class AssertExtensions
{
    public static void GridsAreEqual(this Assert _, Cell[,] left, Cell[,] right)
    {
        var rows = left.GetLength(0);
        var columns = left.GetLength(1);
        
        Assert.AreEqual(rows, right.GetLength(0));
        Assert.AreEqual(columns, right.GetLength(1));

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                Assert.AreEqual(left[i, j].Value, right[i, j].Value);
            }
        }
    }
}