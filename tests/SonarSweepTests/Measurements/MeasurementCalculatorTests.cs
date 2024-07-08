using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SonarSweep.Measurements;

namespace SonarSweepTests.Measurements;

[TestClass]
public class MeasurementCalculatorTests
{
    private readonly MeasurementCalculator calculator = new();
    
    private static IEnumerable<object[]> CalculateIncreasesData()
    {
        yield return new object[] { new List<int>(), 0 };
        yield return new object[] { new List<int> { 1, 2, 3, 4, 5, 6, 7 }, 6 };
        yield return new object[] { new List<int> { 1, 2, 3, 4, 5, 6, 7, 6, 5, 4, 3, 2, 1 }, 6 };
        yield return new object[] { new List<int> { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 }, 7 };
    }

    [TestMethod]
    [DynamicData(nameof(CalculateIncreasesData), DynamicDataSourceType.Method)]
    public void CalculateIncreases_ShouldReturnCorrectCount(List<int> measurements, int expected)
    {
        // Act
        var result = calculator.CalculateIncreases(measurements);
        
        // Assert
        Assert.AreEqual(expected: expected, result);
    }
    
    [TestMethod]
    public void CalculateIncreases_ShouldThrowArgumentNullException_WhenMeasurementsIsNull()
    {
        // Arrange
        List<int>? measurements = null;
        
        // Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() => calculator.CalculateIncreases(measurements));
    }
}