namespace SonarSweep.Measurements;

/// <summary>
/// A class that reads measurements from a file.
/// </summary>
public class MeasurementReader : IMeasurementReader
{
    /// <summary>
    /// Reads measurements from a file.
    /// </summary>
    /// <param name="filePath">
    /// The path to the file containing the measurements.
    /// </param>
    /// <returns>A list of measurements.</returns>
    public List<int> ReadMeasurements(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File not found.", filePath);
        }
        
        var measurements = new List<int>();
        
        using var reader = new StreamReader(filePath);
        while (reader.ReadLine() is { } line)
        {
            if (!int.TryParse(line, out var measurement))
            {
                throw new FormatException("File contains non-integer.");
            }
            
            measurements.Add(measurement);
        }
        
        return measurements;
    }
}