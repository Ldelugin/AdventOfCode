using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeaCucumber;

namespace SeaCucumberTests;

[TestClass]
public class CellTests
{
    [TestMethod]
    [DataRow(Cell.Empty)]
    [DataRow(Cell.EastFacing)]
    [DataRow(Cell.SouthFacing)]
    public void Constructor_SetsValue_AsGiven(char value)
    {
        // Arrange
        var cell = new Cell(value);
        
        // Act
        var actualValue = cell.Value;
        
        // Assert
        Assert.AreEqual(value, actualValue);
    }
}