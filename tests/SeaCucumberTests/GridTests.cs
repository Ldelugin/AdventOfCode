using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeaCucumber;
using SeaCucumberTests.Extensions;

namespace SeaCucumberTests;

[TestClass]
public class GridTests
{
    [TestMethod]
    public void Constructor_ParsesInput_Correctly()
    {
        // Arrange
        var input = new[]
        {
            "...>>>>>...",
            "...>>>.....",
            "...>>......",
        };
        var expectedGrid = new Cell[,]
        {
            { new('.'), new('.'), new('.'), new('>'), new('>'), new('>'), new('>'), new('>'), new('.'), new('.'), new('.') },
            { new('.'), new('.'), new('.'), new('>'), new('>'), new('>'), new('.'), new('.'), new('.'), new('.'), new('.') },
            { new('.'), new('.'), new('.'), new('>'), new('>'), new('.'), new('.'), new('.'), new('.'), new('.'), new('.') }
        };
        
        // Act
        var grid = new Grid(input);
        
        // Assert
        Assert.That.GridsAreEqual(expectedGrid, grid.Value);
    }

    [TestMethod]
    public void MoveEastFacing_ReturnsTrue_WhenAtLeastOneEastFacingMoved()
    {
        // Arrange
        var input = new[]
        {
            ".>..",
            "....",
            ">...",
            "...>"
        };
        var expectedGrid = new Cell[,]
        {
            { new('.'), new('.'), new('>'), new('.') },
            { new('.'), new('.'), new('.'), new('.') },
            { new('.'), new('>'), new('.'), new('.') },
            { new('>'), new('.'), new('.'), new('.') }
        };
        var grid = new Grid(input);
        
        // Act
        var hasMoved = grid.MoveEastFacing();
        
        // Assert
        Assert.IsTrue(hasMoved);
        Assert.That.GridsAreEqual(expectedGrid, grid.Value);
    }

    [TestMethod]
    public void MoveEastFacing_ReturnsFalse_WhenNoEastFacingMoved()
    {
        // Arrange
        var input = new[]
        {
            ".>>v",
            ">v.>",
            ".v.."
        };
        var expectedGrid = new Cell[,]
        {
            { new('.'), new('>'), new('>'), new('v') },
            { new('>'), new('v'), new('.'), new('>') },
            { new('.'), new('v'), new('.'), new('.') }
        };
        var grid = new Grid(input);
        
        // Act
        var hasMoved = grid.MoveEastFacing();
        
        // Assert
        Assert.IsFalse(hasMoved);
        Assert.That.GridsAreEqual(expectedGrid, grid.Value);
    }

    [TestMethod]
    public void MoveSouthFacing_ReturnsTrue_WhenAtLeastOneSouthFacingMoved()
    {
        // Arrange
        var input = new[]
        {
            "...",
            "v..",
            ".v."
        };
        var expectedGrid = new Cell[,]
        {
            { new('.'), new('v'), new('.') },
            { new('.'), new('.'), new('.') },
            { new('v'), new('.'), new('.') }
        };
        
        var grid = new Grid(input);
        
        // Act
        var hasMoved = grid.MoveSouthFacing();
        
        // Assert
        Assert.IsTrue(hasMoved);
        Assert.That.GridsAreEqual(expectedGrid, grid.Value);
    }

    [TestMethod]
    public void MoveSouthFacing_ReturnsFalse_WhenNoSouthFacingMoved()
    {
        // Arrange
        var input = new[]
        {
            ".>>v",
            ">v.>",
            ".v.."
        };
        var expectedGrid = new Cell[,]
        {
            { new('.'), new('>'), new('>'), new('v') },
            { new('>'), new('v'), new('.'), new('>') },
            { new('.'), new('v'), new('.'), new('.') }
        };
        var grid = new Grid(input);
        
        // Act
        var hasMoved = grid.MoveSouthFacing();
        
        // Assert
        Assert.IsFalse(hasMoved);
        Assert.That.GridsAreEqual(expectedGrid, grid.Value);
    }
}