namespace SonarSweep.Measurements;

/// <summary>
/// A class that calculates the number of increases in a list of measurements.
/// </summary>
public class MeasurementCalculator : IMeasurementCalculator
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
    /// <exception cref="ArgumentNullException">
    /// Thrown when the <paramref name="measurements"/> parameter is null.
    /// </exception>
    public int CalculateIncreases(List<int>? measurements)
    {
        if (measurements == null)
        {
            throw new ArgumentNullException(nameof(measurements));
        }

        var increases = 0;
        return increases;
    }
}