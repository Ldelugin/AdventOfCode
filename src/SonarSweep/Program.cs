using SonarSweep;

const string reportFileName = "input.txt";

var reportInspector = new ReportInspector(reportFileName);
var totalIncreases = reportInspector.InspectTotalIncreases();

Console.WriteLine($"The total increases of the '{reportFileName}' report = {totalIncreases}");