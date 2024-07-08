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
}