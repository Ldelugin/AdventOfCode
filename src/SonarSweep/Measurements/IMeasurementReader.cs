namespace SonarSweep.Measurements;

/// <summary>
/// An interface for reading measurements from a file.
/// </summary>
public interface IMeasurementReader
{
    /// <summary>
    /// Reads measurements from a file.
    /// </summary>
    /// <param name="filePath">
    /// The path to the file containing the measurements.
    /// </param>
    /// <returns>A list of measurements.</returns>
    List<int> ReadMeasurements(string filePath);
}