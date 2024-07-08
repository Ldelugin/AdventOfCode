namespace SonarSweep.Measurements;

/// <summary>
/// A processor for measurements.
/// </summary>
public class MeasurementProcessor
{
    private readonly IMeasurementReader measurementReader;
    private readonly IMeasurementCalculator measurementCalculator;
    private readonly IConsole console;
    
    /// <summary>
    /// Creates a new instance of <see cref="MeasurementProcessor"/>.
    /// </summary>
    /// <param name="measurementReader">The reader to use for reading measurements.</param>
    /// <param name="measurementCalculator">The calculator to use for calculating measurements.</param>
    /// <param name="console">The console to use for writing messages.</param>
    /// <exception cref="ArgumentNullException">
    /// Throw when the <paramref name="measurementReader"/> or
    /// <paramref name="measurementCalculator"/> is passed as null or
    /// <paramref name="console"/> is passed as null.
    /// </exception>
    public MeasurementProcessor(IMeasurementReader measurementReader, IMeasurementCalculator measurementCalculator,
        IConsole console)
    {
        this.measurementReader = measurementReader ?? throw new ArgumentNullException(nameof(measurementReader));
        this.measurementCalculator = measurementCalculator ?? throw new ArgumentNullException(nameof(measurementCalculator));
        this.console = console ?? throw new ArgumentNullException(nameof(console));
    }
}