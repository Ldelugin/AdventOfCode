namespace SonarSweep;

/// <summary>
/// Implementation of <see cref="IConsole"/> that wraps the <see cref="Console"/>.
/// </summary>
public class ConsoleWrapper : IConsole
{
    /// <summary>
    /// Writes a message to the console.
    /// </summary>
    /// <param name="message">The message to write.</param>
    public void WriteLine(string message) => Console.WriteLine(message);
}