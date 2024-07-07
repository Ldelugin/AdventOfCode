namespace SeaCucumber;

public class SeaCucumberSimulator
{
    private readonly Grid map;

    public SeaCucumberSimulator(Grid map)
    {
        this.map = map ?? throw new ArgumentNullException(nameof(map));
    }
    
    public int SimulateUntilNoMovementsDetected()
    {
        var steps = 0;
        return steps;
    }
}