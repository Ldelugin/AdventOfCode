using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SonarSweep;
using SonarSweep.Measurements;

namespace SonarSweepTests.Measurements;

[TestClass]
public class MeasurementProcessorTests
{
    private readonly Mock<IMeasurementReader> measurementReaderMock = new();
    private readonly Mock<IMeasurementCalculator> measurementCalculatorMock = new();
    private readonly Mock<IConsole> consoleMock = new();
    private readonly MeasurementProcessor processor;
    
    public MeasurementProcessorTests()
    {
        this.processor = new MeasurementProcessor(this.measurementReaderMock.Object,
            this.measurementCalculatorMock.Object, this.consoleMock.Object);
    }

    [TestMethod]
    public void Constructor_ThrowsArgumentNullException_WhenMeasurementReaderIsNull()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new MeasurementProcessor(measurementReader: null,
            this.measurementCalculatorMock.Object, this.consoleMock.Object));
    }
    
    [TestMethod]
    public void Constructor_ThrowsArgumentNullException_WhenMeasurementCalculatorIsNull()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new MeasurementProcessor(this.measurementReaderMock.Object,
            measurementCalculator: null, this.consoleMock.Object));
    }
    
    [TestMethod]
    public void Constructor_ThrowsArgumentNullException_WhenConsoleIsNull()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new MeasurementProcessor(this.measurementReaderMock.Object,
            this.measurementCalculatorMock.Object, console: null));
    }

    private static IEnumerable<object[]> ProcessData()
    {
        yield return new object[] { new List<int> { 1, 2, 3 }, "input1.txt", 2 };
        yield return new object[] { new List<int> { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 }, "input2.txt", 7 };
    }

    [TestMethod]
    [DynamicData(nameof(ProcessData), DynamicDataSourceType.Method)]
    public void Process_ShouldCalculateIncreasesCorrectly(List<int> measurementsToReturn, string filePath, int expectedIncreases)
    {
        // Arrange
        this.measurementReaderMock.Setup(mock => mock.ReadMeasurements(filePath)).Returns(measurementsToReturn);
        this.measurementCalculatorMock.Setup(mock => mock.CalculateIncreases(measurementsToReturn)).Returns(expectedIncreases);
        
        // Act
        this.processor.Process();

        // Assert
        this.measurementReaderMock.Verify(mock => mock.ReadMeasurements(filePath), Times.Once);
        this.measurementCalculatorMock.Verify(mock => mock.CalculateIncreases(measurementsToReturn), Times.Once);
        this.consoleMock.Verify(mock => mock.WriteLine(It.Is<string>(
            message => message.Contains(expectedIncreases.ToString()))), Times.Once);
    }
}