using SonarSweep;
using SonarSweep.Measurements;

const string reportFileName = "input.txt";
var reportFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reportFileName);

var measurementReader = new MeasurementReader();
var measurementCalculator = new MeasurementCalculator();
var console = new ConsoleWrapper();
var processor = new MeasurementProcessor(measurementReader, measurementCalculator, console);
processor.Process(reportFilePath);

// Keep the original code for comparison
var reportInspector = new ReportInspector(reportFileName);
var totalIncreases = reportInspector.InspectTotalIncreases();

Console.WriteLine($"The total increases of the '{reportFileName}' report = {totalIncreases}");