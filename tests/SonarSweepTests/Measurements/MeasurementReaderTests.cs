using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SonarSweep.Measurements;

namespace SonarSweepTests.Measurements;

[TestClass]
public class MeasurementReaderTests
{
    private readonly MeasurementReader measurementReader = new();
    
    [TestMethod]
    public void ReadMeasurements_ThrowsFileNotFound_WhenFileDoesNotExist()
    {
        // Arrange
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            "non-existent.txt");
        
        // Act & Assert
        Assert.ThrowsException<FileNotFoundException>(() =>
            measurementReader.ReadMeasurements(filePath));
    }
    
    [TestMethod]
    public void ReadMeasurements_ThrowsFormatException_WhenFileContainsNonInteger()
    {
        // Arrange
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            "non-integer.txt");
        
        // Act & Assert
        Assert.ThrowsException<FormatException>(() =>
            measurementReader.ReadMeasurements(filePath));
    }
    
    [TestMethod]
    public void ReadMeasurements_ReturnsMeasurements_WhenFileContainsIntegers()
    {
        // Arrange
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            "input.txt");
        
        // Act
        var measurements = measurementReader.ReadMeasurements(filePath);
        
        // Assert
        var expectedMeasurements = new List<int>
        {
            199, 200, 208, 210, 200, 207, 240, 269, 260, 263
        };
        CollectionAssert.AreEqual(expectedMeasurements, measurements);
    }
}