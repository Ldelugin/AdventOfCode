using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeaCucumber;

namespace SeaCucumberTests;

[TestClass]
public class SeaCucumberSimulatorTests
{
    [TestMethod]
    public void SimulateUntilNoMovementsDetected_Returns58_WithExampleInput()
    {
        // Arrange
        const string inputFileName = "example-input.txt";
        const int expectedSteps = 58;

        var inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName);
        var input = File.ReadAllLines(inputFilePath);
        var map = new Grid(input);
        var simulator = new SeaCucumberSimulator(map);
        
        // Act
        var steps = simulator.SimulateUntilNoMovementsDetected();
        
        // Assert
        Assert.AreEqual(expectedSteps, steps);
    }
}