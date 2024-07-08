namespace SonarSweep;

/// <summary>
/// An interface for calculating increases in measurements.
/// </summary>
public interface IMeasurementCalculator
{
    /// <summary>
    /// Calculates the number of increases in a list of measurements.
    /// </summary>
    /// <param name="measurements">
    /// The list of measurements to calculate the increases for.
    /// </param>
    /// <returns>
    /// The number of increases in the list of measurements.
    /// </returns>
    int CalculateIncreases(List<int> measurements);
}