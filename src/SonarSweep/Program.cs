using SonarSweep;
using SonarSweep.Measurements;

// The file name, this could also be a command line argument
const string reportFileName = "input.txt";

// The full path to the report file
var reportFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reportFileName);

// Set up the processor and run it
var measurementReader = new MeasurementReader();
var measurementCalculator = new MeasurementCalculator();
var console = new ConsoleWrapper();
var processor = new MeasurementProcessor(measurementReader, measurementCalculator, console);
processor.Process(reportFilePath);