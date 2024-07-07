namespace SonarSweep;

/// <summary>
/// An inspector for files representing a Sonar Sweep report.
/// </summary>
public class ReportInspector
{
    /// <summary>
    /// Const value indicating that there was no previous measurement.
    /// </summary>
    private const int NoPreviousMeasurement = -1;
    private readonly FileInfo report;

    /// <summary>
    /// Creates a new instance of <see cref="ReportInspector"/>.
    /// </summary>
    /// <param name="reportFileName">The file name for the report to inspect.</param>
    /// <exception cref="ArgumentNullException">
    /// Throw when the <paramref name="reportFileName"/> is passed as null, empty or whitespace.
    /// </exception>
    public ReportInspector(string reportFileName)
    {
        // Exit early if the reportFileName is incorrect.
        if (string.IsNullOrWhiteSpace(reportFileName))
        {
            throw new ArgumentNullException(nameof(reportFileName));
        }

        var reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reportFileName);
        this.report = new FileInfo(reportPath);

        if (!this.report.Exists)
        {
            throw new InvalidOperationException($"The report at path {this.report.FullName} does not exists");
        }
    }

    /// <summary>
    /// Inspect the report for total increases.
    /// </summary>
    /// <remarks>
    /// A report contains multiple measurements, which are read line by line.
    /// An increase is when the current measurement (from the current read line) is larger than the previous measurement.
    /// </remarks>
    /// <returns>The total number of increases.</returns>
    public int InspectTotalIncreases()
    {
        var totalIncreases = 0;

        // Create a new stream reader.
        using var streamReader = this.report.OpenText();
        
        // Set the previousNumber to NoPreviousMeasurement to indicate that there where no previous measurements.
        var previousNumber = NoPreviousMeasurement;

        // Read the report line by line.
        while (streamReader.ReadLine() is { } line)
        {
            // Trim the line and parse it to an int.
            var number = int.Parse(line.Trim());
            
            // If the number is larger than the previousNumber and the previousNumber is not equal to NoPreviousMeasurement
            // then increment totalIncreases.
            if (number > previousNumber && previousNumber != NoPreviousMeasurement)
            {
                totalIncreases++;
            }
            
            // Set the previousNumber to number
            previousNumber = number;
        }

        // Return the total increases counted in the report.
        return totalIncreases;
    }
}