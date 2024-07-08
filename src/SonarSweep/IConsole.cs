namespace SonarSweep;

/// <summary>
/// An interface for a console.
/// </summary>
public interface IConsole
{
    /// <summary>
    /// Writes a message to the console.
    /// </summary>
    /// <param name="message">The message to write.</param>
    void WriteLine(string message);
}