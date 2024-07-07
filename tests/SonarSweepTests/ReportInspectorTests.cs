using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SonarSweep;

namespace SonarSweepTests;

[TestClass]
public class ReportInspectorTests
{
    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow(null)]
    public void Constructor_ThrowsArgumentNullException_WhenReportFileNameIsNullOrWhiteSpace(string reportFileName)
    {
        // Assert
        Assert.ThrowsException<ArgumentNullException>(() => new ReportInspector(reportFileName));
    }

    [TestMethod]
    public void Constructor_ThrowsInvalidOperationException_WhenReportDoesNotExists()
    {
        // Assert
        Assert.ThrowsException<InvalidOperationException>(() => new ReportInspector("this_does_not_exists.txt"));
    }

    [TestMethod]
    public void InspectTotalIncreases_Returns7_ForInputTextFile()
    {
        // Arrange
        const string reportFileName = "input.txt";
        const int expectedTotalIncreases = 7;
        var reportInspector = new ReportInspector(reportFileName);
        
        // Act
        var totalIncreases = reportInspector.InspectTotalIncreases();
        
        // Assert
        Assert.AreEqual(expectedTotalIncreases, totalIncreases);
    }
}